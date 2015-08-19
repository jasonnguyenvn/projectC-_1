using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Customers.Properties;
using Base_Intefaces;

namespace Customers
{
    public partial class CustomerControl : UserControl, BaseControlInteface
    {


        public CustomerControl()
        {
            InitializeComponent();
            //this.gvCustomers.ContextMenuStrip = this.GridViewMenu;
            Settings setting = new Settings();

            try
            {
                CustomerParser newParser = new CustomerParser();

                dataModel = new CustomerModel(
                                    this.gvCustomers,
                                    setting.DB_HOST,
                                    setting.DB_PORT,
                                    setting.DB_NAME,
                                    setting.DB_USER,
                                    setting.DB_PASS,
                                    "Sales.Customers",
                                    newParser);
                //dataModel = new CustomerModel(this.gvCustomers, ".\\SQL2008", setting.DB_PORT, setting.DB_NAME, setting.DB_USER, setting.DB_PASS, "HR.Customers", newParser);

                newParser.DataModel = dataModel;
                this.cbCountry.Items.Clear();
                this.cbCountry.Items.AddRange(CustomerModel.GetCountries().ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this._initModel();
        }

        public CustomerControl(string host, int port, string dbname, string username,
            string password, string table_name, CustomerParser parser)
        {
            this.InitializeComponent();



            CustomerParser newParser = new CustomerParser();
            try
            {
                dataModel = new CustomerModel(
                                    this.gvCustomers,
                                    host,
                                    port,
                                    dbname,
                                    username,
                                    password,
                                    "Sales.Customers",
                                    newParser);
                newParser.DataModel = dataModel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            this._initModel();
        }

        protected void _initModel()
        {
            this.gvCustomers.Columns.Clear();

            try
            {
                dataModel.resetControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private CustomerModel dataModel;

        public CustomerModel DataModel
        {
            get { return dataModel; }
        }


        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        protected void clearAll()
        {
            this.txtCusID.Text = "";
            this.txtCompName.Text = "";
            this.txtContName.Text = "";
            this.txtContTitle.Text = "";
            this.txtAddr.Text = "";
            this.txtCity.Text = "";
            this.txtPhone.Text = "";
            this.txtFax.Text = "";
            this.cbCountry.Text = "";
            this.txtRegion.Text = "";
            this.txtPos.Text = "";
            this.gvCustomers.ClearSelection();
        }

        public void clearForm()
        {
            this.txtCusID.Text = "";
            this.txtCompName.Text = "";
            this.txtContName.Text = "";
            this.txtContTitle.Text = "";
            this.txtAddr.Text = "";
            this.txtCity.Text = "";
            this.txtRegion.Text = "";
            this.txtPos.Text = "";
            this.cbCountry.Text = "";
            this.txtPhone.Text = "";
            this.txtFax.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Customer newCus = new Customer();
            newCus.CustomerID = -1;
            newCus.CompanyName = this.txtCompName.Text;
            newCus.Contactname = this.txtContName.Text;
            newCus.ContactTitle = this.txtContTitle.Text;
            newCus.Address = this.txtAddr.Text;
            newCus.City = this.txtCity.Text;
            newCus.Region = this.txtRegion.Text;
            newCus.Postalcode = this.txtPos.Text;
            newCus.Country = this.cbCountry.Text;
            newCus.Phone = this.txtPhone.Text;
            newCus.Fax = this.txtFax.Text;

            int check = newCus.isValid();
            if (check < 0)
            {
                MessageBox.Show(newCus.getErrorMessage(check));
            }
            else
            {
                this.dataModel.insertNewRow(newCus);
                MessageBox.Show("Completed");
                clearAll();
            }
        }

      



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.txtCusID.Text.Equals(""))
            {
                MessageBox.Show("You must select a Customer first");
                return;
            }

            try
            {
                Customer updateData = new Customer();
                updateData.CustomerID = int.Parse(this.txtCusID.Text.Trim());
                updateData.CompanyName = this.txtCompName.Text;
                updateData.Contactname = this.txtContName.Text;
                updateData.ContactTitle = this.txtContTitle.Text;
                updateData.Address = this.txtAddr.Text;
                updateData.City = this.txtCity.Text;
                updateData.Region = this.txtRegion.Text;
                updateData.Postalcode = this.txtPos.Text;
                updateData.Country = this.cbCountry.Text;
                updateData.Phone = this.txtPhone.Text;
                updateData.Fax = this.txtFax.Text;

                this.dataModel.updateRow(updateData);
                MessageBox.Show("Updated");
                clearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gvCustomers.SelectedRows.Count > 0)
            {
                Customer get = new Customer();
                get.CustomerID = int.Parse(this.gvCustomers.SelectedRows[0].Cells[0].Value.ToString());
                Customer selectedItem = this.dataModel.Data[dataModel.Data.IndexOf(get)];
                this.txtCusID.Text = selectedItem.CustomerID.ToString();
                this.txtCompName.Text = selectedItem.CompanyName;
                this.txtContName.Text = selectedItem.Contactname;
                this.txtContTitle.Text = selectedItem.ContactTitle;
                this.txtAddr.Text = selectedItem.Address;
                this.txtCity.Text = selectedItem.City;
                this.txtRegion.Text = selectedItem.Region;
                this.txtPos.Text = selectedItem.Postalcode;
                this.cbCountry.Text = selectedItem.Country;
                this.txtPhone.Text = selectedItem.Phone;
                this.txtFax.Text = selectedItem.Fax;

            }
            else
            {
                this.txtCusID.Text = "";
            }
        }

        private void doDelete()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete ?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;
            int idToDelete = int.Parse(this.txtCusID.Text.Trim());
            string deleteSql = "custid =" + idToDelete;
            try
            {

                this.dataModel.deleteRows(deleteSql);
                MessageBox.Show("Deleted");
                clearAll();
            }
            catch
            {
               dialogResult = MessageBox.Show("This customer holds some orders. "
                                +"Delete it means delete all of these orders. Are you sure?",
                                    "WARING!!!", MessageBoxButtons.YesNo);
               if (dialogResult == DialogResult.No)
                   return;

               this.doDeepDelete(idToDelete);
            }
        }

        protected void doDeepDelete(int custID)
        {
            try
            {
                this.dataModel.deepDelete(custID);
                MessageBox.Show("Deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.txtCusID.Text.Equals(""))
            {
                MessageBox.Show("You must select a Customer first");
                return;
            }

            this.doDelete();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
            this.dataModel.resetControl();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            doSearch();
        }


        protected void doSearch()
        {
            try
            {
                this.dataModel.filter(txtCompName.Text, txtContName.Text, txtAddr.Text,
                    txtCity.Text, txtRegion.Text, txtPos.Text,  cbCountry.Text, txtPhone.Text, txtFax.Text); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #region BaseControlInteface Members

        public string getName()
        {
            return "Customers Manager";
        }

        public Control getThis()
        {
            return this;
        }

        bool loaded = false;
        public bool isLoaded()
        {
            return loaded;
        }

        public void resetControl()
        {
            clearAll();
        }

        public void resetData()
        {
            this.dataModel.resetControl();
        }

        public void setLoadStatus(bool status)
        {
            this.loaded = status;
        }

        #endregion
    }
}
