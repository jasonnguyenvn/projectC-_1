using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Employees.Properties;
using Base_Intefaces;

namespace Employees
{
    public partial class EmployeeControl : UserControl, ControlInteface<EmployeeModel, Employee>
    {
        private EmployeeModel dataModel;
        private bool _loaded = false;

        public bool Loaded
        {
            get { return _loaded; }
            set { _loaded = value; }
        }

        public EmployeeModel DataModel
        {
            get { return dataModel; }
        }
        private EmployeeEditForm editItemForm;

        public EmployeeControl()
        {
            InitializeComponent();
            //this.gvEmployees.ContextMenuStrip = this.GridViewMenu;
            Settings setting = new Settings();

            try
            {
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
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this._initModel();
        }

        public EmployeeControl(string host, int port, string dbname, string username,
            string password, string table_name, EmployeeParser parser)
        {
            this.InitializeComponent();

            

            EmployeeParser newParser = new EmployeeParser();
            try
            {
                dataModel = new EmployeeModel(
                                    this.gvEmployees,
                                    host,
                                    port,
                                    dbname,
                                    username,
                                    password,
                                    "HR.Employees",
                                    newParser);
                newParser.DataModel = dataModel;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            this._initModel();
        }

        protected void _initModel()
        {
            this.gvEmployees.Columns.Clear();

            try
            {
                dataModel.resetControl();
                this.editItemForm = new EmployeeEditForm(dataModel);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.cbManagerID.Items.Add("");
            this.cbManagerID.Items.AddRange(dataModel.getIDItemArray("HR.Employees", 0, 1));

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.txtEmployeeID.Text = "";
            this.gvEmployees.ClearSelection();
            this.editItemForm.NewEmpMode = true;
            this.editItemForm.clearForm();
            this.editItemForm.ShowDialog();

            /*Employee newEmp = new Employee();
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
            }*/
            
        }

        protected void doUpdate()
        {
            this.txtEmployeeID.Text = "";
            this.gvEmployees.ClearSelection();
            this.editItemForm.NewEmpMode = false;
            this.editItemForm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.gvEmployees.SelectedRows.Count <= 0)
            {
                MessageBox.Show("You must select an Employee first"); 
                return;
            }

            doUpdate();

            /*try
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
            }*/
        }

        private void gvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gvEmployees.SelectedRows.Count > 0)
            {
                //int selectedIndex = this.gvEmployees.Rows.IndexOf(this.gvEmployees.SelectedRows[0]);
                Employee get = new Employee();
                get.Empid = int.Parse(this.gvEmployees.SelectedRows[0].Cells[0].Value.ToString());
                Employee selectedItem = this.dataModel.Data[dataModel.Data.IndexOf(get)];
                this.txtEmployeeID.Text = selectedItem.Empid.ToString();
                /*this.txtLastname.Text = selectedItem.Lastname;
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
                this.btnAdd.Enabled = false;*/

                this.editItemForm.NewEmpMode = false;
                this.editItemForm.setNewData(selectedItem);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.txtEmployeeID.Text.Equals(""))
            {
                MessageBox.Show("You must select an Employee first");
                return;
            }
              this.doDelete();
        }

        protected void doDelete()
        {
            
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete ?", "Delete", MessageBoxButtons.YesNo);
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
            this.txtName.Text = "";
            this.txtTitle.Text = "";
            this.txtCity.Text = "";
            this.txtRegion.Text = "";
            this.txtPostalCode.Text = "";
            this.cbCountry.Text = "";
            this.txtPhone.Text = "";
            this.cbManagerID.Text = "";

            this.gvEmployees.ClearSelection();
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataModel.resetControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.clearForm();
        }

        private void gvEmployees_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.gvEmployees.SelectedRows.Count > 0)
            {
                doUpdate();
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
                doUpdate();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
                this.doDelete();
        }

        private void gvEmployees_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right
                    && this.gvEmployees.SelectedRows.Count > 0)
            {
                
                this.GridViewMenu.Show(Cursor.Position);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.gvEmployees.ClearSelection();
            
            try
            {
                if(cbManagerID.SelectedIndex==0)
                    this.dataModel.filter(txtName.Text, txtTitle.Text, txtCity.Text,
                        txtRegion.Text, cbCountry.Text, txtPhone.Text, "");
                else
                    this.dataModel.filter(txtName.Text, txtTitle.Text, txtCity.Text,
                        txtRegion.Text, cbCountry.Text, txtPhone.Text, ((EmployeeModel.IdItem) cbManagerID.SelectedItem).Id.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        #region ControlInteface<EmployeeModel,Employee> Members

        public EmployeeModel getDataModel()
        {
            return this.dataModel;
        }

        public bool isLoaded()
        {
            return this.Loaded;
        }

        public void resetControl()
        {
            this.clearForm();
        }

        public void setLoadStatus(bool status)
        {
            this.Loaded = status;
        }

        public void resetData()
        {
            this.dataModel.resetControl();
        }

        public Control getThis()
        {
            return this;
        }

        #endregion

        #region BaseControlInteface Members

        public string getName()
        {
            return "Employees Manager";
        }

        #endregion
    }
}
