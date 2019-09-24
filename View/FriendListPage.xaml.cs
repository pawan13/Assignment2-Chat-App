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
            List <Model.FriendAccount> friendlist = await App.MyDatabase.FriendList(users);
            List<Model.FriendAccount> list = new List<Model.FriendAccount>();
            foreach(Model.FriendAccount testlist in friendlist)
            {
                String name;
                if(String.Equals(users.Username,testlist.FriendUsername))
                {
                    name = testlist.Username;
                    testlist.Username = testlist.FriendUsername;
                    testlist.FriendUsername = name;
                }
                list.Add(testlist);
            }
            listView.ItemsSource = list;
        }

        async void RemoveFriend(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(friendid))
            {
                Console.WriteLine("test 1 " + friendid);
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Chattydata.db3");
                SQLiteAsyncConnection _database = new SQLiteAsyncConnection(path);
                Model.FriendAccount d1 = await _database.Table<Model.FriendAccount>().Where(x => x.ID == friendid).FirstOrDefaultAsync();
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
        }

        //2nd button for searching friend from all user's account database 
        async void Go_SearchFriendPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchFriendPage(users));
        }

        //this page is link to profile page
        async void Go_ProfilePage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage(users));
        }
        
        async void Go_Main_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync();
        }
    }
}
