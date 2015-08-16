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
        public EditOrder()
        {
            InitializeComponent();
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
            this.gvProductDeatail.Parent = this.listPanel;
        }
    }
}
