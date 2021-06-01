using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Timers;

using Model;
using Model.Exceptions;

namespace View
{
    public partial class frm_login : Form
    {
        string currentPassword = "";
        int flag = 0;
        private Thread th;
        private User activeUser;
        public frm_login()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// This function opens the Homepage's window
        /// </summary>
        private void OpenFormApp()
        {
            Application.Run(new frm_HomePage(activeUser));
        }
        /// <summary>
        /// This function puts the timer on the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            TextBox currentInputBox = sender as TextBox;
            var inputString = currentInputBox.Text;

            time_password.Enabled = true;
            time_password.Stop();
            time_password.Start();
            if (flag == 0)
            {
                // Adds the new letter to the global variable currentPassword and then masks the original text box used
                if (inputString.Length > currentPassword.Length)
                {
                    var newChar = inputString.Substring(inputString.Length - 1);
                    currentPassword += newChar;
                    var newBoxText = "";

                    for (int i = 0; i < currentPassword.Length - 1; i++)
                    {
                        newBoxText += "*";
                    }
                    newBoxText += newChar;
                    currentInputBox.Text = newBoxText;
                    txt_password.SelectionStart = txt_password.Text.Count();

                }
                else if ((inputString.Length < currentPassword.Length) && (inputString.Length > -1)) // Removes characters from the currentPassword field til it matches the length of the textbox field and then exposes a single character at the end
                {
                    currentPassword = currentPassword.Remove(inputString.Length, currentPassword.Length - inputString.Length);
                    var newBoxText = "";
                    for (int i = 0; i < currentPassword.Length; i++)
                    {
                        newBoxText += "*";
                    }
                    currentInputBox.Text = newBoxText;
                    txt_password.SelectionStart = txt_password.Text.Count();

                }
            }
        }

        /// <summary>
        /// This fonction connects the user to the application and send him to the HomePage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_connection_Click(object sender, EventArgs e)
        {
            int idUser = 0;
            string user = txt_user.Text;
            string password = currentPassword;
            bool loginSuccess = false;
            bool flagDbError = false;

            if (string.IsNullOrEmpty(txt_user.Text) || string.IsNullOrEmpty(txt_password.Text))
            {
                MessageBox.Show("les champs sont vides", "Erreur dans le formulaire", MessageBoxButtons.OK);

            }
            else
            {
                try
                {

                    this.activeUser = new User(idUser, user, password);
                    loginSuccess = this.activeUser.Login(user, password);

                }

                catch (DbError)
                {
                    MessageBox.Show("Du à un problème avec notre serveur, vos données sont actuellement limitées voir indisponibles", "Problème de connexion");
                    flagDbError = true;
                }

                if (loginSuccess == false && flagDbError == false)
                {
                    MessageBox.Show("l'addresse email ne correpond pas avec le mot de passe ou n'existe pas", "Erreur d'authentification");
                }

                if (loginSuccess == true)
                {
                    this.Close();
                    th = new Thread(OpenFormApp);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
            }
        }
        /// <summary>
        /// This function creates the interval of the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void time_password_Tick(object sender, EventArgs e)
        {
            time_password.Interval = 1000;
            if (flag == 0)
            {
                string text = "";
                for (int i = 0; i < txt_password.Text.Count(); i++)
                {
                    text = text + "*";
                }
                txt_password.Text = text;
                time_password.Enabled = false;
                txt_password.SelectionStart = txt_password.Text.Count();
            }
        }
        /// <summary>
        /// This function closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_leave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
