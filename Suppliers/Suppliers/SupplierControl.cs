using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Suppliers.Properties;

namespace Suppliers
{
    public partial class SupplierControl : UserControl
    {
        public bool Loadded = false;
        private EditSupplier editForm;
        private DeleteOptionsForm warningForm;

        public SupplierControl()
        {
            InitializeComponent();
            this._initModel();
        }

        public SupplierControl(string host, int port, string dbname, string username,
            string password, string table_name, SupplierParser parser)
        {
            this.InitializeComponent();

            SupplierParser newParser = new SupplierParser();
            dataModel = new SupplierModel(
                                this.gvSuppliers,
                                host,
                                port,
                                dbname,
                                username,
                                password,
                                "HR.Employees",
                                newParser);
            newParser.DataModel = dataModel;
            dataModel.resetControl();
        }



        private SupplierModel dataModel;

        public SupplierModel DataModel
        {
            get { return dataModel; }
        }
        protected void _initModel()
        {
            Settings  setting = new Settings();

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
           //dataModel = new SupplierModel(this.gvSuppliers, ".\\SQL2008", setting.DB_PORT, setting.DB_NAME, setting.DB_USER, setting.DB_PASS, "Production.Suppliers", newParser);

            newParser.DataModel = dataModel;

            dataModel.resetControl();
            this.editForm = new EditSupplier(dataModel);
            this.warningForm = new DeleteOptionsForm();
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
                this.editForm.clearForm();
                int selectedIndex = this.gvSuppliers.Rows.IndexOf(this.gvSuppliers.SelectedRows[0]);
                Supplier selectedItem = this.dataModel.Data[selectedIndex];
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
            this.cbCountry.Text = "";
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
            try
            {
                int idToDelete = int.Parse(this.txtSupID.Text.Trim());
                this.dataModel.deleteRows("supplierid =" + idToDelete);
                MessageBox.Show("Deleted");
                clearAll();
            }
            catch 
            {
                this.warningForm.ShowDialog();
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            this.clearAll();
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
    }
}
