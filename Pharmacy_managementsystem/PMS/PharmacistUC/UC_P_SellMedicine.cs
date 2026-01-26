using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMS.PharmacistUC
{
    public partial class UC_P_SellMedicine : UserControl
    {

        function fn = new function();
        String query;
        DataSet ds;

        public UC_P_SellMedicine()
        {
            InitializeComponent();
        }

        private void UC_P_SellMedicine_Load(object sender, EventArgs e)
        {

            listBoxMedicine.Items.Clear();

            query = "select mname from medic where eDate >= getdate() and quantity >'0'";
            ds = fn.getData(query);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBoxMedicine.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_P_SellMedicine_Load(this, null);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            listBoxMedicine.Items.Clear();
            query = "select mname from medic where mname like '" + txtSearch.Text + "%' and eDate >= getdate() and quantity >'0' ";
            ds = fn.getData(query);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBoxMedicine.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void listBoxMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNoOfUnits.Clear();

            String name = listBoxMedicine.GetItemText(listBoxMedicine.SelectedItem);

            txtMediName.Text = name;
            query = "select mid,eDate,perUnit from medic where mname = '" + name + "'";
            ds = fn.getData(query);
            txtMedicineid.Text = ds.Tables[0].Rows[0][0].ToString();
            txtEpireDate.Text = ds.Tables[0].Rows[0][1].ToString();
            txtPricePerUnit.Text = ds.Tables[0].Rows[0][2].ToString();
        }

        private void txtNoOfUnits_TextChanged(object sender, EventArgs e)
        {
            // If no medicine selected
            if (txtMedicineid.Text == "")
            {
                if (txtNoOfUnits.Text != "")
                {
                    MessageBox.Show(
                        "Please select a medicine first.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtNoOfUnits.Clear();
                    txtNoOfUnits.Focus();
                }
                return;
            }

            // If medicine selected, calculate total price
            if (txtNoOfUnits.Text != "")
            {
                Int64 unitPrice = Int64.Parse(txtPricePerUnit.Text);
                Int64 noOfUnits = Int64.Parse(txtNoOfUnits.Text);
                Int64 totalAmount = unitPrice * noOfUnits;
                txtTotalPrice.Text = totalAmount.ToString();
            }
            else
            {
                txtTotalPrice.Clear();
            }
        }


        protected int n, totalAmount = 0;
        protected Int64 quantity, newQuantity;

        private void btnAddToCard_Click(object sender, EventArgs e)
        {
            if (txtMedicineid.Text != "")
            {
                if (txtNoOfUnits.Text != "")
                {
                    query = "select quantity from medic where mid = '" + txtMedicineid.Text + "'";
                    ds = fn.getData(query);

                    quantity = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                    newQuantity = quantity - Int64.Parse(txtNoOfUnits.Text);

                    if (newQuantity >= 0)
                    {
                        n = guna2DataGridView1.Rows.Add();
                        guna2DataGridView1.Rows[n].Cells[0].Value = txtMedicineid.Text;
                        guna2DataGridView1.Rows[n].Cells[1].Value = txtMediName.Text;
                        guna2DataGridView1.Rows[n].Cells[2].Value = txtEpireDate.Text;
                        guna2DataGridView1.Rows[n].Cells[3].Value = txtPricePerUnit.Text;
                        guna2DataGridView1.Rows[n].Cells[4].Value = txtNoOfUnits.Text;
                        guna2DataGridView1.Rows[n].Cells[5].Value = txtTotalPrice.Text;

                        totalAmount = totalAmount + int.Parse(txtTotalPrice.Text);
                        totalLabel.Text = "Tk. " + totalAmount.ToString();

                        query = "update medic set quantity = '" + newQuantity + "' where mid = '" + txtMedicineid.Text + "'";
                        fn.setData(query, "Medicine Added To The Cart.👍");
                    }
                    else
                    {
                        MessageBox.Show("This Medicine Is Out Of Stock. \n Only " + quantity + " Left", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    clearAll();
                    UC_P_SellMedicine_Load(this, null); 
                }
                else
                {
                    MessageBox.Show("Please, Select How many You Want.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please, Select A Medicine First.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        int valueAmount;
        String valueId;
        protected Int64 noOfunit;

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                valueAmount = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                valueId = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                noOfunit = Int64.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            }
            catch (Exception)
            {

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(valueId != null)
            {
                try
                {
                    guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);
                }
                catch
                {

                }
                finally
                {
                    query = "select quantity from medic where mid = '" + valueId + "'";
                    ds = fn.getData(query);
                    quantity = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                    newQuantity = quantity + noOfunit;

                    query = "update medic set quantity = '" + newQuantity + "' where mid = '" + valueId + "'";
                    fn.setData(query, "Medicine Removed From The Cart.👍");
                    totalAmount = totalAmount - valueAmount;
                    totalLabel.Text = "Tk. " + totalAmount.ToString();
                }

                UC_P_SellMedicine_Load(this, null);
            }
            else
            {
                MessageBox.Show("Please, Select A Medicine First.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtNoOfUnits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //private void btnPurchasePrint_Click(object sender, EventArgs e)
        //{

        //    DGVPrinter printer = new DGVPrinter();
        //    printer.Title = "Medicine Bill";
        //    printer.SubTitle = String.Format("Date: {0}", DateTime.Now.Date.ToString("MM/dd/yyyy"));
        //    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
        //    printer.PageNumbers = true;
        //    printer.PageNumberInHeader = false;
        //    printer.PorportionalColumns = true;
        //    printer.HeaderCellAlignment = StringAlignment.Near;
        //    printer.Footer = "Total Amount: " + totalLabel.Text;
        //    printer.FooterSpacing = 15;
        //    printer.PrintDataGridView(guna2DataGridView1);

        //    totalAmount = 0;
        //    totalLabel.Text = "Tk. 0";
        //    guna2DataGridView1.DataSource = 0;
        //}

        private void btnPurchasePrint_Click(object sender, EventArgs e)
        {
            // Check if cart is empty
            if (guna2DataGridView1.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                MessageBox.Show("Please select medicine first!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Open customer info popup
            FrmCustomerInfo frm = new FrmCustomerInfo();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string billNo = "BILL-" + DateTime.Now.ToString("yyyyMMddHHmmss");

                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Medicine Bill";
                printer.SubTitle =
                    "Bill No: " + billNo + "\n" +
                    "Customer: " + frm.CustomerName + "\n" +
                    "Phone: " + frm.CustomerPhone + "\n" +
                    "Date: " + DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");

                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.Footer = "Total Amount: " + totalLabel.Text;
                printer.FooterSpacing = 15;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;

                // Print the bill
                printer.PrintDataGridView(guna2DataGridView1);

                // Reset cart
                totalAmount = 0;
                totalLabel.Text = "Tk. 0";
                guna2DataGridView1.Rows.Clear();
            }
        }






        private void clearAll()
        {
            txtMedicineid.Clear();
            txtMediName.Clear();
            txtEpireDate.ResetText();
            txtPricePerUnit.Clear();
            txtNoOfUnits.Clear();
        }
    }
}
