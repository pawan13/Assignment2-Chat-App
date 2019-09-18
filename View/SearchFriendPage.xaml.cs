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
    public partial class SearchFriendPage : ContentPage
    {
        Model.UserAccount users = new Model.UserAccount();
        public SearchFriendPage(Model.UserAccount user)
        {
            InitializeComponent();
            Showuser(user.Username);
        }

        async void Showuser(String user)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Chattydata.db3");
            SQLiteAsyncConnection _database = new SQLiteAsyncConnection(path);
            Model.UserAccount d1 = await _database.Table<Model.UserAccount>().Where(x => x.Username == user).FirstOrDefaultAsync();
            users = d1;
        }

        async void SearchbuttonClicked(Object sender, EventArgs e)
        {
            if(!String.Equals(searchfriendname.Text,users.Username))
            {
                List<Model.UserAccount> search = await App.MyDatabase.GetFriendInfo(searchfriendname.Text);
                if (search.Count > 0)
                {
                    await Navigation.PushAsync(new ShowSearchResult(users.Username, search));
                }
                else
                {
                    await DisplayAlert("Search Friend", "Friend could not be found", "OK");
                }
            }
            else
            {
                await DisplayAlert("Search Friend", "You cannot search yourself as friend", "OK");
            }
            
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
