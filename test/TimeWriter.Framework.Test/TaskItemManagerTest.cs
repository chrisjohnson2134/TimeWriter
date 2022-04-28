using AutoFixture;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TimeWriter.Framework.TaskItem;

namespace TimeWriter.Framework.Test
{
    public class TaskItemManagerTest
    {
        ITaskItemManager _taskItemManager;
        List<TaskItemModel> _completeTaskItemModel;
        List<TaskItemModel> _inProgressTask;

        Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();

            _taskItemManager = new TaskItemManager();

            _completeTaskItemModel = _fixture.Create<List<TaskItemModel>>();
            _completeTaskItemModel.ForEach(t => { t.IsCompleted = true; _taskItemManager.AddTaskItem(t); });

            _inProgressTask = _fixture.Create<List<TaskItemModel>>();
            _inProgressTask.RemoveAt(0);
            _inProgressTask.ForEach(t => { t.IsCompleted = false; _taskItemManager.AddTaskItem(t); });

        }

        [Test]
        public void GetTheListOfCompleteAndUncompleteItems()
        {
            Assert.AreEqual(_completeTaskItemModel.Count, _taskItemManager.TasksCompleted.Count);

            Assert.AreEqual(_inProgressTask.Count, _taskItemManager.TasksInProgress.Count);

            Assert.AreEqual(_completeTaskItemModel.Count + _inProgressTask.Count,
                _taskItemManager.AllTask.Count);
        }

        [Test]
        public void RemoveTaskByName()
        {
            _taskItemManager.RemoveTaskItem(_completeTaskItemModel[0]);
            Assert.IsFalse(_taskItemManager.AllTask.Any(t => t.Name == _completeTaskItemModel[0].Name));
        }
    }
}