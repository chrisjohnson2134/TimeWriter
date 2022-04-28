using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeWriter.Framework.TaskItem;

namespace TimeWriter.Framework.UserProfile
{
    public class UserProfileManager : IUserProfileManager
    {
        private ITaskItemManager _taskItemManager;
        private UserProfileModel _userProfileModel;

        public UserProfileManager(ITaskItemManager taskItemManager)
        {
            _taskItemManager = taskItemManager;
        }

        public void SaveUserProfile()
        {
            _userProfileModel.TaskItemModels = _taskItemManager.AllTask;
        }
    }
}
