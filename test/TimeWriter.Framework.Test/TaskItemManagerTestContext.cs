using AutoFixture;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TimeWriter.Framework.DataRepos;
using TimeWriter.Framework.TaskItem;

namespace TimeWriter.Framework.Test
{
    public class TaskItemManagerTestContext
    {
        protected Mock<ITaskItemRepo> _taskItemRepoMock;

        protected List<TaskItemModel> _completeTask;
        protected List<TaskItemModel> _inProgressTask;
        protected List<TaskItemModel> _allTask;

        protected Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();

            _taskItemRepoMock = new Mock<ITaskItemRepo>();

            _completeTask = _fixture.Create<List<TaskItemModel>>();
            _completeTask.ForEach(t => { t.IsCompleted = true; });

            _inProgressTask = _fixture.Create<List<TaskItemModel>>();
            _inProgressTask.RemoveAt(0);
            _inProgressTask.ForEach(t => { t.IsCompleted = false; });

            _allTask = new List<TaskItemModel>(_completeTask.Union(_inProgressTask));

            _taskItemRepoMock.Setup(t => t.LoadTask()).Returns(_allTask);
        }

        protected ITaskItemManager CreateTaskItemManagaer()
        {
            return new TaskItemManager(_taskItemRepoMock.Object);
        }
    }
}
