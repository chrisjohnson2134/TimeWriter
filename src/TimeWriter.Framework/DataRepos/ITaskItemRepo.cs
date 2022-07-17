using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeWriter.Framework.TaskItem;

namespace TimeWriter.Framework.DataRepos
{
    public interface ITaskItemRepo
    {
        void SaveTaskItems(List<TaskItemModel> task);

        List<TaskItemModel> LoadTask();
    }
}
