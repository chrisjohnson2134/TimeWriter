using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeWriter.Framework.TaskItem;

namespace TimeWriter.Controls.TaskItem
{
    public class TaskAdderViewModel : BindableBase
    {
        private List<TaskItemModel> _userSelectedItems;
        private TaskItemModel _defaultTaskItemModel = new TaskItemModel { Name = "Not Found" };

        public TaskAdderViewModel()
        {
            _userSelectedItems = new List<TaskItemModel>();
        }

        public TaskItemModel SelectedItem => UserSelectedItems.FirstOrDefault() 
            ?? _defaultTaskItemModel;

        public List<TaskItemModel> UserSelectedItems
        {
            get => _userSelectedItems;
            set
            {
                _userSelectedItems = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

    }
}
