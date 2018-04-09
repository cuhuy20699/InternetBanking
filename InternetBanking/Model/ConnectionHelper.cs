using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Model
{
    class ConnectionHelper
    {
        private static MySqlConnection connection;

        public static MySqlConnection GetDbConnection()
        {
            if(connection == null)
            {
                try
                {
                    connection = GetConnection();
                    connection.Open();

                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
            }
            return connection;
        }

        public void CloseConnection()
        {
            if(connection != null)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
            
        }

        private static MySqlConnection GetConnection()
        {
            string server = "localhost";
            int port = 3306;
            string database = "InternetBanking";
            string username = "root";
            string password = "";

            return GetConnection(server, port, database, username, password);
        }

        private static MySqlConnection GetConnection(string server, int port, string database, string username, string password)
        {
            string ConnectString = "Server = " + server + ";Database = " + database + ";port = " + port + ";username = " + username + ";password = " + password + ";CharSet=utf8;";
            MySqlConnection conn = new MySqlConnection(ConnectString);
            return conn;
        }
    }
}
