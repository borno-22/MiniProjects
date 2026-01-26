using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace event_management
{
    public partial class FormClientBilling : Form
    {
        public FormClientBilling()
        {
            InitializeComponent();
        }


        //
        // Load Customer Billing info
        //
        private void FormClientBilling_Load(object sender, EventArgs e)
        {
            txtBookingID.Text = ApplicationHelper.BookingID;
            txtAmount.Text = ApplicationHelper.Amount;
        }


        //
        //paynow
        //
        private void btnPayNow_Click(object sender, EventArgs e)
        {
            this.PayNow();
        }


        //
        // btn paynow click trigger
        //
        private void PayNow()
        {
            string bookingID = ApplicationHelper.BookingID;
            string amount = ApplicationHelper.Amount;
            string method = cmbMethod.Text;
            string status = "Paid";

            if (method == "")
            {
                MessageBox.Show("Please select a payment method.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"insert into Bills (bbiID,biAmount,biMethod,biStatus) values('{bookingID}','{amount}','{method}','{status}')";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Payment successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
        }


        //
        // btn paylater
        //
        private void btnPayLater_Click(object sender, EventArgs e)
        {
            this.PayLater();
        }

        //
        // btn paylater trigger
        //
        private void PayLater()
        {
            string bookingID = ApplicationHelper.BookingID;
            string amount = ApplicationHelper.Amount;
            string method = "Cash";
            string status = "Pending";

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"insert into Bills (bbiID,biAmount,biMethod,biStatus) values('{bookingID}','{amount}','{method}','{status}')";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Payment is pending.", "Pending", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
        }
    }
}
