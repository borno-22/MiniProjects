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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        //
        //btn login click
        //
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string pass = txtPass.Text;

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select uID,uName,uRole from Users where uEmail='{email}' and uPass='{pass}'";

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                if (dt.Rows.Count != 1)
                {
                    MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string fullName = dt.Rows[0]["uName"].ToString();
                string userType = dt.Rows[0]["uRole"].ToString();
                string userID = dt.Rows[0]["uID"].ToString();

                ApplicationHelper.FullName = fullName;
                ApplicationHelper.UserType = userType;
                ApplicationHelper.UserID = userID;


                MessageBox.Show($"Welcome, {fullName}!", "Greetings", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (userType == "Client")
                {
                    FormClientDashboard fc = new FormClientDashboard();
                    fc.Show(this);
                    this.Hide();
                }
                else
                {
                    FormAdministration fa = new FormAdministration();
                    fa.Show(this);
                    this.Hide();
                }

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //
        //click to show password
        //
        private void btnShow_Click(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = false;
            timer1.Start();
            btnShow.Visible = false;
        }

        //
        //timer to automatically stop showing password after a certain time
        //
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
            timer1.Stop();
            btnShow.Visible = true;
        }

        //
        //go to sign up
        //
        private void lblSignUp_Click(object sender, EventArgs e)
        {
            FormSignup fsign = new FormSignup();
            fsign.Show(this);
            this.Hide();
        }

        //
        //go to forgot password
        //
        private void lblForgot1_Click(object sender, EventArgs e)
        {
            FormForgotPass1 fp1 = new FormForgotPass1();
            fp1.Show();
        }
    }
}
