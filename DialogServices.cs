﻿using System;
using System.Collections.Generic;
using System.Text;
using ChatApp.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChatApp.Services
{
    public class DialogServices : IDialogService
    {
        public Task DisplayAlert(string title, string message, string cancel)
        {
            var page = Application.Current.MainPage;
            if (page == null)
                return Task.CompletedTask;

            return page.DisplayAlert(title, message, cancel);
        }

        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            var page = Application.Current.MainPage;
            if (page == null)
                return Task.FromResult(false);

            return page.DisplayAlert(title, message, accept, cancel);
        }
    }
}
