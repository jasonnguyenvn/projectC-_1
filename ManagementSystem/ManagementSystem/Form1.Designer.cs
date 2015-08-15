namespace ManagementSystem
{
    partial class MainForm
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
            this.btnOpenEmployees = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnOders = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnSuppliers = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnShippers = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenEmployees
            // 
            this.btnOpenEmployees.AutoSize = true;
            this.btnOpenEmployees.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOpenEmployees.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpenEmployees.Location = new System.Drawing.Point(0, 0);
            this.btnOpenEmployees.Name = "btnOpenEmployees";
            this.btnOpenEmployees.Size = new System.Drawing.Size(198, 42);
            this.btnOpenEmployees.TabIndex = 0;
            this.btnOpenEmployees.Text = "Employees Manager";
            this.btnOpenEmployees.UseVisualStyleBackColor = false;
            this.btnOpenEmployees.Click += new System.EventHandler(this.btnOpenEmployees_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 477F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 477F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1022, 573);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(207, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(812, 600);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.btnAbout);
            this.panel2.Controls.Add(this.btnOders);
            this.panel2.Controls.Add(this.btnCustomers);
            this.panel2.Controls.Add(this.btnShippers);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btnSuppliers);
            this.panel2.Controls.Add(this.btnCategories);
            this.panel2.Controls.Add(this.btnProducts);
            this.panel2.Controls.Add(this.btnOpenEmployees);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.MinimumSize = new System.Drawing.Size(150, 250);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 600);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.labelVersion);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(3, 342);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(192, 100);
            this.panel3.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Version 0.6.9.1.3628";
            // 
            // labelVersion
            // 
            this.labelVersion.Location = new System.Drawing.Point(9, 31);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelVersion.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(0, 16);
            this.labelVersion.TabIndex = 1;
            this.labelVersion.Text = "Version 0.6.9.1.3628";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company Management System";
            // 
            // btnAbout
            // 
            this.btnAbout.AutoSize = true;
            this.btnAbout.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAbout.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAbout.Location = new System.Drawing.Point(0, 294);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(198, 42);
            this.btnAbout.TabIndex = 7;
            this.btnAbout.Text = "&About";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnOders
            // 
            this.btnOders.AutoSize = true;
            this.btnOders.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOders.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOders.Location = new System.Drawing.Point(0, 252);
            this.btnOders.Name = "btnOders";
            this.btnOders.Size = new System.Drawing.Size(198, 42);
            this.btnOders.TabIndex = 6;
            this.btnOders.Text = "Orders";
            this.btnOders.UseVisualStyleBackColor = false;
            this.btnOders.Click += new System.EventHandler(this.btnOders_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.AutoSize = true;
            this.btnCustomers.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomers.Location = new System.Drawing.Point(0, 210);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(198, 42);
            this.btnCustomers.TabIndex = 5;
            this.btnCustomers.Text = "Customers";
            this.btnCustomers.UseVisualStyleBackColor = false;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.AutoSize = true;
            this.btnSuppliers.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSuppliers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSuppliers.Location = new System.Drawing.Point(0, 126);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(198, 42);
            this.btnSuppliers.TabIndex = 3;
            this.btnSuppliers.Text = "Suppliers";
            this.btnSuppliers.UseVisualStyleBackColor = false;
            this.btnSuppliers.Click += new System.EventHandler(this.btnSuppliers_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.AutoSize = true;
            this.btnCategories.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategories.Location = new System.Drawing.Point(0, 84);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(198, 42);
            this.btnCategories.TabIndex = 2;
            this.btnCategories.Text = "Categories Manager";
            this.btnCategories.UseVisualStyleBackColor = false;
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.AutoSize = true;
            this.btnProducts.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProducts.Location = new System.Drawing.Point(0, 42);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(198, 42);
            this.btnProducts.TabIndex = 1;
            this.btnProducts.Text = "Products Manager";
            this.btnProducts.UseVisualStyleBackColor = false;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnShippers
            // 
            this.btnShippers.AutoSize = true;
            this.btnShippers.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnShippers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShippers.Location = new System.Drawing.Point(0, 168);
            this.btnShippers.Name = "btnShippers";
            this.btnShippers.Size = new System.Drawing.Size(198, 42);
            this.btnShippers.TabIndex = 4;
            this.btnShippers.Text = "Shippers";
            this.btnShippers.UseVisualStyleBackColor = false;
            this.btnShippers.Click += new System.EventHandler(this.btnShippers_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 573);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(1030, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Mangement";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenEmployees;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnSuppliers;
        private System.Windows.Forms.Button btnOders;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnShippers;

    }
}

