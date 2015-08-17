using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Base_Intefaces;

namespace Productions
{
    public partial class ProductControl : UserControl, BaseControlInteface
    {
        public ProductControl()
        {
            InitializeComponent();
            this._initModel();
        }

        public ProductControl(string host, int port, string dbname, string username,
            string password, string table_name, ProductParser parser)
        {
            this.InitializeComponent();

            ProductParser newParser = new ProductParser();
            dataModel = new ProductModel(
                                this.gvProducts,
                                host,
                                port,
                                dbname,
                                username,
                                password,
                                "Production.Products",
                                newParser);
            newParser.DataModel = dataModel;

            dataModel.resetControl();
        }


        private ProductModel dataModel;
        protected void _initModel()
        {
            Productions.Properties.Settings setting = new Productions.Properties.Settings();

            ProductParser newParser = new ProductParser();

            dataModel = new ProductModel(
                                this.gvProducts, 
                                setting.DB_HOST, 
                                setting.DB_PORT, 
                                setting.DB_NAME, 
                                setting.DB_USER, 
                                setting.DB_PASS, 
                                "Production.Products", 
                                newParser);
            
            dataModel = new ProductModel(this.gvProducts, ".\\SQL2008", setting.DB_PORT, setting.DB_NAME, setting.DB_USER, setting.DB_PASS, "Production.Products", newParser);
            
            newParser.DataModel = dataModel;

            dataModel.resetControl();

            this.cbxCaID.Items.Add("");
            this.cbxCaID.Items.AddRange(dataModel.getIDItemList("Production.Categories", 0, 1, " deactive=0").ToArray());
            this.cbxSupID.Items.Add("");
            this.cbxSupID.Items.AddRange(dataModel.getIDItemList("Production.Suppliers", 0, 1, " deactive=0").ToArray());
        }

        protected void doAdd_Update(bool add)
        {
            Product dataObj = new Product();
            dataObj.ProductID = -1;
            dataObj.ProductName = txtproName.Text;
            try
            {
                dataObj.SupplierID = ((ProductModel.IdItem) cbxSupID.SelectedItem).Id;
                dataObj.CategoryID = ((ProductModel.IdItem) cbxCaID.SelectedItem).Id;
            }
            catch
            {
                MessageBox.Show("SupplierID or CatogoryID isValid");
            }

            dataObj.UnitPrice = float.Parse(txtUnitprice.Text);
            dataObj.Discontinued = this.cbDiscontinued.Checked;
            int check = dataObj.isValid();
            if (check < -1)
            {
                MessageBox.Show(dataObj.getErrorMessage(check));
            }
            else
            {
                if (add == true)
                    this.dataModel.insertNewRow(dataObj);
                else
                {
                    dataObj.ProductID = int.Parse(this.txtproID.Text);
                    this.dataModel.updateRow(dataObj);
                }
                //this.datamodel.resetControl();
                MessageBox.Show("Completed");
                clearAll();
            }
        }

        private void btnproAdd_Click(object sender, EventArgs e)
        {
            this.doAdd_Update(true);
        }

        private void btnproUpdate_Click(object sender, EventArgs e)
        {
            if (this.txtproID.Text.Equals(""))
            {
                MessageBox.Show("You should select an Product first.");
                return;
            }

            this.doAdd_Update(false);
        }
        

        private void gvProducts_SelectionChanged(object sender, EventArgs e)
        {
            this.doChangeSelectedItem();
        }

        protected void doChangeSelectedItem()
        {
            if (this.gvProducts.SelectedRows.Count > 0)
            {
                Product get = new Product();
                get.ProductID = int.Parse(this.gvProducts.SelectedRows[0].Cells[0].Value.ToString());
                Product selectedItem = this.dataModel.Data[this.dataModel.Data.IndexOf(get)];
                this.txtproID.Text = selectedItem.ProductID.ToString();

                this.txtproID.Text = selectedItem.ProductID.ToString();
                this.txtproName.Text = selectedItem.ProductName;
                ProductModel.IdItem tmp = new ProductModel.IdItem();
                tmp.Id = selectedItem.CategoryID;
                this.cbxCaID.SelectedIndex = this.cbxCaID.Items.IndexOf(tmp);
                tmp.Id = selectedItem.SupplierID;
                this.cbxSupID.SelectedIndex = this.cbxSupID.Items.IndexOf(tmp);

                this.txtUnitprice.Text = selectedItem.UnitPrice.ToString();
                this.cbDiscontinued.Checked = selectedItem.Discontinued;
                
            }
            else
            {
                this.txtproID.Text = "";
            }
        }

        private void btnproRemove_Click(object sender, EventArgs e)
        {
            if (this.txtproID.Text.Equals(""))
            {
                MessageBox.Show("You should select an Product first.");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete ?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;
            int IdToDelete = -1;
            try
            {
                IdToDelete = int.Parse(this.txtproID.Text.Trim());
                this.dataModel.deleteRows("productid=" + IdToDelete);
                MessageBox.Show("Deleted.");
                clearAll();
            }
            catch
            {
                MessageBox.Show("THISP PRODUCT CANNOT BE DELETE BECAUSE IT IS IN SOME ORDERS!");
                dialogResult = MessageBox.Show("Do you want to discountinue it??", "DDiscontinue option", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return;
                this.doDiscontinue(IdToDelete);
            }
        }

        protected void doDiscontinue(int id)
        {
            if (id < 0)
            {
                MessageBox.Show("ERROR: COULD NOT DIS CONTINUE. INVALID ID");
                return;
            }

            Product get = new Product();
            get.ProductID = id;
            Product Item = this.dataModel.Data[this.dataModel.Data.IndexOf(get)];
            Item.Discontinued = true;
            try
            {
                this.dataModel.updateRow(Item);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void clearAll()
        {
            this.txtproID.Text = "";
            this.txtproName.Text = "";
            this.cbxSupID.Text = "";
            this.cbxCaID.Text = "";
            this.txtUnitprice.Text = "";
            this.cbDiscontinued.Checked = false;

            this.gvProducts.ClearSelection();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();

            try
            {
                this.dataModel.resetControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region BaseControlInteface Members

        public string getName()
        {
            return "Product Manager";
        }

        public Control getThis()
        {
            return this;
        }

        private bool loaded = false;
        public bool isLoaded()
        {
            return loaded;
        }

        public void resetControl()
        {
            this.clearAll();
        }

        public void resetData()
        {
            this.dataModel.resetControl();
        }

        public void setLoadStatus(bool status)
        {
            loaded = status;
        }

        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            doSearch();
        }

        protected void doSearch()
        {
            this.gvProducts.ClearSelection();
            try
            {
                string newFilter = " ";
                int supID = -1, catID = -1;
                if (cbxSupID.SelectedIndex > 0)
                    supID =  ((ProductModel.IdItem)cbxSupID.SelectedItem).Id;
                if (cbxCaID.SelectedIndex > 0)
                    catID = ((ProductModel.IdItem)cbxCaID.SelectedItem).Id;
                newFilter += this.dataModel.filter(this.txtproName.Text, supID,
                                                          catID,
                                                          this.txtUnitprice.Text,
                                                          this.cbDiscontinued.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
