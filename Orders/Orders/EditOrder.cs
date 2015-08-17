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
    public partial class EditOrder : Form
    {
        OrderControl itsParent;
        OrderModel dataModel = null;

        public bool addNewMode = true;

        public OrderControl ItsParent
        {
            get { return itsParent; }
            set { itsParent = value; }
        }
        public OrderDetailControl listControl;
        public EditOrder(OrderModel dataModel)
        {
            InitializeComponent();
            listControl = new OrderDetailControl(dataModel.DetailModel);
            listControl.Dock = DockStyle.Top;
            this.listPanel.Controls.Add(listControl);

            this.dataModel = dataModel;
        }


        private void cboxNotShipped_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cboxNotShipped.Checked == true)
                this.dtpShippedDate.Enabled = false;
            else
                this.dtpShippedDate.Enabled = true;
        }

        public Order CurrentData = null;

        private void EditOrder_Load(object sender, EventArgs e)
        {
            this.listControl.Parent = this.listPanel;
            if (this.addNewMode == true)
                this.listControl.enableControls(true);

            this.resetComboBoxes();

            if (addNewMode == true)
            {
                this.clearForm();
                this.listControl.enableControls(true);
                return;
            }

            if (CurrentData != null)
            {
                this.doLoadCurrentData();
            }
        }

        public void clearForm()
        {
            this.dataModel.DetailModel.OrderID = -1;
            this.dataModel.DetailModel.resetControl();

            this.txtOrderID.Text = "";
            this.cbCustID.SelectedIndex = 0;
            this.cbEmpID.SelectedIndex = 0;
            this.cbShipperID.SelectedIndex = 0;

            this.dtpOrderDate.Value = DateTime.Now;
            
            
            this.dtpRequiredDate.Value = DateTime.Now;
            this.cboxNotShipped.Checked = true;
            this.dtpShippedDate.Value = DateTime.Now;
            
            this.txtFreight.Text = "";
            this.txtShipName.Text = "";
            this.txtShipAddress.Text = "";
            this.txtShipCity.Text = "";
            this.txtShipRegion.Text = "";
            this.txtShipPostalCode.Text = "";
            this.cbCountry.Text = "";
            this.listControl.enableControls(true);
        }

        private void resetComboBoxes()
        {
            this.cbCustID.Items.Clear();
            this.cbEmpID.Items.Clear();
            this.cbShipperID.Items.Clear();
            this.cbCustID.Items.Add("");
            this.cbCustID.Items.AddRange(dataModel.getIDItemArray("Sales.Customers", 0, 1));
            this.cbEmpID.Items.Add("");
            this.cbEmpID.Items.AddRange(dataModel.getIDItemArray("HR.Employees", 0, 1));
            this.cbShipperID.Items.Add("");
            this.cbShipperID.Items.AddRange(dataModel.getIDItemArray("Sales.Shippers", 0, 1));
        }

        private void doLoadCurrentData()
        {
            this.txtOrderID.Text = CurrentData.Orderid.ToString();
            this.cbCustID.SelectedIndex = this.cbCustID.Items.IndexOf((object)CurrentData.getCustIdItem());
            this.cbEmpID.SelectedIndex = this.cbEmpID.Items.IndexOf((object)CurrentData.getEmpIdItem());
            this.cbShipperID.SelectedIndex = this.cbShipperID.Items.IndexOf((object)CurrentData.getShipperIdItem());

            this.dtpOrderDate.Value = CurrentData.Orderdate;
            this.dtpOrderDate.Value = CurrentData.Requireddate;

            if (CurrentData.isShipped == true)
            {
                this.dtpShippedDate.Value = CurrentData.Shippeddate;
                this.dtpShippedDate.Enabled = true;
                this.cboxNotShipped.Checked = false;
            }
            else
            {
                this.cboxNotShipped.Checked = true;
                this.dtpShippedDate.Enabled = false;
                this.dtpShippedDate.Value = DateTime.Now;
            }

            this.txtFreight.Text = CurrentData.Freight.ToString();
            this.txtShipName.Text = CurrentData.Shipname;
            this.txtShipAddress.Text = CurrentData.Shipaddress;
            this.txtShipCity.Text = CurrentData.Shipcity;
            this.txtShipRegion.Text = CurrentData.Shipregion;
            this.txtShipPostalCode.Text = CurrentData.Shippostalcode;
            this.cbCountry.Text = CurrentData.Shipcountry;


        }

        private void EditOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.listControl.enableControls(false);
            this.listControl.Parent = this.itsParent.panOrderDetail;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.doUpdate_Add();
        }

        protected void showErrors(Order objData, int[] errorSet)
        {
            foreach (int eachError in errorSet)
            {

                if(eachError == -2)
                    this.errorProvider.SetError(cbEmpID,
                        objData.getErrorMessage(eachError));

                if (eachError == -3)
                    this.errorProvider.SetError(dtpRequiredDate,
                        objData.getErrorMessage(eachError));

                if (eachError == -4)
                    this.errorProvider.SetError(dtpShippedDate,
                        objData.getErrorMessage(eachError));

                if (eachError == -5)
                    this.errorProvider.SetError(cbShipperID,
                        objData.getErrorMessage(eachError));

                if (eachError == -6)
                {
                    if (this.txtShipName.Text.Equals(""))
                        this.errorProvider.SetError(txtShipName,
                            objData.getErrorMessage(eachError));
                    if (this.txtShipAddress.Text.Equals(""))
                        this.errorProvider.SetError(txtShipAddress,
                            objData.getErrorMessage(eachError));
                    if (this.txtShipCity.Text.Equals(""))
                        this.errorProvider.SetError(txtShipCity,
                            objData.getErrorMessage(eachError));
                    if (this.cbCountry.Text.Equals(""))
                        this.errorProvider.SetError(cbCountry,
                            objData.getErrorMessage(eachError));
                }

            }
        }

        protected void raiseSelectIdErrors()
        {
            if (this.cbEmpID.SelectedIndex == 0)
                this.errorProvider.SetError(cbEmpID, "##THIS FIELD CANNOT BE EMPTY");
            if (this.cbShipperID.SelectedIndex == 0)
                this.errorProvider.SetError(cbShipperID, "##THIS FIELD CANNOT BE EMPTY");
        }

        protected Order createNewDataObj()
        {
            Order dataObj = new Order();
            dataObj.Orderid = -1;

            if (this.cbCustID.SelectedIndex == 0)
                dataObj.Custid = -2905;
            else
                dataObj.Custid = ((OrderModel.IdItem)this.cbCustID.SelectedItem).Id;

            try
            {
                dataObj.Empid = ((OrderModel.IdItem)this.cbEmpID.SelectedItem).Id;
                dataObj.Shipperid = ((OrderModel.IdItem)this.cbShipperID.SelectedItem).Id;
            }
            catch
            {
                this.raiseSelectIdErrors();
            }

            try
            {
                dataObj.Freight = float.Parse(this.txtFreight.Text);
            }
            catch
            {
                this.errorProvider.SetError(this.txtFreight, "###INVALID VALUE");
            }

            dataObj.Orderdate = this.dtpOrderDate.Value;
            dataObj.Requireddate = this.dtpRequiredDate.Value;
            if (this.cboxNotShipped.Checked == false)
                dataObj.Shippeddate = this.dtpShippedDate.Value;


            dataObj.Shipname = this.txtShipName.Text;
            dataObj.Shipaddress = this.txtShipAddress.Text;
            dataObj.Shipcity = this.txtShipCity.Text;
            dataObj.Shipregion = this.txtShipRegion.Text;
            dataObj.Shippostalcode = this.txtShipPostalCode.Text;
            dataObj.Shipcountry = this.cbCountry.Text;

            this._initDataObjProductList(dataObj);
            return dataObj;
        }

        protected void _initDataObjProductList(Order dataObj)
        {
            List<Order.OrderItem> productList = dataObj.OrderItems;
            Order.OrderItemParser parser = new Order.OrderItemParser();

            foreach (DataRow eachRow in dataModel.DetailModel.DataSource.Rows)
            {
                productList.Add( parser.parse(eachRow) );
            }
        }

        protected void doUpdate_Add()
        {
            this.errorProvider.Clear();
            Order dataObj = this.createNewDataObj();

            try
            {

                int[] check = dataObj.isValid_multi();

                if (check.Length > 0)
                {
                    this.showErrors(dataObj, check);

                }
                else
                {
                    if (this.addNewMode == true)
                        this.dataModel.insertNewRow(dataObj);
                    else
                    {
                        dataObj.Orderid = int.Parse(this.txtOrderID.Text.Trim());
                        this.dataModel.updateRow(dataObj);
                    }
                    this.clearForm();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (this.addNewMode == true)
                this.clearForm();
            else
                MessageBox.Show("You can NOT clear this form in the MODIFY MODE");
        }
    }
}
