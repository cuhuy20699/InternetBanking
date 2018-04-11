using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Entity
{
    class UserInformation
    {
        private string BankNumber;
        private string Salt;
        private int BankBalance;
        private string FullName;
        private int Gender;
        private string Birthday;
        private string IdNumber;
        private string Phone;
        private string email;
        private string address;
        private string createdAt;
        private string updatedAt;

        public UserInformation()
        {

        }

        public global::System.Int32 BankNumber1 { get => BankNumber; set => BankNumber = value; }
        public global::System.String Salt1 { get => Salt; set => Salt = value; }
        public global::System.Int32 BankBalance1 { get => BankBalance; set => BankBalance = value; }
        public global::System.String FullName1 { get => FullName; set => FullName = value; }
        public global::System.Int32 Gender1 { get => Gender; set => Gender = value; }
        public global::System.String Birthday1 { get => Birthday; set => Birthday = value; }
        public global::System.String IdNumber1 { get => IdNumber; set => IdNumber = value; }
        public global::System.String Phone1 { get => Phone; set => Phone = value; }
        public global::System.String Email { get => email; set => email = value; }
        public global::System.String Address { get => address; set => address = value; }
        public global::System.String CreatedAt { get => createdAt; set => createdAt = value; }
        public global::System.String UpdatedAt { get => updatedAt; set => updatedAt = value; }
    }
}
