using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class PaymentManager
    {
        private int idPayment;
        private int activeAccount;
        private DateTime datePayment;
        private string accountRecipient;
        private decimal amount;
        private string informationSent;
        private string personnalInformation;
        private List<Payment> allPayments;

        public PaymentManager(int idPayment, int activeAccount, string accountRecipient, DateTime datePayment, decimal amount, string informationSent, string personnalInformation)
        {
            this.idPayment = idPayment;
            this.activeAccount = activeAccount;
            this.datePayment = datePayment;
            this.accountRecipient = accountRecipient;
            this.amount = amount;
            this.informationSent = informationSent;
            this.personnalInformation = personnalInformation;
        }

        public bool addPayment(Account activeAccount, string accountRecipient, DateTime datePayment, decimal amount, string informationSent, string personnalInformation )
        {
            ApplicationSettings settings = JsonDataSaverReader.ReadAppSettings();
            DbConnector dbConnector = new DbConnector(settings.ConnectionString);


            string query = "INSERT INTO E-banking('FkidAccount','AccountNumber_Recipient','Amount','Date','information','personal_information') VALUES ('"+ activeAccount.ToString() + "', '" + accountRecipient +"','"+ amount+"','"+ datePayment.ToString("yyyy-MM-dd")+"','"+ informationSent+"','" + personnalInformation+ "')";
            bool queryResult = dbConnector.Insert(query);
            if (queryResult == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}
