using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Productions
{
    public partial class Products : UserControl
    {
        public Products()
        {
            InitializeComponent();
            this._initModel();
        }

        public Products(string host, int port, string dbname, string username,
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
                                "HR.Employees",
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
        }

        private void btnproAdd_Click(object sender, EventArgs e)
        {
            Product newPro = new Product();
            newPro.ProductID = -1;
            newPro.ProductName = txtproName.Text;
            try
            {
                newPro.SupplierID = int.Parse(cbxSupID.Text);
                newPro.CategoryID = int.Parse(cbxCaID.Text);
            }
            catch { MessageBox.Show("SupplierID or CatogoryID isValid");
            }

            newPro.UnitPrice = txtUnitprice.Text;
            newPro.Discontinued = this.cbDiscontinued.Checked;
           int check = newPro.isValid();
            if (check < -1)
            {
                MessageBox.Show(newPro.getErrorMessage(check));
            }
            else
            {
                this.dataModel.insertNewRow(newPro);
                //this.datamodel.resetControl();
                MessageBox.Show("Completed");
                clearAll();
            }
        }

        private void btnproUpdate_Click(object sender, EventArgs e)
        {
            if (this.txtproID.Text.Equals(""))
            {
                MessageBox.Show("You should select an Product first.");
                return;
            }

            try
            {
                Product updateData = new Product();
                updateData.ProductID = int.Parse(this.txtproID.Text.Trim());
                updateData.ProductName = this.txtproName.Text;
                updateData.SupplierID = int.Parse(this.cbxSupID.Text);
                updateData.CategoryID = int.Parse(this.cbxCaID.Text);
                updateData.UnitPrice = this.txtUnitprice.Text;
                updateData.Discontinued = this.cbDiscontinued.Checked;
                int check = updateData.isValid();
                if (check < -1)
                {
                    MessageBox.Show("You should select an Product first.");
                    return;
                }
                else
                {


                    //int IdOfRow = this.gvCategories.Rows.IndexOf(this.gvCategories.SelectedRows[0]);
                    this.dataModel.updateRow(updateData);
                    MessageBox.Show("Updated.");
                    clearAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void gvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gvProducts.SelectedRows.Count > 0)
            {
                int selectedIndex = this.gvProducts.Rows.IndexOf(this.gvProducts.SelectedRows[0]);
                Product selectedItem = this.dataModel.Data[selectedIndex];
                this.txtproID.Text = selectedItem.ProductID.ToString();
                this.txtproName.Text = selectedItem.ProductName;
                this.cbxSupID.Text = selectedItem.SupplierID.ToString();
                this.cbxCaID.Text = selectedItem.CategoryID.ToString();
                this.txtUnitprice.Text = selectedItem.UnitPrice;
                this.cbDiscontinued.Checked = selectedItem.Discontinued;
            }
        }

        private void btnproRemove_Click(object sender, EventArgs e)
        {
            if (this.txtproID.Text.Equals(""))
            {
                MessageBox.Show("You should select an Product first.");
                return;
            }

            try
            {
                int IdToDelete = int.Parse(this.txtproID.Text.Trim());
                this.dataModel.deleteRows("productid=" + IdToDelete);
                MessageBox.Show("Deleted.");
                clearAll();
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
        }
    }
}
