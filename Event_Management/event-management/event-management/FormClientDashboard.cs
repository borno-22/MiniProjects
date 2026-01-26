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
    public partial class FormClientDashboard : Form
    {
        public FormClientDashboard()
        {
            InitializeComponent();
        }

        //
        //go to previous page
        //
        private void FormClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
        }

        //
        //customer dashboard
        //
        private void FormClient_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        //
        //btn refresh
        //
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        //
        //load all the labels
        //
        private void LoadData()
        {
            string fullname = ApplicationHelper.FullName;
            lblGreeting.Text = $"It's pleasure to see you again, {fullname}";

            string id = ApplicationHelper.UserID;

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select count(*) 'Tbook' from Booking where Booking.buID='{id}' and bStatus not in ('Pending', 'Cancelled'); \r\n" +
                    $"select count(*) 'Pbook' from Booking where Booking.buid = {id} and bStatus = 'Pending'; \r\n" +
                    $"select sum(biAmount) 'Spending' from Bills inner join Booking on Booking.bID = Bills.bbiID where Booking.buID = {id} and Bills.biStatus = 'Paid'; \r\n" +
                    $"select sum(biAmount) 'Unpaid' from Bills inner join Booking on Booking.bID = Bills.bbiID where Booking.buID = {id} and Bills.biStatus = 'Pending';";

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                lblTbook.Text = ds.Tables[0].Rows[0][0].ToString();
                lblPbook.Text = ds.Tables[1].Rows[0][0].ToString();
                lblSpending.Text = ds.Tables[2].Rows[0][0].ToString();
                lblUnpaid.Text = ds.Tables[3].Rows[0][0].ToString();

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //
        //go to new booking
        //
        private void btnBooking_Click(object sender, EventArgs e)
        {
            FormClientBooking cusBooking = new FormClientBooking();
            cusBooking.Show(this);
            this.Hide();
        }

        //
        //go to customer history
        //
        private void btnHistory_Click(object sender, EventArgs e)
        {
            FormClientHistory cusHistory = new FormClientHistory();
            cusHistory.Show(this);
            this.Hide();
        }

        //
        //logout
        //
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
                this.Close();
            }
        }

        //
        //settings
        //
        private void btnSettings_Click(object sender, EventArgs e)
        {
            FormSetting setting = new FormSetting();
            setting.ShowDialog();
        }

    }
}
