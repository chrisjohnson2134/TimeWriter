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
    public partial class ReuseableTaskList : UserControl
    {


        public List<TaskItemModel> SelectedItems
        {
            get { return (List<TaskItemModel>)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(List<TaskItemModel>), typeof(ReuseableTaskList),
                new FrameworkPropertyMetadata(null,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public ReuseableTaskList()
        {
            InitializeComponent();
        }

        private void TaskListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedItems = TaskListView.SelectedItems.Cast<TaskItemModel>().ToList();

        }

    }
}
