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
    public partial class frm_Versement : Form
    {
        PaymentManager activePayment;
        User activeUser ;
        Account activeAccount;
        int idAccount;
       

        private UserSettings settingsUser = new UserSettings();
        private int idAccountRecipient;
        private int id;
        public frm_Versement(PaymentManager activePayment, Account activeAccount, User activeUser)
        {
            this.activeUser = activeUser;
            
            //settingsUser = JsonDataSaverReader.ReadUserSettings(activeUser.UserName);
            this.activePayment = activePayment;
            this.activeAccount = activeAccount;
            this.activeUser = activeUser;
            this.idAccount = idAccount;
            
            InitializeComponent();
        }
        public PaymentManager ActivePayment
        {
            get
            {
                return activePayment;
            }
            set
            {
                this.activePayment = value;
            }
        }



        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            bool findCustomerSuccess = false;
            bool saveSuccess = false;
            bool flagDbError = false;
            string numberAccount = "";
            decimal amount = 0;
            int idAccount = 0;
            string accountRecipient = txt_accountRecipient.Text;
            
            string informationTransmitted = txt_informationTransmitted.Text;
            string personnalInformation = txt_personnalInformation.Text;
            DateTime dateTemps = DTP_datePayment.Value;

            
            if (!string.IsNullOrEmpty(txt_amount.Text))
            {
                amount = Convert.ToDecimal(txt_amount.Text);
            }
            

            if ((string.IsNullOrEmpty(txt_accountRecipient.Text)) || (string.IsNullOrEmpty(txt_amount.Text)) )
            {
                MessageBox.Show("les champs sont vides", "Erreur dans le formulaire", MessageBoxButtons.OK);
            } 
            else
            {
                try
                {
                    activeAccount = new Account(idAccount, numberAccount, amount, activeUser);
                    findCustomerSuccess = activeAccount.loadAccount(idAccount, numberAccount, amount);
                }
                catch (DbError)
                {
                    flagDbError = true;
                }
                if(findCustomerSuccess == true)
                {
                    if (txt_accountRecipient.Text == activeAccount.AccountNumber)
                    {
                        MessageBox.Show("Vous ne pouvez pas écrire votre numéro de compte", "Erreur dans le formulaire", MessageBoxButtons.OK);
                    }
                    else if ((Convert.ToDecimal(txt_amount.Text) > activeAccount.Amount))
                    {
                        MessageBox.Show("Le montant doit être moins élevé que votre solde, votre solde actuel : " + activeAccount.Amount, "Données incompatibles", MessageBoxButtons.OK);

                    }else if(Convert.ToDecimal(txt_amount.Text) < 0)
                    {
                        MessageBox.Show("Le montant doit être positif", "Erreur dans le formulaire", MessageBoxButtons.OK);
                    }
                    else
                    {
                        try
                        {
                            activePayment = new PaymentManager(id, idAccount, accountRecipient, dateTemps, amount, informationTransmitted, personnalInformation, idAccountRecipient);
                            saveSuccess = activePayment.addPayment(activeAccount, idAccountRecipient, dateTemps, amount, informationTransmitted, personnalInformation);
                        }
                        catch (DbError)
                        {
                            MessageBox.Show("Du à un problème avec notre serveur, vos données sont actuellement limitées voir indisponibles", "Problème de connexion");
                            flagDbError = true;
                        }
                        if (saveSuccess == true)
                        {
                            MessageBox.Show("Votre versement a été validé et enregistré ", "Enregistrement");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        if (saveSuccess == false && flagDbError == false)
                        {
                            MessageBox.Show("Destinataire Introuvable", "Problème d'importation", MessageBoxButtons.OK);
                        }

                    }
                }
                
            }
            
        }
        

        private void txt_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
