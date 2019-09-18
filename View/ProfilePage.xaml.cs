using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment2_ChatApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        Model.UserAccount users = new Model.UserAccount();
        public ProfilePage(Model.UserAccount user)
        {
            InitializeComponent();
            Showuser(user.Username);
        }

        async void Showuser(String username)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Chattydata.db3");
            SQLiteAsyncConnection _database = new SQLiteAsyncConnection(path);
            Model.UserAccount d1 = await _database.Table<Model.UserAccount>().Where(x => x.Username == username).FirstOrDefaultAsync();
            users = d1;
            user.Text = "Your username is " + users.Username;
        }

        private async void LogOut_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Quit", "You wish to LogOut?", "Confirm");
            await Navigation.PushAsync(new MainPage());
        }

        async void Go_FriendListPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FriendListPage(users));
        }

        async void Go_SearchFriendPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchFriendPage(users));
        }

        async void Go_ProfilePage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage(users));
        }
    }
}
