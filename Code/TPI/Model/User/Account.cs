﻿using System;
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

        public bool logAccount(int idAccount, string accountNUmber, decimal amount)
        {
            ApplicationSettings settings = JsonDataSaverReader.ReadAppSettings();
            DbConnector connector = new DbConnector(settings.ConnectionString);
            string accountQuery = "SELECT ID, AccountNumber, Amount FROM accounts WHERE FkID = " + ActiveUser.IdUser ;

            List<List<object>> queryResult = connector.Select(accountQuery);

            if (queryResult.Count == 1)
            {


                this.idAccount = Convert.ToInt32(queryResult[0][0]);
                this.accountNumber = queryResult[0][1].ToString();
                this.amount = Convert.ToDecimal(queryResult[0][2]);
                return true;


            }
            else { return false; }

        }
    }
}