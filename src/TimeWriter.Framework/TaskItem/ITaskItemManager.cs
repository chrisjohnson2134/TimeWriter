using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeWriter.Framework.TaskItem
{
    public interface ITaskItemManager
    {
        public List<TaskItemModel> AllTask { get; set; }
        public List<TaskItemModel> TasksInProgress { get; }
        public List<TaskItemModel> TasksCompleted { get; }

        void AddTaskItem(TaskItemModel taskItemModel);
        void RemoveTaskItem(TaskItemModel taskItemModel);
    }
}
