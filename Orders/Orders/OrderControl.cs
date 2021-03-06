﻿using System;
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

        

        

        public OrderControl()
        {
            InitializeComponent();
            
            //this.gvCatetories.ContextMenuStrip = this.GridViewMenu;
            Settings setting = new Settings();

            try
            {
                OrderParser newParser = new OrderParser();

                dataModel = new OrderModel(
                                    this.gvOrders,
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
                this.cbEmpID.Items.AddRange(this.dataModel.getIDItemList("HR.Employees", 0, 1, " jobStatus=1").ToArray());
                this.cbShipperID.Items.Add("");
                this.cbShipperID.Items.AddRange(this.dataModel.getIDItemList("Sales.Shippers", 0, 1, " deactive=0").ToArray());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
             _initControls();
        }

        private void _initControls()
        {
            try
            {
                editForm = new EditOrder(this.dataModel);
                editForm.ItsParent = this;
                editForm.listControl.Dock = DockStyle.Fill;
                editForm.listControl.enableControls(false);
                this.panOrderDetail.Controls.Add(editForm.listControl);

                dataModel.DetailModel.setNewControl(editForm.listControl.gvProductDeatail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearAll()
        {
            this.cbCustID.SelectedIndex = 0;
            this.cbEmpID.SelectedIndex = 0;
            this.cbShipperID.SelectedIndex = 0;
            this.dtpOrderDate.Value = DateTime.Now;
            this.dtpRequiredDate.Value = DateTime.Now;
            this.dtpShippedDate.Value = DateTime.Now;

            this.checkSearchOrderDate.Checked = false;
            this.checkSearchRequiredDate.Checked = false;
            this.checkSearchShippedDate.Checked = false;

            this.txtSelectedID.Text = "";

            this.gvOrders.ClearSelection();
            this.dataModel.DetailModel.OrderID = -1;
            this.dataModel.DetailModel.resetControl();
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
            clearAll();
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
            this.gvOrders.ClearSelection();
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

        private void gvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gvOrders.SelectedRows.Count > 0)
            {
                Order get = new Order();
                get.Orderid = int.Parse(this.gvOrders.SelectedRows[0].Cells[0].Value.ToString());
                Order selectedItem = this.dataModel.Data[dataModel.Data.IndexOf(get)];
                this.txtSelectedID.Text = selectedItem.Orderid.ToString();
                dataModel.DetailModel.OrderID = selectedItem.Orderid;
                dataModel.DetailModel.resetControl();

                this.editForm.CurrentData = selectedItem;

                
            }
            else
            {
                if (dataModel.DetailModel.DataSource != null)
                {
                    dataModel.DetailModel.DataSource.Rows.Clear();
                    this.editForm.CurrentData = null;
                }
            }
        }

        private void menuTripOfGV_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                ContextMenuStrip cast = (ContextMenuStrip)sender;
                if (this.gvOrders.SelectedRows.Count <= 0)
                    e.Cancel = true;
                else
                    e.Cancel = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.clearAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.txtSelectedID.Equals("") == false)
                doDelete();
        }

        protected void doDelete()
        {
            try
            {
                this.dataModel.deleteRow(int.Parse(this.txtSelectedID.Text.Trim()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mitmDeleteOrder_Click(object sender, EventArgs e)
        {
            this.doDelete();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.editForm.addNewMode = false;
            this.editForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int custID = -1;
                int empID = -1;
                int shipperID = -1;
                if(cbCustID.SelectedIndex>0)
                    custID = ((OrderModel.IdItem)cbCustID.SelectedItem).Id;
                if(cbEmpID.SelectedIndex>0)
                    empID = ((OrderModel.IdItem)cbEmpID.SelectedItem).Id;
                if(cbShipperID.SelectedIndex>0)
                    shipperID = ((OrderModel.IdItem)cbShipperID.SelectedItem).Id;

                string orderDate = "";
                string reqDate = "";
                string shippedDate = "";

                if (checkSearchOrderDate.Checked == true)
                    orderDate = dtpOrderDate.Value.ToShortDateString();
                if (checkSearchRequiredDate.Checked == true)
                    reqDate = dtpRequiredDate.Value.ToShortDateString();
                if (checkSearchShippedDate.Checked == true)
                    shippedDate = dtpShippedDate.Value.ToShortDateString();

                dataModel.filter(custID, empID, orderDate, reqDate, shippedDate, shipperID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
