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
    public partial class Suppliers : UserControl
    {
        public Suppliers()
        {
            InitializeComponent();
            this._initModel();
        }
        private SupplierModel dataModel;
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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Supplier newSup = new Supplier();
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
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.txtSupID.Text.Equals(""))
            {
                MessageBox.Show("You must select a Supplier first");
                return;
            }

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
            }
        }

        private void gvSuppliers_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gvSuppliers.SelectedRows.Count > 0)
            {
                int selectedIndex = this.gvSuppliers.Rows.IndexOf(this.gvSuppliers.SelectedRows[0]);
                Supplier selectedItem = this.dataModel.Data[selectedIndex];
                this.txtSupID.Text = selectedItem.SupplierID.ToString();
                this.txtCompName.Text = selectedItem.CompanyName;
                this.txtContname.Text = selectedItem.Contactname;
                this.txtContTitle.Text = selectedItem.ContactTitle;
                this.txtAddr.Text = selectedItem.Address;
                this.txtCity.Text = selectedItem.City;
                this.txtRegion.Text = selectedItem.Region;
                this.txtPos.Text = selectedItem.Postalcode;
                this.cbCountry.Text = selectedItem.Country;
                this.txtPhone.Text = selectedItem.Phone;
                this.txtFax.Text = selectedItem.Fax;

            }
        }

        protected void clearAll()
        {
            this.txtSupID.Text = "";
            this.txtCompName.Text = "";
            this.txtContname.Text = "";
            this.txtContTitle.Text = "";
            this.txtAddr.Text = "";
            this.txtCity.Text = "";
            this.txtRegion.Text = "";
            this.txtPos.Text = "";
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

            try
            {
                int idToDelete = int.Parse(this.txtSupID.Text.Trim());
                this.dataModel.deleteRows("supplierid =" + idToDelete );
                MessageBox.Show("Deleted");
                clearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
