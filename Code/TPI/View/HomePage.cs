using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Model;
using Model.Exceptions;
namespace View
{
    public partial class frm_HomePage : Form
    {
        public User activeUser;
        public Account activeAccount;
        public PaymentManager payment;
        private PaymentManager allPayments;
        public Account allAccountRecipient;
        public Account allAccountSender;
        private DateTime datePayment;
        private int idAccountRecipient;
        public frm_HomePage()
        {

            int idUser = 1;
            string Username = "paul";
            string Password = "1234";
            this.activeUser = new User(idUser ,Username, Password);


            InitializeComponent();
        }

        private void frm_HomePage_Load(object sender, EventArgs e)
        {
            bool loadAccountSuccess = false;
            bool foundPaymentSuccess = false;
            bool foundUserByIdSuccessRecipient = false;
            bool foundUserByIdSuccessSender = false;
            int idUser = 0;
            bool flagDbError = false;
            int idAccount = 0;
            int id = 0;
            string accountRecipient = "";
            string numberAccount = "";
            decimal amount = 0;
            
            string informationTransmitted = "";
            string personnalInformation = "";

            

            try
            {
                this.activeAccount = new Account(idAccount, numberAccount, amount, activeUser);
                loadAccountSuccess = this.activeAccount.loadAccount(idAccount, numberAccount, amount);
            }
            catch (DbError)
            {
                MessageBox.Show("Du à un problème avec notre serveur, vos données sont actuellement limitées voir indisponibles", "Problème de connexion");
                flagDbError = true;
            }

            if (loadAccountSuccess == true)
            {
                MessageBox.Show("Vous êtes connecté au compte " + activeAccount.AccountNumber, "Connexion");
                
            }

            


            try
            {
                this.allPayments = new PaymentManager(id, idAccount, accountRecipient, datePayment, amount, informationTransmitted, personnalInformation, idAccountRecipient);
                foundPaymentSuccess = this.allPayments.displayPayment(activeAccount);

            }
            catch (DbError)
            {
                MessageBox.Show("Du à un problème avec notre serveur, vos données sont actuellement limitées voir indisponibles", "Problème de connexion");
                flagDbError = true;
            }
            if (foundPaymentSuccess == true)
            {
                
                foreach (Payment payment in allPayments.AllPayments)
                {
                    try
                    {
                        allAccountRecipient = new Account(idAccount, numberAccount, amount, activeUser);
                        foundUserByIdSuccessRecipient = allAccountRecipient.findAccountById(Convert.ToInt32(payment.AccountRecipient), numberAccount, amount);
                        allAccountSender = new Account(idAccount, numberAccount, amount, activeUser);
                        foundUserByIdSuccessSender = allAccountSender.findAccountById(Convert.ToInt32(payment.ActiveAccount), numberAccount, amount);
                    }
                    catch (DbError)
                    {

                        flagDbError = true;
                    }
                    if ((foundUserByIdSuccessRecipient == true) && ( foundUserByIdSuccessSender == true))
                    {

                        ListViewItem listPayment = new ListViewItem(allAccountRecipient.AccountNumber, 0);
                        listPayment.SubItems.Add(allAccountSender.AccountNumber);
                        listPayment.SubItems.Add(payment.Amount.ToString());
                        listPayment.SubItems.Add(payment.DatePayment.ToString("yyyy-MM-dd HH:mm:ss"));
                        listPayment.SubItems.Add(payment.InformationTransmitted);
                        listPayment.SubItems.Add(payment.PersonnalInformation);
                        var list = LSV_payment.Items.Add(listPayment);
                    }
                }
                
            }
            lbl_amountOwner.Text = activeAccount.Amount.ToString();
        }

        private void btn_payment_Click(object sender, EventArgs e)
        {
            frm_Versement frm = new frm_Versement(payment, activeAccount, activeUser);

            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                payment = frm.ActivePayment;
            }
        }

        private void btn_leave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_listRefresh_Click(object sender, EventArgs e)
        {
            bool foundPaymentSuccess = false;
            
            bool foundUserByIdSuccessRecipient = false;
            bool foundUserByIdSuccessSender = false;
            bool loadAccountSuccess = false;
            bool flagDbError = false;
            int idAccount = 0;
            int id = 0;
            string accountRecipient = "";
            string numberAccount = "";
            decimal amount = 0;

            string informationTransmitted = "";
            string personnalInformation = "";
            this.LSV_payment.Clear();
            

            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "Destinataire";
            columnHeader1.Width = 92;

            ColumnHeader columnHeader2 = new ColumnHeader();
            columnHeader2.Text = "Envoyeur";
            columnHeader2.Width = 92;

            ColumnHeader columnHeader3 = new ColumnHeader();
            columnHeader3.Text = "Montant";
            columnHeader3.Width = 73;

            ColumnHeader columnHeader4 = new ColumnHeader();
            columnHeader4.Text = "Date";
            columnHeader4.Width = 80;

            ColumnHeader columnHeader5 = new ColumnHeader();
            columnHeader5.Text = "Information Transmise";
            columnHeader5.Width = 115;

            ColumnHeader columnHeader6 = new ColumnHeader();
            columnHeader6.Text = "Information Personnel";
            columnHeader6.Width = 127;



            this.LSV_payment.Columns.Add(columnHeader1);
            this.LSV_payment.Columns.Add(columnHeader2);
            this.LSV_payment.Columns.Add(columnHeader3);
            this.LSV_payment.Columns.Add(columnHeader4);
            this.LSV_payment.Columns.Add(columnHeader5);
            this.LSV_payment.Columns.Add(columnHeader6);




            try
            {
                this.allPayments = new PaymentManager(id, idAccount, accountRecipient, datePayment, amount, informationTransmitted, personnalInformation, idAccountRecipient);
                foundPaymentSuccess = this.allPayments.displayPayment(activeAccount);

            }
            catch (DbError)
            {
                MessageBox.Show("Du à un problème avec notre serveur, vos données sont actuellement limitées voir indisponibles", "Problème de connexion");
                flagDbError = true;
            }
            if (foundPaymentSuccess == true)
            {

                foreach (Payment payment in allPayments.AllPayments)
                {
                    try
                    {
                        allAccountRecipient = new Account(idAccount, numberAccount, amount, activeUser);
                        foundUserByIdSuccessRecipient = allAccountRecipient.findAccountById(Convert.ToInt32(payment.AccountRecipient), numberAccount, amount);
                        allAccountSender = new Account(idAccount, numberAccount, amount, activeUser);
                        foundUserByIdSuccessSender = allAccountSender.findAccountById(Convert.ToInt32(payment.ActiveAccount), numberAccount, amount);
                    }
                    catch (DbError)
                    {

                        flagDbError = true;
                    }
                    if ((foundUserByIdSuccessRecipient == true) && (foundUserByIdSuccessSender == true))
                    {

                        ListViewItem listPayment = new ListViewItem(allAccountRecipient.AccountNumber, 0);
                        listPayment.SubItems.Add(allAccountSender.AccountNumber);
                        listPayment.SubItems.Add(payment.Amount.ToString());
                        listPayment.SubItems.Add(payment.DatePayment.ToString("yyyy-MM-dd HH:mm:ss"));
                        listPayment.SubItems.Add(payment.InformationTransmitted);
                        listPayment.SubItems.Add(payment.PersonnalInformation);
                        var list = LSV_payment.Items.Add(listPayment);
                    }
                }

            }
            try
            {
                this.activeAccount = new Account(idAccount, numberAccount, amount, activeUser);
                loadAccountSuccess = this.activeAccount.loadAccount(idAccount, numberAccount, amount);
            }
            catch (DbError)
            {
                MessageBox.Show("Du à un problème avec notre serveur, vos données sont actuellement limitées voir indisponibles", "Problème de connexion");
                flagDbError = true;
            }
            if(loadAccountSuccess == true)
            {
                lbl_amountOwner.Text = activeAccount.Amount.ToString();
            }
            
        }

        private void btn_sort_Click(object sender, EventArgs e)
        {
            bool foundPaymentSuccess = false;

            bool foundUserByIdSuccessRecipient = false;
            bool foundUserByIdSuccessSender = false;
            bool loadAccountSuccess = false;
            bool flagDbError = false;
            int idAccount = 0;
            int id = 0;
            string accountRecipient = "";
            string numberAccount = "";
            decimal amount = 0;
            DateTime firstDate = DTP_firstDate.Value;
            DateTime lastDate = DTP_lastDate.Value;

            string informationTransmitted = "";
            string personnalInformation = "";
            this.LSV_payment.Clear();


            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "Destinataire";
            columnHeader1.Width = 92;

            ColumnHeader columnHeader2 = new ColumnHeader();
            columnHeader2.Text = "Envoyeur";
            columnHeader2.Width = 92;

            ColumnHeader columnHeader3 = new ColumnHeader();
            columnHeader3.Text = "Montant";
            columnHeader3.Width = 73;

            ColumnHeader columnHeader4 = new ColumnHeader();
            columnHeader4.Text = "Date";
            columnHeader4.Width = 80;

            ColumnHeader columnHeader5 = new ColumnHeader();
            columnHeader5.Text = "Information Transmise";
            columnHeader5.Width = 115;

            ColumnHeader columnHeader6 = new ColumnHeader();
            columnHeader6.Text = "Information Personnel";
            columnHeader6.Width = 127;



            this.LSV_payment.Columns.Add(columnHeader1);
            this.LSV_payment.Columns.Add(columnHeader2);
            this.LSV_payment.Columns.Add(columnHeader3);
            this.LSV_payment.Columns.Add(columnHeader4);
            this.LSV_payment.Columns.Add(columnHeader5);
            this.LSV_payment.Columns.Add(columnHeader6);


            if(DTP_firstDate.Value > DTP_lastDate.Value)
            {
                MessageBox.Show("La valeur du premier doit être inférieur au deuxième", "Problème de connexion");
            }
            else
            {
                try
                {
                    this.allPayments = new PaymentManager(id, idAccount, accountRecipient, datePayment, amount, informationTransmitted, personnalInformation, idAccountRecipient);
                    foundPaymentSuccess = this.allPayments.displayPaymentSort(activeAccount, firstDate, lastDate);

                }
                catch (DbError)
                {
                    MessageBox.Show("Du à un problème avec notre serveur, vos données sont actuellement limitées voir indisponibles", "Problème de connexion");
                    flagDbError = true;
                }
                if (foundPaymentSuccess == true)
                {

                    foreach (Payment payment in allPayments.AllPayments)
                    {
                        try
                        {
                            allAccountRecipient = new Account(idAccount, numberAccount, amount, activeUser);
                            foundUserByIdSuccessRecipient = allAccountRecipient.findAccountById(Convert.ToInt32(payment.AccountRecipient), numberAccount, amount);
                            allAccountSender = new Account(idAccount, numberAccount, amount, activeUser);
                            foundUserByIdSuccessSender = allAccountSender.findAccountById(Convert.ToInt32(payment.ActiveAccount), numberAccount, amount);
                        }
                        catch (DbError)
                        {

                            flagDbError = true;
                        }
                        if ((foundUserByIdSuccessRecipient == true) && (foundUserByIdSuccessSender == true))
                        {

                            ListViewItem listPayment = new ListViewItem(allAccountRecipient.AccountNumber, 0);
                            listPayment.SubItems.Add(allAccountSender.AccountNumber);
                            listPayment.SubItems.Add(payment.Amount.ToString());
                            listPayment.SubItems.Add(payment.DatePayment.ToString("yyyy-MM-dd HH:mm:ss"));
                            listPayment.SubItems.Add(payment.InformationTransmitted);
                            listPayment.SubItems.Add(payment.PersonnalInformation);
                            var list = LSV_payment.Items.Add(listPayment);
                        }
                    }

                }
            }

            
        }
    }
}