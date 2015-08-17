using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Suppliers.Properties;
using Base_Intefaces;
using WinForm_Dialogs;

namespace Suppliers
{
    public partial class SupplierControl : UserControl , ControlInteface<SupplierModel, Supplier>
    {
        public bool Loadded = false;
        private EditSupplier editForm;
        private DeleteOptionsForm warningForm;

        public SupplierControl()
        {
            InitializeComponent();
            //this.gvSuppliers.ContextMenuStrip = this.GridViewMenu;
            Settings setting = new Settings();

            try
            {
                SupplierParser newParser = new SupplierParser();

                dataModel = new SupplierModel(
                                    this.gvSuppliers,
                                    setting.DB_HOST,
                                    setting.DB_PORT,
                                    setting.DB_NAME,
                                    setting.DB_USER,
                                    setting.DB_PASS,
                                    "Production.Suppliers",
                                    newParser);
                //dataModel = new SupplierModel(this.gvSuppliers, ".\\SQL2008", setting.DB_PORT, setting.DB_NAME, setting.DB_USER, setting.DB_PASS, "HR.Suppliers", newParser);

                newParser.DataModel = dataModel;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this._initModel();
        }

        public SupplierControl(string host, int port, string dbname, string username,
            string password, string table_name, SupplierParser parser)
        {
            this.InitializeComponent();

            

            SupplierParser newParser = new SupplierParser();
            try
            {
                dataModel = new SupplierModel(
                                    this.gvSuppliers,
                                    host,
                                    port,
                                    dbname,
                                    username,
                                    password,
                                    "Production.Suppliers",
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
            this.gvSuppliers.Columns.Clear();

            try
            {
                dataModel.resetControl();
                this.editForm = new EditSupplier(dataModel);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.warningForm = new DeleteOptionsForm();

        }


        private SupplierModel dataModel;

        public SupplierModel DataModel
        {
            get { return dataModel; }
        }
       

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.gvSuppliers.ClearSelection();
            this.txtSupID.Text = "";
            this.editForm.clearForm();
            this.editForm.AddNewMode = true;
            this.editForm.ShowDialog();


            /*Supplier newSup = new Supplier();
            newSup.SupplierID = -1;
            newSup.CompanyName = this.txtCompName.Text;
            newSup.Contactname = this.txtContname.Text;
            newSup.ContactTitle = this.txtContTitle.Text;
            newSup.Address = this.txtAddr.Text;
            newSup.City = this.txtCity.Text;
            newSup.Region = this.txtRegion.Text;
            newSup.Postalcode = this.txtPos.Text;
            newSup.Country = this.cbCountry.Text;
            newSup.Phone = this.txtPhone.Text;
            newSup.Fax = this.txtFax.Text;

            int check = newSup.isValid();
            if (check < 0)
            {
                MessageBox.Show(newSup.getErrorMessage(check));
            }
            else
            {
                this.dataModel.insertNewRow(newSup);
                MessageBox.Show("Completed");
                clearAll();
            }*/
        }

        private void doUpdate()
        {
            this.gvSuppliers.ClearSelection();
            this.txtSupID.Text = "";
            this.editForm.AddNewMode = false;
            this.editForm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.txtSupID.Text.Equals(""))
            {
                MessageBox.Show("You must select a Supplier first");
                return;
            }

            this.doUpdate();
            /*
            try
            {
                Supplier updateData = new Supplier();
                updateData.SupplierID = int.Parse(this.txtSupID.Text.Trim());
                updateData.CompanyName = this.txtCompName.Text;
                updateData.Contactname = this.txtContname.Text;
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
            }*/
        }



        private void gvSuppliers_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gvSuppliers.SelectedRows.Count > 0)
            {
                Supplier get = new Supplier();
                get.SupplierID = int.Parse(this.gvSuppliers.SelectedRows[0].Cells[0].Value.ToString());
                Supplier selectedItem = this.dataModel.Data[dataModel.Data.IndexOf(get)];
                this.txtSupID.Text = selectedItem.SupplierID.ToString();
                this.editForm.txtSupID.Text = selectedItem.SupplierID.ToString();
                this.editForm.txtCompName.Text = selectedItem.CompanyName;
                this.editForm.txtContname.Text = selectedItem.Contactname;
                this.editForm.txtContTitle.Text = selectedItem.ContactTitle;
                this.editForm.txtAddr.Text = selectedItem.Address;
                this.editForm.txtCity.Text = selectedItem.City;
                this.editForm.txtRegion.Text = selectedItem.Region;
                this.editForm.txtPos.Text = selectedItem.Postalcode;
                this.editForm.cbCountry.Text = selectedItem.Country;
                this.editForm.txtPhone.Text = selectedItem.Phone;
                this.editForm.txtFax.Text = selectedItem.Fax;

            }
        }

        protected void clearAll()
        {
            this.txtSupID.Text = "";
            this.txtCompName.Text = "";
            this.txtContname.Text = "";
            this.txtAddr.Text = "";
            this.txtCity.Text = "";
            this.txtPhone.Text = "";
            this.txtFax.Text = "";
            this.gvSuppliers.ClearSelection();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.txtSupID.Text.Equals(""))
            {
                MessageBox.Show("You must select a Supplier first");
                return;
            }

            this.doDelete();
            
        }

        private void doDelete()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete ?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;
            int idToDelete = int.Parse(this.txtSupID.Text.Trim());
            string deleteSql = "supplierid =" + idToDelete;
            try
            {

                this.dataModel.deleteRows(deleteSql);
                MessageBox.Show("Deleted");
                clearAll();
            }
            catch 
            {
                this.warningForm.ShowDialog();
                UserOption result = this.warningForm.GetUserOption;
                if (result == UserOption.Option1)
                    this.dataModel.SafetyDelete(deleteSql);
                if (result == UserOption.Option2)
                {
                    this.doBadDelete(idToDelete);
                }
            }
        }

        private void doBadDelete(int idToDelete)
        {
            try
            {
                Supplier supp = this.dataModel.BadDelete(idToDelete);
                if (supp != null)
                    MessageBox.Show("DELETE SUCCESSFULLY");
                else
                    MessageBox.Show("THIS CATEGORY'S PRODUCTS MAY BE LIST ON ORDER. CANNOT DELETE!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("THIS CATEGORY'S PRODUCTS MAY BE LIST ON ORDER. CANNOT DELETE!");
                MessageBox.Show(ex.Message);
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.gvSuppliers.ClearSelection();

            try
            {
                this.dataModel.filter(txtCompName.Text, txtContname.Text, txtAddr.Text,
                    txtCity.Text, cbCountry.Text, txtPhone.Text, txtFax.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            this.clearAll();
            try
            {
                this.dataModel.resetControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gvSuppliers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.gvSuppliers.SelectedRows.Count > 0)
            {
                doUpdate();
            }
        }

        private void meUpdate_Click(object sender, EventArgs e)
        {
            if (this.gvSuppliers.SelectedRows.Count > 0)
            {
                doUpdate();
            }
        }

        private void meDelete_Click(object sender, EventArgs e)
        {
            if (this.gvSuppliers.SelectedRows.Count > 0)
            {
                doDelete();
            }
        }

        private void gvSuppliers_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right
                    && this.gvSuppliers.SelectedRows.Count > 0)
            {

                this.contextMenu.Show(Cursor.Position);
            }
        }




        #region ControlInteface<SupplierModel,Supplier> Members

        public SupplierModel getDataModel()
        {
            return this.dataModel;
        }

        public bool isLoaded()
        {
            return this.Loadded;
        }

        public void resetControl()
        {
            this.clearAll();
        }

        public void setLoadStatus(bool status)
        {
            this.Loadded = status;
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
            return "Suppliers Manager";
        }

        #endregion
    }
}
