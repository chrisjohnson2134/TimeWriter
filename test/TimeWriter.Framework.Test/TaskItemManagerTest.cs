using AutoFixture;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TimeWriter.Framework.TaskItem;

namespace TimeWriter.Framework.Test
{
    public class TaskItemManagerTest : TaskItemManagerTestContext
    {
        [Test]
        public void ItemsAreLoadedFromDatabaseOnClassInitialization()
        {
            var testObject = CreateTaskItemManagaer();
            Assert.IsTrue(_completeTask.All(t => testObject.AllTask.Contains(t)));
            Assert.IsTrue(_inProgressTask.All(t => testObject.AllTask.Contains(t)));
        }

        [Test]
        public void TaskCanBeRemovedGivenATaskItemModel()
        {
            var testObject = CreateTaskItemManagaer();
            bool eventCorrect = false;
            var removeTaskItem = _completeTask[0];

            testObject.TaskItemDeleted += (object? sender, TaskItemModel e) =>
            {
                if (e == removeTaskItem)
                    eventCorrect = true;
            };

            testObject.RemoveTaskItem(removeTaskItem);

            Assert.IsTrue(eventCorrect);
            Assert.IsFalse(testObject.AllTask.Any(t => t.Name == _completeTask[0].Name));
        }

        [Test]
        public void TaskCanBeAdded()
        {
            var testObject = CreateTaskItemManagaer();
            bool eventCorrect = false;

            var addTaskItem = _fixture.Create<TaskItemModel>();

            testObject.TaskItemAdded += (object? sender, TaskItemModel e) =>
            {
                if (e == addTaskItem)
                    eventCorrect = true;
            };

            testObject.AddTaskItem(addTaskItem);

            Assert.IsTrue(eventCorrect);
            Assert.IsTrue(testObject.AllTask.Contains(addTaskItem));

        }

        [Test]
        public void SaveAllMethodCallsTheRepoSaveAll()
        {
            var testObject = CreateTaskItemManagaer();
            testObject.SaveAll();

            _taskItemRepoMock.Verify(t => t.SaveTaskItems(testObject.AllTask));
        }

        [Test]
        public void LoadAllMethodLoadsTheCurrentFile()
        {
            var testObject = CreateTaskItemManagaer();
            testObject.AllTask = new List<TaskItemModel>();

            Assert.AreEqual(0, testObject.AllTask.Count);

            testObject.LoadAll();
            Assert.AreEqual(5, testObject.AllTask.Count);

        }
    }
}