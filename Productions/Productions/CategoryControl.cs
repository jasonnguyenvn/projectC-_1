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

        private EditCatForm editForm;

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
                this.editForm = new EditCatForm(dataModel);
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

        private void gvCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gvCategories.SelectedRows.Count > 0)
            {
                Category get = new Category();
                get.CategoryID = int.Parse(this.gvCategories.SelectedRows[0].Cells[0].Value.ToString());
                Category selectedItem = this.dataModel.Data[dataModel.Data.IndexOf(get)];
                this.txtSelectedID.Text = selectedItem.CategoryID.ToString();
                this.editForm.currentData = selectedItem;
            }
            else
            {
                this.txtSelectedID.Text = "";
            }
        }


        protected void clearAll()
        {
            this.txtSelectedID.Text = "";
            this.txtDescription.Text = "";
            this.txtDescription.Text = "";

            this.gvCategories.ClearSelection();

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.editForm.AddNewMode = true;
            this.editForm.ShowDialog();
            this.gvCategories.ClearSelection();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.txtSelectedID.Text.Equals(""))
            {
                MessageBox.Show("You should select an Category first.");
                return;
            }
            this.editForm.AddNewMode = false;
            this.editForm.ShowDialog();
            this.gvCategories.ClearSelection();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.txtSelectedID.Text.Equals(""))
            {
                MessageBox.Show("You should select an Category first.");
                return;
            }
            this.doDelete();
        }

        protected void doDelete()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete ?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;

            int idToDelete = int.Parse(this.txtSelectedID.Text);
            string deleteSql = "categoryid=" + idToDelete;
            try
            {
                dataModel.deleteRows(deleteSql);
            }
            catch
            {
                this.warningForm.ShowDialog();
                UserOption result = this.warningForm.GetUserOption;
                if (result == UserOption.Option1)
                    this.dataModel.SafeDelete(idToDelete);
                if (result == UserOption.Option2)
                {
                    this.doBadDelete(idToDelete);
                }
            }

        }

        protected void doBadDelete(int idToDelete)
        {
            try
            {
                Category supp = this.dataModel.BadDelete(idToDelete);
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
            doSearch();
        }

        public void doSearch()
        {
            this.gvCategories.ClearSelection();
            try
            {
                string newFilter = " ";
                newFilter += this.dataModel.filter(this.txtName.Text, this.txtDescription.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
