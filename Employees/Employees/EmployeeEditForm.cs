using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Employees
{
    public partial class EmployeeEditForm : Form
    {
        private bool newEmpMode = true;

        public bool NewEmpMode
        {
            get { return newEmpMode; }
            set { newEmpMode = value; }
        }
        protected EmployeeModel dataModel;


        public EmployeeEditForm(EmployeeModel _dataModel)
        {
            InitializeComponent();
            this.dataModel = _dataModel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            doUpdate_Add();
        }

        protected void doUpdate_Add()
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

            try
            {

                int check = newEmp.isValid();

                if (check < 0)
                {
                    MessageBox.Show(newEmp.getErrorMessage(check));

                }
                else
                {
                    if (this.newEmpMode == true)
                        this.dataModel.insertNewRow(newEmp);
                    else
                    {
                        newEmp.Empid = int.Parse(this.txtEmployeeID.Text.Trim());
                        this.dataModel.updateRow(newEmp);
                    }
                    this.clearForm();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void clearForm()
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
            this.btnSave.Enabled = true;
        }

        public void setNewData(Employee data)
        {
            this.txtEmployeeID.Text = data.Empid.ToString();
            this.txtLastname.Text = data.Lastname;
            this.txtFirstname.Text = data.Firstname;
            this.txtTitle.Text = data.Title;
            this.txtTitleofCourtesy.Text = data.Titleofcourtesy;
            this.dTPBirthday.Value = data.Birthdate;
            this.dTPHireday.Value = data.Hiredate;
            this.txtAddress.Text = data.Address;
            this.txtCity.Text = data.City;
            this.txtRegion.Text = data.Region;
            this.txtPostalCode.Text = data.Postalcode;
            this.txtCountry.Text = data.Country;
            this.txtPhone.Text = data.Phone;
            this.txtManagerID.Text = data.Mgrid.ToString();
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            this.clearForm();
        }


    }
}
