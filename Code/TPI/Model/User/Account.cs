using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Account
    {

        private int idAccount;
        private decimal amount;
        private string accountNumber;
        private int activerUser;

        public Account(int idAccount, decimal amount, string accountNumber, int activeUser)
        {
            this.idAccount = idAccount;
            this.amount = amount;
            this.accountNumber = accountNumber;
            this.activerUser = activeUser;
        }

        public int IdAccount
        {
            get { return idAccount; }
        }
        public decimal Amount
        {
            get { return amount; }
        }
        public string AccountNumber
        {
            get { return accountNumber; }
        }
        public int ActiveUser
        {
            get { return activerUser; }
        }
    }
}
