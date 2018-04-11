using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Controller
{
    class AccountController
    {
        public void Signin()
        {
            string username;
            string password;
            Console.WriteLine("Please Enter your username: ");
            username = Console.ReadLine();
            validate.ValidateUserName(username);
            Console.WriteLine("Please Enter your password: ");
            password = Console.ReadLine();
            validate.ValidatePassword(password);
            AccountModel model = new AccountModel();
            model.SignIn(username, password);
        }
    }
}
