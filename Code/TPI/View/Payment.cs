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
        public frm_Versement(PaymentManager activePayment, Account activeAccount)
        {
            this.activeUser = activeUser;
            
            //settingsUser = JsonDataSaverReader.ReadUserSettings(activeUser.UserName);
            this.activePayment = activePayment;
            this.activeAccount = activeAccount;
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
            bool saveSuccess = false;
            bool flagDbError = false;
            string AccountRecipient = txt_accountRecipient.Text;
            decimal amount = Int32.Parse(txt_amount.Text);
            string informationTransmitted = txt_informationTransmitted.Text;
            string personnalInformation = txt_personnalInformation.Text;
            DateTime dateTemps = DTP_datePayment.Value;
            

            if ((string.IsNullOrEmpty(txt_accountRecipient.Text)) || (string.IsNullOrEmpty(txt_amount.Text)) )
            {
                MessageBox.Show("les champs sont vides", "Erreur dans le formulaire", MessageBoxButtons.OK);
            }
            else if ((Int32.Parse(txt_amount.Text) > activeAccount.Amount))
            {
                MessageBox.Show("Le montant doit être moins élevé que votre solde", "Données incompatibles", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    activePayment = new PaymentManager(id, idAccount, AccountRecipient, dateTemps, amount, informationTransmitted, personnalInformation, idAccountRecipient);
                    saveSuccess = activePayment.addPayment(activeAccount, idAccountRecipient, dateTemps, amount, informationTransmitted, personnalInformation);
                }
                catch (DbError)
                {
                    MessageBox.Show("Du à un problème avec notre serveur, vos données sont actuellement limitées voir indisponibles", "Problème de connexion");
                    flagDbError = true;
                }
                if (saveSuccess == true)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                if (saveSuccess == false && flagDbError == false)
                {
                    MessageBox.Show("Vous ne pouvez pas sauvegarder cette importation", "Problème d'importation", MessageBoxButtons.OK);
                }

            }
        }
    }
}
