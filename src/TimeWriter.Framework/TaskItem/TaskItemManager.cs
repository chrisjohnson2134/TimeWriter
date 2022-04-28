using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeWriter.Framework.TaskItem
{
    public class TaskItemManager : ITaskItemManager
    {
        public List<TaskItemModel> AllTask { get; set; }
        public List<TaskItemModel> TasksInProgress => AllTask.Where(t => !t.IsCompleted).ToList();
        public List<TaskItemModel> TasksCompleted => AllTask.Where(t => t.IsCompleted).ToList();

        public TaskItemManager()
        {
            AllTask = new List<TaskItemModel>();
            AddTaskItem(new TaskItemModel() { Name = "New Task 0",IsCompleted = false});
            AddTaskItem(new TaskItemModel() { Name = "New Task 1",IsCompleted = false});
            AddTaskItem(new TaskItemModel() { Name = "New Task 2",IsCompleted = true});
        }

        public void AddTaskItem(TaskItemModel taskItemModel)
        {
            AllTask.Add(taskItemModel);
        }

        public void RemoveTaskItem(TaskItemModel taskItemModel)
        {
            AllTask.RemoveAll(t => t.Name == taskItemModel.Name);
        }
    }
}
