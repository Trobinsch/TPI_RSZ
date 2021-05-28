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
        private User activeUser;
        private Account activeAccount;
        private PaymentManager payment;
        private PaymentManager allPayments;
        private Account allAccountRecipient;
        private Account allAccountSender;
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


            ColumnHeader clm_recipient = new ColumnHeader();
            clm_recipient.Text = "Destinataire";
            clm_recipient.Width = 92;

            ColumnHeader clm_sender = new ColumnHeader();
            clm_sender.Text = "Envoyeur";
            clm_sender.Width = 92;

            ColumnHeader clm_amount = new ColumnHeader();
            clm_amount.Text = "Montant";
            clm_amount.Width = 73;

            ColumnHeader clm_datePay = new ColumnHeader();
            clm_datePay.Text = "Date";
            clm_datePay.Width = 80;

            ColumnHeader clm_informationTransmitted = new ColumnHeader();
            clm_informationTransmitted.Text = "Information Transmise";
            clm_informationTransmitted.Width = 115;

            ColumnHeader clm_personnalInformation = new ColumnHeader();
            clm_personnalInformation.Text = "Information Personnel";
            clm_personnalInformation.Width = 127;



            this.LSV_payment.Columns.Add(clm_recipient);
            this.LSV_payment.Columns.Add(clm_sender);
            this.LSV_payment.Columns.Add(clm_amount);
            this.LSV_payment.Columns.Add(clm_datePay);
            this.LSV_payment.Columns.Add(clm_informationTransmitted);
            this.LSV_payment.Columns.Add(clm_personnalInformation);




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


            ColumnHeader clm_recipient = new ColumnHeader();
            clm_recipient.Text = "Destinataire";
            clm_recipient.Width = 92;

            ColumnHeader clm_sender = new ColumnHeader();
            clm_sender.Text = "Envoyeur";
            clm_sender.Width = 92;

            ColumnHeader clm_amount = new ColumnHeader();
            clm_amount.Text = "Montant";
            clm_amount.Width = 73;

            ColumnHeader clm_datePay = new ColumnHeader();
            clm_datePay.Text = "Date";
            clm_datePay.Width = 80;

            ColumnHeader clm_informationTransmitted = new ColumnHeader();
            clm_informationTransmitted.Text = "Information Transmise";
            clm_informationTransmitted.Width = 115;

            ColumnHeader clm_personnalInformation = new ColumnHeader();
            clm_personnalInformation.Text = "Information Personnel";
            clm_personnalInformation.Width = 127;



            this.LSV_payment.Columns.Add(clm_recipient);
            this.LSV_payment.Columns.Add(clm_sender);
            this.LSV_payment.Columns.Add(clm_amount);
            this.LSV_payment.Columns.Add(clm_datePay);
            this.LSV_payment.Columns.Add(clm_informationTransmitted);
            this.LSV_payment.Columns.Add(clm_personnalInformation);


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