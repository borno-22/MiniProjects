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
    public partial class FormClientBooking : Form
    {
        public FormClientBooking()
        {
            InitializeComponent();
        }

        //
        //close customer booking
        //
        private void FormClientBooking_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
        }


        //
        //load Customer booking
        //
        private void FormClientBooking_Load(object sender, EventArgs e)
        {
            this.LoadEventType();
            this.defProperties();
        }


        //
        // available roomtype
        //
        private void LoadEventType()
        {
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select * from Events";

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                cmbType.DataSource = dt;
                cmbType.DisplayMember = "eType";
                cmbType.ValueMember = "eID";

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //
        // set some default properties
        //
        private void defProperties()
        {
            cmbVenue.Enabled = false;
            txtCapacity.Enabled = false;
            txtAmount.Enabled = false;

            cmbType.SelectedIndex = -1;
            cmbVenue.SelectedIndex = -1;
        }

        //
        //if roomtype change --- roomno will change
        //
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbVenue.SelectedIndex = -1;
            cmbVenue.Enabled = false;
        }


        //
        //btn search room
        //
        private void btnSearchVenue_Click(object sender, EventArgs e)
        {
            //this.LoadPrice();
            this.LoadAvailableVenue();
        }

        //
        //find available room
        //
        private void LoadAvailableVenue()
        {
            string date = dateEvent.Value.ToString("yyyy-MMM-dd");

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select vID, vName from Venues where vID NOT IN (select bvID from Booking where bStatus IN ('Confirmed') and (bEventDate = '{date}'))";

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No available venue.", "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                cmbVenue.DataSource = dt;
                cmbVenue.DisplayMember = "vName";
                cmbVenue.ValueMember = "vID";
                cmbVenue.Enabled = true;

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //
        //change venue trigger
        //
        private void cmbVenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadCapacityAmount();
        }


        //
        // find price & capacity
        //
        private void LoadCapacityAmount()
        {
            if (cmbVenue.SelectedValue == null || cmbType.SelectedValue == null)
            {
                return;
            }

            string venue = cmbVenue.SelectedValue.ToString();
            string eventType = cmbType.SelectedValue.ToString();

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select vCapacity, vBasePrice from Venues where vID=@venue;" +
                    "select ePrice from Events where eID=@eventType";

                cmd.Parameters.AddWithValue("@venue", venue);
                cmd.Parameters.AddWithValue("@eventType", eventType);

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                int capacity = Convert.ToInt32(ds.Tables[0].Rows[0]["vCapacity"]);
                decimal basePrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["vBasePrice"]);
                decimal eventPrice = Convert.ToDecimal(ds.Tables[1].Rows[0]["ePrice"]);

                txtCapacity.Text = capacity.ToString();
                txtAmount.Text = (basePrice + eventPrice).ToString();

                ApplicationHelper.Amount = txtAmount.Text;

                con.Close();
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }



        //
        //btn submit
        //
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.Submit();
        }

        //
        // btn submit trigger
        //
        private void Submit()
        {
            if (cmbVenue.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string clientID = ApplicationHelper.UserID;
            string eType = cmbType.SelectedValue.ToString();
            string venue = cmbVenue.SelectedValue.ToString();
            string eDate = dateEvent.Value.ToString("yyyy-MM-dd");
            string amount = ApplicationHelper.Amount;
            string status = "Pending";

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"insert into Booking (buID,beID,bvID,bEventDate,bTotalAmount,bStatus) values ('{clientID}','{eType}','{venue}','{eDate}','{amount}','{status}') ";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Booking request sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmd.CommandText = $"select Booking.bID from Booking where buID='{clientID}' and beID='{eType}' and bvID='{venue}' and bEventDate='{eDate}'";
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                ApplicationHelper.BookingID = dt.Rows[0][0].ToString();

                FormClientBilling cusBilling = new FormClientBilling();
                cusBilling.ShowDialog();
                this.Close();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
