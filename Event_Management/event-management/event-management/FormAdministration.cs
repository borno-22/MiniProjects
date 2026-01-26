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
    public partial class FormAdministration : Form
    {
        public FormAdministration()
        {
            InitializeComponent();
        }

        //
        //go to previous page
        //
        private void FormAdministration_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
        }

        //
        //role based dashboard load
        //
        private void FormAdministrator_Load(object sender, EventArgs e)
        {
            lblFullname.Text = $"{ApplicationHelper.FullName}";
            lblUserType.Text = $"{ApplicationHelper.UserType}";
            this.LoadData();
            this.empRestriction();
        }

        //
        //restriction for employee
        //
        private void empRestriction()
        {
            if (ApplicationHelper.UserType != "Admin")
            {
                btnVenueMG.Visible = false;
                btnEmployeeMG.Visible = false;
                pnlEmp.Visible = false;
                pnlRevenue.Visible = false;
                pnlPending.Visible = false;
            }
        }

        //
        //all the labels info --counting
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
                cmd.CommandText = $"select count(*) 'Employee' from Users where uRole <> 'Client';\r\n" +
                    $"select count(*) 'Client' from Users where uRole = 'Client';\r\n" +
                    $"select count(*) 'TEvent' from Events;\r\n" +
                    $"select count(*) 'TVenue' from Venues;\r\n" +
                    $"select sum(biAmount) 'Revenue' from Bills where biStatus ='Paid';\r\n" +
                    $"select sum(biAmount) 'Pending' from Bills where biStatus = 'Pending';\r\n" +
                    $"select count(*) 'Book' from Booking where cast(CreateAt as DATE) = cast(GETDATE() as DATE);\r\n" +
                    $"select count(*) 'Pbook' from Booking where bStatus = 'Pending';\r\n" +
                    $"select count(*) 'Cbook' from Booking where bStatus = 'Cancelled'; \r\n" +
                    $"select count(*) 'Paid' from Bills where biStatus = 'Paid';\r\n" +
                    $"select count(*) 'Unpaid' from Bills where biStatus = 'Pending';";

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                lblEmp.Text = ds.Tables[0].Rows[0][0].ToString();
                lblClient.Text = ds.Tables[1].Rows[0][0].ToString();
                lblTEvent.Text = ds.Tables[2].Rows[0][0].ToString();
                lblTVenue.Text = ds.Tables[3].Rows[0][0].ToString();
                lblRevenue.Text = ds.Tables[4].Rows[0][0].ToString();
                lblPending.Text = ds.Tables[5].Rows[0][0].ToString();
                lblBook.Text = ds.Tables[6].Rows[0][0].ToString();
                lblPbook.Text = ds.Tables[7].Rows[0][0].ToString();
                lblCbook.Text = ds.Tables[8].Rows[0][0].ToString();
                lblPaidCount.Text = $"Total Revenue ({ds.Tables[9].Rows[0][0].ToString()})";
                lblPendingCount.Text = $"Pending Payment ({ds.Tables[10].Rows[0][0].ToString()})";

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //
        //btn refresh
        //
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        //
        //all the management --below
        //
        private void btnClientMG_Click(object sender, EventArgs e)
        {
            FormClientMG cs = new FormClientMG();
            cs.ShowDialog();
        }

        private void btnBookingMG_Click(object sender, EventArgs e)
        {
            FormBookingMG bk = new FormBookingMG();
            bk.ShowDialog();
        }

        private void btnBillingMG_Click(object sender, EventArgs e)
        {
            FormBillingMG bl = new FormBillingMG();
            bl.ShowDialog();
        }

        private void btnEventTypeMG_Click(object sender, EventArgs e)
        {
            FormEventType et = new FormEventType();
            et.ShowDialog();
        }

        private void btnVenueMG_Click(object sender, EventArgs e)
        {
            FormVenueMG rmt = new FormVenueMG();
            rmt.ShowDialog();
        }

        private void btnEmployeeMG_Click(object sender, EventArgs e)
        {
            FormEmployeeMG em = new FormEmployeeMG();
            em.ShowDialog();
        }

        //
        //go to settings
        //
        private void btnSettings_Click(object sender, EventArgs e)
        {
            FormSetting setting = new FormSetting();
            setting.ShowDialog();
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

    }
}
