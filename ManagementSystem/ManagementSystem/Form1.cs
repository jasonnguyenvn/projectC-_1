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

using System.Threading;

namespace ManagementSystem
{
    public partial class MainForm : Form
    {
        private EmployeeControl EmpControl;
        private SupplierControl SuppControl;
        private ProductControl ProControl;
        private CategoryControl CatControl;
        private OrderControl OrdControl;
        private AboutControl aboutBox;



        private BaseControlInteface currentControl;

        public MainForm()
        {
            InitializeComponent();
            this.initControls();
        }

        Loading loadForm;

        private void initControls()
        {
            loadForm = new Loading();
            loadForm.Owner = this;
            

            Thread th1 = new Thread(new ThreadStart(initDataControls));

            th1.Start();
            loadForm.ShowDialog();
            //loadForm.ShowDialog();

            this.currentControl = EmpControl;

            aboutBox = new AboutControl();
            
        }

        private void initDataControls()
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

                ProControl = new ProductControl();
                ProControl.Dock = DockStyle.Fill;
                ProControl.AutoSize = true;
                ProControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                CatControl = new CategoryControl();
                CatControl.Dock = DockStyle.Fill;
                CatControl.AutoSize = true;
                CatControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                OrdControl = new OrderControl();
                OrdControl.Dock = DockStyle.Fill;
                OrdControl.AutoSize = true;
                OrdControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                System.Threading.Thread.Sleep(500);
                this.Invoke(new CloseDelegate(loadForm.Close));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public delegate void CloseDelegate();


        private void loadControl(BaseControlInteface control)
        {
            this.currentControl.resetControl();
            this.panel1.Controls.Clear();
            //System.Threading.Thread.Sleep(100);
            try
            {
                if (control.isLoaded() == true)
                    control.resetData();
                else control.setLoadStatus(true);
                this.panel1.Controls.Add(control.getThis());
                this.currentControl = control;
                this.Text = this.currentControl.getName() + " - Company Mangement";

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
            this.loadControl(this.ProControl);
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
            this.loadControl(this.OrdControl);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(this.aboutBox);
            this.Text = "About Company Mangement 0.6.9.1";
        }

        private void btnShippers_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(this.picHome);
            this.Text = "Company Mangement";
        }
    }
}
