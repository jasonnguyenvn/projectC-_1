using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataModel;
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
            this.cbManagerID.Items.Add("");
            this.cbManagerID.Items.AddRange(dataModel.getIDItemArray("HR.Employees", 0, 1));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            doUpdate_Add();
        }

        protected void showErrors(Employee empData, int [] errorSet)
        {
            foreach (int eachError in errorSet)
            {
                if (eachError == -1)
                {
                    if(this.txtLastname.Text.Equals(""))
                        this.errProvider.SetError(this.txtLastname,
                            empData.getErrorMessage(eachError));
                    if (this.txtFirstname.Text.Equals(""))
                        this.errProvider.SetError(this.txtFirstname,
                            empData.getErrorMessage(eachError));
                    if (this.txtTitle.Text.Equals(""))
                        this.errProvider.SetError(this.txtTitle,
                            empData.getErrorMessage(eachError));
                    if (this.cbTitleofCourtesy.Text.Equals(""))
                        this.errProvider.SetError(this.cbTitleofCourtesy,
                            empData.getErrorMessage(eachError));
                    if (this.txtAddress.Text.Equals(""))
                        this.errProvider.SetError(this.txtAddress,
                            empData.getErrorMessage(eachError));
                    if (this.txtCity.Text.Equals(""))
                        this.errProvider.SetError(this.txtCity,
                            empData.getErrorMessage(eachError));
                    if (this.cbCountry.Text.Equals(""))
                        this.errProvider.SetError(this.cbCountry,
                            empData.getErrorMessage(eachError));
                    if (this.txtPhone.Text.Equals(""))
                        this.errProvider.SetError(this.txtPhone,
                            empData.getErrorMessage(eachError));
                }
                if (eachError == -5)
                {
                    this.errProvider.SetError(this.dTPBirthday,
                        empData.getErrorMessage(eachError));
                }
            }
        }

        protected void doUpdate_Add()
        {
            this.errProvider.Clear();
            Employee newEmp = new Employee();
            newEmp.Empid = -1;
            newEmp.Lastname = this.txtLastname.Text;
            newEmp.Firstname = this.txtFirstname.Text;
            newEmp.Title = this.txtTitle.Text;
            newEmp.Titleofcourtesy = this.cbTitleofCourtesy.Text;
            newEmp.Birthdate = this.dTPBirthday.Value;
            newEmp.Hiredate = this.dTPHireday.Value;
            newEmp.Address = this.txtAddress.Text;
            newEmp.City = this.txtCity.Text;
            newEmp.Region = this.txtRegion.Text;
            newEmp.Postalcode = this.txtPostalCode.Text;
            newEmp.Country = this.cbCountry.Text;
            newEmp.Phone = this.txtPhone.Text;
            try
            {
                EmployeeModel.IdItem cbItem = (EmployeeModel.IdItem)this.cbManagerID.SelectedItem;
                newEmp.Mgrid = cbItem.Id;
            }
            catch { newEmp.Mgrid = -1; }
            newEmp.JobStatus = true;

            try
            {

                int[] check = newEmp.isValid_multi();

                if (check.Length>0)
                {
                    this.showErrors(newEmp, check);

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
            this.cbTitleofCourtesy.Text = "";
            this.dTPBirthday.Value = DateTime.Now;
            this.dTPHireday.Value = DateTime.Now;
            this.txtAddress.Text = "";
            this.txtCity.Text = "";
            this.txtRegion.Text = "";
            this.txtPostalCode.Text = "";
            this.cbCountry.Text = "";
            this.txtPhone.Text = "";
            this.cbManagerID.Text = "";
            this.btnSave.Enabled = true;
            this.errProvider.Clear();
        }

        public void setNewData(Employee data)
        {
            this.txtEmployeeID.Text = data.Empid.ToString();
            this.txtLastname.Text = data.Lastname;
            this.txtFirstname.Text = data.Firstname;
            this.txtTitle.Text = data.Title;
            this.cbTitleofCourtesy.Text = data.Titleofcourtesy;
            this.dTPBirthday.Value = data.Birthdate;
            this.dTPHireday.Value = data.Hiredate;
            this.txtAddress.Text = data.Address;
            this.txtCity.Text = data.City;
            this.txtRegion.Text = data.Region;
            this.txtPostalCode.Text = data.Postalcode;
            this.cbCountry.Text = data.Country;
            this.txtPhone.Text = data.Phone;

            try
            {
                EmployeeModel.IdItem cbItem = new EmployeeModel.IdItem();
                cbItem.Id = data.Mgrid;
                this.cbManagerID.SelectedIndex = this.cbManagerID.Items.IndexOf((object)cbItem);
            }
            catch
            {
                this.cbManagerID.SelectedIndex = 0;
            }
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            this.clearForm();
        }

        private void EmployeeEditForm_Load(object sender, EventArgs e)
        {
            this.errProvider.Clear();
        }


    }
}
