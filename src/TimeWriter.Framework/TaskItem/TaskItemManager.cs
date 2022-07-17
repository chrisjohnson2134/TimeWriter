using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeWriter.Framework.DataRepos;

namespace TimeWriter.Framework.TaskItem
{
    public class TaskItemManager : ITaskItemManager
    {
        private ITaskItemRepo _taskItemRepo;

        public TaskItemManager(ITaskItemRepo taskItemRepo)
        {
            _taskItemRepo = taskItemRepo;
            AllTask = new List<TaskItemModel>();
            LoadAll();
        }

        public List<TaskItemModel> AllTask { get; set; }

        public EventHandler<TaskItemModel> TaskItemAdded { get; set; }
        public EventHandler<TaskItemModel> TaskItemDeleted { get; set; }

        public void AddTaskItem(TaskItemModel taskItemModel)
        {
            AllTask.Add(taskItemModel);
            TaskItemAdded?.Invoke(this,taskItemModel);
        }

        public void RemoveTaskItem(TaskItemModel taskItemModel)
        {
            AllTask.Remove(taskItemModel);
            TaskItemDeleted?.Invoke(this,taskItemModel);

        }

        public void SaveAll()
        {
            _taskItemRepo.SaveTaskItems(AllTask);
        }

        public void LoadAll()
        {
            var items = _taskItemRepo.LoadTask();
            if (items == null)
                return;

            AllTask = items;
        }
    }
}
