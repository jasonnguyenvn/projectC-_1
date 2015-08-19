using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Orders
{
    public partial class OrderDetailControl : UserControl
    {
        AddItem addForm;
        OrderModel.OrderDetailModel dataModel;

        public OrderDetailControl(OrderModel.OrderDetailModel dataModel)
        {
            InitializeComponent();
            _controls = new Control[] 
            {
                this.btnAddnewProduct,
                this.btnRemoveProducts,
                this.btnRemoveAll
            };
            this.dataModel = dataModel;
            addForm = new AddItem(this.dataModel);
        }

        private Control[] _controls;


        public void enableControls(bool enable)
        {
            foreach (Control eachControl in this._controls)
            {
                eachControl.Enabled = enable;
            }
        }

        protected void doAdd()
        {
            addForm.clearAll();
            addForm.cbProductID.Items.Clear();
            addForm.cbProductID.Items.Add("");
            addForm.cbProductID.Items.AddRange(this.dataModel.getIDItemList("Production.Products", 0, 1, " discontinued=0" ).ToArray());
            addForm.ShowDialog();
            if (addForm.Result == null)
                return;
            if (addForm.AddMode == true)
                dataModel.DataSource.Rows.Add(addForm.Result.convertToRow());
            else
            {
                DataRow row = dataModel.DataSource.Rows[addForm.EditIndex];
                object[] rowData = addForm.Result.convertToRow();
                for(int i=0; i<row.Table.Columns.Count;i++)
                {
                    row[i] = rowData[i];
                }
               // foreach(DataColumn col in row.
            }

        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnAddnewProduct_Click(object sender, EventArgs e)
        {
            doAdd();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            this.doRemoveAll();
        }

        protected void doRemoveAll()
        {
            int count = this.gvProductDeatail.Rows.Count;
            this.removeItems(0, count - 1);
        }

        private void btnRemoveProducts_Click(object sender, EventArgs e)
        {
            this.doRemoveItems();

        }

        protected void doRemoveItems()
        {
            int count = this.gvProductDeatail.SelectedRows.Count;
            if (count <= 0)
            {
                MessageBox.Show("YOU SHOUD SELECT ITEMS FIRST");
                return;
            }
            int start = this.gvProductDeatail.Rows.IndexOf(gvProductDeatail.SelectedRows[0]);
            int end = this.gvProductDeatail.Rows.IndexOf(gvProductDeatail.SelectedRows[count - 1]);
            this.removeItems(start, end);
        }

        private void removeItems(int start, int end)
        {
            if (end < start)
            {
                int tmp = end;
                end = start;
                start = tmp;
            }
            try
            {
                for (int i = start; i <= end; i++)
                {
                    this.dataModel.DataSource.Rows.RemoveAt(start);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
