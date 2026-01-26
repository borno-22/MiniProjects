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
    public partial class FormVenueMG : Form
    {
        public FormVenueMG()
        {
            InitializeComponent();
        }

        //
        //load form
        //
        private void FormVenueMG_Load(object sender, EventArgs e)

        {
            this.LoadVenue();
        }

        //
        //load dgv
        //
        private void LoadVenue()
        {
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Venues";

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                dgvVenue.AutoGenerateColumns = false;
                dgvVenue.DataSource = dt;
                dgvVenue.Refresh();
                dgvVenue.ClearSelection();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //
        //btn new
        //
        private void btnNew_Click(object sender, EventArgs e)

        {
            this.NewData();
            txtID.Enabled = false;
            txtName.Enabled = true;
            txtCapacity.Enabled = true;
            txtLocation.Enabled = true;
            txtPrice.Enabled = true;
        }

        //
        //btn new click trigger
        //
        private void NewData()
        {
            txtID.Text = "Auto Generate";
            txtName.Text = "";
            txtCapacity.Text = "";
            txtLocation.Text = "";
            txtPrice.Text = "";
            dgvVenue.ClearSelection();
            this.LoadVenue();
        }

        //
        //dgv cell click
        //
        private void dgvVenue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txtID.Text = dgvVenue.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dgvVenue.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCapacity.Text = dgvVenue.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtLocation.Text = dgvVenue.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPrice.Text = dgvVenue.Rows[e.RowIndex].Cells[4].Value.ToString();

            txtName.Enabled = false;
            txtCapacity.Enabled = false;
            txtLocation.Enabled = false;
            txtPrice.Enabled = false;
        }

        //
        //btn save click
        //
        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string name = txtName.Text;
            string capacity = txtCapacity.Text;
            string location = txtLocation.Text;
            string price = txtPrice.Text;
            string query = "";

            if (id == "Auto Generate")

            {
                query = $"insert into Venues values ('{name}','{capacity}','{location}','{price}') ";
            }
            else
            {
                query = $"update  Venues set  vName='{name}',vCapacity='{capacity}',vLocation='{location}',vBasePrice='{price}' Where vID='{id}'";
            }

            if (name == "" || capacity=="" || location == "" || price == "")
            {
                MessageBox.Show("please fill the input");
                return;
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
                this.LoadVenue();
                this.NewData();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //
        //btn update click
        //
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            txtPrice.Enabled = true;
            txtCapacity.Enabled = true;
            txtLocation.Enabled = true;

            string id = txtID.Text;
            if (id == "Auto Generate")
            {
                MessageBox.Show("Please select a row first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        //
        //btn delete clickk
        //
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
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
                cmd.CommandText = $"delete from Venues where vID={id}";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LoadVenue();
                this.NewData();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

