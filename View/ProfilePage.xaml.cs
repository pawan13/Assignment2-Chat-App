using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment2_ChatApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private async void LogOut_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Quit", "You wish to LogOut?", "Confirm");
            await Navigation.PushAsync(new MainPage());
            //Application.Current.Quit();
            //throw new NotImplementedException();
        }

        async void Go_FriendListPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FriendListPage());
            //throw new NotImplementedException();
        }

        async void Go_SearchFriendPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchFriendPage());
            //throw new NotImplementedException();
        }

        async void Go_ProfilePage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
            //throw new NotImplementedException();
        }
    }
}