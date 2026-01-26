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

namespace PMS
{
    public partial class CUsSignUP : Form
    {
        public CUsSignUP()
        {
            InitializeComponent();
        }

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
            string role = "Customer";
            string fullname = txtFname.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (fullname == "" || email == "" || phone == "" || username == "" || password == "")
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
                cmd.CommandText = $"insert into Users  (userRole,name,mobile,email,username,pass)values('{role}','{fullname}','{phone}','{email}','{username}','{password}')";
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Sign up successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSignup_Click_1(object sender, EventArgs e)
        {
            this.SignUp();

            if (this.Owner != null)
            {
                this.Owner.Show();
                this.Close();
            }
        }


    }
}
