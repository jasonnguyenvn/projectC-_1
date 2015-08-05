namespace Productions
{
    partial class catelogy
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
            this.rtxtDiscription = new System.Windows.Forms.RichTextBox();
            this.btnCaUpdate = new System.Windows.Forms.Button();
            this.btnCaRemute = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // 
            // rtxtDiscription
            // 
            this.rtxtDiscription.Location = new System.Drawing.Point(431, 119);
            this.rtxtDiscription.Name = "rtxtDiscription";
            this.rtxtDiscription.Size = new System.Drawing.Size(204, 96);
            this.rtxtDiscription.TabIndex = 7;
            this.rtxtDiscription.Text = "";
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
            // btnCaRemute
            // 
            this.btnCaRemute.Location = new System.Drawing.Point(353, 262);
            this.btnCaRemute.Name = "btnCaRemute";
            this.btnCaRemute.Size = new System.Drawing.Size(75, 23);
            this.btnCaRemute.TabIndex = 9;
            this.btnCaRemute.Text = "Remute";
            this.btnCaRemute.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(283, 254);
            this.dataGridView1.TabIndex = 10;
            // 
            // catelogy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCaRemute);
            this.Controls.Add(this.btnCaUpdate);
            this.Controls.Add(this.rtxtDiscription);
            this.Controls.Add(this.btnCaAdd);
            this.Controls.Add(this.txtCaName);
            this.Controls.Add(this.txtCaID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "catelogy";
            this.Size = new System.Drawing.Size(672, 333);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.RichTextBox rtxtDiscription;
        private System.Windows.Forms.Button btnCaUpdate;
        private System.Windows.Forms.Button btnCaRemute;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
