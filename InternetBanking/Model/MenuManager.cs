using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Model
{
    class MenuManager
    {
        public void MnManager()
        {
            
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("+         MENU MANAGER         +");
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("+      1: Check the amount     +");
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("+      2: Money Withdraw       +");
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("+      3: Money Transfer       +");
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("+      4: Transaction Log      +");
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("+      5: EXIT                 +");
            Console.WriteLine("+------------------------------+");
            Console.Write("\nEnter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n+------------------------------+");
                    Console.WriteLine("+      1: Check the amount     +");
                    Console.WriteLine("+------------------------------+");
                    // Gọi hàm check số dư tài khoản

                    break;
                case 2:
                    Console.WriteLine("\n+------------------------------+");
                    Console.WriteLine("+      2: Money Withdraw       +");
                    Console.WriteLine("+------------------------------+");
                    // Gọi hàm rút tiền

                    break;
                case 3:
                    Console.WriteLine("\n+------------------------------+");
                    Console.WriteLine("+      3: Money Transfer       +");
                    Console.WriteLine("+------------------------------+");
                    // Gọi hàm chuyển tiền

                    break;
                case 4:
                    Console.WriteLine("\n+------------------------------+");
                    Console.WriteLine("+      4: Transaction Log      +");
                    Console.WriteLine("+------------------------------+");
                    // Gọi hàm show lịch sử giao dịch

                    break;
                case 5:
                    Console.WriteLine("\n+------------------------------+");
                    Console.WriteLine("+           GOOD BYE           +");
                    Console.WriteLine("+------------------------------+");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\n+------------------------------+");
                    Console.WriteLine("+   Please choice from 1 to 5  +");
                    Console.WriteLine("+          THANK YOU!          +");
                    Console.WriteLine("+------------------------------+");

                    /*Console.WriteLine("Có mỗi từ 1 tới 5 mà thí chủ chọn " + choice + " ở đâu vậy?");
                    Console.WriteLine("Thí chủ chọn ngu vờ lờ. :D đéo dùng được app đâu nha. Ahihi đồ chó!");
                    Console.WriteLine("Bye Nhé =))");
                    Console.ReadLine();
                    Environment.Exit(0);*/
                    break;
            }
        }
    }
}
