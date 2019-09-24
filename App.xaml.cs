using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using ChatApp.View;
using Xamarin.Essentials;
using ChatApp.Helpers;
using Microsoft.AppCenter.Distribute;
using Microsoft.AppCenter.Analytics;
using ChatApp.Cores;

namespace ChatApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<ChatService>();

            MainPage = new HomePage();
        }

        protected override void OnStart()
        {
            if (DeviceInfo.Platform == DevicePlatform.Android && Settings.AppCenterAndroid != "AC_ANDROID")
            {
                AppCenter.Start($"android={Settings.AppCenterAndroid};" +
                    "uwp={Your UWP App secret here};" +
                    "ios={Your iOS App secret here}",
                    typeof(Analytics), typeof(Crashes), typeof(Distribute));
            }
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
