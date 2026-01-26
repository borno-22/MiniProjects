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
    public partial class FormForgotPass2 : Form
    {
        public FormForgotPass2()
        {
            InitializeComponent();
        }

        //
        //enter new password
        //
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string pass = txtPass.Text;
            string rpass = txtRePass.Text;

            if (pass != rpass || pass == "" || rpass == "")
            {
                MessageBox.Show("Please enter a valid password.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"update Users set uPass='{pass}' where uID='{ApplicationHelper.UserID}'";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //
        //show pass
        private void ckbShowpass_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = false;
            txtRePass.UseSystemPasswordChar = false;
            timerShowPass.Start();
        }

        //
        //timer
        private void timerShowPass_Tick(object sender, EventArgs e)
        {
            ckbShowpass.Checked = false;
            txtPass.UseSystemPasswordChar = true;
            txtRePass.UseSystemPasswordChar = true;
            timerShowPass.Stop();
        }
    }
}
