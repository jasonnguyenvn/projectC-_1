namespace Employees
{
    partial class EmployeeControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.gvEmployees = new System.Windows.Forms.DataGridView();
            this.tbEmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbLastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbFirstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbTitleofCourtesy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbHireday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbRegion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPostalcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbManagerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClearForm = new System.Windows.Forms.Button();
            this.GridViewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtManagerID = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmployees)).BeginInit();
            this.GridViewMenu.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Title";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "City";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Region";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Postal Code";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Country";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 156);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Phone";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 182);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Manager ID";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Enabled = false;
            this.txtEmployeeID.Location = new System.Drawing.Point(259, 3);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(129, 20);
            this.txtEmployeeID.TabIndex = 14;
            // 
            // gvEmployees
            // 
            this.gvEmployees.AllowUserToAddRows = false;
            this.gvEmployees.AllowUserToDeleteRows = false;
            this.gvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.gvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tbEmployeeID,
            this.tbLastname,
            this.tbFirstname,
            this.tbTitle,
            this.tbTitleofCourtesy,
            this.tbBirthday,
            this.tbHireday,
            this.tbAddress,
            this.tbCity,
            this.tbRegion,
            this.tbPostalcode,
            this.tbCountry,
            this.tbPhone,
            this.tbManagerID});
            this.gvEmployees.Dock = System.Windows.Forms.DockStyle.Top;
            this.gvEmployees.Location = new System.Drawing.Point(0, 0);
            this.gvEmployees.MultiSelect = false;
            this.gvEmployees.Name = "gvEmployees";
            this.gvEmployees.ReadOnly = true;
            this.gvEmployees.Size = new System.Drawing.Size(494, 488);
            this.gvEmployees.TabIndex = 28;
            this.gvEmployees.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gvEmployees_MouseClick);
            this.gvEmployees.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gvEmployees_MouseDoubleClick);
            this.gvEmployees.SelectionChanged += new System.EventHandler(this.gvEmployees_SelectionChanged);
            // 
            // tbEmployeeID
            // 
            this.tbEmployeeID.HeaderText = "EmpID";
            this.tbEmployeeID.Name = "tbEmployeeID";
            this.tbEmployeeID.ReadOnly = true;
            this.tbEmployeeID.Width = 5;
            // 
            // tbLastname
            // 
            this.tbLastname.HeaderText = "Last Name";
            this.tbLastname.Name = "tbLastname";
            this.tbLastname.ReadOnly = true;
            this.tbLastname.Width = 5;
            // 
            // tbFirstname
            // 
            this.tbFirstname.HeaderText = "First Name";
            this.tbFirstname.Name = "tbFirstname";
            this.tbFirstname.ReadOnly = true;
            this.tbFirstname.Width = 5;
            // 
            // tbTitle
            // 
            this.tbTitle.HeaderText = "Title";
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.ReadOnly = true;
            this.tbTitle.Width = 5;
            // 
            // tbTitleofCourtesy
            // 
            this.tbTitleofCourtesy.HeaderText = "TitleOfCourtesy";
            this.tbTitleofCourtesy.Name = "tbTitleofCourtesy";
            this.tbTitleofCourtesy.ReadOnly = true;
            this.tbTitleofCourtesy.Width = 5;
            // 
            // tbBirthday
            // 
            this.tbBirthday.HeaderText = "Birthday";
            this.tbBirthday.Name = "tbBirthday";
            this.tbBirthday.ReadOnly = true;
            this.tbBirthday.Width = 5;
            // 
            // tbHireday
            // 
            this.tbHireday.HeaderText = "Hireday";
            this.tbHireday.Name = "tbHireday";
            this.tbHireday.ReadOnly = true;
            this.tbHireday.Width = 5;
            // 
            // tbAddress
            // 
            this.tbAddress.HeaderText = "Address";
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.ReadOnly = true;
            this.tbAddress.Width = 5;
            // 
            // tbCity
            // 
            this.tbCity.HeaderText = "City";
            this.tbCity.Name = "tbCity";
            this.tbCity.ReadOnly = true;
            this.tbCity.Width = 5;
            // 
            // tbRegion
            // 
            this.tbRegion.HeaderText = "Region";
            this.tbRegion.Name = "tbRegion";
            this.tbRegion.ReadOnly = true;
            this.tbRegion.Width = 5;
            // 
            // tbPostalcode
            // 
            this.tbPostalcode.HeaderText = "Postal Code";
            this.tbPostalcode.Name = "tbPostalcode";
            this.tbPostalcode.ReadOnly = true;
            this.tbPostalcode.Width = 5;
            // 
            // tbCountry
            // 
            this.tbCountry.HeaderText = "Country";
            this.tbCountry.Name = "tbCountry";
            this.tbCountry.ReadOnly = true;
            this.tbCountry.Width = 5;
            // 
            // tbPhone
            // 
            this.tbPhone.HeaderText = "Phone";
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.ReadOnly = true;
            this.tbPhone.Width = 5;
            // 
            // tbManagerID
            // 
            this.tbManagerID.HeaderText = "MgrID";
            this.tbManagerID.Name = "tbManagerID";
            this.tbManagerID.ReadOnly = true;
            this.tbManagerID.Width = 5;
            // 
            // btnClearForm
            // 
            this.btnClearForm.Location = new System.Drawing.Point(101, 3);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(90, 23);
            this.btnClearForm.TabIndex = 32;
            this.btnClearForm.Text = "Clear Filter";
            this.btnClearForm.UseVisualStyleBackColor = true;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // GridViewMenu
            // 
            this.GridViewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.GridViewMenu.Name = "GridViewMenu";
            this.GridViewMenu.Size = new System.Drawing.Size(110, 48);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1MinSize = 400;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.gvEmployees);
            this.splitContainer1.Size = new System.Drawing.Size(898, 507);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 36;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 507);
            this.panel1.TabIndex = 38;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74F));
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtManagerID, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtPhone, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtCountry, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPostalCode, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtTitle, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtRegion, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtCity, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 8);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(394, 255);
            this.tableLayoutPanel1.TabIndex = 70;
            // 
            // txtManagerID
            // 
            this.txtManagerID.Location = new System.Drawing.Point(105, 185);
            this.txtManagerID.Name = "txtManagerID";
            this.txtManagerID.Size = new System.Drawing.Size(286, 20);
            this.txtManagerID.TabIndex = 65;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(105, 159);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(286, 20);
            this.txtPhone.TabIndex = 64;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(105, 133);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(286, 20);
            this.txtCountry.TabIndex = 63;
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Location = new System.Drawing.Point(105, 107);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(286, 20);
            this.txtPostalCode.TabIndex = 62;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(105, 29);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(286, 20);
            this.txtTitle.TabIndex = 38;
            // 
            // txtRegion
            // 
            this.txtRegion.Location = new System.Drawing.Point(105, 81);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(286, 20);
            this.txtRegion.TabIndex = 61;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(105, 55);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(286, 20);
            this.txtCity.TabIndex = 60;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(105, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(286, 20);
            this.txtName.TabIndex = 37;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.btnAdd);
            this.panel5.Controls.Add(this.btnDelete);
            this.panel5.Controls.Add(this.txtEmployeeID);
            this.panel5.Controls.Add(this.btnUpdate);
            this.panel5.Location = new System.Drawing.Point(3, 264);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(392, 106);
            this.panel5.TabIndex = 69;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::Employees.Properties.Resources.Filter2HS;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(197, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(86, 23);
            this.btnSearch.TabIndex = 33;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Employees.Properties.Resources.NewDocumentHS;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnAdd.Location = new System.Drawing.Point(313, 31);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 29;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Employees.Properties.Resources.DeleteHS1;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnDelete.Location = new System.Drawing.Point(125, 31);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = global::Employees.Properties.Resources.NewCardHS;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnUpdate.Location = new System.Drawing.Point(212, 31);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 23);
            this.btnUpdate.TabIndex = 30;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 54);
            this.panel2.TabIndex = 66;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = global::Employees.Properties.Resources.Users;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 54);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 35;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Algerian", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 26);
            this.label2.TabIndex = 36;
            this.label2.Text = "Employees Manager";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 54);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.83664F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.16336F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(400, 453);
            this.tableLayoutPanel2.TabIndex = 71;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnClearForm);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Location = new System.Drawing.Point(105, 211);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(286, 37);
            this.panel3.TabIndex = 66;
            // 
            // EmployeeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "EmployeeControl";
            this.Size = new System.Drawing.Size(898, 507);
            ((System.ComponentModel.ISupportInitialize)(this.gvEmployees)).EndInit();
            this.GridViewMenu.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.DataGridView gvEmployees;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbEmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbLastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbFirstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbTitleofCourtesy;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbBirthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbHireday;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbRegion;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbPostalcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbManagerID;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClearForm;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip GridViewMenu;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTitle;
        public System.Windows.Forms.TextBox txtPhone;
        public System.Windows.Forms.TextBox txtCountry;
        public System.Windows.Forms.TextBox txtPostalCode;
        public System.Windows.Forms.TextBox txtRegion;
        public System.Windows.Forms.TextBox txtCity;
        public System.Windows.Forms.TextBox txtManagerID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
    }
}
