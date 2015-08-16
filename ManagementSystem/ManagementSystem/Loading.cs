using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DataModel;
using Base_Intefaces;
using Employees;
using Suppliers;
using Productions;
using Orders;



namespace ManagementSystem
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
            
        }

        

        private void Loading_Load(object sender, EventArgs e)
        {
            
        }

        private void Loading_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void Loading_Activated(object sender, EventArgs e)
        {
            
        }

        private void Loading_Enter(object sender, EventArgs e)
        {
            
        }

        private void Loading_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Loading_ControlAdded(object sender, ControlEventArgs e)
        {
        }

        private void Loading_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
        }

        private void Loading_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Loading_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Alt)
            {
                e.SuppressKeyPress = true;

            }
        }
    }
}
