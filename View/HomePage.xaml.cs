using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using System.IO;
using Xamarin.Forms.Xaml;

namespace Assignment2_ChatApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        Model.UserAccount users = new Model.UserAccount();
        public HomePage(String name)
        {
            InitializeComponent();
            profile(name);
            NavigationPage.SetHasBackButton(this, false);
        }

        async void profile(String name)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Chattydata.db3");
            SQLiteAsyncConnection _database = new SQLiteAsyncConnection(path);

            Model.UserAccount d1 = await _database.Table<Model.UserAccount>().Where(x => x.Username == name).FirstOrDefaultAsync();
            users = d1;
        }

        async void Go_FriendListPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FriendListPage(users));
            //throw new NotImplementedException();
        }

        async void Go_SearchFriendPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchFriendPage(users));
            //throw new NotImplementedException();
        }

        async void Go_ProfilePage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage(users));
            //throw new NotImplementedException();
        }
    }
}
