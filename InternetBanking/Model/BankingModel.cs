using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Model
{
    class BankingModel
    {
        private MySqlTransaction transaction;
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public BankingModel()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "MyDatabase";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("error");
                        break;

                    case 1045:
                        Console.WriteLine("error");
                        break;
                }
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("error");
                return false;
            }
        }

        public int CheckMoney(string username)
        {
            string bankNumber;
            string query = "SELECT " + username + ", bankNumber FROM acounts,userinformation WHERE accounts.id = userinformation.accountId ";
            OpenConnection();
            MySqlCommand cmd1 = new MySqlCommand(query, connection);
            MySqlDataReader dataReader1 = cmd1.ExecuteReader();
            bankNumber = dataReader1["bankNumber"] + "";
            dataReader1.Close();
            string query2 = "SELECT " + bankNumber + ", money FROM userinformation,transactionlog WHERE userinformation.bankNumber = transactionlog.bankNumber";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataReader dataReader2 = cmd2.ExecuteReader();
            int money = Convert.ToInt32(dataReader2["money"]);
            Console.WriteLine("Số tiền trong tài khoản quý khách hiện nay là: " + money);
            dataReader2.Close();
            CloseConnection();
            return money;
        }

        public void Withdraw(string username)
        {
            Console.WriteLine("Số tiền khách hàng muốn rút : ");
            DateTime dateTime = DateTime.Today;
            string transactionDate = dateTime.ToString("dd/MM/yyyy");
            int moneyWithdraw = Convert.ToInt32(Console.ReadLine());
            int moneyBase = CheckMoney(username);
            if (moneyBase < moneyWithdraw)
            {
                Console.WriteLine("Số tiền trong tài khoản không đủ để rút");
            }
            if (moneyWithdraw < 0)
            {
                Console.WriteLine("Số tiền muốn rút không hợp lệ");
            }
            int moneyAfter = moneyBase - moneyWithdraw;
            string query = "UPDATE transactionlog SET money = " + moneyAfter + ", transactionDate = '" + transactionDate + "' WHERE money = " + moneyBase;
            MySqlCommand cmd = new MySqlCommand(query, connection, transaction);
            transaction = connection.BeginTransaction();
            try
            {
                cmd.ExecuteNonQuery();
                transaction.Commit();
                Console.WriteLine("Chúc quý khác tiêu tiền hợp lý");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi bất ngờ");
                transaction.Rollback();
            }
        }
    }
}
