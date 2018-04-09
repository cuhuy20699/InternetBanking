using System;
using System.Text;

namespace InternetBanking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Model.MenuManager menu = new Model.MenuManager();
            menu.MnManager();
            Console.Read();
        }
    }
}
