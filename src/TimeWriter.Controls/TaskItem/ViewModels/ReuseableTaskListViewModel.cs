using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TimeWriter.Framework.TaskItem;

namespace TimeWriter.Controls.TaskItem
{
    public class ReuseableTaskListViewModel : BindableBase
    {
        public EventHandler<List<TaskItemModel>> taskListSelectionChanged;
        private string _searchField;
        private bool _showCompleted;
        private ITaskItemManager _taskItemManager;

        public ReuseableTaskListViewModel(ITaskItemManager taskItemManager)
        {
            _taskItemManager = taskItemManager;
            _taskItemManager.TaskItemAdded += taskItemManager_TaskItemAdded; 
            _taskItemManager.TaskItemDeleted += taskItemManager_TaskItemDeleted;

            _searchField = String.Empty;
            TaskItems = new ObservableCollection<TaskItemModel>(_taskItemManager.AllTask);
            TaskItemsCollectionView = CollectionViewSource.GetDefaultView(TaskItems);

            TaskItemsCollectionView.Filter = FilterTaskList;

            UpdateSearchResults();
        }

        public ObservableCollection<TaskItemModel> TaskItems { get; set; }
        public ICollectionView TaskItemsCollectionView { get; }

        public bool ShowCompleted
        {
            get => _showCompleted;
            set
            {
                SetProperty(ref _showCompleted, value);
                UpdateSearchResults();
            }
        }

        public string SearchField
        {
            get => _searchField;
            set
            {
                SetProperty(ref _searchField, value);
                UpdateSearchResults();
            }
        }

        private void UpdateSearchResults()
        {
            TaskItemsCollectionView.Refresh();
        }

        private bool FilterTaskList(object obj)
        {
            if(obj is TaskItemModel taskItem)
            {
                return (taskItem.IsCompleted == ShowCompleted || !taskItem.IsCompleted) && 
                    taskItem.Name.ToLower().Contains(SearchField);
            }
            return false;
        }

        private void taskItemManager_TaskItemAdded(object? sender, TaskItemModel e)
        {
            TaskItems.Add(e);
        }

        private void taskItemManager_TaskItemDeleted(object? sender, TaskItemModel e)
        {
            TaskItems.Remove(e);
        }

    }
}
