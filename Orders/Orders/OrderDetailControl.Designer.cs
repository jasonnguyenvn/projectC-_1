﻿namespace Orders
{
    partial class OrderDetailControl
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
            this.gvProductDeatail = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.proList_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mitmAddProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmRemoveSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.itmRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnRemoveProducts = new System.Windows.Forms.Button();
            this.btnAddnewProduct = new System.Windows.Forms.Button();
            this.mitmEditProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSelector = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.gvProductDeatail)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.proList_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvProductDeatail
            // 
            this.gvProductDeatail.AllowUserToAddRows = false;
            this.gvProductDeatail.AllowUserToDeleteRows = false;
            this.gvProductDeatail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.gvProductDeatail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.gvProductDeatail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProductDeatail.ContextMenuStrip = this.proList_menu;
            this.gvProductDeatail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvProductDeatail.Location = new System.Drawing.Point(0, 20);
            this.gvProductDeatail.Name = "gvProductDeatail";
            this.gvProductDeatail.ReadOnly = true;
            this.gvProductDeatail.Size = new System.Drawing.Size(663, 99);
            this.gvProductDeatail.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRemoveAll);
            this.panel1.Controls.Add(this.btnRemoveProducts);
            this.panel1.Controls.Add(this.btnAddnewProduct);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 119);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel1.Size = new System.Drawing.Size(663, 47);
            this.panel1.TabIndex = 41;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gvProductDeatail);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.MinimumSize = new System.Drawing.Size(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.panel2.Size = new System.Drawing.Size(663, 119);
            this.panel2.TabIndex = 42;
            // 
            // proList_menu
            // 
            this.proList_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmEditProduct,
            this.itmSelector,
            this.mitmAddProduct,
            this.mitmRemoveSelected,
            this.toolStripSeparator1,
            this.itmRemoveAll});
            this.proList_menu.Name = "proList_menu";
            this.proList_menu.Size = new System.Drawing.Size(185, 126);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // mitmAddProduct
            // 
            this.mitmAddProduct.Image = global::Orders.Properties.Resources.AddTableHS;
            this.mitmAddProduct.Name = "mitmAddProduct";
            this.mitmAddProduct.Size = new System.Drawing.Size(184, 22);
            this.mitmAddProduct.Text = "Add product...";
            this.mitmAddProduct.Click += new System.EventHandler(this.addProductToolStripMenuItem_Click);
            // 
            // mitmRemoveSelected
            // 
            this.mitmRemoveSelected.Image = global::Orders.Properties.Resources.DeleteHS;
            this.mitmRemoveSelected.Name = "mitmRemoveSelected";
            this.mitmRemoveSelected.Size = new System.Drawing.Size(184, 22);
            this.mitmRemoveSelected.Text = "Remove selected items";
            // 
            // itmRemoveAll
            // 
            this.itmRemoveAll.Image = global::Orders.Properties.Resources.DeleteFolderHS;
            this.itmRemoveAll.Name = "itmRemoveAll";
            this.itmRemoveAll.Size = new System.Drawing.Size(184, 22);
            this.itmRemoveAll.Text = "Remove all itmes";
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRemoveAll.Image = global::Orders.Properties.Resources.DeleteFolderHS;
            this.btnRemoveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveAll.Location = new System.Drawing.Point(0, 5);
            this.btnRemoveAll.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(96, 42);
            this.btnRemoveAll.TabIndex = 41;
            this.btnRemoveAll.Text = "       Remove All";
            this.btnRemoveAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            // 
            // btnRemoveProducts
            // 
            this.btnRemoveProducts.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRemoveProducts.Image = global::Orders.Properties.Resources.DeleteHS1;
            this.btnRemoveProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveProducts.Location = new System.Drawing.Point(382, 5);
            this.btnRemoveProducts.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.btnRemoveProducts.Name = "btnRemoveProducts";
            this.btnRemoveProducts.Size = new System.Drawing.Size(163, 42);
            this.btnRemoveProducts.TabIndex = 40;
            this.btnRemoveProducts.Text = "Remove Selected Products";
            this.btnRemoveProducts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveProducts.UseVisualStyleBackColor = true;
            // 
            // btnAddnewProduct
            // 
            this.btnAddnewProduct.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddnewProduct.Image = global::Orders.Properties.Resources.AddTableHS;
            this.btnAddnewProduct.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAddnewProduct.Location = new System.Drawing.Point(545, 5);
            this.btnAddnewProduct.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.btnAddnewProduct.Name = "btnAddnewProduct";
            this.btnAddnewProduct.Size = new System.Drawing.Size(118, 42);
            this.btnAddnewProduct.TabIndex = 39;
            this.btnAddnewProduct.Text = "Add New Product";
            this.btnAddnewProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddnewProduct.UseVisualStyleBackColor = true;
            // 
            // mitmEditProduct
            // 
            this.mitmEditProduct.Name = "mitmEditProduct";
            this.mitmEditProduct.Size = new System.Drawing.Size(184, 22);
            this.mitmEditProduct.Text = "Edit...";
            // 
            // itmSelector
            // 
            this.itmSelector.Name = "itmSelector";
            this.itmSelector.Size = new System.Drawing.Size(181, 6);
            // 
            // OrderDetailControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "OrderDetailControl";
            this.Size = new System.Drawing.Size(663, 166);
            ((System.ComponentModel.ISupportInitialize)(this.gvProductDeatail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.proList_menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView gvProductDeatail;
        private System.Windows.Forms.Button btnRemoveProducts;
        private System.Windows.Forms.Button btnAddnewProduct;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip proList_menu;
        private System.Windows.Forms.ToolStripMenuItem mitmAddProduct;
        private System.Windows.Forms.ToolStripMenuItem mitmRemoveSelected;
        private System.Windows.Forms.ToolStripMenuItem itmRemoveAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.ToolStripMenuItem mitmEditProduct;
        private System.Windows.Forms.ToolStripSeparator itmSelector;
    }
}
