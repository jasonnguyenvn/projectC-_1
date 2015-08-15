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
    public partial class UserControl1 : UserControl
    {
        private EditOrder editForm;

        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            editForm = new EditOrder();
            this.panOrderDetail.Controls.Add(editForm.gvProductDeatail);
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
