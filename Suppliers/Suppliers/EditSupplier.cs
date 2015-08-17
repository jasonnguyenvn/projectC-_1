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
            Supplier dataObj = new Supplier();
            dataObj.SupplierID = -1;
            dataObj.CompanyName = this.txtCompName.Text;
            dataObj.Contactname = this.txtContname.Text;
            dataObj.ContactTitle = this.txtContTitle.Text;
            dataObj.Address = this.txtAddr.Text;
            dataObj.City = this.txtCity.Text;
            dataObj.Region = this.txtRegion.Text;
            dataObj.Postalcode = this.txtPos.Text;
            dataObj.Country = this.cbCountry.Text;
            dataObj.Phone = this.txtPhone.Text;
            dataObj.Fax = this.txtFax.Text;

            int check = dataObj.isValid();
            if (check < 0)
            {
                showErrors(dataObj, check);
            }
            else
            {
                try
                {
                    if (this.AddNewMode == true)
                        this.dataModel.insertNewRow(dataObj);
                    else
                    {
                        dataObj.SupplierID = int.Parse(this.txtSupID.Text);
                        this.dataModel.updateRow(dataObj);
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
