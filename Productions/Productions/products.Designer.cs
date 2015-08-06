namespace Productions
{
    partial class products
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
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(388, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "productID";
            // 
            // gvProducts
            // 
            this.gvProducts.AllowUserToAddRows = false;
            this.gvProducts.AllowUserToDeleteRows = false;
            this.gvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProducts.Location = new System.Drawing.Point(17, 19);
            this.gvProducts.Name = "gvProducts";
            this.gvProducts.ReadOnly = true;
            this.gvProducts.Size = new System.Drawing.Size(347, 268);
            this.gvProducts.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(387, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "productname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(387, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "supplierid";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(387, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "cateloryID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(387, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Unitprice";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(387, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 6;
            // 
            // txtproID
            // 
            this.txtproID.Location = new System.Drawing.Point(475, 19);
            this.txtproID.Name = "txtproID";
            this.txtproID.Size = new System.Drawing.Size(206, 20);
            this.txtproID.TabIndex = 7;
            // 
            // txtproName
            // 
            this.txtproName.Location = new System.Drawing.Point(475, 62);
            this.txtproName.Name = "txtproName";
            this.txtproName.Size = new System.Drawing.Size(206, 20);
            this.txtproName.TabIndex = 8;
            // 
            // txtUnitprice
            // 
            this.txtUnitprice.Location = new System.Drawing.Point(475, 180);
            this.txtUnitprice.Name = "txtUnitprice";
            this.txtUnitprice.Size = new System.Drawing.Size(206, 20);
            this.txtUnitprice.TabIndex = 9;
            // 
            // cbxSupID
            // 
            this.cbxSupID.FormattingEnabled = true;
            this.cbxSupID.Location = new System.Drawing.Point(475, 99);
            this.cbxSupID.Name = "cbxSupID";
            this.cbxSupID.Size = new System.Drawing.Size(206, 21);
            this.cbxSupID.TabIndex = 10;
            // 
            // cbxCaID
            // 
            this.cbxCaID.FormattingEnabled = true;
            this.cbxCaID.Location = new System.Drawing.Point(475, 137);
            this.cbxCaID.Name = "cbxCaID";
            this.cbxCaID.Size = new System.Drawing.Size(206, 21);
            this.cbxCaID.TabIndex = 11;
            // 
            // cbDiscontinued
            // 
            this.cbDiscontinued.AutoSize = true;
            this.cbDiscontinued.Location = new System.Drawing.Point(475, 219);
            this.cbDiscontinued.Name = "cbDiscontinued";
            this.cbDiscontinued.Size = new System.Drawing.Size(88, 17);
            this.cbDiscontinued.TabIndex = 12;
            this.cbDiscontinued.Text = "Discontinued";
            this.cbDiscontinued.UseVisualStyleBackColor = true;
            // 
            // btnproAdd
            // 
            this.btnproAdd.Location = new System.Drawing.Point(606, 264);
            this.btnproAdd.Name = "btnproAdd";
            this.btnproAdd.Size = new System.Drawing.Size(75, 23);
            this.btnproAdd.TabIndex = 13;
            this.btnproAdd.Text = "Add";
            this.btnproAdd.UseVisualStyleBackColor = true;
            // 
            // btnproUpdate
            // 
            this.btnproUpdate.Location = new System.Drawing.Point(498, 264);
            this.btnproUpdate.Name = "btnproUpdate";
            this.btnproUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnproUpdate.TabIndex = 14;
            this.btnproUpdate.Text = "Update";
            this.btnproUpdate.UseVisualStyleBackColor = true;
            // 
            // btnproRemove
            // 
            this.btnproRemove.Location = new System.Drawing.Point(391, 264);
            this.btnproRemove.Name = "btnproRemove";
            this.btnproRemove.Size = new System.Drawing.Size(75, 23);
            this.btnproRemove.TabIndex = 15;
            this.btnproRemove.Text = "Remove";
            this.btnproRemove.UseVisualStyleBackColor = true;
            // 
            // products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Name = "products";
            this.Size = new System.Drawing.Size(704, 307);
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).EndInit();
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
    }
}
