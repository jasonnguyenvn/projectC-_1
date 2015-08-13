using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Suppliers
{
    public partial class EditSupplier : Form
    {
        private SupplierModel dataModel;
        public bool AddNewMode = true;

        public EditSupplier(SupplierModel DataModel)
        {
            InitializeComponent();
            dataModel = DataModel;
        }

        public void clearForm()
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.doSave_Update();
        }

        private void doSave_Update()
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
                try
                {
                    if (this.AddNewMode == true)
                        this.dataModel.insertNewRow(newSup);
                    else
                    {
                        newSup.SupplierID = int.Parse(this.txtSupID.Text);
                        this.dataModel.updateRow(newSup);
                    }
                    
                    this.clearForm();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                }
            }
        }

    }
}
