using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMS.PharmacistUC
{
    public partial class UC_P_AddMedicine : UserControl
    {

        function fn = new function();
        String query;

        public UC_P_AddMedicine()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMediId.Text!= ""&& txtmediName.Text!="" && txtMediNumber.Text!="" && txtQuantity.Text!= "" && txtPricePerUnit.Text!="") 
            { 
                String mid = txtMediId.Text;
                String mname = txtmediName.Text;
                String mnumber = txtMediNumber.Text;
                String mdate = txtManufacturingDate.Text;
                String edate = txtExpireDate.Text;
                Int64 quantity = Int64.Parse(txtQuantity.Text);
                Int64 perUnit = Int64.Parse(txtPricePerUnit.Text);

                query = "insert into medic (mid,mname,mnumber,mDate,eDate,quantity,perUnit) values('" + mid + "','" + mname + "','" + mnumber + "','" + mdate + "','" + edate + "'," + quantity + "," + perUnit + ")";
                fn.setData(query, "Medicine Added Successfully.");
                clearAll();
            }
            else
            {
                MessageBox.Show("Please Fill All The Fields.","Information",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        public void clearAll()
        {
            txtMediId.Clear();
            txtmediName.Clear();
            txtQuantity.Clear();
            txtMediNumber.Clear();
            txtPricePerUnit.Clear();
            txtManufacturingDate.ResetText();
            txtExpireDate.ResetText();
        }
    }
}
