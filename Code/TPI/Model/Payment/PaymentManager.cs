﻿using System;
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
        private User activeUser;

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
        
    }

}
