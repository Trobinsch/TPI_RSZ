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
            bool loginAccountSuccess = false;
            bool flagDbError = false;
            int idAccount = 0;
            string numberAccount = "";
            decimal amount = 0;
            try
            {
                this.activeAccount = new Account(idAccount, numberAccount, amount, activeUser);
                loginAccountSuccess = this.activeAccount.loadAccount(idAccount, numberAccount, amount);
            }
            catch (DbError)
            {
                MessageBox.Show("Du à un problème avec notre serveur, vos données sont actuellement limitées voir indisponibles", "Problème de connexion");
                flagDbError = true;
            }

            if (loginAccountSuccess == true)
            {
                MessageBox.Show("Vous êtes connecté au compte " + activeAccount.AccountNumber, "Connexion");
                
            }

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
    }
}
