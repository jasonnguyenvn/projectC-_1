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

namespace ManagementSystem
{
    public partial class MainForm : Form
    {
        private EmployeeControl EmpControl;
        private SupplierControl SuppControl;
        private CategoryControl CatControl;
        private AboutControl aboutBox;

        private BaseControlInteface currentControl;

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
                this.currentControl = EmpControl;

                SuppControl = new SupplierControl();
                SuppControl.Dock = DockStyle.Fill;
                SuppControl.AutoSize = true;
                SuppControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                CatControl = new CategoryControl();
                CatControl.Dock = DockStyle.Fill;
                CatControl.AutoSize = true;
                CatControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            aboutBox = new AboutControl();

            
        }

        private void loadControl(BaseControlInteface control)
        {
            this.currentControl.resetControl();
            this.panel1.Controls.Clear();

            try
            {
                if (control.isLoaded() == true)
                    control.resetData();
                else control.setLoadStatus(true);
                this.panel1.Controls.Add(control.getThis());
                this.currentControl = control;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnOpenEmployees_Click(object sender, EventArgs e)
        {
            this.loadControl(this.EmpControl);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            this.loadControl(this.CatControl);
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            this.loadControl(this.SuppControl);

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
