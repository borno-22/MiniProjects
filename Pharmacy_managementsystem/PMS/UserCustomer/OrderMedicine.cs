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
    public partial class OrderMedicine : Form
    {
        public OrderMedicine()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            txtProductID.Text = ApplicationHelper.ProductID;
            txtMname.Text = ApplicationHelper.Mname;
            txtQuan.Text = ApplicationHelper.Quantity;
            txtTAmount.Text = ApplicationHelper.Price;
        }

        private void OrderMedicine_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void txtUnit_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtUnit.Text, out int unit) || unit==0)
            {
                txtTAmount.Text = "0";
                btnPlaceOrder.Enabled = false;
                return;
            }
            else
            {
                btnPlaceOrder.Enabled = true;
            }
            
            int price = Convert.ToInt32(ApplicationHelper.Price);
            int total = unit * price;
            txtTAmount.Text= total.ToString();
        }



        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            this.Orderbtn();
        }

        private void Orderbtn()
        {
            ApplicationHelper.unit=txtUnit.Text;
            ApplicationHelper.TotalPrice=txtTAmount.Text;

            OrderPayment payment = new OrderPayment();
            payment.ShowDialog();
            this.Close();
        }

        private void OrderMedicine_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
        }
    }
}
