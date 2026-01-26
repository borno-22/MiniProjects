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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace event_management
{
    public partial class FormBookingMG : Form
    {
        public FormBookingMG()
        {
            InitializeComponent();
        }

        //
        // Booking form load
        //
        private void FormBookingMG_Load(object sender, EventArgs e)
        {
            this.LoadBookingData();
            this.defProperties();
        }


        //
        // set some default properties
        //
        private void defProperties()
        {
            txtID.Enabled = false;
            txtCID.Enabled = false;
            txtCname.Enabled = false;
            txtPhone.Enabled = false;
            btnSearchPhone.Enabled = false;
            dateEvent.Enabled = false;
            cmbType.Enabled = false;
            btnSearchVenue.Enabled = false;
            cmbVenue.Enabled = false;
            cmbStatus.Enabled = false;

            txtID.Text = "Auto Generate";
            txtCID.Text = "";
            txtCname.Text = "";
            txtPhone.Text = "";
            txtCapacity.Text = "";
            txtAmount.Text = "";

            dateEvent.Value = DateTime.Today;

            cmbType.SelectedIndex = -1;
            cmbVenue.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
        }


        //
        // Refresh btn load
        //
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadBookingData();
            this.defProperties();
        }


        //
        // Load dgv + cmb
        //
        private void LoadBookingData()
        {
            ApplicationHelper.BookingStaus = "";
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText =
                     $"select Booking.bID, Users.uName, Users.uContact, " +
                     $"Events.eID, Events.eType, Venues.vName, " +
                     $"Booking.bEventDate, Booking.bTotalAmount, " +
                     $"Booking.bStatus, Booking.CreateAt,Users.uID, Venues.vID,Venues.vCapacity " +
                     $"from Booking inner join Users on Booking.buID=Users.uID " +
                     $"inner join Events on Booking.beID=Events.eID " +
                     $"inner join Venues on Booking.bvID=Venues.vID ;" +
                     $"select * from Events; " +
                     $"select * from Venues";

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                dgvBooking.AutoGenerateColumns = false;
                dgvBooking.DataSource = ds.Tables[0];
                dgvBooking.Refresh();
                dgvBooking.ClearSelection();

                cmbType.DataSource = ds.Tables[1];
                cmbType.DisplayMember = "eType";
                cmbType.ValueMember = "eID";

                cmbVenue.DataSource = ds.Tables[2];
                cmbVenue.DisplayMember = "vName";
                cmbVenue.ValueMember = "vID";

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //
        // dgv click
        //
        private void dgvBooking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.defProperties();

            if (e.RowIndex < 0)
                return;

            txtID.Text = dgvBooking.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtCID.Text = dgvBooking.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtCname.Text = dgvBooking.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPhone.Text = dgvBooking.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbType.SelectedValue = dgvBooking.Rows[e.RowIndex].Cells[3].Value.ToString();
            cmbVenue.SelectedValue = dgvBooking.Rows[e.RowIndex].Cells[11].Value.ToString();
            dateEvent.Value = Convert.ToDateTime(dgvBooking.Rows[e.RowIndex].Cells[6].Value);
            txtAmount.Text = dgvBooking.Rows[e.RowIndex].Cells[7].Value.ToString();
            cmbStatus.Text = dgvBooking.Rows[e.RowIndex].Cells[8].Value.ToString();
        }


        //
        // new btn
        //
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.NewData();
        }


        //
        // new btn click trigger
        //
        private void NewData()
        {
            dgvBooking.ClearSelection();

            txtID.Text = "Auto Generate";
            txtCID.Text = "";
            txtCname.Text = "";
            txtPhone.Text = "";
            dateEvent.Value = DateTime.Today;
            cmbType.SelectedIndex = -1;
            cmbVenue.SelectedIndex = -1;
            txtCapacity.Text = "";
            txtAmount.Text = "";
            cmbStatus.SelectedIndex = -1;

            txtPhone.Enabled = true;
            btnSearchPhone.Enabled = true;
            dateEvent.Enabled = true;
            cmbType.Enabled = true;
            cmbVenue.Enabled = true;
            btnSearchVenue.Enabled = true;
            btnSave.Enabled = true;
        }


        //
        // Search guest for new booking
        //
        private void btnSearchPhone_Click(object sender, EventArgs e)
        {
            try
            {
                string phone = txtPhone.Text;

                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select uID, uName from Users where uContact='{phone}'";

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                if (dt.Rows.Count != 1)
                {
                    MessageBox.Show("Client not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                txtCID.Text = dt.Rows[0]["uID"].ToString();
                txtCname.Text = dt.Rows[0]["uName"].ToString();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        //
        // change venue cmb--- when eventType change 
        //
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbVenue.SelectedIndex = -1;
            cmbVenue.Enabled = false;
            cmbVenue.DataSource = null;
            txtAmount.Text = "";
            txtAmount.Enabled = false;
            txtCapacity.Text = "";
        }


        //
        //btn venue search
        //
        private void btnSearchVenue_Click(object sender, EventArgs e)
        {
            this.LoadAvailableVenue();
            cmbVenue.SelectedIndex = -1;
        }


        //
        //find available venue
        //
        private void LoadAvailableVenue()
        {
            string date = dateEvent.Value.ToString("yyyy-MMM-dd");
            string client = txtCID.Text;

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select vID, vName from Venues where vID NOT IN (select bvID from Booking where bStatus IN ('Confirmed') and (bEventDate = '{date}') and (buID<>'{client}'))";

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
                cmbStatus.Enabled = true;

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

               // int capacity = Convert.ToInt32(ds.Tables[0].Rows[0]["vCapacity"]);
                decimal basePrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["vBasePrice"]);
                decimal eventPrice = Convert.ToDecimal(ds.Tables[1].Rows[0]["ePrice"]);

                //txtCapacity.Text = capacity.ToString();
                txtCapacity.Text = ds.Tables[0].Rows[0]["vCapacity"].ToString();
                txtAmount.Text = (basePrice + eventPrice).ToString();

                ApplicationHelper.Amount = txtAmount.Text;

                con.Close();
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            if (id == "Auto Generate")
            {
                MessageBox.Show("Please select a row first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dateEvent.Enabled = true;
            cmbType.Enabled = true;
            btnSearchVenue.Enabled = true;
            cmbStatus.Enabled = true;
            btnSave.Enabled = true;
        }


        //
        // save btn
        //
        private void btnSave_Click(object sender, EventArgs e)  //save done
        {
            this.Save();
            this.LoadBookingData();
            this.defProperties();
        }


        //
        //save btn click trigger
        //

        private void Save()
        {
            if (txtCID.Text == "" || cmbVenue.SelectedValue == null || cmbStatus.Text == "")
            {
                MessageBox.Show("Please fill in all the fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = txtID.Text;
            string clientID = txtCID.Text;
            string eType = cmbType.SelectedValue.ToString();
            string venue = cmbVenue.SelectedValue.ToString();
            string eDate = dateEvent.Value.ToString("yyyy-MM-dd");
            string amount= ApplicationHelper.Amount;
            string status = cmbStatus.Text;


            string query = "";

            if (id == "Auto Generate")

            {
                query = $"insert into Booking (buID,beID,bvID,bEventDate,bTotalAmount,bStatus) values ('{clientID}','{eType}','{venue}','{eDate}','{amount}','{status}') ";
            }
            else
            {
                query = $"update Booking set beID='{eType}', bvID='{venue}', bEventDate='{eDate}',bTotalAmount='{amount}', bStatus='{status}'  Where bID='{id}'";
            }

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                if (id == "Auto Generate")
                {
                    cmd.CommandText = $"select bID from Booking where buID='{clientID}' and bvID='{venue}' and bEventDate='{eDate}'";
                    DataTable dt = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt);

                    ApplicationHelper.BookingID = dt.Rows[0][0].ToString();

                    FormClientBilling cusBilling = new FormClientBilling();
                    cusBilling.ShowDialog();
                }
                else
                {
                    cmd.CommandText = $"select biStatus from Bills where bbiID='{id}'";
                    DataTable dt = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt);

                    if (dt.Rows[0][0].ToString() == "Pending")
                    {
                        ApplicationHelper.BookingID = id;
                        ApplicationHelper.Amount = txtAmount.Text;
                        FormClientBilling cusBilling = new FormClientBilling();
                        cusBilling.ShowDialog();
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
