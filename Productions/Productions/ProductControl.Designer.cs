namespace Productions
{
    partial class ProductControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.gvProducts = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtproID = new System.Windows.Forms.TextBox();
            this.txtproName = new System.Windows.Forms.TextBox();
            this.txtUnitprice = new System.Windows.Forms.TextBox();
            this.cbxSupID = new System.Windows.Forms.ComboBox();
            this.cbxCaID = new System.Windows.Forms.ComboBox();
            this.cbDiscontinued = new System.Windows.Forms.CheckBox();
            this.btnproAdd = new System.Windows.Forms.Button();
            this.btnproUpdate = new System.Windows.Forms.Button();
            this.btnproRemove = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product ID";
            // 
            // gvProducts
            // 
            this.gvProducts.AllowUserToAddRows = false;
            this.gvProducts.AllowUserToDeleteRows = false;
            this.gvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProducts.Location = new System.Drawing.Point(385, 11);
            this.gvProducts.MultiSelect = false;
            this.gvProducts.Name = "gvProducts";
            this.gvProducts.ReadOnly = true;
            this.gvProducts.Size = new System.Drawing.Size(428, 363);
            this.gvProducts.TabIndex = 1;
            this.gvProducts.SelectionChanged += new System.EventHandler(this.gvProducts_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Product Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Supplier ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Category ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Unit Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 6;
            // 
            // txtproID
            // 
            this.txtproID.Enabled = false;
            this.txtproID.Location = new System.Drawing.Point(119, 80);
            this.txtproID.Name = "txtproID";
            this.txtproID.Size = new System.Drawing.Size(206, 20);
            this.txtproID.TabIndex = 7;
            // 
            // txtproName
            // 
            this.txtproName.Location = new System.Drawing.Point(119, 116);
            this.txtproName.Name = "txtproName";
            this.txtproName.Size = new System.Drawing.Size(206, 20);
            this.txtproName.TabIndex = 8;
            // 
            // txtUnitprice
            // 
            this.txtUnitprice.Location = new System.Drawing.Point(119, 226);
            this.txtUnitprice.Name = "txtUnitprice";
            this.txtUnitprice.Size = new System.Drawing.Size(206, 20);
            this.txtUnitprice.TabIndex = 9;
            // 
            // cbxSupID
            // 
            this.cbxSupID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSupID.FormattingEnabled = true;
            this.cbxSupID.Location = new System.Drawing.Point(119, 152);
            this.cbxSupID.Name = "cbxSupID";
            this.cbxSupID.Size = new System.Drawing.Size(206, 21);
            this.cbxSupID.TabIndex = 10;
            // 
            // cbxCaID
            // 
            this.cbxCaID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCaID.FormattingEnabled = true;
            this.cbxCaID.Location = new System.Drawing.Point(119, 189);
            this.cbxCaID.Name = "cbxCaID";
            this.cbxCaID.Size = new System.Drawing.Size(206, 21);
            this.cbxCaID.TabIndex = 11;
            // 
            // cbDiscontinued
            // 
            this.cbDiscontinued.AutoSize = true;
            this.cbDiscontinued.Location = new System.Drawing.Point(119, 262);
            this.cbDiscontinued.Name = "cbDiscontinued";
            this.cbDiscontinued.Size = new System.Drawing.Size(88, 17);
            this.cbDiscontinued.TabIndex = 12;
            this.cbDiscontinued.Text = "Discontinued";
            this.cbDiscontinued.UseVisualStyleBackColor = true;
            // 
            // btnproAdd
            // 
            this.btnproAdd.Image = global::Productions.Properties.Resources.NewDocumentHS;
            this.btnproAdd.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnproAdd.Location = new System.Drawing.Point(273, 351);
            this.btnproAdd.Name = "btnproAdd";
            this.btnproAdd.Size = new System.Drawing.Size(75, 23);
            this.btnproAdd.TabIndex = 13;
            this.btnproAdd.Text = "Add";
            this.btnproAdd.UseVisualStyleBackColor = true;
            this.btnproAdd.Click += new System.EventHandler(this.btnproAdd_Click);
            // 
            // btnproUpdate
            // 
            this.btnproUpdate.Image = global::Productions.Properties.Resources.NewCardHS;
            this.btnproUpdate.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnproUpdate.Location = new System.Drawing.Point(189, 351);
            this.btnproUpdate.Name = "btnproUpdate";
            this.btnproUpdate.Size = new System.Drawing.Size(84, 23);
            this.btnproUpdate.TabIndex = 14;
            this.btnproUpdate.Text = "Update";
            this.btnproUpdate.UseVisualStyleBackColor = true;
            this.btnproUpdate.Click += new System.EventHandler(this.btnproUpdate_Click);
            // 
            // btnproRemove
            // 
            this.btnproRemove.Image = global::Productions.Properties.Resources.DeleteHS;
            this.btnproRemove.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnproRemove.Location = new System.Drawing.Point(93, 351);
            this.btnproRemove.Name = "btnproRemove";
            this.btnproRemove.Size = new System.Drawing.Size(90, 23);
            this.btnproRemove.TabIndex = 15;
            this.btnproRemove.Text = "Remove";
            this.btnproRemove.UseVisualStyleBackColor = true;
            this.btnproRemove.Click += new System.EventHandler(this.btnproRemove_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(22, 351);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(65, 23);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(3, 11);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(347, 60);
            this.panel4.TabIndex = 67;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Algerian", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(85, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(262, 26);
            this.label7.TabIndex = 36;
            this.label7.Text = "Products Manager";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(189, 285);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(149, 23);
            this.btnSearch.TabIndex = 68;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = global::Productions.Properties.Resources.AWS_icon;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(79, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 35;
            this.pictureBox2.TabStop = false;
            // 
            // ProductControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnproRemove);
            this.Controls.Add(this.btnproUpdate);
            this.Controls.Add(this.btnproAdd);
            this.Controls.Add(this.cbDiscontinued);
            this.Controls.Add(this.cbxCaID);
            this.Controls.Add(this.cbxSupID);
            this.Controls.Add(this.txtUnitprice);
            this.Controls.Add(this.txtproName);
            this.Controls.Add(this.txtproID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gvProducts);
            this.Controls.Add(this.label1);
            this.Name = "ProductControl";
            this.Size = new System.Drawing.Size(840, 405);
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvProducts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtproID;
        private System.Windows.Forms.TextBox txtproName;
        private System.Windows.Forms.TextBox txtUnitprice;
        private System.Windows.Forms.ComboBox cbxSupID;
        private System.Windows.Forms.ComboBox cbxCaID;
        private System.Windows.Forms.CheckBox cbDiscontinued;
        private System.Windows.Forms.Button btnproAdd;
        private System.Windows.Forms.Button btnproUpdate;
        private System.Windows.Forms.Button btnproRemove;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSearch;
    }
}
