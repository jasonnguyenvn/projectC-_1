using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Employees.Properties;

namespace Employees
{
    public partial class Employees : UserControl
    {
        private EmployeeModel dataModel;
        public Employees()
        {
            InitializeComponent();
            this._initModel();
        }

        protected void _initModel()
        {
            Settings setting = new Settings();

            EmployeeParser newParser = new EmployeeParser();

            dataModel = new EmployeeModel(
                                this.gvEmployees,
                                setting.DB_HOST,
                                setting.DB_PORT,
                                setting.DB_NAME,
                                setting.DB_USER,
                                setting.DB_PASS,
                                "HR.Employees",
                                newParser);
            //dataModel = new EmployeeModel(this.gvEmployees, ".\\SQL2008", setting.DB_PORT, setting.DB_NAME, setting.DB_USER, setting.DB_PASS, "HR.Employees", newParser);

            newParser.DataModel = dataModel;

            dataModel.resetControl();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Employee newEmp = new Employee();
            newEmp.Empid = -1;
            newEmp.Lastname = this.txtLastname.Text;
            newEmp.Firstname = this.txtFirstname.Text;
            newEmp.Title = this.txtTitle.Text;
            newEmp.Titleofcourtesy = this.txtTitleofCourtesy.Text;
            newEmp.Birthdate = this.dTPBirthday.Value;
            newEmp.Hiredate = this.dTPHireday.Value;
            newEmp.Address = this.txtAddress.Text;
            newEmp.City = this.txtCity.Text;
            newEmp.Region = this.txtRegion.Text;
            newEmp.Postalcode = this.txtPostalCode.Text;
            newEmp.Country = this.txtCountry.Text;
            newEmp.Phone = this.txtPhone.Text;
            try
            {
                newEmp.Mgrid = int.Parse(this.txtManagerID.Text);
            }
            catch { newEmp.Mgrid = -1; }


            int check = newEmp.isValid();

            if (check < 0)
            {
                MessageBox.Show(newEmp.getErrorMessage(check));

            }
            else
            {
                this.dataModel.insertNewRow(newEmp);
                MessageBox.Show("Completed adding");
                this.clearForm();
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(this.txtEmployeeID.Text.Equals(""))
            {
                MessageBox.Show("You must select an Employee first"); 
                return;
            }
            try
            {
                Employee updateEmp = new Employee();
                updateEmp.Empid = int.Parse(this.txtEmployeeID.Text.Trim());
                updateEmp.Lastname = this.txtLastname.Text;
                updateEmp.Firstname = this.txtFirstname.Text;
                updateEmp.Title = this.txtTitle.Text;
                updateEmp.Titleofcourtesy = this.txtTitleofCourtesy.Text;
                updateEmp.Birthdate = this.dTPBirthday.Value;
                updateEmp.Hiredate = this.dTPHireday.Value;
                updateEmp.Address = this.txtAddress.Text;
                updateEmp.City = this.txtCity.Text;
                updateEmp.Region = this.txtRegion.Text;
                updateEmp.Postalcode = this.txtPostalCode.Text;
                updateEmp.Country = this.txtCountry.Text;
                updateEmp.Phone = this.txtPhone.Text;

                try
                {
                    updateEmp.Mgrid = int.Parse(this.txtManagerID.Text);
                }
                catch { updateEmp.Mgrid = -1; }

                this.dataModel.updateRow(updateEmp);
                MessageBox.Show("Updated !");
                this.clearForm();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gvEmployees.SelectedRows.Count > 0)
            {
                int selectedIndex = this.gvEmployees.Rows.IndexOf(this.gvEmployees.SelectedRows[0]);
                Employee selectedItem = this.dataModel.Data[selectedIndex];
                this.txtEmployeeID.Text = selectedItem.Empid.ToString();
                this.txtLastname.Text = selectedItem.Lastname;
                this.txtFirstname.Text = selectedItem.Firstname;
                this.txtTitle.Text = selectedItem.Title;
                this.txtTitleofCourtesy.Text = selectedItem.Titleofcourtesy;
                this.dTPBirthday.Value = selectedItem.Birthdate;
                this.dTPHireday.Value = selectedItem.Hiredate;
                this.txtAddress.Text = selectedItem.Address;
                this.txtCity.Text = selectedItem.City;
                this.txtRegion.Text = selectedItem.Region;
                this.txtPostalCode.Text = selectedItem.Postalcode;
                this.txtCountry.Text = selectedItem.Country;
                this.txtPhone.Text = selectedItem.Phone;
                this.txtManagerID.Text = selectedItem.Mgrid.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.txtEmployeeID.Text.Equals(""))
            {
                MessageBox.Show("You must select an Employee first");
                return;
            }
           
            DialogResult dialogResult = MessageBox.Show("Are you sure to Delete ?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int ID = int.Parse(this.txtEmployeeID.Text.Trim());
                this.dataModel.deleteRows(" empid=" + ID);
                this.clearForm(); 
            }
          
        }

        private void clearForm()
        {
            this.txtEmployeeID.Text = "";
            this.txtLastname.Text = "";
            this.txtFirstname.Text = "";
            this.txtTitle.Text = "";
            this.txtTitleofCourtesy.Text = "";
            this.dTPBirthday.Value = DateTime.Now;
            this.dTPHireday.Value = DateTime.Now;
            this.txtAddress.Text = "";
            this.txtCity.Text = "";
            this.txtRegion.Text = "";
            this.txtPostalCode.Text = "";
            this.txtCountry.Text = "";
            this.txtPhone.Text = "";
            this.txtManagerID.Text = "";

            this.gvEmployees.ClearSelection();
        }
<<<<<<< HEAD

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            this.clearForm();
        }
=======
>>>>>>> 43ab0f06ba906f00cba59a80b347a31f728e1a82
    }
}
