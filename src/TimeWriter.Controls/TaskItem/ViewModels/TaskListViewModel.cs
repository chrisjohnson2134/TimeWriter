using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeWriter.Framework.TaskItem;

namespace TimeWriter.Controls.TaskItem
{
    public class TaskListViewModel : BindableBase
    {
        private readonly DelegateCommand<List<TaskItemModel>> _taskItemsChanged;

        public TaskListViewModel(ITaskItemManager taskItemManager)
        {
            _taskItemsChanged = new DelegateCommand<List<TaskItemModel>>(s => { });

            TaskItems = new ObservableCollection<TaskItemModel>();
            TaskItems.AddRange(taskItemManager.TasksInProgress);
        }

        public ObservableCollection<TaskItemModel> TaskItems { get; set; }

        //public DelegateCommand TaskItemsChanged
        //{
        //    get { return _taskItemsChanged; }
        //}
    }
}
