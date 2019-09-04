using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;


namespace Assignment2_ChatApp
{
    public partial class App : Application
    {
        public static View.Database myDatabase;
        public static View.Database MyDatabase
        {
            get
            {
                if(myDatabase == null)
                {
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Chattydata.db3");
                    myDatabase = new View.Database(path);
                }
                return myDatabase;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
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
