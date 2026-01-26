using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMS
{
    public partial class FrmCustomerInfo : Form
    {
        public string CustomerName { get; private set; }
        public string CustomerPhone { get; private set; }
        public string CustomerEmail { get; private set; }


        public FrmCustomerInfo()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            CustomerName = txtName.Text;
            CustomerPhone = txtPhone.Text;
            CustomerEmail = txtEmail.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
