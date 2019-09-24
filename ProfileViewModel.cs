using ChatApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.ViewModel
{
    public class ProfileViewModel : ViewModelBase
    {
        public string UserName
        {
            get => Settings.UserName;
            set
            {
                if (value == UserName)
                    return;
                Settings.UserName = value;
                OnPropertyChanged();
            }
        }

        public string ServerIP
        {
            get => Settings.ServerIP;
            set
            {
                if (value == ServerIP)
                    return;
                Settings.ServerIP = value;
                OnPropertyChanged();
            }
        }

    }
}
