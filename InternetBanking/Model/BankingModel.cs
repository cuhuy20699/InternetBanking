using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Model
{
    class BankingModel
    {
        private MySqlTransaction transaction;
        private MySqlConnection connection;
        private Security security = new Security();

        public int CheckMoney(string username)
        {
            connection = ConnectionHelper.GetDbConnection();
            int bankNumber = GetBankNumber(username);
            string query2 = "SELECT FROM userinformation WHERE bankNumber = " + bankNumber;
            MySqlCommand cmd2 = new MySqlCommand(query2, connection);
            MySqlDataReader dataReader2 = cmd2.ExecuteReader();
            int bankBalance = Convert.ToInt32(dataReader2["bankBalance"]);
            Console.WriteLine("Số tiền trong tài khoản quý khách hiện nay là: " + bankBalance);
            dataReader2.Close();
            connection.Close();
            return bankBalance;
        }

        public void Withdraw(string username)
        {
            Console.WriteLine("Số tiền khách hàng muốn rút : ");
            long transactionDate = DateTime.Now.Ticks;
            int moneyWithdraw = Convert.ToInt32(Console.ReadLine());
            int bankBalance = CheckMoney(username);
            string query3 = "SELECT FROM userinformation WHERE bankBalance = " + bankBalance;
            connection = ConnectionHelper.GetDbConnection();
            MySqlCommand cmd3 = new MySqlCommand(query3, connection);
            MySqlDataReader dataReader = cmd3.ExecuteReader();
            int bankNumber = Convert.ToInt32(dataReader["bankBalance"]);
            dataReader.Close();
            if (bankBalance < moneyWithdraw)
            {
                Console.WriteLine("Số tiền trong tài khoản không đủ để rút");
            }
            if (moneyWithdraw < 0)
            {
                Console.WriteLine("Số tiền muốn rút không hợp lệ");
            }
            int money = bankBalance - moneyWithdraw;
            string query = "UPDATE userinformation SET bankBalance = " + money + " WHERE bankBalance = " + bankBalance;
            string query2 = "INSERT INTO  transactionlog (transactionCode, transactionTitle, bankNumber, money, transactionDate) VALUES ('" + security.TransactionCode() + "','Rut tien'," + bankNumber + "," + moneyWithdraw + "," + transactionDate + ")";
            MySqlCommand cmd1 = new MySqlCommand(query, connection, transaction);
            MySqlCommand cmd2 = new MySqlCommand(query, connection, transaction);
            try
            {
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                transaction.Commit();
                Console.WriteLine("Chúc quý khác tiêu tiền hợp lý");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi bất ngờ");
                transaction.Rollback();
            }
            connection.Close();
        }

        public void Transfer(string username)
        {
            connection = ConnectionHelper.GetDbConnection();
            Console.WriteLine("Nhập số tài khoản quý khách muốn chuyển tiền : ");
            int bankNumber = int.Parse(Console.ReadLine());
            string query = "SELECT FROM userinformation WHERE bankNumber = " + bankNumber;
            try
            {
                MySqlCommand cmd1 = new MySqlCommand(query, connection);
                if (cmd1.ExecuteScalar() != null)
                {
                    Console.WriteLine("Tài khoản này hợp lệ.");
                }
                else
                {
                    Console.WriteLine("Tài khoản này không tồn tại.");
                }

            }
            catch (Exception)
            {

                throw;
            }
            Console.WriteLine("Số tiền quý khách muốn chuyển: ");
            int moneyTransfer = int.Parse(Console.ReadLine());
            if (CheckMoney(username) < moneyTransfer)
            {
                Console.WriteLine("Số tiền vượt quá tiền trong tài khoản, vui lòng nhập lại");
                while (true)
                {
                    Console.WriteLine("Số tiền bạn muốn chuyển: ");
                    moneyTransfer = int.Parse(Console.ReadLine());
                }
            }
            long transactionDate = DateTime.Now.Ticks;
            int moneyAfter = CheckMoney(username) - moneyTransfer;
            int bankBalance = SelectBankBalance(bankNumber) + moneyTransfer;
            string query1 = "UPDATE userinformation SET bankBalance = " + moneyAfter + "WHERE bankBalance = " + CheckMoney(username);
            string query2 = "UPDATE userinformation SET bankBalance = " + bankBalance + "WHERE bankNumber = " + bankNumber;
            string query3 = "INSERT INTO  transactionlog (transactionCode, transactionTitle, bankNumber, money, transactionDate) VALUES ('" + security.TransactionCode() + "','Chuyển tiền'," + GetBankNumber(username) + "," + moneyTransfer + "," + transactionDate + ")";
            string query4 = "INSERT INTO  transactionlog (transactionCode, transactionTitle, bankNumber, money, transactionDate) VALUES ('" + security.TransactionCode() + "','Nhận tiền'," + bankNumber + "," + moneyTransfer + "," + transactionDate + ")";
            transaction = connection.BeginTransaction();
            try
            {
                MySqlCommand cmd1 = new MySqlCommand(query1, connection, transaction);
                MySqlCommand cmd2 = new MySqlCommand(query2, connection, transaction);
                MySqlCommand cmd3 = new MySqlCommand(query3, connection, transaction);
                MySqlCommand cmd4 = new MySqlCommand(query4, connection, transaction);
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception)
            {
                Console.WriteLine("Unexpected Error");
                transaction.Rollback();
            }
        }

        public int SelectBankBalance(int bankNumber)
        {
            connection = ConnectionHelper.GetDbConnection();
            string query = "SELECT FROM userinformation WHERE bankNumber = " + bankNumber;
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                int bankBalance = int.Parse(Console.ReadLine());
                dataReader.Close();
                return bankBalance;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetBankNumber(string username)
        {
            connection = ConnectionHelper.GetDbConnection();
            string query = "SELECT userinformation.bankNumber FROM userinformation INNER JOIN accounts ON accounts.id = userinformation.accountId AND accounts.username = '" + username + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                int bankNumber = Convert.ToInt32(dataReader["bankNumber"]);
                dataReader.Close();
                return bankNumber;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void transactionlog(string username)
        {
            List<Transactionlog> lt = new List<Transactionlog>();
            int bankNumber = GetBankNumber(username);
            connection = ConnectionHelper.GetDbConnection();
            string query = "SELECT* FROM transactionlog WHERE bankNumber =" + bankNumber;
            MySqlCommand cmd = new MySqlCommand(query, connection);
            try
            {
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    string transactionCode = dataReader["transactionCode"] + "";
                    string transactionTitle = dataReader["transactionTitle"] + "";
                    int money = Convert.ToInt32(dataReader["money"]);
                    long datetime = Convert.ToInt32(dataReader["transactionDate"]);
                    int receiveBankNumber = Convert.ToInt32(dataReader["receiveBankNumber"]);
                    string transactionNote = dataReader["transactionNote"] + "";
                    Transactionlog transactionlog = new Transactionlog(transactionCode, transactionTitle, money, datetime, receiveBankNumber, transactionNote);
                    lt.Add(transactionlog);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
                throw;
            }
            foreach (Transactionlog transactionlog in lt)
            {
                DateTime d = new DateTime(transactionlog.TransactionDate1);
                string da = d.ToString("dd/MM/yyyy");
                Console.WriteLine("Lịch sử giao dịch: ");
                Console.WriteLine("TransactionCode: " + transactionlog.TransactionCode1 + ", TransactionTitle: " + transactionlog.TransactionTitle1 + ",BankNumber: " + bankNumber + ",Money: " + transactionlog.Money1 + ",TransactionDate: " + da + ".");
            }
            {

            }
        }
    }
}
