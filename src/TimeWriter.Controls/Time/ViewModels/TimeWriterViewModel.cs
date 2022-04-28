using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeWriter.Controls.Time
{
    public class TimeWriterViewModel : BindableBase
    {
        private string _outputTimeTemplate = "Select task to create template...";

        public TimeWriterViewModel()
        {
        }

        public string OutputTimeTemplate 
        {
            get => _outputTimeTemplate;
            set => SetProperty(ref _outputTimeTemplate, value);
        }
    }
}
