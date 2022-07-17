using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeWriter.Framework.TaskItem
{
    public interface ITaskItemManager
    {
        EventHandler<TaskItemModel> TaskItemAdded { get; set; }
        EventHandler<TaskItemModel> TaskItemDeleted { get; set; }

        public List<TaskItemModel> AllTask { get; set; }

        void AddTaskItem(TaskItemModel taskItemModel);
        void RemoveTaskItem(TaskItemModel taskItemModel);

        /// <summary>
        /// This will Overwrite the entire save file.
        /// </summary>
        void SaveAll();

        /// <summary>
        /// This will Overwrite all the models in the program.
        /// </summary>
        void LoadAll();
    }
}
