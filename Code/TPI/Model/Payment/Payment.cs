using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    
    public class Payment
    {

        private int idPayment;
        private int activeAccount;
        private DateTime datePayment;
        private string accountRecipient;
        private decimal amount;
        private string informationSent;
        private string personnalInformation;

        public Payment(int idPayment, int activeAccount, DateTime datePayment, string accountRecipient, decimal amount, string informationSent, string personnalInformation)
        {
            this.idPayment = idPayment;
            this.activeAccount = activeAccount;
            this.datePayment = datePayment;
            this.accountRecipient = accountRecipient;
            this.amount = amount;
            this.informationSent = informationSent;
            this.personnalInformation = personnalInformation;
        }

        public int IdPayment
        {
            get { return idPayment; }
        }
        public int ActiveAccount
        {
            get { return activeAccount; }
        }
        public DateTime DatePayment
        {
            get { return datePayment; }
        }
        public string AccountRecipient
        {
            get { return accountRecipient; }
        }
        public decimal Amount
        {
            get { return amount; }
        }
        public string InformationSent
        {
            get { return informationSent; }
        }
        public string PersonnalInformation
        {
            get { return personnalInformation; }
        }

    }
}
