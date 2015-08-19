using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using DataModel;
using Orders;
using System.Collections.Generic;

namespace WebForms
{
    public partial class Orders : System.Web.UI.Page
    {
        private OrderModel _dataModel;
        private List<Control> textboxs;

        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();
        }

        protected void loadData()
        {
            string currentFilter ;
            if (IsPostBack == false)
            {
                Session["ord_filter"] = "";
                currentFilter = ""; 
            }
            else
                currentFilter = (string)Session["ord_filter"];
            //this.scriptLb.Text = currentFilter;
            OrderParser newParser = new OrderParser();
            this._dataModel = new OrderModel (this.gvOrders, @".\SQL2008",
                 1433, "TSQLFundamentals2008","sa", "123456", "Sales.Orders", "Sales.OrderDetails", newParser);
            newParser.DataModel = this._dataModel;
            try
            {
                this._dataModel.resetControl(currentFilter);
                //if (this.IsPostBack == false)
                  //  this.loadEmpIDS();
            }
            catch(Exception ex)
            {
                Session["current_error"] = ex.Message;
                Response.Redirect("serverError.aspx");
            }
            custList = new List<object>();
            empList = new List<object>();
            shipperList = new List<object>();
            custList.Add("");
            empList.Add("");
            shipperList.Add("");
            custList.AddRange(_dataModel.getIDItemList("Sales.Customers", 0, 1, "").ToArray());
            empList.AddRange(_dataModel.getIDItemList("HR.Employees", 0, 1, " jobStatus=1").ToArray());
            shipperList.AddRange(_dataModel.getIDItemList("Sales.Shippers", 0, 1, " deactive=0").ToArray());
            if (IsPostBack == false)
            {
                this.cbCustID.DataSource = custList;
                this.cbEmpID.DataSource = empList;
                this.cbShipper.DataSource = shipperList;

                cbCustID.DataBind();
                cbEmpID.DataBind();
                cbShipper.DataBind();

            }


        }


        List<object> custList;
        List<object> empList;
        List<object> shipperList;

        /*protected void loadEmpIDS()
        {
            this.cbManagerID.Items.Add("");
            object[] getIds = this._dataModel.getOrderIDs();
            foreach (object eachItem in getIds)
            {
                this.cbManagerID.Items.Add(eachItem.ToString());
            }
        }*/

        protected void gvOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvOrders.SelectedIndex = -1;
            this.txtID.Text = "";
            this.bntDelete.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.gvOrders.PageIndex = e.NewPageIndex;
            this.gvOrders.DataBind();
        }

        protected void clearGVSelection()
        {
            this.gvOrders.SelectedIndex = -1;
            this.btnUpdate.Enabled = false;
            this.bntDelete.Enabled = false;
            this.txtID.Text = "";
        }

        protected void clearFilter()
        {
            string newFilter = "";
            Session["ord_filter"] = newFilter;
            try
            {
                this._dataModel.resetControl(newFilter);
                this.gvOrders.PageIndex = 0;
                this.gvOrders.DataBind();

            }
            catch (Exception ex)
            {
                Session["current_error"] = ex.Message;
                Response.Redirect("serverError.aspx");
            }
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            clearGVSelection();
            try
            {
                int custID = -1;
                int empID = -1;
                int shipperID = -1;
                if (cbCustID.SelectedIndex > 0)
                {
                    custID = ((OrderModel.IdItem) custList[cbCustID.SelectedIndex] ).Id;
                }
                if (cbEmpID.SelectedIndex > 0)
                {
                    empID = ((OrderModel.IdItem) empList[cbCustID.SelectedIndex] ).Id;
                }
                if (cbShipper.SelectedIndex > 0)
                {
                    shipperID = ((OrderModel.IdItem) shipperList[cbShipper.SelectedIndex] ).Id;
                }

                string orderDate = "";
                string reqDate = "";
                string shippedDate = "";

                if (checkSearchOrderDate.Checked == true)
                    orderDate = dtpOrderDate.Text.Trim(); 
                if (checkSearchRequiredDate.Checked == true)
                    reqDate = dtpRequiredDate.Text.Trim(); 
                if (checkSearchShippedDate.Checked == true)
                    shippedDate = dtpShippedDate.Text.Trim(); 

                string newFilter = _dataModel.filter(custID, empID, orderDate, reqDate, shippedDate, shipperID);

                Session["ord_filter"] = newFilter;
                this.gvOrders.DataBind();
            }
            catch (Exception ex)
            {
                Session["current_error"] = ex.Message;
                Response.Redirect("serverError.aspx");
            }
        }

        protected void doDelete()
        {
            int ID = int.Parse(this.txtID.Text.Trim());
            try
            {
                this._dataModel.deleteRows(" Orderid=" + ID);
                this.gvOrders.DataBind();
                this.clearGVSelection();
            }
            catch
            {
                this.doBadDelete(ID);
            }
        }

        private void doBadDelete(int idToDelete)
        {
            string mess = "";
            try
            {
               
            }
            catch
            {
                mess = "THIS Order'S PRODUCTS MAY BE LIST ON ORDER. CANNOT DELETE! ";
            }

            this.scriptLb.Text = "<script>alert(\"" + mess + "\");window.location.assign(\"Orders.aspx\")</script>";
            
        }

        protected void doUpdate()
        {
            int ID = int.Parse(this.txtID.Text.Trim());
           // Response.Redirect("Edit-Cat.aspx?suppid=" + ID);
        }

        protected void gvOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.bntDelete.Enabled = true;
            this.btnUpdate.Enabled = true;
            int selectedIndex = int.Parse(this.gvOrders.SelectedRow.Cells[1].Text);
            this.txtID.Text = selectedIndex.ToString();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            string newFilter = "";
            Session["ord_filter"] = newFilter;
            Response.Redirect("Orders.aspx");
            /*this.clearGVSelection();
            this.clearFilter();*/
        }

        protected void bntDelete_Click(object sender, EventArgs e)
        {
            if (this.txtID.Text.Equals(""))
            {
                return;
            }

            this.doDelete();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.txtID.Text.Equals(""))
            {
                return;
            }

            this.doUpdate();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
           // Response.Redirect("Edit-Cat.aspx");
        }

    }
}
