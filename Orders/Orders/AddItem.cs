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
        public AddItem()
        {
            InitializeComponent();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
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

            if (result.isValid() < 0)
            {
                result = null;
                return;
            }

            this.Close();
        }

        private void AddItem_Load(object sender, EventArgs e)
        {
            
        }
    }
}
