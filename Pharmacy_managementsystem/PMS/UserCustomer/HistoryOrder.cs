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
    public partial class HistoryOrder : Form
    {
        public HistoryOrder()
        {
            InitializeComponent();
        }

        private void HistoryOrder_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

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
                cmd.CommandText = $"select * from orders where userID={id}";

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                dgvHistory.AutoGenerateColumns = false;
                dgvHistory.DataSource = dt;
                dgvHistory.Refresh();
                dgvHistory.ClearSelection();

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txtOrderID.Text = dgvHistory.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtStatus.Text = dgvHistory.Rows[e.RowIndex].Cells[4].Value.ToString();
            string amount= dgvHistory.Rows[e.RowIndex].Cells[3].Value.ToString();

            if (txtStatus.Text == "Unpaid")
            {
                pnlPay.Enabled = true;
                ApplicationHelper.orderID = txtOrderID.Text;
                ApplicationHelper.TotalPrice= amount;
            }
            else
            {
                pnlPay.Enabled = false;
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            OrderPayment payment = new OrderPayment();
            payment.ShowDialog();
            this.Close();
        }

        private void HistoryOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
        }
    }
}
