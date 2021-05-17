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
        private User activeUser;

        public Account(int idAccount, string accountNumber, decimal amount, User activeUser)
        {
            this.idAccount = idAccount;
            this.amount = amount;
            this.accountNumber = accountNumber;
            this.activeUser = activeUser;
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
        public User ActiveUser
        {
            get { return activeUser; }
        }
    }
}
