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
    public partial class EditOrder : Form
    {
        OrderControl itsParent;

        public bool addNewMode = true;

        public OrderControl ItsParent
        {
            get { return itsParent; }
            set { itsParent = value; }
        }
        public OrderDetailControl listControl;
        public EditOrder()
        {
            InitializeComponent();
            listControl = new OrderDetailControl();
            listControl.Dock = DockStyle.Top;
            this.listPanel.Controls.Add(listControl);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cboxNotShipped_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cboxNotShipped.Checked == true)
                this.dtpShippedDate.Enabled = false;
            else
                this.dtpShippedDate.Enabled = true;
        }

        private void EditOrder_Load(object sender, EventArgs e)
        {
            this.listControl.Parent = this.listPanel;
            if (this.addNewMode == true)
                this.listControl.enableControls(true);
        }

        private void EditOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.listControl.enableControls(false);
            this.listControl.Parent = this.itsParent.panOrderDetail;
        }
    }
}
