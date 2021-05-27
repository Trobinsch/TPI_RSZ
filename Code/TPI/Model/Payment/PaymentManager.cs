using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class PaymentManager
    {
        private int idPayment;
        private int activeAccountId;
        private DateTime datePayment;
        private string accountRecipient;
        private decimal amount;
        private string informationTransmitted;
        private string personnalInformation;
        private List<Payment> allPayments;
        private int idAccountRecipient;
        private User activeUser;
        private Account activeAccount;
        

        public PaymentManager(int idPayment, int activeAccountId, string accountRecipient, DateTime datePayment, decimal amount, string informationTransmitted, string personnalInformation, int idAccountRecipient)
        {
            this.idPayment = idPayment;
            this.activeAccountId = activeAccountId;
            this.datePayment = datePayment;
            this.accountRecipient = accountRecipient;
            this.amount = amount;
            this.informationTransmitted = informationTransmitted;
            this.personnalInformation = personnalInformation;
            this.idAccountRecipient = idAccountRecipient;
            


            

        }
        public bool displayPayment(Account activeAccount)
        {
            string currentMonth = DateTime.Now.ToString("MM");
           
            allPayments = new List<Payment>();

            ApplicationSettings settings = JsonDataSaverReader.ReadAppSettings();
            DbConnector dbConnector = new DbConnector(settings.ConnectionString);

            string query = "SELECT * FROM payments WHERE DatePay LIKE '%-"+ currentMonth + "-%' AND (FkIDAccountOwner = " + activeAccount.IdAccount + " OR FkIDAccountRecipient =" + activeAccount.IdAccount +")";

            List<List<object>> queryResult = dbConnector.Select(query);
            if (queryResult.Count >= 1)
            {
                foreach (List<object> row in queryResult)
                {
                    int idPayment = Convert.ToInt32(row[0]);
                    int activeAccountId = Convert.ToInt32(row[1]);
                    string accountRecipient = row[2].ToString();
                    decimal amount = Convert.ToDecimal(row[3]);
                    DateTime datePayment = (DateTime)row[4];
                    string informationTransmitted = row[5].ToString();
                    string personnalInformation = row[6].ToString();
                    allPayments.Add(new Payment(idPayment, activeAccountId, datePayment, accountRecipient, amount, informationTransmitted, personnalInformation));
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool addPayment(Account activeAccount, int idAccountRecipient, DateTime datePayment, decimal amount, string informationSent, string personnalInformation )
        {
            ApplicationSettings settings = JsonDataSaverReader.ReadAppSettings();
            DbConnector dbConnector = new DbConnector(settings.ConnectionString);
            string querySelect = "SELECT ID from accounts WHERE AccountNumber = " + "'" + this.accountRecipient +"'";

            List<List<object>> queryResultSelect = dbConnector.Select(querySelect);
            if (queryResultSelect.Count == 1)
            {
              
                this.idAccountRecipient = Convert.ToInt32(queryResultSelect[0][0]);
                string query = "INSERT INTO payments(`FkIDAccountOwner`,`FkIDAccountRecipient`,`Amount`,`DatePay`,`InformationTransmitted`,`PersonalInformation`) VALUES ('" + activeAccount.IdAccount.ToString() + "', '" + this.idAccountRecipient + "','" + amount + "','" + datePayment.ToString("yyyy-MM-dd-HH-mm-ss") + "','" + informationSent + "','" + personnalInformation + "');";
                bool queryResult = dbConnector.Insert(query);
                if (queryResult == false)
                {
                    return false;
                }
                else
                {
                    string querySelectOwner = "SELECT Amount from accounts WHERE AccountNumber = " + "'" + activeAccount.AccountNumber + "'";
                    List<List<object>> queryResultSelectOwner = dbConnector.Select(querySelectOwner);
                    if (queryResultSelectOwner.Count == 1)
                    {
                        decimal amountFinalOwner = Convert.ToDecimal(queryResultSelectOwner[0][0]) - amount;
                        string queryUpdate = "UPDATE accounts SET Amount = " + amountFinalOwner + " WHERE ID =" + activeAccount.IdAccount.ToString();
                        bool queryResultUpdate = dbConnector.Update(queryUpdate);
                        if (queryResultUpdate == true)
                        {
                            string querySelectRecipient = "SELECT Amount from accounts WHERE AccountNumber = " + "'" + accountRecipient + "'";
                            List<List<object>> queryResultSelecRecipient = dbConnector.Select(querySelectRecipient);
                            if (queryResultSelecRecipient.Count == 1)
                            {
                              
                                decimal amountFinalRecipient = Convert.ToDecimal(queryResultSelecRecipient[0][0]) + amount;
                                string queryUpdateRecipient = "UPDATE accounts SET Amount = " + amountFinalRecipient + " WHERE ID =" + this.idAccountRecipient;
                                bool queryResultUpdateRecipient = dbConnector.Update(queryUpdateRecipient);
                                if (queryResultUpdateRecipient == true)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                       
                }
            }
            else { return false; } 
        }
        public List<Payment> AllPayments
        {
            get { return allPayments; }
        }
        public bool displayPaymentSort(Account activeAccount, DateTime firstDate, DateTime lastDate)
        {
            

            allPayments = new List<Payment>();

            ApplicationSettings settings = JsonDataSaverReader.ReadAppSettings();
            DbConnector dbConnector = new DbConnector(settings.ConnectionString);

            string query = "SELECT * FROM payments WHERE (FkIDAccountOwner = " + activeAccount.IdAccount + " OR FkIDAccountRecipient =" + activeAccount.IdAccount + ") AND DatePay BETWEEN '" + firstDate.ToString("yyyy-MM-dd") + "' AND '"+ lastDate.ToString("yyyy-MM-dd") +"'";

            List<List<object>> queryResult = dbConnector.Select(query);
            if (queryResult.Count >= 1)
            {
                foreach (List<object> row in queryResult)
                {
                    int idPayment = Convert.ToInt32(row[0]);
                    int activeAccountId = Convert.ToInt32(row[1]);
                    string accountRecipient = row[2].ToString();
                    decimal amount = Convert.ToDecimal(row[3]);
                    DateTime datePayment = (DateTime)row[4];
                    string informationTransmitted = row[5].ToString();
                    string personnalInformation = row[6].ToString();
                    allPayments.Add(new Payment(idPayment, activeAccountId, datePayment, accountRecipient, amount, informationTransmitted, personnalInformation));
                }
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}
