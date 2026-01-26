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

namespace PMS.UserCustomer
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }


        private void Settings_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        //
        //get current info
        //
        private void LoadData()
        {
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();


                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select * from Users where id='{ApplicationHelper.UserID}'";

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);


                txtID.Text = dt.Rows[0]["id"].ToString();
                txtFname.Text = dt.Rows[0]["name"].ToString();
                txtEmail.Text = dt.Rows[0]["email"].ToString();
                txtUsername.Text = dt.Rows[0]["username"].ToString();
                txtPhone.Text = dt.Rows[0]["mobile"].ToString();

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //
        //btn save---generalinfo
        //
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.generalInfo();
        }

        //
        // general info update
        //
        private void generalInfo()
        {
            string id = txtID.Text;
            string fullname = txtFname.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string username = txtUsername.Text;

            if (fullname == "" || phone == "" || email == "")
            {
                MessageBox.Show("Please fill in all required fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"update Users set name='{fullname}',mobile='{phone}', email='{email}' Where id='{id}'";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //
        //unable password section
        //
        private void ckbShowpass_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.Enabled = ckbShowpass.Checked;
            txtNewPass.Enabled = ckbShowpass.Checked;
            btnConfirm.Enabled = ckbShowpass.Checked;
        }

        //
        //btn confirm-- change pass
        //
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.securityInfo();
        }

        //
        //change password
        //
        private void securityInfo()
        {
            string id = txtID.Text;
            string pass = txtPass.Text;
            string npass = txtNewPass.Text;

            if (pass == "" || npass == "")
            {
                MessageBox.Show("Please enter a valid password.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (pass == npass)
            {
                MessageBox.Show("The new password cannot be the same as the current password.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select Password from Users where id='{id}'";

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                string dbPass = dt.Rows[0]["Password"].ToString();
                if (dbPass != pass)
                {
                    MessageBox.Show("Current password and new password do not match.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    con.Close();
                    return;
                }
                else
                {
                    cmd.CommandText = $"update Users set Password= '{npass}' where UserID='{id}'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
        }
    }
}
