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

        void AddTaskItem(TaskItemModel taskItemModel);
        void RemoveTaskItem(TaskItemModel taskItemModel);
    }
}
