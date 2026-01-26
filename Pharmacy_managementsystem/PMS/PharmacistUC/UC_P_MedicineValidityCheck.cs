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
    public partial class UC_P_MedicineValidityCheck : UserControl
    {

        function fn = new function();
        String query;

        public UC_P_MedicineValidityCheck()
        {
            InitializeComponent();
        }

        private void txtCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtCheck.SelectedIndex == 0)
            {
                query = "select * from medic where edate >= getdate()";
                DataSet ds = fn.getData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];
                setLabel.Text = "Valid Medicines";
                setLabel.ForeColor = Color.Green;
            }
            else if(txtCheck.SelectedIndex == 1)
            {
                query = "select * from medic where edate <= getdate()";
                DataSet ds = fn.getData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];
                setLabel.Text = "Expired Medicines";
                setLabel.ForeColor = Color.Red;

            }
            else if (txtCheck.SelectedIndex == 2)
            {
                query = "select * from medic";
                DataSet ds = fn.getData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];
                setLabel.Text = "All Medicines";
                setLabel.ForeColor = Color.Black;
            }
        }

        private void UC_P_MedicineValidityCheck_Load(object sender, EventArgs e)
        {
            setLabel.Text = "";
        }
    }
}
