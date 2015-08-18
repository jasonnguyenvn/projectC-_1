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
using Customers;
using System.Collections.Generic;

namespace WebForms
{
    public partial class Customers: System.Web.UI.Page
    {
        private CustomerModel dataModel;
        private List<Control> textboxs;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                this.txtCountry.DataSource = CustomerModel.GetCountries();
                this.txtCountry.DataBind();
            }

            loadData();
            this.textboxs = new List<Control>();
            this.textboxs.Add(txtName);
            this.textboxs.Add(txtContName);
            this.textboxs.Add(txtCity);
            this.textboxs.Add(txtRegion);
            this.textboxs.Add(txtCountry);
            this.textboxs.Add(txtPhone);
        }

        protected void loadData()
        {
            string currentFilter ;
            if (IsPostBack == false)
            {
                Session["cust_filter"] = "";
                currentFilter = ""; 
            }
            else
                currentFilter = (string)Session["cust_filter"];
            //this.scriptLb.Text = currentFilter;
            CustomerParser newParser = new CustomerParser();
            this.dataModel = new CustomerModel(this.gvCustomers, @".\SQL2008",
                 1433, "TSQLFundamentals2008","sa", "123456", "Sales.Customers", newParser);
            newParser.DataModel = this.dataModel;
            try
            {
                this.dataModel.resetControl(currentFilter);
            }
            catch(Exception ex)
            {
                Session["current_error"] = ex.Message;
                Response.Redirect("serverError.aspx");
            }

            
        }

        protected void gvCustomers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvCustomers.SelectedIndex = -1;
            this.txtID.Text = "";
            this.bntDelete.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.gvCustomers.PageIndex = e.NewPageIndex;
            this.gvCustomers.DataBind();
        }
        protected void clearGVSelection()
        {
            this.gvCustomers.SelectedIndex = -1;
            this.btnUpdate.Enabled = false;
            this.bntDelete.Enabled = false;
            this.txtID.Text = "";
        }

        protected void clearFilter()
        {
            string newFilter = "";
            Session["cust_filter"] = newFilter;
            try
            {
                this.dataModel.resetControl(newFilter);
                this.gvCustomers.PageIndex = 0;
                this.gvCustomers.DataBind();

                this.txtID.Text = "";

                this.txtName.Text = "";
                this.txtContName.Text = "";
                this.txtCity.Text = "";
                this.txtRegion.Text = "";
                this.txtPostalCode.Text = "";
                this.txtCountry.SelectedIndex = 0;
                this.txtPhone.Text = "";
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
                string newFilter = "";
                newFilter += this.dataModel.filter(txtName.Text, txtContName.Text, "", txtCity.Text, txtRegion.Text, 
                    txtPostalCode.Text, txtCountry.Text, txtPhone.Text, "");

                Session["cust_filter"] = newFilter;
                this.gvCustomers.DataBind();
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
                this.dataModel.deleteRows(" custid=" + ID);
                this.gvCustomers.DataBind();
                this.clearGVSelection();
            }
            catch 
            {
                string mess = "CANNOT DELETE THIS CUSTOMER BECAUSE THERE ARE" 
                    +" SOME ORDERS OF THIS CUSTOMER. PLEASE USE DESKTOP APP TO" 
                    +" DELETE THIS OR YOU CAN USE ORDERS MANAGER TO DELETE ALL " 
                    +"ORDERS OF THIS CUSTOEMRS AND THEN GO BACK TO DELETE IT.";
                this.scriptLb.Text = "<script>alert(\"" + mess + "\");window.location.assign(\"Products.aspx\")</script>";
            }
        }

        

        protected void doUpdate()
        {
            int ID = int.Parse(this.txtID.Text.Trim());
            Response.Redirect("Edit-Emp.aspx?empid=" + ID);
        }

        protected void gvCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            this.txtID.Text = "";
            this.bntDelete.Enabled = true;
            this.btnUpdate.Enabled = true;
            int selectedIndex = int.Parse(this.gvCustomers.SelectedRow.Cells[1].Text);
            this.txtID.Text = selectedIndex.ToString();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            string newFilter = "";
            Session["cust_filter"] = newFilter;
            Response.Redirect("Customers.aspx");
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
            Response.Redirect("Edit-Emp.aspx");
        }

    }
}
