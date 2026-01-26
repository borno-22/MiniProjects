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
    public partial class LogIn : Form
    {
        function fn = new function();
        String query;
        DataSet ds;

        public LogIn()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();  
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            query = "Select * from users";
            ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count == 0)
            {
                if (txtUsername.Text == "root" && txtPassword.Text == "root")
                {
                    Admin admin = new Admin();
                    admin.Show();
                    this.Hide();
                }
            }
            else
            {
                query = "SELECT * FROM users WHERE username = '" + txtUsername.Text +"' COLLATE Latin1_General_CS_AS AND pass = '" + txtPassword.Text +"' COLLATE Latin1_General_CS_AS";

                ds = fn.getData(query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    String role = ds.Tables[0].Rows[0][1].ToString();
                    if (role == "Administrator")
                    {
                        Admin admin = new Admin(txtUsername.Text);
                        admin.Show();
                        this.Hide();
                    }
                    else if (role == "Pharmacist")
                    {
                        Pharmacist pharm = new Pharmacist();
                        pharm.Show();
                        this.Hide();
                    }
                    else if (role == "Customer")
                    {
                        ApplicationHelper.UserID = ds.Tables[0].Rows[0]["id"].ToString();
                        ApplicationHelper.FullName = ds.Tables[0].Rows[0]["name"].ToString();
                        UserCustomer.CusDashboard cus = new UserCustomer.CusDashboard();
                        cus.Show(this);
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show(" :( Wrong Username or Password. Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }




            //if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
            //{
            //    Admin am = new Admin();
            //    am.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("Why Man? Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            CUsSignUP fsign = new CUsSignUP();
            fsign.Show(this);
            this.Hide();
        }
    }
}
