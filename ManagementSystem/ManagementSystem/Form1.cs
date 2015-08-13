using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DataModel;
using Employees;
using Suppliers;

namespace ManagementSystem
{
    public partial class MainForm : Form
    {
        private EmployeeControl EmpControl;
        private SupplierControl SuppControl;
        private AboutControl aboutBox;

        public MainForm()
        {
            InitializeComponent();
            this.initControls();
        }

        private void initControls()
        {
            try
            {
                EmpControl = new EmployeeControl();
                EmpControl.Dock = DockStyle.Fill;
                EmpControl.AutoSize = true;
                EmpControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                SuppControl = new SupplierControl();
                SuppControl.Dock = DockStyle.Fill;
                SuppControl.AutoSize = true;
                SuppControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            aboutBox = new AboutControl();

            
        }

        private void btnOpenEmployees_Click(object sender, EventArgs e)
        {
            try
            {
                this.panel1.Controls.Clear();
                if (this.EmpControl.Loaded == true)
                    this.EmpControl.DataModel.resetControl();
                else this.EmpControl.Loaded = true;
                this.panel1.Controls.Add(this.EmpControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            try
            {
                if (this.SuppControl.Loadded == true)
                    this.SuppControl.DataModel.resetControl();
                else this.SuppControl.Loadded = true;
                this.panel1.Controls.Add(this.SuppControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
        }

        private void btnOders_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(this.aboutBox);
        }
    }
}
