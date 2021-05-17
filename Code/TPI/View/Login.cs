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

namespace View
{
    public partial class Login : Form
    {
        private User activeUser;
        public Login()
        {
            InitializeComponent();
            string Username = "paul";
            string Password = "1234";
            this.activeUser = new User(Username,Password);
        }
    }
}
