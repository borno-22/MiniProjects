using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace event_management
{
    public partial class FormEventType : Form
    {
        public FormEventType()
        {
            InitializeComponent();
        }

        //
        //load the form
        //
        private void FormEventType_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        //
        //load dgv
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
                cmd.CommandText = "Select * from Events";

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                dgvEvent.AutoGenerateColumns = false;
                dgvEvent.DataSource = dt;
                dgvEvent.Refresh();
                dgvEvent.ClearSelection();

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
            this.LoadData();

            txtType.Enabled = true;
            txtPrice.Enabled = true;
            txtDesc.Enabled = true;
        }

        //
        //btn new click trigger
        //
        private void NewData()
        {
            txtID.Text = "Auto Generate";
            txtPrice.Text = "";
            txtType.Text = "";
            txtDesc.Text = "";
            dgvEvent.ClearSelection();
        }

        //
        // dgv cell click
        //
        private void dgvEvent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txtID.Text = dgvEvent.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtType.Text = dgvEvent.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPrice.Text = dgvEvent.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDesc.Text = dgvEvent.Rows[e.RowIndex].Cells[3].Value.ToString();

            txtType.Enabled = false;
            txtPrice.Enabled = false;
            txtDesc.Enabled = false;
        }

        //
        //btn delete click
        //
        private void btnDel_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            if (id == "Auto Generate")
            {
                MessageBox.Show("Please select a row first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
                cmd.CommandText = $"delete from Events where eID={id}";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LoadData();
                this.NewData();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //
        //btn save click
        //
        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string type = txtType.Text;
            string price = txtPrice.Text;
            string description = txtDesc.Text;
            string query = "";

            if (id == "Auto Generate")
            {
                query = $"insert into Events(eType,ePrice,eDesc) values ('{type}','{price}','{description}') ";
            }
            else
            {
                query = $"update Events set  eType='{type}',ePrice='{price}',eDesc='{description}'  Where eID={id}";
            }

            if (type == "" || price == "" || description == "")
            {
                MessageBox.Show("Please fill in all the fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                this.LoadData();
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
            txtType.Enabled = true;
            txtPrice.Enabled = true;
            txtDesc.Enabled = true;

            string id = txtID.Text;
            if (id == "Auto Generate")
            {
                MessageBox.Show("Please select a row first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

    }
}
