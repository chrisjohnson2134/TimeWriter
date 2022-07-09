using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeWriter.Controls.TaskItem;
using TimeWriter.Framework.TaskItem;

namespace TimeWriter.Controls.Time
{
    public class TimeWriterViewModel : BindableBase
    {
        private string _outputTimeTemplate = "Select task to create template...";
        private List<TaskItemModel> _selectedItems;

        public TimeWriterViewModel()
        {
        }

        public string OutputTimeTemplate 
        {
            get => _outputTimeTemplate;
            set => SetProperty(ref _outputTimeTemplate, value);
        }

        public List<TaskItemModel> SelectedItems 
        {
            get => _selectedItems;
            set
            {
                _selectedItems = value;
            }
        }
    }
}
