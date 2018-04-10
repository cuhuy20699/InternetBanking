using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Entity
{
    class Account
    {
        private int id;
        private string username;
        private string password;

        public Account(int id, string username, string password)
        {
            this.id = id;
            this.username = username;
            this.password = password;
        }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}
