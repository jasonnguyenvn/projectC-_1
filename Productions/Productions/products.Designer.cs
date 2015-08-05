﻿namespace Productions
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
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSupID = new System.Windows.Forms.TextBox();
            this.txtCompName = new System.Windows.Forms.TextBox();
            this.txtContname = new System.Windows.Forms.TextBox();
            this.txtContTitle = new System.Windows.Forms.TextBox();
            this.txtAddr = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtPos = new System.Windows.Forms.TextBox();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.clSupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCompName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clContName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clContTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clRegion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvView
            // 
            this.dgvView.AllowUserToAddRows = false;
            this.dgvView.AllowUserToDeleteRows = false;
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clSupID,
            this.clCompName,
            this.clContName,
            this.clContTitle,
            this.clAddr,
            this.clCity,
            this.clRegion,
            this.clPos,
            this.clCountry,
            this.clPhone,
            this.clFax});
            this.dgvView.Location = new System.Drawing.Point(17, 23);
            this.dgvView.Name = "dgvView";
            this.dgvView.ReadOnly = true;
            this.dgvView.Size = new System.Drawing.Size(511, 335);
            this.dgvView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(557, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Suppliers ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(557, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Company Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(557, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Contact Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(557, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Contact Title";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(557, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(557, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "City";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(557, 276);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Region";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(557, 314);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Postal Code";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(557, 351);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Country";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(557, 390);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Phone";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(557, 421);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Fax";
            // 
            // txtSupID
            // 
            this.txtSupID.Location = new System.Drawing.Point(664, 23);
            this.txtSupID.Name = "txtSupID";
            this.txtSupID.Size = new System.Drawing.Size(100, 20);
            this.txtSupID.TabIndex = 2;
            // 
            // txtCompName
            // 
            this.txtCompName.Location = new System.Drawing.Point(664, 57);
            this.txtCompName.Name = "txtCompName";
            this.txtCompName.Size = new System.Drawing.Size(174, 20);
            this.txtCompName.TabIndex = 2;
            // 
            // txtContname
            // 
            this.txtContname.Location = new System.Drawing.Point(664, 96);
            this.txtContname.Name = "txtContname";
            this.txtContname.Size = new System.Drawing.Size(174, 20);
            this.txtContname.TabIndex = 2;
            // 
            // txtContTitle
            // 
            this.txtContTitle.Location = new System.Drawing.Point(664, 135);
            this.txtContTitle.Name = "txtContTitle";
            this.txtContTitle.Size = new System.Drawing.Size(174, 20);
            this.txtContTitle.TabIndex = 2;
            // 
            // txtAddr
            // 
            this.txtAddr.Location = new System.Drawing.Point(664, 170);
            this.txtAddr.Multiline = true;
            this.txtAddr.Name = "txtAddr";
            this.txtAddr.Size = new System.Drawing.Size(174, 48);
            this.txtAddr.TabIndex = 2;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(664, 231);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(174, 20);
            this.txtCity.TabIndex = 2;
            // 
            // txtPos
            // 
            this.txtPos.Location = new System.Drawing.Point(664, 311);
            this.txtPos.Name = "txtPos";
            this.txtPos.Size = new System.Drawing.Size(100, 20);
            this.txtPos.TabIndex = 2;
            // 
            // cbCountry
            // 
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Items.AddRange(new object[] {
            "Viet Nam",
            "Laos",
            "Cambodia",
            "Myanmar",
            "Thailand",
            "Brunei",
            "Philippines",
            "Singapore",
            "Indonesia",
            "Malaysia"});
            this.cbCountry.Location = new System.Drawing.Point(664, 348);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(174, 21);
            this.cbCountry.TabIndex = 3;
            // 
            // txtRegion
            // 
            this.txtRegion.Location = new System.Drawing.Point(664, 273);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(174, 20);
            this.txtRegion.TabIndex = 2;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(664, 387);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(174, 20);
            this.txtPhone.TabIndex = 2;
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(664, 418);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(174, 20);
            this.txtFax.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(17, 390);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(137, 390);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(269, 390);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // clSupID
            // 
            this.clSupID.HeaderText = "Suppliers ID";
            this.clSupID.Name = "clSupID";
            this.clSupID.ReadOnly = true;
            // 
            // clCompName
            // 
            this.clCompName.HeaderText = "Company Name";
            this.clCompName.Name = "clCompName";
            this.clCompName.ReadOnly = true;
            // 
            // clContName
            // 
            this.clContName.HeaderText = "Contact Name";
            this.clContName.Name = "clContName";
            this.clContName.ReadOnly = true;
            // 
            // clContTitle
            // 
            this.clContTitle.HeaderText = "Contact Title";
            this.clContTitle.Name = "clContTitle";
            this.clContTitle.ReadOnly = true;
            // 
            // clAddr
            // 
            this.clAddr.HeaderText = "Address";
            this.clAddr.Name = "clAddr";
            this.clAddr.ReadOnly = true;
            // 
            // clCity
            // 
            this.clCity.HeaderText = "City";
            this.clCity.Name = "clCity";
            this.clCity.ReadOnly = true;
            // 
            // clRegion
            // 
            this.clRegion.HeaderText = "Region";
            this.clRegion.Name = "clRegion";
            this.clRegion.ReadOnly = true;
            // 
            // clPos
            // 
            this.clPos.HeaderText = "Postal Code";
            this.clPos.Name = "clPos";
            this.clPos.ReadOnly = true;
            // 
            // clCountry
            // 
            this.clCountry.HeaderText = "Country";
            this.clCountry.Name = "clCountry";
            this.clCountry.ReadOnly = true;
            // 
            // clPhone
            // 
            this.clPhone.HeaderText = "Phone";
            this.clPhone.Name = "clPhone";
            this.clPhone.ReadOnly = true;
            // 
            // clFax
            // 
            this.clFax.HeaderText = "Fax";
            this.clFax.Name = "clFax";
            this.clFax.ReadOnly = true;
            // 
            // products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.txtAddr);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.txtRegion);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtContTitle);
            this.Controls.Add(this.txtContname);
            this.Controls.Add(this.txtCompName);
            this.Controls.Add(this.txtPos);
            this.Controls.Add(this.txtSupID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvView);
            this.Name = "products";
            this.Size = new System.Drawing.Size(919, 462);
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSupID;
        private System.Windows.Forms.TextBox txtCompName;
        private System.Windows.Forms.TextBox txtContname;
        private System.Windows.Forms.TextBox txtContTitle;
        private System.Windows.Forms.TextBox txtAddr;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtPos;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSupID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCompName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clContName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clContTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn clAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clRegion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFax;
    }
}
