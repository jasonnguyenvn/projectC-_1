using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Orders
{
    public partial class AddItem : Form
    {
        public bool AddMode = true;
        public int EditIndex = -1;
        OrderModel.OrderDetailModel model;
        public AddItem(OrderModel.OrderDetailModel model)
        {
            InitializeComponent();
            this.model = model;

        }

        Order.OrderItem result = null;

        public Order.OrderItem Result
        {
            get { return result; }
        }

        public void clearForm()
        {
            this.cbProductID.SelectedIndex = 0;
            this.txtUnitPrice.Text = "";
            this.txtQty.Text = "";
            this.txtUnitPrice.Text = "";
            result = null;
        }

        protected void doAdd()
        {
            this.errorProvider.Clear();
            this.errorProvider.Clear();
            result = new Order.OrderItem();
            if (cbProductID.SelectedIndex == 0)
                this.errorProvider.SetError(cbProductID, "CANNOT BE EMPTY");
            else
            {
                OrderModel.OrderDetailModel.IdItem idItem = (OrderModel.OrderDetailModel.IdItem)this.cbProductID.SelectedItem;
                result.Productid = idItem.Id;
            }

            try
            {
                result.Qty = int.Parse(this.txtQty.Text);
            }
            catch
            {
                this.errorProvider.SetError(txtQty, "INVALID NUMBER");
            }

            try
            {
                result.Discount = float.Parse(this.txtDiscount.Text);
            }
            catch
            {
                this.errorProvider.SetError(txtDiscount, "INVALID VALUE");
            }

            try
            {
                result.Uinitprice = float.Parse(this.txtUnitPrice.Text);
            }
            catch
            {
                this.errorProvider.SetError(txtUnitPrice, "INVALID VALUE");
            }

            if (result.isValid() < 0)
            {
                result = null;
                return;
            }

            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.doAdd();
        }

        private void AddItem_Load(object sender, EventArgs e)
        {
            this.errorProvider.Clear();
        }

        private void cbProductID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbProductID.SelectedIndex > 0)
            {
                OrderModel.OrderDetailModel.IdItem idItem = (OrderModel.OrderDetailModel.IdItem)this.cbProductID.SelectedItem;
                int Productid = idItem.Id;

                if (model.DataSource.Rows.Count > 0)
                {
                    Order.OrderItem tmp = new Order.OrderItem();
                    model.setPrimaryKey();
                    tmp.Productid = Productid;
                    DataRow r = model.DataSource.Rows.Find(Productid);
                    if (r != null)
                    {
                        MessageBox.Show("This product has aldready selected.\nPlease choose another or change the existing item.");
                        this.cbProductID.Text = "";
                        return;
                    }
                }


                float price = this.model.getUnitPrice(Productid);
                this.txtUnitPrice.Text = price.ToString();
            }
        }

        public void clearAll()
        {
            this.cbProductID.Text = "";
            this.txtUnitPrice.Text = "";
            this.txtQty.Text = "";
            this.txtDiscount.Text = "";
            this.result = null;
        }
    }
}
