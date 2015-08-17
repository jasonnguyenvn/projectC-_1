using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Productions
{
    public partial class EditCatForm : Form
    {
        public bool AddNewMode = true;
        public Category currentData = null;
        private CategoryModel dataModel;


        public EditCatForm(CategoryModel DataModel)
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

            this.txtCatID.Text = currentData.CategoryID.ToString();
            this.txtCatName.Text = currentData.CategoryName;
            this.rtxtDescription.Text = currentData.Description;
        }

        protected void showErrors()
        {
            if (this.txtCatName.Equals(""))
                this.errorProvider.SetError(txtCatName, "THIS ITEM CANNOT BE EMPTY");
        }

        protected void doAdd_Update()
        {
            this.errorProvider.Clear();

            Category dataObj = new Category();
            dataObj.CategoryID = -1;
            dataObj.CategoryName = this.txtCatName.Text;
            dataObj.Description = this.rtxtDescription.Text;

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
                    dataObj.CategoryID = int.Parse(this.txtCatID.Text);
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
            this.rtxtDescription.Text = "";
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            doAdd_Update();
        }
    }
}
