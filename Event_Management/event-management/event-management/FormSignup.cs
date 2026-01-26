using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace event_management
{
    public partial class FormSignup : Form
    {
        public FormSignup()
        {
            InitializeComponent();
        }

        //
        //return to previous form
        //
        private void FormSignup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
        }

        //
        //btn signUp
        //
        private void btnSignup_Click(object sender, EventArgs e)
        {
            this.SignUp();
        }

        //
        //btn SignUp click trigger
        //
        private void SignUp()
        {
            string role = "Client";
            string fullname = txtFname.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            string password = txtPassword.Text;


            if (fullname == "" || email == "" || phone == "" || address=="" || password == "")
            {
                MessageBox.Show("Please fill in all the fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"insert into Users (uName,uEmail,uRole,uContact,uAddress,uPass) values('{fullname}','{email}','{role}','{phone}','{address}','{password}')";
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Sign up successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (this.Owner != null)
                {
                    this.Owner.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //
        //return to login page
        //
        private void lblLogin_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
            this.Close();
        }

        //
        //click to show pass
        //
        private void btnHidden_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
            btnHidden.Visible = false;
            btnEye.Visible = true;

        }

        //
        //clickk to hide pass
        //
        private void btnEye_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            btnEye.Visible = false;
            btnHidden.Visible = true;
        }

    }
}
