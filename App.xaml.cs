using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Application = Microsoft.Maui.Controls.Application;

namespace TagSort
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			Code.UserSettings.changeTheme();
            Code.database.initTags();

			MainPage = new Pages.Tabs();
		}

        protected override void OnStart()
        {
            OnResume();
        }

        protected override void OnSleep()
        {
            Code.UserSettings.changeTheme();
            Code.database.initTags();
        }

        protected override void OnResume()
        {
            Code.UserSettings.changeTheme();
            Code.database.initTags();
        }
    }
}
