using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMS.AdminUC
{
    public partial class UC_AddUser : UserControl
    {


        function fn = new function();
        String query;

        public UC_AddUser()
        {
            InitializeComponent();
        }

        private void UC_AddUser_Load(object sender, EventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // 1️⃣ Check if any field is empty
            if (txtUserRole.Text == "" || txtName.Text == "" || txtDob.Text == "" || txtMobileNo.Text == "" || txtEmail.Text == "" || txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill all the details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop execution
            }

            // 2️⃣ Get input values
            string role = txtUserRole.Text;
            string name = txtName.Text;
            string dob = txtDob.Text;
            string email = txtEmail.Text;
            string username = txtUsername.Text;
            string pass = txtPassword.Text;

            // 3️⃣ Check mobile number is numeric
            if (!Int64.TryParse(txtMobileNo.Text, out long mobile))
            {
                MessageBox.Show("Mobile number must be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMobileNo.Clear();
                txtMobileNo.Focus();
                return;
            }

            try
            {
                // 4️⃣ Insert into database (your original style)
                query = "insert into users (userRole,name,dob,mobile,email,username,pass) " +
                        "values('" + role + "' , '" + name + "' , '" + dob + "' , " + mobile + " , '" + email + "' , '" + username + "' , '" + pass + "')";
                fn.setData(query, "Sign Up Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Username already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        public void clearAll()
        {
            txtName.Clear();
            txtDob.ResetText();
            txtMobileNo.Clear();
            txtEmail.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtUserRole.SelectedIndex = -1;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
