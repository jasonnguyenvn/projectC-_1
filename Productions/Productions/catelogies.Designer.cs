namespace Productions
{
    partial class catelogies
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCaID = new System.Windows.Forms.TextBox();
            this.txtCaName = new System.Windows.Forms.TextBox();
            this.btnCaAdd = new System.Windows.Forms.Button();
            this.rtxtDescription = new System.Windows.Forms.RichTextBox();
            this.btnCaUpdate = new System.Windows.Forms.Button();
            this.btnCaRemove = new System.Windows.Forms.Button();
            this.gvCategories = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cateloryid";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cateloryname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Discription";
            // 
            // txtCaID
            // 
            this.txtCaID.Enabled = false;
            this.txtCaID.Location = new System.Drawing.Point(431, 31);
            this.txtCaID.Name = "txtCaID";
            this.txtCaID.Size = new System.Drawing.Size(204, 20);
            this.txtCaID.TabIndex = 3;
            // 
            // txtCaName
            // 
            this.txtCaName.Location = new System.Drawing.Point(431, 75);
            this.txtCaName.Name = "txtCaName";
            this.txtCaName.Size = new System.Drawing.Size(204, 20);
            this.txtCaName.TabIndex = 4;
            // 
            // btnCaAdd
            // 
            this.btnCaAdd.Location = new System.Drawing.Point(560, 262);
            this.btnCaAdd.Name = "btnCaAdd";
            this.btnCaAdd.Size = new System.Drawing.Size(75, 23);
            this.btnCaAdd.TabIndex = 6;
            this.btnCaAdd.Text = "Add";
            this.btnCaAdd.UseVisualStyleBackColor = true;
            this.btnCaAdd.Click += new System.EventHandler(this.btnCaAdd_Click);
            // 
            // rtxtDescription
            // 
            this.rtxtDescription.Location = new System.Drawing.Point(431, 119);
            this.rtxtDescription.Name = "rtxtDescription";
            this.rtxtDescription.Size = new System.Drawing.Size(204, 96);
            this.rtxtDescription.TabIndex = 7;
            this.rtxtDescription.Text = "";
            // 
            // btnCaUpdate
            // 
            this.btnCaUpdate.Location = new System.Drawing.Point(457, 262);
            this.btnCaUpdate.Name = "btnCaUpdate";
            this.btnCaUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnCaUpdate.TabIndex = 8;
            this.btnCaUpdate.Text = "Update";
            this.btnCaUpdate.UseVisualStyleBackColor = true;
            // 
            // btnCaRemove
            // 
            this.btnCaRemove.Location = new System.Drawing.Point(353, 262);
            this.btnCaRemove.Name = "btnCaRemove";
            this.btnCaRemove.Size = new System.Drawing.Size(75, 23);
            this.btnCaRemove.TabIndex = 9;
            this.btnCaRemove.Text = "Remove";
            this.btnCaRemove.UseVisualStyleBackColor = true;
            // 
            // gvCategories
            // 
            this.gvCategories.AllowUserToAddRows = false;
            this.gvCategories.AllowUserToDeleteRows = false;
            this.gvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCategories.Location = new System.Drawing.Point(21, 31);
            this.gvCategories.Name = "gvCategories";
            this.gvCategories.ReadOnly = true;
            this.gvCategories.Size = new System.Drawing.Size(283, 254);
            this.gvCategories.TabIndex = 10;
            // 
            // catelogies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gvCategories);
            this.Controls.Add(this.btnCaRemove);
            this.Controls.Add(this.btnCaUpdate);
            this.Controls.Add(this.rtxtDescription);
            this.Controls.Add(this.btnCaAdd);
            this.Controls.Add(this.txtCaName);
            this.Controls.Add(this.txtCaID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "catelogies";
            this.Size = new System.Drawing.Size(672, 333);
            ((System.ComponentModel.ISupportInitialize)(this.gvCategories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCaID;
        private System.Windows.Forms.TextBox txtCaName;
        private System.Windows.Forms.Button btnCaAdd;
        private System.Windows.Forms.RichTextBox rtxtDescription;
        private System.Windows.Forms.Button btnCaUpdate;
        private System.Windows.Forms.Button btnCaRemove;
        private System.Windows.Forms.DataGridView gvCategories;
    }
}
