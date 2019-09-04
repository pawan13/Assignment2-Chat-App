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
    public partial class Register : ContentPage
    {
        Model.UserAccount users = new Model.UserAccount();
        public Register()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }

        async void Register_Clicked(object sender, EventArgs e)
        {
     
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Chattydata.db3");
            Database db = new Database(path);

            SQLiteAsyncConnection _database;
            _database = new SQLiteAsyncConnection(path);
            List<Model.UserAccount> usercnt = await _database.Table<Model.UserAccount>().ToListAsync();

            int id = usercnt.Count + 1;

            users.ID = id.ToString();
            users.Username = UserName.Text;
            users.Password = password.Text;

            string returnvalue = await db.AddUser(users);
            if (returnvalue == "Successfully Added")
            {
                await DisplayAlert("User Add", returnvalue, "OK");

                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("User Add", returnvalue, "OK");
                UserName.Text = string.Empty;
            }
        }

        async void Back_Login_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
            //throw new NotImplementedException();
        }
    }
}