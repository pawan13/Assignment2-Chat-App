﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace assignment2.Database
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string userName { get; set; }
        public string name { get; set; }
        [MaxLength(12)]
        public string password { get; set; }
        [MaxLength(10)]
        public string phone { get; set; }
        public User()
        {
        }
    }
}
