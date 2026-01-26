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
    public partial class UC_P_ViewMedicine : UserControl
    {
        function fn = new function();
        String query;

        public UC_P_ViewMedicine()
        {
            InitializeComponent();
        }

        private void UC_P_ViewMedicine_Load(object sender, EventArgs e)
        {
            query = "select * from medic";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            query = "select * from medic where mname like '" + txtSearch.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }


        String medicineId;


        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_P_ViewMedicine_Load(this, null);
        }

        private void btnSync_Click_1(object sender, EventArgs e)
        {
            UC_P_ViewMedicine_Load(this, null);
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure! You want to delete this medicine?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                query = "delete from medic where mid = '" + medicineId + "'";
                fn.setData(query, "Medicine Deleted Successfully.");
                UC_P_ViewMedicine_Load(this, null);
            }
        }

        String midcineId;

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                medicineId = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            }
            catch
            {

            }
        }
    }
}
