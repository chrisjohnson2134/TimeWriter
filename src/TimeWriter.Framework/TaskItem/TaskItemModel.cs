using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeWriter.Framework.TaskItem
{
    [Serializable]
    public sealed class TaskItemModel
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
