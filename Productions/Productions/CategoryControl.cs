using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Productions.Properties;

using Base_Intefaces;
using WinForm_Dialogs;


namespace Productions
{
    public partial class CategoryControl : UserControl, ControlInteface<CategoryModel, Category>
    {
        private CategoryModel dataModel;

        private DeleteOptionsForm warningForm;
        private bool loaded = false;

        public CategoryControl()
        {
            InitializeComponent();
            //this.gvCatetories.ContextMenuStrip = this.GridViewMenu;
            Settings setting = new Settings();

            try
            {
                CategoryParser newParser = new CategoryParser();

                dataModel = new CategoryModel(
                                    this.gvCategories,
                                    setting.DB_HOST,
                                    setting.DB_PORT,
                                    setting.DB_NAME,
                                    setting.DB_USER,
                                    setting.DB_PASS,
                                    "Production.Categories",
                                    newParser);
                dataModel = new CategoryModel(this.gvCategories, ".\\SQL2008", setting.DB_PORT, setting.DB_NAME, setting.DB_USER, setting.DB_PASS, "Production.Categories", newParser);

                newParser.DataModel = dataModel;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this._initModel();
        }

        public CategoryControl(string host, int port, string dbname, string username,
            string password, string table_name, CategoryParser parser)
        {
            this.InitializeComponent();

            

            CategoryParser newParser = new CategoryParser();
            try
            {
                dataModel = new  CategoryModel(
                                    this.gvCategories,
                                    host,
                                    port,
                                    dbname,
                                    username,
                                    password,
                                    "Production.Categories",
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
            this.gvCategories.Columns.Clear();

            try
            {
                dataModel.resetControl();
                //this.editForm = new EditCatetories(dataModel);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.warningForm = new DeleteOptionsForm("WARNING: This category holds some products", 
                                "(1) SAFETY DELETE: Deactive this category in the manager.", 
                                "(2) Delete this supplier and all of its data.");

        }
        private void btnCaAdd_Click(object sender, EventArgs e)
        {
            Category newCat = new Category();
            newCat.CategoryID = -1;
            newCat.CategoryName = txtCatName.Text;
            newCat.Description = rtxtDescription.Text;

            int check = newCat.isValid();

            if (check < -1)
            {
                MessageBox.Show(newCat.getErrorMessage(check));
            }
            else {
                this.dataModel.insertNewRow(newCat);
                //this.datamodel.resetControl();
                MessageBox.Show("Completed");
                clearAll();
            }
        }

        private void gvCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gvCategories.SelectedRows.Count>0)
            {
                int selectedIndex = this.gvCategories.Rows.IndexOf(this.gvCategories.SelectedRows[0]);
                Category selectedItem = this.dataModel.Data[selectedIndex];
                this.txtCatID.Text = selectedItem.CategoryID.ToString();
                this.txtCatName.Text = selectedItem.CategoryName;
                this.rtxtDescription.Text = selectedItem.Description;
            }
        }

        private void btnCaRemove_Click(object sender, EventArgs e)
        {
            if(this.txtCatID.Text.Equals(""))
            {
                MessageBox.Show("You should select an Category first.");
                return;
            }

            try {
                int IdToDelete = int.Parse(this.txtCatID.Text.Trim());
                this.dataModel.deleteRows("categoryid="+IdToDelete);
                MessageBox.Show("Deleted.");
                clearAll();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCaUpdate_Click(object sender, EventArgs e)
        {
            if (this.txtCatID.Text.Equals(""))
            {
                MessageBox.Show("You should select an Category first.");
                return;
            }

            try
            {
                Category updateData = new Category();
                updateData.CategoryID = int.Parse(this.txtCatID.Text.Trim());
                updateData.CategoryName = this.txtCatName.Text;
                updateData.Description = this.rtxtDescription.Text;

                //int IdOfRow = this.gvCategories.Rows.IndexOf(this.gvCategories.SelectedRows[0]);
                this.dataModel.updateRow(updateData);
                MessageBox.Show("Updated.");
                clearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void clearAll()
        {
            this.txtCatID.Text = "";
            this.txtCatName.Text = "";
            this.rtxtDescription.Text = "";

            this.gvCategories.ClearSelection();

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        #region ControlInteface<CategoryModel,Category> Members

        public CategoryModel getDataModel()
        {
            return this.dataModel;
        }

        #endregion

        #region BaseControlInteface Members

        public bool isLoaded()
        {
            return this.loaded;
        }

        public void resetControl()
        {
            this.clearAll();
        }

        public void setLoadStatus(bool status)
        {
            this.loaded = status;
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
            return "Categories Manager";
        }

        #endregion
    }
}
