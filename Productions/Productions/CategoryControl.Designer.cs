namespace Productions
{
    partial class CategoryControl
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
            this.txtCatID = new System.Windows.Forms.TextBox();
            this.txtCatName = new System.Windows.Forms.TextBox();
            this.btnCaAdd = new System.Windows.Forms.Button();
            this.rtxtDescription = new System.Windows.Forms.RichTextBox();
            this.btnCaUpdate = new System.Windows.Forms.Button();
            this.btnCaRemove = new System.Windows.Forms.Button();
            this.gvCategories = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(474, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cateloryid";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(474, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cateloryname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(474, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            // 
            // txtCatID
            // 
            this.txtCatID.Enabled = false;
            this.txtCatID.Location = new System.Drawing.Point(579, 31);
            this.txtCatID.Name = "txtCatID";
            this.txtCatID.Size = new System.Drawing.Size(204, 20);
            this.txtCatID.TabIndex = 3;
            // 
            // txtCatName
            // 
            this.txtCatName.Location = new System.Drawing.Point(579, 75);
            this.txtCatName.Name = "txtCatName";
            this.txtCatName.Size = new System.Drawing.Size(204, 20);
            this.txtCatName.TabIndex = 4;
            // 
            // btnCaAdd
            // 
            this.btnCaAdd.Location = new System.Drawing.Point(708, 262);
            this.btnCaAdd.Name = "btnCaAdd";
            this.btnCaAdd.Size = new System.Drawing.Size(75, 23);
            this.btnCaAdd.TabIndex = 6;
            this.btnCaAdd.Text = "Add";
            this.btnCaAdd.UseVisualStyleBackColor = true;
            this.btnCaAdd.Click += new System.EventHandler(this.btnCaAdd_Click);
            // 
            // rtxtDescription
            // 
            this.rtxtDescription.Location = new System.Drawing.Point(579, 119);
            this.rtxtDescription.Name = "rtxtDescription";
            this.rtxtDescription.Size = new System.Drawing.Size(204, 96);
            this.rtxtDescription.TabIndex = 7;
            this.rtxtDescription.Text = "";
            // 
            // btnCaUpdate
            // 
            this.btnCaUpdate.Location = new System.Drawing.Point(627, 262);
            this.btnCaUpdate.Name = "btnCaUpdate";
            this.btnCaUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnCaUpdate.TabIndex = 8;
            this.btnCaUpdate.Text = "Update";
            this.btnCaUpdate.UseVisualStyleBackColor = true;
            this.btnCaUpdate.Click += new System.EventHandler(this.btnCaUpdate_Click);
            // 
            // btnCaRemove
            // 
            this.btnCaRemove.Location = new System.Drawing.Point(549, 263);
            this.btnCaRemove.Name = "btnCaRemove";
            this.btnCaRemove.Size = new System.Drawing.Size(75, 23);
            this.btnCaRemove.TabIndex = 9;
            this.btnCaRemove.Text = "Remove";
            this.btnCaRemove.UseVisualStyleBackColor = true;
            this.btnCaRemove.Click += new System.EventHandler(this.btnCaRemove_Click);
            // 
            // gvCategories
            // 
            this.gvCategories.AllowUserToAddRows = false;
            this.gvCategories.AllowUserToDeleteRows = false;
            this.gvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCategories.Location = new System.Drawing.Point(21, 31);
            this.gvCategories.MultiSelect = false;
            this.gvCategories.Name = "gvCategories";
            this.gvCategories.ReadOnly = true;
            this.gvCategories.Size = new System.Drawing.Size(411, 254);
            this.gvCategories.TabIndex = 10;
            this.gvCategories.SelectionChanged += new System.EventHandler(this.gvCategories_SelectionChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(459, 262);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // catelogies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.gvCategories);
            this.Controls.Add(this.btnCaRemove);
            this.Controls.Add(this.btnCaUpdate);
            this.Controls.Add(this.rtxtDescription);
            this.Controls.Add(this.btnCaAdd);
            this.Controls.Add(this.txtCatName);
            this.Controls.Add(this.txtCatID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "catelogies";
            this.Size = new System.Drawing.Size(812, 311);
            ((System.ComponentModel.ISupportInitialize)(this.gvCategories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCatID;
        private System.Windows.Forms.TextBox txtCatName;
        private System.Windows.Forms.Button btnCaAdd;
        private System.Windows.Forms.RichTextBox rtxtDescription;
        private System.Windows.Forms.Button btnCaUpdate;
        private System.Windows.Forms.Button btnCaRemove;
        private System.Windows.Forms.DataGridView gvCategories;
        private System.Windows.Forms.Button btnClear;
    }
}
