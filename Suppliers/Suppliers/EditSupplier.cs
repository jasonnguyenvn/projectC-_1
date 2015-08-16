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

            this.errorProvider.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.doSave_Update();
        }

        private void showErrors(Supplier supp, int code)
        {
            if (code == -2)
            {
                if (this.txtCompName.Text.Equals(""))
                    this.errorProvider.SetError(txtCompName,
                            supp.getErrorMessage(code));
                if (this.txtContname.Text.Equals(""))
                    this.errorProvider.SetError(txtContname,
                            supp.getErrorMessage(code));
                if (this.txtContTitle.Text.Equals(""))
                    this.errorProvider.SetError(txtContTitle,
                            supp.getErrorMessage(code));
                if (this.txtAddr.Text.Equals(""))
                    this.errorProvider.SetError(txtAddr,
                            supp.getErrorMessage(code));
                if (this.txtCity.Text.Equals(""))
                    this.errorProvider.SetError(txtCity,
                            supp.getErrorMessage(code));
                if (this.cbCountry.Text.Equals(""))
                    this.errorProvider.SetError(cbCountry,
                            supp.getErrorMessage(code));
                if (this.txtPhone.Text.Equals(""))
                    this.errorProvider.SetError(txtPhone,
                            supp.getErrorMessage(code));
            }
        }

        private void doSave_Update()
        {
            this.errorProvider.Clear();
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
                showErrors(newSup, check);
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
