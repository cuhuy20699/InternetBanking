using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Security
{
    class Security
    {
        private static Random random = new Random();
        private static string RandomString(int length)
        {
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }

        private static string RandomString1(int length)
        {
            const string pool = "0123456789";
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }

        public string MD5Encrypt(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(password));
            byte[] result = md5.Hash;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                stringBuilder.Append(result[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }

        public string SaltRandom()
        {
            return RandomString(6);
        }

        public string BankNumberRandom()
        {
            return RandomString1(15);
        }
        public string TransactionCode()
        {
            const string tranCodeS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            const string tranCodeI = "0123456789";

            StringBuilder builder1 = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                var character1 = tranCodeS[random.Next(0, tranCodeS.Length)];
                builder1.Append(character1);
                var character2 = tranCodeI[random.Next(0, tranCodeI.Length)];
                builder2.Append(character2);
            }

            string transcode1 = builder1.ToString();

            string transcode2 = builder2.ToString();

            string code = "TEC" + transcode2 + transcode1;

            return code;
        }
    }
}
