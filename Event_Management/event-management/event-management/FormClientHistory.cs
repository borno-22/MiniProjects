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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace event_management
{
    public partial class FormClientHistory : Form
    {
        public FormClientHistory()
        {
            InitializeComponent();
        }

        //
        //return to prevoius page
        //
        private void FormClientHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
        }

        //
        //load dgv
        //
        private void FormClientHistory_Load(object sender, EventArgs e)
        {
            this.LoadData();
            this.defProperties();
        }

        //
        //some default properties
        //
        private void defProperties()
        {
            pnlCancelBooking.Enabled = false;
            pnlBillPay.Enabled = false;
        }

        //
        //dgv + txt + cmb
        //
        private void LoadData()
        {
            string id = ApplicationHelper.UserID;

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select Booking.bID, Events.eType, Venues.vName, Booking.bEventDate, Booking.bStatus from Booking inner join Events on Booking.beID=Events.eID inner join Venues on Venues.vID=Booking.bvID inner join Users on Users.uID=Booking.buID  where Booking.buID='{id}' order by Booking.CreateAt desc; \r\n" +
                    $"select Bills.biID,Bills.bbiID,Bills.biAmount,Bills.biMethod,Bills.biStatus,Bills.GeneratedAt from Bills inner join Booking on Booking.bID=Bills.bbiID  where Booking.buID='{id}' order by Bills.GeneratedAt desc;";

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                dgvBooking.AutoGenerateColumns = false;
                dgvBooking.DataSource = ds.Tables[0];
                dgvBooking.Refresh();
                dgvBooking.ClearSelection();

                dgvPayment.AutoGenerateColumns = false;
                dgvPayment.DataSource = ds.Tables[1];
                dgvPayment.Refresh();
                dgvPayment.ClearSelection();

                cmbMethod.SelectedIndex = -1;

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //
        //booking dgv click
        //
        private void dgvBooking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txtBookingID.Text = dgvBooking.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtBookingStatus.Text = dgvBooking.Rows[e.RowIndex].Cells[4].Value.ToString();

            if (txtBookingStatus.Text == "Pending")
            {
                pnlCancelBooking.Enabled = true;
            }
            else
            {
                pnlCancelBooking.Enabled = false;
            }
        }

        //
        //cancel booking
        //
        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            string id = txtBookingID.Text;
            string status = "Cancelled";

            var result = MessageBox.Show("Are you sure you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"update  Booking set bStatus='{status}' where bID='{id}'";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Booking Cancelled");

                this.LoadData();
                this.defProperties();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //
        //payment dgv click
        //
        private void dgvPayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txtBillingID.Text = dgvPayment.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAmount.Text = dgvPayment.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtBillingStatus.Text = dgvPayment.Rows[e.RowIndex].Cells[4].Value.ToString();
            cmbMethod.Text = dgvPayment.Rows[e.RowIndex].Cells[3].Value.ToString();

            if (txtBillingStatus.Text == "Pending")
            {
                pnlBillPay.Enabled = true;
            }
            else
            {
                pnlBillPay.Enabled = false;
            }
        }

        //
        //btn pay now
        //
        private void btnPayNow_Click(object sender, EventArgs e)
        {
            if (cmbMethod.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a payment method.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            string id = txtBillingID.Text;
            string method = cmbMethod.Text;
            string status = "Paid";

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"update Bills set biMethod='{method}', biStatus='{status}' where biID='{id}'";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Payment successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.LoadData();
                this.defProperties();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
