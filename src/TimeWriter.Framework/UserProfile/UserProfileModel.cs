using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeWriter.Framework.TaskItem;

namespace TimeWriter.Framework.UserProfile
{
    public class UserProfileModel
    {
        public string UserName { get; set; }
        public List<TaskItemModel> TaskItemModels { get; set; }
    }
}
