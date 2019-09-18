using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment2_ChatApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowSearchResult : ContentPage
    {
        Model.UserAccount users = new Model.UserAccount();
        Model.FriendAccount friend = new Model.FriendAccount();
        String friendid;
        public ShowSearchResult(String username, List<Model.UserAccount> search)
        {
            InitializeComponent();
            Showuser(username);
            listView.ItemsSource = search;
        }

        private void selectfriend(object s, SelectedItemChangedEventArgs e)
        {
            var obj = (Model.UserAccount)e.SelectedItem;
            var ide = Convert.ToInt32(obj.ID);
            String IdInt = ide.ToString();
            friendid = IdInt;
        }

        async void Showuser(String user)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Chattydata.db3");
            SQLiteAsyncConnection _database = new SQLiteAsyncConnection(path);
            Model.UserAccount d1 = await _database.Table<Model.UserAccount>().Where(x => x.Username == user).FirstOrDefaultAsync();
            users = d1;
        }

        
        async void AddFriend(object sender, System.EventArgs e)
        {
            if(!string.IsNullOrEmpty(friendid))
            {
                Console.WriteLine("testing 0 " + friendid);
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Chattydata.db3");
                SQLiteAsyncConnection _database = new SQLiteAsyncConnection(path);
                Model.UserAccount d1 = await _database.Table<Model.UserAccount>().Where(x => x.ID == friendid).FirstOrDefaultAsync();
                Model.FriendAccount d2 = await _database.Table<Model.FriendAccount>().Where(x => (x.Username == users.Username && x.FriendUsername == d1.Username) || (x.Username == d1.Username && x.FriendUsername == users.Username)).FirstOrDefaultAsync();
                Model.FriendID d3 = await _database.Table<Model.FriendID>().Where(x => x.ID == "1").FirstOrDefaultAsync();
                if (d2 == null)
                {
                    List<Model.FriendAccount> usercnt = await _database.Table<Model.FriendAccount>().ToListAsync();
                    int id = Convert.ToInt32(d3.FriendlistID);
                    id = id + 1;
                    friend.ID = id.ToString();
                    friend.Username = users.Username;
                    friend.FriendUsername = d1.Username;
                    d3.FriendlistID = id.ToString();
                    await App.MyDatabase.SaveFriendIDInfo(d3);
                    await App.MyDatabase.SaveFriendInfo(friend);
                    await DisplayAlert("Successful", "Add friend successfully", "OK");
                }
                else
                {
                    await DisplayAlert("Fail", "he/she is your friend", "OK");
                }
                
            }
            else
            {
                await DisplayAlert("Add Friend", "Please select a friend", "OK");
            }     
        }
    }
}
