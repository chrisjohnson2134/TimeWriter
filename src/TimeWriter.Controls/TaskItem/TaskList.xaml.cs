using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeWriter.Framework.TaskItem;

namespace TimeWriter.Controls.TaskItem
{
    /// <summary>
    /// Interaction logic for TaskList.xaml
    /// </summary>
    public partial class TaskList : UserControl
    {

        //public ICommand SelectedItemsChangedCommand
        //{
        //    get { return (ICommand)GetValue(SelectedItemsChangedCommandProperty); }
        //    set { SetValue(SelectedItemsChangedCommandProperty, value); }
        //}

        // Using a DependencyProperty as the backing store for SelectedItemsChangedCommand.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SelectedItemsChangedCommandProperty =
        //    DependencyProperty.Register("SelectedItemsChangedCommand", typeof(ICommand), typeof(ownerclass), new PropertyMetadata(0));



        public TaskList()
        {
            InitializeComponent();
        }

        private void TaskListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
