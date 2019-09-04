using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment2_ChatApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FriendListPage : ContentPage
    {
        public FriendListPage()
        {
            InitializeComponent();
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
    // everytime people login, ID will set to the Friendlist class (database), so when add user, it add into the table
    //a search bar to search people in it and find it through database(Useraccount class)
    //then, add user into the database(Friendlist class) binding with ID/username.
    // 
}