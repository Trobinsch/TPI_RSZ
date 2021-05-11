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
    public partial class frm_HomePage : Form
    {
        public User activeUser;
        public Account activeAccount;
        public PaymentManager payment;
        public frm_HomePage()
        {

            InitializeComponent();
        }

        private void frm_HomePage_Load(object sender, EventArgs e)
        {
            frm_Versement frm = new frm_Versement(payment, activeAccount);

            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                payment = frm.ActivePayment;
            }
        }
    }
}
