using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Assignment2_ChatApp.Model
{
    public class UserAccount
    {
        [PrimaryKey]
        public string ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public UserAccount()
        {

        }
    }

    public class FriendAccount
    {
        [PrimaryKey]
        public string ID { get; set; }
        public string Username { get; set; }

        public FriendAccount()
        {
          
        }
    }

}
