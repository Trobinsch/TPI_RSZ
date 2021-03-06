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
        private string informationTransmitted;
        private string personalInformation;

        public Payment(int idPayment, int activeAccount, DateTime datePayment, string accountRecipient, decimal amount, string informationTransmitted, string personalInformation)
        {
            this.idPayment = idPayment;
            this.activeAccount = activeAccount;
            this.datePayment = datePayment;
            this.accountRecipient = accountRecipient;
            this.amount = amount;
            this.informationTransmitted = informationTransmitted;
            this.personalInformation = personalInformation;
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
        public string InformationTransmitted
        {
            get { return informationTransmitted; }
        }
        public string PersonalInformation
        {
            get { return personalInformation; }

            set { personalInformation = value; }
        }

    }
}
