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

namespace PMS.UserCustomer
{
    public partial class BrowseCatalog : Form
    {
        public BrowseCatalog()
        {
            InitializeComponent();
        }

        private void BrowseCatalog_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void LoadData()
        {
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();


                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select * from medic";

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                dgvCatalog.AutoGenerateColumns = false;
                dgvCatalog.DataSource = dt;
                dgvCatalog.Refresh();
                dgvCatalog.ClearSelection();

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCatalog_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
                return;

            txtMname.Text = dgvCatalog.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPrice.Text = dgvCatalog.Rows[e.RowIndex].Cells[3].Value.ToString();


            ApplicationHelper.ProductID = dgvCatalog.Rows[e.RowIndex].Cells[0].Value.ToString();
            ApplicationHelper.Quantity = dgvCatalog.Rows[e.RowIndex].Cells[2].Value.ToString();
            ApplicationHelper.Mname = txtMname.Text;
            ApplicationHelper.Price = txtPrice.Text;
        }


        private void Search()
        {
            try
            {
                string phone = txtSearch.Text;

                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select * from medic where mname like '" + txtSearch.Text + "%'";

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                dgvCatalog.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnOrderNow_Click(object sender, EventArgs e)
        {
            OrderMedicine orderPage = new OrderMedicine();
            orderPage.Show(this);
            this.Hide();
        }

        private void BrowseCatalog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
    }
}
