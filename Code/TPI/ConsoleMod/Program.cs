using System;
using Model;

namespace ConsoleMod
{
    class Program
    {
        static void Main(string[] args)
        {
            Account sellerAccount;
            int idAccount = 0;
            string accountSeller;
            decimal amountSeller;
            User seller;
            int flag;
            string accountNumber;
            string accountCustomer;
            decimal amount;
            string request = "0";
            do
            {
                
                
                
                Console.WriteLine("Ecrivez le numero de compte du vendeur");
                accountNumber = Console.ReadLine();
                Console.WriteLine("Ecrivez le numero de compte du client");
                accountCustomer = Console.ReadLine();
                Console.WriteLine("Ecrivez le montant à payer");
                amount = Convert.ToDecimal(Console.ReadLine());



            } while (request != "exit");


            
        }
    }
}
