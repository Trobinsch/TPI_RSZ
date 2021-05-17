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
        private int idAccountRecipient;

        public PaymentManager(int idPayment, int activeAccount, string accountRecipient, DateTime datePayment, decimal amount, string informationSent, string personnalInformation, int idAccountRecipient)
        {
            this.idPayment = idPayment;
            this.activeAccount = activeAccount;
            this.datePayment = datePayment;
            this.accountRecipient = accountRecipient;
            this.amount = amount;
            this.informationSent = informationSent;
            this.personnalInformation = personnalInformation;
            this.idAccountRecipient = idAccountRecipient;


        }

        public bool addPayment(Account activeAccount, int idAccountRecipient, DateTime datePayment, decimal amount, string informationSent, string personnalInformation )
        {
            ApplicationSettings settings = JsonDataSaverReader.ReadAppSettings();
            DbConnector dbConnector = new DbConnector(settings.ConnectionString);
            string querySelect = "SELECT ID from accounts WHERE AccountNumber = " + "'" + accountRecipient +"'";

            List<List<object>> queryResultSelect = dbConnector.Select(querySelect);
            if (queryResultSelect.Count == 1)
            {


                this.accountRecipient = accountRecipient;
                this.idAccountRecipient = Convert.ToInt32(queryResultSelect[0][0]);
                string query = "INSERT INTO payments(`FkIDAccountOwner`,`FkIDAccountRecipient`,`Amount`,`DatePay`,`InformationTransmitted`,`PersonalInformation`) VALUES ('" + activeAccount.IdAccount.ToString() + "', '" + this.idAccountRecipient + "','" + amount + "','" + datePayment.ToString("yyyy-MM-dd-HH-MM-ss") + "','" + informationSent + "','" + personnalInformation + "');";
                bool queryResult = dbConnector.Insert(query);
                if (queryResult == false)
                {
                    return false;
                }
                else
                {
                    decimal amountFinalOwner = Convert.ToDecimal(activeAccount.Amount) - amount;
                    string queryUpdate = "UPDATE accounts SET Amount = " + amountFinalOwner + " WHERE ID ="+ activeAccount.IdAccount.ToString();
                    bool queryResultUpdate = dbConnector.Update(queryUpdate);
                    if (queryResultUpdate == true)
                    {
                        decimal amountFinalRecipient = Convert.ToDecimal(activeAccount.Amount) - amount;
                        string queryUpdate = "UPDATE accounts SET Amount = " + amountFinalRecipient + " WHERE ID =" + this.idAccountRecipient;
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                    
                }


            }
            else { return false; }


            
        }
        
    }

}
