namespace PMS
{
    partial class Pharmacist
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pharmacist));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogOut = new Guna.UI2.WinForms.Guna2Button();
            this.btnSellMedicine = new Guna.UI2.WinForms.Guna2Button();
            this.btnMedValidityCheck = new Guna.UI2.WinForms.Guna2Button();
            this.btnModifyMedicine = new Guna.UI2.WinForms.Guna2Button();
            this.btnViewMedicine = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddMedicine = new Guna.UI2.WinForms.Guna2Button();
            this.btnDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse4 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse5 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse6 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.uC_P_MedicineValidityCheck1 = new PMS.PharmacistUC.UC_P_MedicineValidityCheck();
            this.uC_P_UpdateMedicine1 = new PMS.PharmacistUC.UC_P_UpdateMedicine();
            this.uC_P_ViewMedicine1 = new PMS.PharmacistUC.UC_P_ViewMedicine();
            this.uC_P_AddMedicine1 = new PMS.PharmacistUC.UC_P_AddMedicine();
            this.uC_P_Dashboard1 = new PMS.PharmacistUC.UC_P_Dashboard();
            this.uC_P_SellMedicine1 = new PMS.PharmacistUC.UC_P_SellMedicine();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Coral;
            this.panel1.Controls.Add(this.btnLogOut);
            this.panel1.Controls.Add(this.btnSellMedicine);
            this.panel1.Controls.Add(this.btnMedValidityCheck);
            this.panel1.Controls.Add(this.btnModifyMedicine);
            this.panel1.Controls.Add(this.btnViewMedicine);
            this.panel1.Controls.Add(this.btnAddMedicine);
            this.panel1.Controls.Add(this.btnDashboard);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 768);
            this.panel1.TabIndex = 0;
            // 
            // btnLogOut
            // 
            this.btnLogOut.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnLogOut.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnLogOut.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnLogOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogOut.FillColor = System.Drawing.Color.Coral;
            this.btnLogOut.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.ImageSize = new System.Drawing.Size(30, 30);
            this.btnLogOut.Location = new System.Drawing.Point(35, 684);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(240, 45);
            this.btnLogOut.TabIndex = 8;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnSellMedicine
            // 
            this.btnSellMedicine.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnSellMedicine.Checked = true;
            this.btnSellMedicine.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnSellMedicine.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnSellMedicine.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSellMedicine.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSellMedicine.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSellMedicine.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSellMedicine.FillColor = System.Drawing.Color.Coral;
            this.btnSellMedicine.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSellMedicine.ForeColor = System.Drawing.Color.White;
            this.btnSellMedicine.Image = ((System.Drawing.Image)(resources.GetObject("btnSellMedicine.Image")));
            this.btnSellMedicine.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSellMedicine.Location = new System.Drawing.Point(35, 620);
            this.btnSellMedicine.Name = "btnSellMedicine";
            this.btnSellMedicine.Size = new System.Drawing.Size(240, 45);
            this.btnSellMedicine.TabIndex = 7;
            this.btnSellMedicine.Text = "Sell Medicine";
            this.btnSellMedicine.Click += new System.EventHandler(this.btnSellMedicine_Click);
            // 
            // btnMedValidityCheck
            // 
            this.btnMedValidityCheck.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnMedValidityCheck.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnMedValidityCheck.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnMedValidityCheck.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMedValidityCheck.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMedValidityCheck.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMedValidityCheck.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMedValidityCheck.FillColor = System.Drawing.Color.Coral;
            this.btnMedValidityCheck.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedValidityCheck.ForeColor = System.Drawing.Color.White;
            this.btnMedValidityCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnMedValidityCheck.Image")));
            this.btnMedValidityCheck.ImageSize = new System.Drawing.Size(30, 30);
            this.btnMedValidityCheck.Location = new System.Drawing.Point(35, 552);
            this.btnMedValidityCheck.Name = "btnMedValidityCheck";
            this.btnMedValidityCheck.Size = new System.Drawing.Size(240, 62);
            this.btnMedValidityCheck.TabIndex = 6;
            this.btnMedValidityCheck.Text = "Medicine Validity Check";
            this.btnMedValidityCheck.Click += new System.EventHandler(this.btnMedValidityCheck_Click);
            // 
            // btnModifyMedicine
            // 
            this.btnModifyMedicine.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnModifyMedicine.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnModifyMedicine.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnModifyMedicine.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnModifyMedicine.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnModifyMedicine.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnModifyMedicine.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnModifyMedicine.FillColor = System.Drawing.Color.Coral;
            this.btnModifyMedicine.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifyMedicine.ForeColor = System.Drawing.Color.White;
            this.btnModifyMedicine.Image = ((System.Drawing.Image)(resources.GetObject("btnModifyMedicine.Image")));
            this.btnModifyMedicine.ImageSize = new System.Drawing.Size(25, 25);
            this.btnModifyMedicine.Location = new System.Drawing.Point(35, 484);
            this.btnModifyMedicine.Name = "btnModifyMedicine";
            this.btnModifyMedicine.Size = new System.Drawing.Size(240, 45);
            this.btnModifyMedicine.TabIndex = 5;
            this.btnModifyMedicine.Text = "Modify Medicine";
            this.btnModifyMedicine.Click += new System.EventHandler(this.btnModifyMedicine_Click);
            // 
            // btnViewMedicine
            // 
            this.btnViewMedicine.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnViewMedicine.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnViewMedicine.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnViewMedicine.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewMedicine.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewMedicine.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewMedicine.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewMedicine.FillColor = System.Drawing.Color.Coral;
            this.btnViewMedicine.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewMedicine.ForeColor = System.Drawing.Color.White;
            this.btnViewMedicine.Image = ((System.Drawing.Image)(resources.GetObject("btnViewMedicine.Image")));
            this.btnViewMedicine.ImageSize = new System.Drawing.Size(25, 25);
            this.btnViewMedicine.Location = new System.Drawing.Point(35, 417);
            this.btnViewMedicine.Name = "btnViewMedicine";
            this.btnViewMedicine.Size = new System.Drawing.Size(240, 45);
            this.btnViewMedicine.TabIndex = 4;
            this.btnViewMedicine.Text = "View Medicine";
            this.btnViewMedicine.Click += new System.EventHandler(this.btnViewMedicine_Click);
            // 
            // btnAddMedicine
            // 
            this.btnAddMedicine.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnAddMedicine.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnAddMedicine.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnAddMedicine.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddMedicine.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddMedicine.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddMedicine.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddMedicine.FillColor = System.Drawing.Color.Coral;
            this.btnAddMedicine.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnAddMedicine.ForeColor = System.Drawing.Color.White;
            this.btnAddMedicine.Image = ((System.Drawing.Image)(resources.GetObject("btnAddMedicine.Image")));
            this.btnAddMedicine.ImageSize = new System.Drawing.Size(25, 25);
            this.btnAddMedicine.Location = new System.Drawing.Point(35, 348);
            this.btnAddMedicine.Name = "btnAddMedicine";
            this.btnAddMedicine.Size = new System.Drawing.Size(240, 45);
            this.btnAddMedicine.TabIndex = 3;
            this.btnAddMedicine.Text = "Add Medicine";
            this.btnAddMedicine.Click += new System.EventHandler(this.btnAddMedicine_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnDashboard.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnDashboard.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnDashboard.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDashboard.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDashboard.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDashboard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDashboard.FillColor = System.Drawing.Color.Coral;
            this.btnDashboard.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageSize = new System.Drawing.Size(25, 25);
            this.btnDashboard.Location = new System.Drawing.Point(35, 282);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(240, 45);
            this.btnDashboard.TabIndex = 2;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(32, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 49);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pharmacist";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(275, 209);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.uC_P_SellMedicine1);
            this.panel2.Controls.Add(this.uC_P_MedicineValidityCheck1);
            this.panel2.Controls.Add(this.uC_P_UpdateMedicine1);
            this.panel2.Controls.Add(this.uC_P_ViewMedicine1);
            this.panel2.Controls.Add(this.uC_P_AddMedicine1);
            this.panel2.Controls.Add(this.uC_P_Dashboard1);
            this.panel2.Location = new System.Drawing.Point(274, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1107, 769);
            this.panel2.TabIndex = 1;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this.panel2;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.TargetControl = this.panel2;
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.TargetControl = this.panel2;
            // 
            // guna2Elipse4
            // 
            this.guna2Elipse4.TargetControl = this.panel2;
            // 
            // guna2Elipse5
            // 
            this.guna2Elipse5.TargetControl = this.panel2;
            // 
            // guna2Elipse6
            // 
            this.guna2Elipse6.TargetControl = this.panel2;
            // 
            // uC_P_MedicineValidityCheck1
            // 
            this.uC_P_MedicineValidityCheck1.BackColor = System.Drawing.Color.White;
            this.uC_P_MedicineValidityCheck1.Location = new System.Drawing.Point(-2, -2);
            this.uC_P_MedicineValidityCheck1.Name = "uC_P_MedicineValidityCheck1";
            this.uC_P_MedicineValidityCheck1.Size = new System.Drawing.Size(1105, 768);
            this.uC_P_MedicineValidityCheck1.TabIndex = 4;
            // 
            // uC_P_UpdateMedicine1
            // 
            this.uC_P_UpdateMedicine1.BackColor = System.Drawing.Color.White;
            this.uC_P_UpdateMedicine1.Location = new System.Drawing.Point(-2, -2);
            this.uC_P_UpdateMedicine1.Name = "uC_P_UpdateMedicine1";
            this.uC_P_UpdateMedicine1.Size = new System.Drawing.Size(1105, 768);
            this.uC_P_UpdateMedicine1.TabIndex = 3;
            // 
            // uC_P_ViewMedicine1
            // 
            this.uC_P_ViewMedicine1.BackColor = System.Drawing.Color.White;
            this.uC_P_ViewMedicine1.Location = new System.Drawing.Point(-2, 2);
            this.uC_P_ViewMedicine1.Name = "uC_P_ViewMedicine1";
            this.uC_P_ViewMedicine1.Size = new System.Drawing.Size(1105, 768);
            this.uC_P_ViewMedicine1.TabIndex = 2;
            // 
            // uC_P_AddMedicine1
            // 
            this.uC_P_AddMedicine1.BackColor = System.Drawing.Color.White;
            this.uC_P_AddMedicine1.Location = new System.Drawing.Point(-1, 0);
            this.uC_P_AddMedicine1.Name = "uC_P_AddMedicine1";
            this.uC_P_AddMedicine1.Size = new System.Drawing.Size(1105, 768);
            this.uC_P_AddMedicine1.TabIndex = 1;
            this.uC_P_AddMedicine1.Load += new System.EventHandler(this.uC_P_AddMedicine1_Load);
            // 
            // uC_P_Dashboard1
            // 
            this.uC_P_Dashboard1.BackColor = System.Drawing.Color.White;
            this.uC_P_Dashboard1.Location = new System.Drawing.Point(3, 2);
            this.uC_P_Dashboard1.Name = "uC_P_Dashboard1";
            this.uC_P_Dashboard1.Size = new System.Drawing.Size(1105, 768);
            this.uC_P_Dashboard1.TabIndex = 0;
            // 
            // uC_P_SellMedicine1
            // 
            this.uC_P_SellMedicine1.BackColor = System.Drawing.Color.White;
            this.uC_P_SellMedicine1.Location = new System.Drawing.Point(0, -3);
            this.uC_P_SellMedicine1.Name = "uC_P_SellMedicine1";
            this.uC_P_SellMedicine1.Size = new System.Drawing.Size(1105, 768);
            this.uC_P_SellMedicine1.TabIndex = 5;
            // 
            // Pharmacist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1380, 768);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Pharmacist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pharmacist";
            this.Load += new System.EventHandler(this.Pharmacist_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnDashboard;
        private Guna.UI2.WinForms.Guna2Button btnLogOut;
        private Guna.UI2.WinForms.Guna2Button btnSellMedicine;
        private Guna.UI2.WinForms.Guna2Button btnMedValidityCheck;
        private Guna.UI2.WinForms.Guna2Button btnModifyMedicine;
        private Guna.UI2.WinForms.Guna2Button btnViewMedicine;
        private Guna.UI2.WinForms.Guna2Button btnAddMedicine;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private PharmacistUC.UC_P_Dashboard uC_P_Dashboard1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private PharmacistUC.UC_P_AddMedicine uC_P_AddMedicine1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private PharmacistUC.UC_P_ViewMedicine uC_P_ViewMedicine1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse4;
        private PharmacistUC.UC_P_UpdateMedicine uC_P_UpdateMedicine1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse5;
        private PharmacistUC.UC_P_MedicineValidityCheck uC_P_MedicineValidityCheck1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse6;
        private PharmacistUC.UC_P_SellMedicine uC_P_SellMedicine1;
    }
}