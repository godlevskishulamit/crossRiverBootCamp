﻿using System;
namespace CoronaApp.Dal.Models
{
    public class User
    {
        public int  UserId { get; set; }
        public string  Password { get; set; }
        public string UserName { get; set; }

        public User()
        {
        }
    }
}

