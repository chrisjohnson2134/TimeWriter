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

        public TaskItemManager()
        {
            AllTask = new List<TaskItemModel>();
            AddTaskItem(new TaskItemModel() { Name = "T - 123 Find all things",IsCompleted = false});
            AddTaskItem(new TaskItemModel() { Name = "T - 321 Find new things", IsCompleted = false});
            AddTaskItem(new TaskItemModel() { Name = "D - Small Name Change", IsCompleted = false});
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
