using System;

using Model;
using Model.Exceptions;


namespace ConsoleMod
{
    class Program
    {
        static void Main(string[] args)
        {
            Account sellerAccount;
            int idSeller = 0;
            string accountSeller = "";
            decimal amountSeller = 0;

            Account customerAccount;
            int idCustomer = 0;
            string accountCustomer = "";
            decimal amountCustomer = 0;

            User seller;
            int idSellerUser = 0;
            string sellerName = "";
            string sellerPassword = "";

            User customer;
            int idCustomerUser = 0;
            string customerName = "";
            string customerPassword = "";


            bool loginAccountSuccess = false;
            bool findCustomerSuccess = false;
            bool findSellerSuccess = false;
            bool saveSuccess = false;
            bool flagDbError = false;
          

            int idPayment = 0;
            int id = 0;
            PaymentManager activePayment;
            string informationTransmitted = "";
            string personnalInformation = "";

            
            DateTime now = DateTime.Now;


            seller = new User(idSellerUser, sellerName, sellerPassword);
            customer = new User(idCustomerUser, customerName, customerPassword);
            sellerAccount = new Account(idSeller, accountSeller, amountSeller, seller);
            customerAccount = new Account(idCustomer, accountCustomer, amountCustomer, customer);



            Console.WriteLine("request-payment " + args[0]+ " " + args[1] + " " + args[2]);

            try
            {
                sellerAccount = new Account(idSeller, args[0], amountSeller, seller);
                findSellerSuccess = sellerAccount.findAccount(idSeller, args[0], amountSeller, id);
            }
            catch (DbError)
            {

                flagDbError = true;
            }
            if ((findSellerSuccess == false) || (!args[0].Contains("VA-")))
            {
                Console.WriteLine("Aborted. invalid vendor account number");
            }
            else
            {
                try
                {
                    customerAccount = new Account(idCustomer, args[1], amountCustomer, customer);
                    findCustomerSuccess = customerAccount.findAccount(idCustomer, args[1], amountCustomer, id);
                }
                catch (DbError)
                {

                    flagDbError = true;
                }
                if (findCustomerSuccess == false)
                {
                    Console.WriteLine("Aborted. invalid customer account number");
                }
                else
                {
                    if (Convert.ToDecimal(args[2]) > customerAccount.Amount)
                    {
                        Console.WriteLine("Aborted, invalid amount");
                    }
                    else
                    {
                        try
                        {
                            activePayment = new PaymentManager(idPayment, id, args[0], now, Convert.ToDecimal(args[2]), informationTransmitted, personnalInformation, idSeller);
                            saveSuccess = activePayment.addPayment(customerAccount, idSeller, now, Convert.ToDecimal(args[2]), informationTransmitted, personnalInformation);
                        }
                        catch (DbError)
                        {
                            Console.WriteLine("Du à un problème avec notre serveur, vos données sont actuellement limitées voir indisponibles", "Problème de connexion");
                            flagDbError = true;
                        }
                        Console.WriteLine("Success, payment done");
                    }
                }

            }

            
        }
    }
}
