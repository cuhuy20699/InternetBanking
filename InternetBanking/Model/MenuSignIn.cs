using System;
using System.Collections.Generic;
using System.Text;


namespace InternetBanking.Model
{
    class MenuSignIn
    {
        public void MenuSign()
        {
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("+|            MENU            |+");
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("+          1: Sign In          +");
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("+          2: Sign Up          +");
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("+          3: Exit             +");
            Console.WriteLine("+------------------------------+");
            Console.Write("\nEnter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n+------------------------------+");
                    Console.WriteLine("+          1: SIGN IN          +");
                    Console.WriteLine("+------------------------------+");
                    // Gọi hàm đăng nhập: 

                    break;
                case 2:
                    Console.WriteLine("\n+------------------------------+");
                    Console.WriteLine("+          2: SIGN UP          +");
                    Console.WriteLine("+------------------------------+");
                    // Gọi hàm đăng ký: 

                    break;
                case 3:
                    Console.WriteLine("\n+------------------------------+");
                    Console.WriteLine("+          3: GOOD BYE         +");
                    Console.WriteLine("+------------------------------+");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\n+------------------------------+");
                    Console.WriteLine("+   Please choice from 1 to 3  +");
                    Console.WriteLine("+          THANK YOU!          +");
                    Console.WriteLine("+------------------------------+");
                    break;
            }
        }
    }
}
