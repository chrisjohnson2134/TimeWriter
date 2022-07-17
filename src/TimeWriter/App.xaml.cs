using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using TimeWriter.Framework.DataRepos;
using TimeWriter.Framework.TaskItem;
using TimeWriter.Framework.UserProfile;

namespace TimeWriter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {

        protected override Window CreateShell()
        {
            var w = Container.Resolve<MainWindow>();
            return w;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IUserProfileManager, UserProfileManager>();
            containerRegistry.RegisterSingleton<ITaskItemManager, TaskItemManager>();
            containerRegistry.RegisterSingleton<ITaskItemRepo, TaskItemRepo>();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            (Container.Resolve<ITaskItemManager>() as ITaskItemManager).SaveAll();

            base.OnExit(e);
        }

    }
}
