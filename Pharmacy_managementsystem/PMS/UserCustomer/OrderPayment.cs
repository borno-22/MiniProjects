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
    public partial class OrderPayment : Form
    {
        public OrderPayment()
        {
            InitializeComponent();
        }

        private void OrderPayment_Load(object sender, EventArgs e)
        {
            txtAmount.Text = ApplicationHelper.TotalPrice;
            if(ApplicationHelper.orderID != "")
            {
                btnPayLater.Enabled = false;
                btnPayLater.Visible = false;
            }
            else
            {
                btnPayLater.Enabled = true;
                btnPayLater.Visible = true;
            }
        }


        string productID = ApplicationHelper.ProductID;
        string productName = ApplicationHelper.Mname;
        string unit = ApplicationHelper.unit;
        string totalAmount = ApplicationHelper.TotalPrice;
        string userID = ApplicationHelper.UserID;



        private void btnPayNow_Click(object sender, EventArgs e)
        {
            this.PayNow();
        }

        private void PayNow()
        {
            string query = "";
            string method = cmbMethod.Text;
            if (method == "")
            {
                MessageBox.Show("Please select a payment method.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ApplicationHelper.orderID != "")
            {
                query = $"UPDATE orders SET paid = '{totalAmount}',pending='0', status = 'Paid', method='{method}' WHERE orderID = '{ApplicationHelper.orderID}'";
            }
            else
            {
                query = $"insert into orders (productID,productName,totalUnit,totalAmount,UserID,paid,pending,method,status) values('{productID}','{productName}','{unit}','{totalAmount}','{userID}','{totalAmount}','0','{method}','Paid'); " +
                        $"UPDATE medic SET quantity = quantity - {int.Parse(unit)} WHERE id = '{productID}'";
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

                    MessageBox.Show("Payment successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            ApplicationHelper.orderID = "";
            this.Close();
        }



        private void btnPayLater_Click(object sender, EventArgs e)
        {
            this.PayLater();
        }

        private void PayLater()
        {
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"insert into orders (productID,productName,totalUnit,totalAmount,UserID,paid,pending,method,status) values('{productID}','{productName}','{unit}','{totalAmount}','{userID}','0','{totalAmount}','Cash','Unpaid'); " +
                                     $"UPDATE medic SET quantity = quantity - {int.Parse(unit)} WHERE id = '{productID}'";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Payment pending!", "Pending", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
        }

        private void OrderPayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
            ApplicationHelper.orderID = "";
        }
    }
}
