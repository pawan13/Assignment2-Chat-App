using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using System.IO;

namespace Assignment2_ChatApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private SQLiteAsyncConnection _database;
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }

        async void Login_Clicked(object sender, EventArgs e)
        {
            //this will run validation with database to ensure the account is there then login, or else it wont login
            bool login = await LoginValidate(loginname.Text, loginpassword.Text);
            if(login == true)
            {
                await Navigation.PushAsync(new View.HomePage(loginname.Text));
            }
           // throw new NotImplementedException();
        }

        async void Register_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.Register());
            //throw new NotImplementedException();
        }

        async void All_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Model.UserList());
            //throw new NotImplementedException();
        }
        
        async public Task<bool> LoginValidate(string userName1, string pwd1)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Chattydata.db3");
            _database = new SQLiteAsyncConnection(path);
            Model.UserAccount d1 = await _database.Table<Model.UserAccount>().Where(x => x.Username == userName1 && x.Password == pwd1).FirstOrDefaultAsync();

            if (d1 == null)
            {
                await DisplayAlert("Login..", "Login Fail", "OK");
                return false;
            }
            else
            {
                await DisplayAlert("Login..", "Welcome", "OK");
                return true;
            }
        }

    }
}
