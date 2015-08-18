using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Orders
{
    public partial class EditShipperForm : Form
    {
        public bool AddNewMode = true;
        public Shipper currentData = null;
        private ShipperModel dataModel;


        public EditShipperForm(ShipperModel DataModel)
        {
            InitializeComponent();
            this.dataModel = DataModel;
        }

        private void EditCatForm_Load(object sender, EventArgs e)
        {
            this.errorProvider.Clear();
            if (AddNewMode == true)
            {
                currentData = null;
                this.clearForm();
            }
            else
                this.loadCurrentData();
        }

        protected void loadCurrentData()
        {
            if (currentData == null)
                return;

            this.txtCatID.Text = currentData.ShipperID.ToString();
            this.txtCatName.Text = currentData.CompanyName;
            this.txtPhone.Text = currentData.Phone;
        }

        protected void showErrors()
        {
            if (this.txtCatName.Equals(""))
                this.errorProvider.SetError(txtCatName, "THIS ITEM CANNOT BE EMPTY");
        }

        protected void doAdd_Update()
        {
            this.errorProvider.Clear();

            Shipper dataObj = new Shipper();
            dataObj.ShipperID = -1;
            dataObj.CompanyName = this.txtCatName.Text;
            dataObj.Phone = this.txtPhone.Text;

            int check = dataObj.isValid();

            if (check < 0)
            {
                this.showErrors();
                return;
            }

            try
            {
                if (this.AddNewMode == true)
                {
                    this.dataModel.insertNewRow(dataObj);
                }
                else
                {
                    dataObj.ShipperID = int.Parse(this.txtCatID.Text);
                    this.dataModel.updateRow(dataObj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.clearForm();
                this.Close();
            }

        }


        public void clearForm()
        {
            this.txtCatID.Text = "";
            this.txtCatName.Text = "";
            this.txtPhone.Text = "";
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            doAdd_Update();
        }
    }
}
