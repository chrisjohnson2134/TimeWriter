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
        public EventHandler<List<TaskItemModel>> taskListSelectionChanged;

        public TaskListViewModel(ITaskItemManager taskItemManager)
        {
            TaskItems = new ObservableCollection<TaskItemModel>();
            TaskItems.AddRange(taskItemManager.TasksInProgress);
        }

        public ObservableCollection<TaskItemModel> TaskItems { get; set; }


    }
}
