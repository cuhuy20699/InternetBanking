using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Entity
{
    class Transactionlog
    {
        private string TransactionCode;
        private string TransactionTitle;
        private int BankNumber;
        private int Money;
        private long TransactionDate;
        private int ReceiveBankNumber;
        private string TransactionNote;
        private long datetime;

        public Transactionlog()
        {

        }

        public Transactionlog(string transactionCode, string transactionTitle, int money, long datetime, int receiveBankNumber, string transactionNote)
        {
            TransactionCode1 = transactionCode;
            TransactionTitle1 = transactionTitle;
            Money1 = money;
            this.Datetime = datetime;
            ReceiveBankNumber1 = receiveBankNumber;
            TransactionNote1 = transactionNote;
        }

        public string TransactionCode1 { get => TransactionCode; set => TransactionCode = value; }
        public string TransactionTitle1 { get => TransactionTitle; set => TransactionTitle = value; }
        public int BankNumber1 { get => BankNumber; set => BankNumber = value; }
        public int Money1 { get => Money; set => Money = value; }
        public long TransactionDate1 { get => TransactionDate; set => TransactionDate = value; }
        public int ReceiveBankNumber1 { get => ReceiveBankNumber; set => ReceiveBankNumber = value; }
        public string TransactionNote1 { get => TransactionNote; set => TransactionNote = value; }
        public long Datetime { get => datetime; set => datetime = value; }
    }
}
