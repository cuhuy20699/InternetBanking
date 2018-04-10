using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Model
{
    class AccountModel
    {
        MenuManager menu = new MenuManager();
        public void SignIn(string username, string password)
        {
            string query = "SELECT FROM InternetBanking WHERE username = " + username;
            ConnectionHelper.GetDbConnection();
            MySqlCommand cmd = new MySqlCommand(query);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            string username1 = dataReader["username"] + "";
            string password1 = dataReader["password"] + "";
            if (username == username1 && password == password1)
            {
                Console.WriteLine("login sucess");
                menu.MnManager();
            }
            else
            {
                Console.WriteLine("username or password is incorrect, please try again.");
            }
        }
    }
    }
}
