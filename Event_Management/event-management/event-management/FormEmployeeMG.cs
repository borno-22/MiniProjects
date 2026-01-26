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

namespace event_management
{
    public partial class FormEmployeeMG : Form
    {
        public FormEmployeeMG()
        {
            InitializeComponent();
        }

        //
        // employee info form load
        //
        private void FormEmployeeMG_Load(object sender, EventArgs e)
        {
            this.LoadData();
            this.defProperties();
        }

        //
        // loading dgv+cmb
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
                cmd.CommandText = $"select * from Users where uRole<>'Client'";

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                dgvEmployee.AutoGenerateColumns = false;
                dgvEmployee.DataSource = dt;
                dgvEmployee.Refresh();
                dgvEmployee.ClearSelection();

                cmbRole.SelectedIndex = -1;

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //
        //some default properties
        //
        private void defProperties()
        {
            txtFname.Enabled = false;
            txtEmail.Enabled = false;
            txtPhone.Enabled = false;
            txtAddress.Enabled = false;
            cmbRole.Enabled = false;
            cmbRole.SelectedIndex = -1;
        }

        //
        // grid veiw click
        //
        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.defProperties();

            if (e.RowIndex < 0)
                return;

            txtID.Text = dgvEmployee.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtFname.Text = dgvEmployee.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbRole.Text = dgvEmployee.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvEmployee.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPhone.Text = dgvEmployee.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtAddress.Text = dgvEmployee.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        //
        //new btn
        //
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.NewData();
        }

        //
        //new btn click trigger
        //
        private void NewData()
        {
            txtID.Text = "Auto Generate";
            txtFname.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            cmbRole.SelectedIndex = -1;

            txtFname.Enabled = true;
            txtEmail.Enabled = true;
            txtPhone.Enabled = true;
            txtAddress.Enabled = true;
            cmbRole.Enabled = true;

            dgvEmployee.ClearSelection();
        }

        //
        // update btn click trigger
        //
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            if (id == "Auto Generate")
            {
                MessageBox.Show("Please select a row first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtFname.Enabled = true;
            txtPhone.Enabled = true;
            txtAddress.Enabled = true;
            cmbRole.Enabled = true;
        }

        //
        // btn delete
        //
        private void btnDel_Click(object sender, EventArgs e)
        {
            this.Delete();
            this.LoadData();
            this.defProperties();
        }

        //
        // btn delete click trigger
        //
        private void Delete()
        {
            string id = txtID.Text;
            if (id == "Auto Generate")
            {
                MessageBox.Show("Please select a row first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.connectionPath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"delete from UserInfo where UserID='{id}'";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //
        // btn save
        //
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
            this.LoadData();
            this.defProperties();
        }

        //
        //save function for both new+update
        //
        private void Save()
        {
            string query = "";
            string id = txtID.Text;
            string fullname = txtFname.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            string password = txtPhone.Text;
            string role = cmbRole.Text;

            if (fullname == "" || email == "" || phone == "" || address == "" || role == "")
            {
                MessageBox.Show("Please fill in all the fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if (id == "Auto Generate")
            {
                query = $"insert into Users (uName,uEmail,uRole,uContact,uAddress,uPass) values ('{fullname}','{email}','{role}','{phone}','{address}','{password}') ";
            }
            else
            {
                query = $"update  Users set uName='{fullname}',uContact='{phone}', uRole='{role}', uAddress='{address}'  Where uID='{id}'";
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
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
