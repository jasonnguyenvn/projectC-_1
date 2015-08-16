using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Base_Intefaces;
using Orders.Properties;

namespace Orders
{
    public partial class OrderControl : UserControl, ControlInteface<OrderModel, Order>
    {
        private EditOrder editForm;
        private OrderModel dataModel;

        public OrderModel DataModel
        {
            get { return dataModel; }
        }

        private void _initControls()
        {
            try
            {
                editForm = new EditOrder();
                editForm.ItsParent = this;
                editForm.listControl.Dock = DockStyle.Fill;
                editForm.listControl.enableControls(false);
                this.panOrderDetail.Controls.Add(editForm.listControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        public OrderControl()
        {
            InitializeComponent();
            _initControls();
            //this.gvCatetories.ContextMenuStrip = this.GridViewMenu;
            Settings setting = new Settings();

            try
            {
                OrderParser newParser = new OrderParser();

                dataModel = new OrderModel(
                                    this.gvOrders,
                                    editForm.listControl.gvProductDeatail,
                                    setting.DB_HOST,
                                    setting.DB_PORT,
                                    setting.DB_NAME,
                                    setting.DB_USER,
                                    setting.DB_PASS,
                                    "Sales.Orders",
                                    "Sales.OrderDetails",
                                    newParser);
                //dataModel = new OrderModel(this.gvOrders, ".\\SQL2008", setting.DB_PORT, setting.DB_NAME, setting.DB_USER, setting.DB_PASS, "Production.Categories", newParser);

                newParser.DataModel = dataModel;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this._initModel();
        }

        public OrderControl(string host, int port, string dbname, string username,
            string password, string table_name, OrderParser parser)
        {
            this.InitializeComponent();

            _initControls();

            OrderParser newParser = new OrderParser();
            try
            {
                dataModel = new  OrderModel(
                                    this.gvOrders,
                                    editForm.listControl.gvProductDeatail,
                                    host,
                                    port,
                                    dbname,
                                    username,
                                    password,
                                    "Sales.Orders",
                                    "Sales.OrderDetails",
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
            this.gvOrders.Columns.Clear();

            try
            {
                dataModel.resetControl();
                //this.editForm = new EditCatetories(dataModel);
                this.cbCustID.Items.Add("");
                this.cbCustID.Items.AddRange(this.dataModel.getIDItemArray("Sales.Customers", 0, 1));
                this.cbEmpID.Items.Add("");
                this.cbEmpID.Items.AddRange(this.dataModel.getIDItemArray("HR.Employees", 0, 1));
                this.cbShipperID.Items.Add("");
                this.cbShipperID.Items.AddRange(this.dataModel.getIDItemArray("Sales.Shippers", 0, 1));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        #region ControlInteface<OrderModel,Order> Members

        public OrderModel getDataModel()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region BaseControlInteface Members

        public string getName()
        {
            return "Orders Manager";
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
            
        }

        public void resetData()
        {
            this.dataModel.resetControl();
        }

        public void setLoadStatus(bool status)
        {
            this.loaded = status;
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.editForm.ShowDialog();
        }

        public void doEnanbleSearchDate(DateTimePicker control, CheckBox checkControl)
        {
            if (checkControl.Checked == true)
                control.Enabled = true;
            else control.Enabled = false;
        }

        private void checkSearchOrderDate_CheckedChanged(object sender, EventArgs e)
        {
            this.doEnanbleSearchDate(dtpOrderDate, checkSearchOrderDate);
            this.meEnableSearchByOrderDate.Checked = checkSearchOrderDate.Checked;
        }

        private void checkSearchRequiredDate_CheckedChanged(object sender, EventArgs e)
        {
            this.doEnanbleSearchDate(dtpRequiredDate, checkSearchRequiredDate);
            this.meEnanbleSerchByRequiredDate.Checked = checkSearchRequiredDate.Checked;
        }

        private void checkSearchShippedDate_CheckedChanged(object sender, EventArgs e)
        {
            this.doEnanbleSearchDate(dtpShippedDate, checkSearchShippedDate);
            this.meSearchByShippedDate.Checked = checkSearchShippedDate.Checked;
        }

        private void meEnableSearchByOrderDate_Click(object sender, EventArgs e)
        {
            checkSearchOrderDate.Checked = !checkSearchOrderDate.Checked;
        }

        private void meEnanbleSerchByRequiredDate_Click(object sender, EventArgs e)
        {
            checkSearchRequiredDate.Checked = !checkSearchRequiredDate.Checked;
        }

        private void meSearchByShippedDate_Click(object sender, EventArgs e)
        {
            checkSearchShippedDate.Checked = !checkSearchShippedDate.Checked;
        }
    }
}
