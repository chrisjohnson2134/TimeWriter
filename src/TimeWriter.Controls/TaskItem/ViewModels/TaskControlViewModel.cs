using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeWriter.Framework.ViewModelHelper;
using TimeWriter.Framework.TaskItem;

namespace TimeWriter.Controls.TaskItem
{
    public class TaskControlViewModel : SimplisticBase
    {
        private List<TaskItemModel> _userSelectedItems;
        private TaskItemModel _defaultTaskItemModel = new TaskItemModel { Name = "Create or Select" };
        private ITaskItemManager _taskItemManager;
        public TaskControlViewModel(ITaskItemManager taskItemManager)
        {
            _taskItemManager = taskItemManager;
            _userSelectedItems = new List<TaskItemModel>();

            SelectedItem = _defaultTaskItemModel;

            CreateNewTaskCommand = new DelegateCommand(createNewTaskCommandHandler);
            AddNewTaskCommand = new DelegateCommand(addNewTaskCommandHandler,addNewTaskCommandCanExecute);
            DeleteTaskCommand = new DelegateCommand(deleteTaskCommand);

        }

        public DelegateCommand CreateNewTaskCommand { get; set; }
        public DelegateCommand AddNewTaskCommand { get; set; }
        public DelegateCommand DeleteTaskCommand { get; set; }

        public TaskItemModel SelectedItem
        {
            get => GetPropertyValue<TaskItemModel>();
            set => SetPropertyValue(value);
        }

        public List<TaskItemModel> UserSelectedItems
        {
            get => _userSelectedItems;
            set
            {
                _userSelectedItems = value;
                CanAddTask = false;
                SelectedItem = value.FirstOrDefault() ?? _defaultTaskItemModel;
            }
        }

        public bool CanAddTask
        {
            get => GetPropertyValue<bool>();
            set => SetPropertyValue(value);
        }

        private void createNewTaskCommandHandler()
        {

            CanAddTask = true;
            SelectedItem = new TaskItemModel();
        }

        private void deleteTaskCommand()
        {
            _taskItemManager.RemoveTaskItem(SelectedItem);
        }

        private void addNewTaskCommandHandler()
        {
            _taskItemManager.AddTaskItem(SelectedItem);
        }

        private bool addNewTaskCommandCanExecute()
        {
            return CanAddTask;
        }
    }
}
