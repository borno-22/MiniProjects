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
    public partial class FormForgotPass1 : Form
    {
        public FormForgotPass1()
        {
            InitializeComponent();
        }

        //
        //check if email and phone match or not
        //
        private void btnResetPass_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string phone = txtPhone.Text;

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select * from Users where uEmail='{email}' and uContact='{phone}'";

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                if (dt.Rows.Count != 1)
                {
                    MessageBox.Show("Invalid email or phone number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ApplicationHelper.UserID = dt.Rows[0]["uID"].ToString();

                FormForgotPass2 fp2 = new FormForgotPass2();
                fp2.Show();
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
