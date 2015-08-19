using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Orders.Properties;
using Base_Intefaces;
using WinForm_Dialogs;

namespace Orders
{
    public partial class ShipperControl : UserControl, ControlInteface<ShipperModel, Shipper>
    {
        private ShipperModel dataModel;

        private DeleteOptionsForm warningForm;
        private bool loaded = false;

        private EditShipperForm editForm;

        public ShipperControl()
        {
            InitializeComponent();


            //this.gvCatetories.ContextMenuStrip = this.GridViewMenu;
            Settings setting = new Settings();

            try
            {
                ShipperParser newParser = new ShipperParser();

                dataModel = new ShipperModel(
                                    this.gvShippers,
                                    setting.DB_HOST,
                                    setting.DB_PORT,
                                    setting.DB_NAME,
                                    setting.DB_USER,
                                    setting.DB_PASS,
                                    "Sales.Shippers",
                                    newParser);

                newParser.DataModel = dataModel;
                this.editForm = new EditShipperForm(dataModel);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this._initModel();
        }

        public ShipperControl(string host, int port, string dbname, string username,
            string password, string table_name, ShipperParser parser)
        {
            this.InitializeComponent();

            

            ShipperParser newParser = new ShipperParser();
            try
            {
                dataModel = new  ShipperModel(
                                    this.gvShippers,
                                    host,
                                    port,
                                    dbname,
                                    username,
                                    password,
                                    "Sales.Shippers",
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
            this.gvShippers.Columns.Clear();

            try
            {
                dataModel.resetControl();
                //this.editForm = new EditCatetories(dataModel);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.warningForm = new DeleteOptionsForm("WARNING: This Shipper holds some products", 
                                "(1) SAFETY DELETE: Deactive this Shipper in the manager.", 
                                "(2) Delete this Shipper and all of its data.");

        }

        private void gvCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gvShippers.SelectedRows.Count > 0)
            {
                Shipper get = new Shipper();
                get.ShipperID = int.Parse(this.gvShippers.SelectedRows[0].Cells[0].Value.ToString());
                Shipper selectedItem = this.dataModel.Data[dataModel.Data.IndexOf(get)];
                this.txtSelectedID.Text = selectedItem.ShipperID.ToString();
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
            this.txtPhone.Text = "";
            this.txtName.Text = "";

            this.gvShippers.ClearSelection();

        }

        #region ControlInteface<ShipperModel,Shipper> Members

        public ShipperModel getDataModel()
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
            this.gvShippers.ClearSelection();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.txtSelectedID.Text.Equals(""))
            {
                MessageBox.Show("You should select an Shipper first.");
                return;
            }
            this.editForm.AddNewMode = false;
            this.editForm.ShowDialog();
            this.gvShippers.ClearSelection();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.txtSelectedID.Text.Equals(""))
            {
                MessageBox.Show("You should select an Shipper first.");
                return;
            }
            this.doDelete();
        }

        protected void doDelete()
        {
            try
            {
                int ID = int.Parse(this.txtSelectedID.Text.Trim());
                this.dataModel.deleteRows("shipperid=" + ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /*protected void doBadDelete(int idToDelete)
        {
            try
            {
                Shipper supp = this.dataModel.BadDelete(idToDelete);
                if (supp != null)
                    MessageBox.Show("DELETE SUCCESSFULLY");
                else
                    MessageBox.Show("THIS Shipper'S PRODUCTS MAY BE LIST ON ORDER. CANNOT DELETE!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("THIS Shipper'S PRODUCTS MAY BE LIST ON ORDER. CANNOT DELETE!");
                MessageBox.Show(ex.Message);
            }
        }*/

        private void btnSearch_Click(object sender, EventArgs e)
        {
            doSearch();
        }

        public void doSearch()
        {
            this.gvShippers.ClearSelection();
            try
            {
                string newFilter = " ";
                newFilter += this.dataModel.filter(this.txtName.Text, this.txtPhone.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /*
        public ShipperControl()
        {
            InitializeComponent();
        }*/
    }
}
