using System;
using System.Collections;
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
    public partial class FormBillingMG : Form
    {
        public FormBillingMG()
        {
            InitializeComponent();
        }

        //
        //Role based load
        //
        private void FormBillingMG_Load(object sender, EventArgs e)
        {
            this.defProperties();
            this.LoadBillingData();

            if (ApplicationHelper.UserType != "Admin")
                btnDel.Visible = false;
        }

        //
        //some default properties
        //
        private void defProperties()
        {
            txtID.Text = "Auto Generate";
            txtBookingID.Text = "";
            txtAmount.Text = "";
            cmbMethod.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;

            txtID.Enabled = false;
            txtBookingID.Enabled = true;
            btnSearchBkID.Enabled = true;
            txtAmount.Enabled = false;
            cmbMethod.Enabled = false;
            cmbStatus.Enabled = false;
            btnSave.Enabled = false;
        }

        //
        //load dgv
        //
        private void LoadBillingData()
        {
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select Bills.biID, Bills.bbiID, Users.uName, Users.uContact, Bills.biAmount, Bills.biMethod, Bills.biStatus, Bills.GeneratedAt from Bills inner join Booking on Bills.bbiID=Booking.bID inner join Users on Booking.buID=Users.uID;";

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                dgvBilling.AutoGenerateColumns = false;
                dgvBilling.DataSource = dt;
                dgvBilling.Refresh();
                dgvBilling.ClearSelection();

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
            this.LoadBillingData();
            this.defProperties();
        }

        //
        //dgv click
        //
        private void dgvBilling_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.defProperties();

            if (e.RowIndex < 0)
                return;

            txtID.Text = dgvBilling.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtBookingID.Text = dgvBilling.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtAmount.Text = dgvBilling.Rows[e.RowIndex].Cells[4].Value.ToString();
            cmbMethod.Text = dgvBilling.Rows[e.RowIndex].Cells[5].Value.ToString();
            cmbStatus.Text = dgvBilling.Rows[e.RowIndex].Cells[6].Value.ToString();

        }

        //
        //search total amount -- from booking id
        //
        private void btnSearchBkID_Click(object sender, EventArgs e)
        {
            try
            {
                string bookingID = txtBookingID.Text;
                txtBookingID.Enabled = false;

                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select * from Bills where bbiID='{bookingID}'";

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid Booking ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtID.Text = dt.Rows[0]["biID"].ToString();
                txtAmount.Text = dt.Rows[0]["biAmount"].ToString();
                cmbMethod.Text = dt.Rows[0]["biMethod"].ToString();
                cmbStatus.Text = dt.Rows[0]["biStatus"].ToString();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //
        //btn update click trigger
        //
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            if (id == "Auto Generate")
            {
                MessageBox.Show("Please select a row first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cmbMethod.Enabled = true;
            cmbStatus.Enabled = true;
            btnSave.Enabled = true;
        }

        //
        // btn save
        //
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
            this.LoadBillingData();
            this.defProperties();
        }

        //
        //btn save click trigger
        //
        private void Save()
        {
            string id = txtID.Text;
            string bookingID = txtBookingID.Text;
            string amount = txtAmount.Text;
            string method = cmbMethod.Text;
            string status = cmbStatus.Text;

            if (bookingID == "" || method == "" || status == "")
            {
                MessageBox.Show("Please fill in all the fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"update Bills set bbiID='{bookingID}', biAmount='{amount}', biMethod='{method}', biStatus='{status}'  Where biID='{id}'";

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
        // btn delete
        private void btnDel_Click(object sender, EventArgs e)
        {
            this.Delete();
            this.LoadBillingData();
            this.defProperties();
        }

        //
        //btn click trigger
        //
        private void Delete()
        {
            string id = txtID.Text;
            string bookingID = txtBookingID.Text;
            if (id == "Auto Generate")
            {
                MessageBox.Show("Please select a row first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"delete from Bills where biID='{id}' \r\n" +
                    $"delete from Booking where bbiID='{bookingID}'";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
