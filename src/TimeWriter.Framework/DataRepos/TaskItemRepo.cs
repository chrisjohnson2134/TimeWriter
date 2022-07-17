using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeWriter.Framework.DataRepos.Helpers;
using TimeWriter.Framework.TaskItem;

namespace TimeWriter.Framework.DataRepos
{
    public class TaskItemRepo : ITaskItemRepo
    {
        private string _localPath = Directory.GetCurrentDirectory() + "\\taskList.xml";

        public List<TaskItemModel> LoadTask()
        {
            try
            {
                return File.ReadAllText(_localPath).XmlDeserialize<List<TaskItemModel>>();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Failed to Load Task Items : {e}");
            }

            return null;
        }

        public void SaveTaskItems(List<TaskItemModel> task)
        {
            try
            {
                File.WriteAllText(_localPath, task.XmlSerialize());
            }catch(Exception e)
            {
                Console.WriteLine($"Failed To Save Task Items : {e}");
            }
        }
    }
}
