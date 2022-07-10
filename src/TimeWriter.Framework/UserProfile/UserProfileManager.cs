using System;
using System.Collections.Generic;
using System.IO;
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
            _userProfileModel = new UserProfileModel();
            _taskItemManager = taskItemManager;
            SaveUserProfile();
            LoadUserProfile();
        }

        public void SaveUserProfile()
        {
            _userProfileModel.TaskItemModels = _taskItemManager.AllTask;
            _userProfileModel.UserName = "cj";

            System.Xml.Serialization.XmlSerializer writer =
            new System.Xml.Serialization.XmlSerializer(typeof(UserProfileModel));

            var path =  "SerializationOverview.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, _userProfileModel);
            file.Close();
        }

        public void LoadUserProfile()
        {
            _taskItemManager.AllTask = _userProfileModel.TaskItemModels;

            // Now we can read the serialized book ...  
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(UserProfileModel));
            System.IO.StreamReader file = new System.IO.StreamReader(
                @"SerializationOverview.xml");
            _userProfileModel = (UserProfileModel)reader.Deserialize(file);
            file.Close();
        }
    }
}
