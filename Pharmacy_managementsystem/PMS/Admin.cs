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
    public partial class Admin : Form
    {
        String user = "";
        public Admin()
        {
            InitializeComponent();
        }

        public string ID
        {
            get { return user.ToString(); }
        }

        public Admin(String username)
        {
            InitializeComponent();
            userNameLabel.Text = username;
            user = username;
            uC_ViewUser1.ID = ID;
            uC_Profile1.ID = ID;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LogIn fm = new LogIn();
            fm.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            uC_Dashboard1.Visible = true;
            uC_Dashboard1.BringToFront();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            uC_Dashboard1.Visible = false;
            uC_AddUser1.Visible=false;
            uC_ViewUser1.Visible = false;
            uC_Profile1.Visible = false;
            btnDashboard.PerformClick();
        }

        private void uC_Dashboard1_Load(object sender, EventArgs e)
        {

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            uC_AddUser1.Visible = true;
            uC_AddUser1.BringToFront();
        }

        private void uC_AddUser1_Load(object sender, EventArgs e)
        {

        }

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            uC_ViewUser1.Visible = true;
            uC_ViewUser1.BringToFront();

        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            uC_Profile1.Visible = true;
            uC_Profile1.BringToFront();
        }
    }
}
