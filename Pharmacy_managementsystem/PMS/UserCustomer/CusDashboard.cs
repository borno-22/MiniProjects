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
using System.Xml;

namespace PMS.UserCustomer
{
    public partial class CusDashboard : Form
    {
        public CusDashboard()
        {
            InitializeComponent();
        }

        private void CusDashboard_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

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
                cmd.CommandText = $"select count(*) 'orderID' from orders where orders.UserID='{id}'; \r\n" +
                    $"select sum(totalUnit) 'Units' from orders where orders.UserID = '{id}'; \r\n" +
                    $"select sum(paid) 'Spending' from orders where orders.UserID = '{id}'; \r\n" +
                    $"select sum(pending) 'Unpaid' from orders where orders.UserID = '{id}';";

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                lblTorder.Text = ds.Tables[0].Rows[0][0].ToString();
                lblUorder.Text = ds.Tables[1].Rows[0][0].ToString();
                lblSpending.Text = ds.Tables[2].Rows[0][0].ToString();
                lblUnpaid.Text = ds.Tables[3].Rows[0][0].ToString();

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCatalog_Click(object sender, EventArgs e)
        {
            BrowseCatalog catalog = new BrowseCatalog();
            catalog.Show(this);
            this.Hide();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            HistoryOrder history = new HistoryOrder();
            history.Show(this);
            this.Hide();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings setting = new Settings();
            setting.ShowDialog();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }


        private void FormCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
        }
    }
}
