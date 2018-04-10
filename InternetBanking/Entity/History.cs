using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Entity
{
    class History
    {
        private string TransactionCode;
        private string TransactionTitle;
        private int BankNumber;
        private int Money;
        private string TransactionDate;
        private int ReceiveBankNumber;
        private string TransactionNote;

        public History()
        {

        }

        public global::System.String TransactionCode1 { get => TransactionCode; set => TransactionCode = value; }
        public global::System.String TransactionTitle1 { get => TransactionTitle; set => TransactionTitle = value; }
        public global::System.Int32 BankNumber1 { get => BankNumber; set => BankNumber = value; }
        public global::System.Int32 Money1 { get => Money; set => Money = value; }
        public global::System.String TransactionDate1 { get => TransactionDate; set => TransactionDate = value; }
        public global::System.Int32 ReceiveBankNumber1 { get => ReceiveBankNumber; set => ReceiveBankNumber = value; }
        public global::System.String TransactionNote1 { get => TransactionNote; set => TransactionNote = value; }
    }
}
