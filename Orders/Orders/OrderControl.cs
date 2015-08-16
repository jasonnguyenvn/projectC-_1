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

        private void initEditForm()
        {
            editForm = new EditOrder();
            this.listpanel.Controls.Add(editForm.gvProductDeatail);
        }

        public OrderControl()
        {
            InitializeComponent();
            initEditForm();
            //this.gvCatetories.ContextMenuStrip = this.GridViewMenu;
            Settings setting = new Settings();

            try
            {
                OrderParser newParser = new OrderParser();

                dataModel = new OrderModel(
                                    this.gvOrders,
                                    editForm.gvProductDeatail,
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

            

            OrderParser newParser = new OrderParser();
            try
            {
                dataModel = new  OrderModel(
                                    this.gvOrders,
                                    editForm.gvProductDeatail,
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.editForm.ShowDialog();
        }
    }
}
