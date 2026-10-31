namespace SQLLiteDemo
{
    partial class EmployeeForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            label1 = new Label();
            pnlbuttons = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnSave = new Button();
            btnUpdate = new Button();
            btnClear = new Button();
            btnClose = new Button();
            pnlForm = new Panel();
            tnlForm = new TableLayoutPanel();
            txtEmpCode = new TextBox();
            txtName = new TextBox();
            txtSalary = new TextBox();
            lblEmpCode = new Label();
            lbSalary = new Label();
            lblName = new Label();
            lblDoj = new Label();
            dtDoj = new DateTimePicker();
            pnlGrid = new Panel();
            dgvEmployee = new DataGridView();
            pnlHeader.SuspendLayout();
            pnlbuttons.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnlForm.SuspendLayout();
            tnlForm.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(224, 224, 224);
            pnlHeader.Controls.Add(label1);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.MaximumSize = new Size(0, 50);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1300, 50);
            pnlHeader.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(211, 32);
            label1.TabIndex = 0;
            label1.Text = "Employee Master";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlbuttons
            // 
            pnlbuttons.Controls.Add(flowLayoutPanel1);
            pnlbuttons.Dock = DockStyle.Top;
            pnlbuttons.Location = new Point(0, 50);
            pnlbuttons.MaximumSize = new Size(0, 50);
            pnlbuttons.Name = "pnlbuttons";
            pnlbuttons.Size = new Size(1300, 50);
            pnlbuttons.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(txtSearch);
            flowLayoutPanel1.Controls.Add(btnSearch);
            flowLayoutPanel1.Controls.Add(btnSave);
            flowLayoutPanel1.Controls.Add(btnUpdate);
            flowLayoutPanel1.Controls.Add(btnClear);
            flowLayoutPanel1.Controls.Add(btnClose);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(10);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(10);
            flowLayoutPanel1.Size = new Size(1300, 50);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(13, 13);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(256, 27);
            txtSearch.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(275, 13);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 10F);
            btnSave.Location = new Point(375, 13);
            btnSave.MaximumSize = new Size(90, 30);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 29);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 10F);
            btnUpdate.Location = new Point(471, 13);
            btnUpdate.MaximumSize = new Size(90, 30);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(90, 29);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 10F);
            btnClear.Location = new Point(567, 13);
            btnClear.MaximumSize = new Size(90, 30);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(90, 29);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 10F);
            btnClose.Location = new Point(663, 13);
            btnClose.MaximumSize = new Size(90, 30);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(90, 29);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pnlForm
            // 
            pnlForm.Controls.Add(tnlForm);
            pnlForm.Dock = DockStyle.Top;
            pnlForm.Location = new Point(0, 100);
            pnlForm.MaximumSize = new Size(0, 120);
            pnlForm.Name = "pnlForm";
            pnlForm.Padding = new Padding(10);
            pnlForm.Size = new Size(1300, 120);
            pnlForm.TabIndex = 2;
            // 
            // tnlForm
            // 
            tnlForm.ColumnCount = 4;
            tnlForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tnlForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tnlForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tnlForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tnlForm.Controls.Add(txtEmpCode, 1, 0);
            tnlForm.Controls.Add(txtName, 3, 0);
            tnlForm.Controls.Add(txtSalary, 1, 1);
            tnlForm.Controls.Add(lblEmpCode, 0, 0);
            tnlForm.Controls.Add(lbSalary, 0, 1);
            tnlForm.Controls.Add(lblName, 2, 0);
            tnlForm.Controls.Add(lblDoj, 2, 1);
            tnlForm.Controls.Add(dtDoj, 3, 1);
            tnlForm.Dock = DockStyle.Fill;
            tnlForm.Location = new Point(10, 10);
            tnlForm.Name = "tnlForm";
            tnlForm.RowCount = 2;
            tnlForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tnlForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tnlForm.Size = new Size(1280, 100);
            tnlForm.TabIndex = 0;
            // 
            // txtEmpCode
            // 
            txtEmpCode.Dock = DockStyle.Fill;
            txtEmpCode.Location = new Point(259, 3);
            txtEmpCode.Name = "txtEmpCode";
            txtEmpCode.Size = new Size(378, 27);
            txtEmpCode.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Dock = DockStyle.Fill;
            txtName.Location = new Point(899, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(378, 27);
            txtName.TabIndex = 1;
            // 
            // txtSalary
            // 
            txtSalary.Dock = DockStyle.Fill;
            txtSalary.Location = new Point(259, 43);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(378, 27);
            txtSalary.TabIndex = 2;
            // 
            // lblEmpCode
            // 
            lblEmpCode.AutoSize = true;
            lblEmpCode.Dock = DockStyle.Top;
            lblEmpCode.Location = new Point(3, 0);
            lblEmpCode.Name = "lblEmpCode";
            lblEmpCode.Size = new Size(250, 20);
            lblEmpCode.TabIndex = 4;
            lblEmpCode.Text = "Emp Code";
            lblEmpCode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbSalary
            // 
            lbSalary.AutoSize = true;
            lbSalary.Dock = DockStyle.Top;
            lbSalary.Location = new Point(3, 40);
            lbSalary.Name = "lbSalary";
            lbSalary.Size = new Size(250, 20);
            lbSalary.TabIndex = 5;
            lbSalary.Text = "Salary";
            lbSalary.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Dock = DockStyle.Top;
            lblName.Location = new Point(643, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(250, 20);
            lblName.TabIndex = 6;
            lblName.Text = "Name";
            lblName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDoj
            // 
            lblDoj.AutoSize = true;
            lblDoj.Dock = DockStyle.Top;
            lblDoj.Location = new Point(643, 40);
            lblDoj.Name = "lblDoj";
            lblDoj.Size = new Size(250, 20);
            lblDoj.TabIndex = 7;
            lblDoj.Text = "DOJ";
            lblDoj.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtDoj
            // 
            dtDoj.Dock = DockStyle.Fill;
            dtDoj.Location = new Point(899, 43);
            dtDoj.Name = "dtDoj";
            dtDoj.Size = new Size(378, 27);
            dtDoj.TabIndex = 8;
            // 
            // pnlGrid
            // 
            pnlGrid.Controls.Add(dgvEmployee);
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.Location = new Point(0, 220);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Padding = new Padding(5);
            pnlGrid.Size = new Size(1300, 478);
            pnlGrid.TabIndex = 3;
            // 
            // dgvEmployee
            // 
            dgvEmployee.AllowUserToAddRows = false;
            dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvEmployee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvEmployee.DefaultCellStyle = dataGridViewCellStyle2;
            dgvEmployee.Dock = DockStyle.Fill;
            dgvEmployee.Location = new Point(5, 5);
            dgvEmployee.Name = "dgvEmployee";
            dgvEmployee.ReadOnly = true;
            dgvEmployee.RowHeadersWidth = 51;
            dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployee.Size = new Size(1290, 468);
            dgvEmployee.TabIndex = 0;
            dgvEmployee.CellContentClick += dgvEmployee_CellContentClick;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1300, 698);
            Controls.Add(pnlGrid);
            Controls.Add(pnlForm);
            Controls.Add(pnlbuttons);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(5);
            MinimumSize = new Size(900, 600);
            Name = "EmployeeForm";
            Text = "Employee Form";
            Load += Form1_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlbuttons.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            pnlForm.ResumeLayout(false);
            tnlForm.ResumeLayout(false);
            tnlForm.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Panel pnlbuttons;
        private Panel pnlForm;
        private TableLayoutPanel tnlForm;
        private Panel pnlGrid;
        private TextBox txtEmpCode;
        private TextBox txtName;
        private TextBox txtSalary;
        private Label lblEmpCode;
        private Label lbSalary;
        private Label lblName;
        private Label lblDoj;
        private DateTimePicker dtDoj;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnClear;
        private Button btnClose;
        private DataGridView dgvEmployee;
        private Label label1;
        private Button btnSearch;
        private TextBox txtSearch;
    }
}
