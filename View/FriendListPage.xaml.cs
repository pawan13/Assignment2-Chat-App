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
    public partial class FriendListPage : ContentPage
    {
        Model.UserAccount users = new Model.UserAccount();
        String friendid;
        public FriendListPage(Model.UserAccount username)
        {
            InitializeComponent();
            Showfriend(username.Username);
        }

        async void Showfriend(String user)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Chattydata.db3");
            SQLiteAsyncConnection _database = new SQLiteAsyncConnection(path);
            Model.UserAccount d1 = await _database.Table<Model.UserAccount>().Where(x => x.Username == user).FirstOrDefaultAsync();
            users = d1;
        }

        private void selectfriend(object s, SelectedItemChangedEventArgs e)
        {
            var obj = (Model.FriendAccount)e.SelectedItem;
            var ide = Convert.ToInt32(obj.ID);
            String IdInt = ide.ToString();
            friendid = IdInt;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //listView.iText = "{Binding FriendUsername}";
            listView.ItemsSource = await App.MyDatabase.FriendList(users);
        }

        async void RemoveFriend(object sender, System.EventArgs e)
        {
            // if(!string.IsNullOrEmpty(FriendID) && friend.Username == FriendID)
            if (!string.IsNullOrEmpty(friendid))
            {
                Console.WriteLine("test 1 " + friendid);
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Chattydata.db3");
                SQLiteAsyncConnection _database = new SQLiteAsyncConnection(path);
                Model.FriendAccount d1 = await _database.Table<Model.FriendAccount>().Where(x => x.ID == friendid).FirstOrDefaultAsync();
                /*List<Model.FriendAccount> usercnt = await _database.Table<Model.FriendAccount>().ToListAsync();
                int id = usercnt.Count - 1;
                friend.ID = id.ToString();
                friend.Username = users.Username;
                friend.FriendUsername = d1.Username;*/
                await App.MyDatabase.RemoveFriendInfo(d1);
                await DisplayAlert("Successful", "Remove friend successfully", "OK");
                await Navigation.PushAsync(new FriendListPage(users));
            }
            else
            {
                Console.WriteLine("testing" + friendid);
                await DisplayAlert("Friend list", "No specific friend is found", "OK");
            }
        }

        //Methods below are the navigation button to link to each page
        //1st button for this page(list the friend list for the current user)
        async void Go_FriendListPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FriendListPage(users));
            //throw new NotImplementedException();
        }

        //2nd button for searching friend from all user's account database 
        async void Go_SearchFriendPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchFriendPage(users));
            //throw new NotImplementedException();
        }

        //this page is link to profile page
        async void Go_ProfilePage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage(users));
            //throw new NotImplementedException();
        }
    }
    // everytime people login, ID will set to the Friendlist class (database), so when add user, it add into the table
    //a search bar to search people in it and find it through database(Useraccount class)
    //then, add user into the database(Friendlist class) binding with ID/username.
    // 
}
