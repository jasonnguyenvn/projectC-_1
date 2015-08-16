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
        public OrderDetailControl()
        {
            InitializeComponent();
            _controls = new Control[] 
            {
                this.btnAddnewProduct,
                this.btnRemoveProducts,
                this.btnRemoveAll
            };
        }

        private Control[] _controls;


        public void enableControls(bool enable)
        {
            foreach (Control eachControl in this._controls)
            {
                eachControl.Enabled = enable;
            }
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
