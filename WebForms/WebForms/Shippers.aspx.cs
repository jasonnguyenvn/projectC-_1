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
    public partial class Shippers : System.Web.UI.Page
    {
        private ShipperModel _dataModel;
        private List<Control> textboxs;

        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();
            this.textboxs = new List<Control>();
            this.textboxs.Add(txtName);
            this.textboxs.Add(txtDescription);
        }

        protected void loadData()
        {
            string currentFilter ;
            if (IsPostBack == false)
            {
                Session["cat_filter"] = "deactive=0 ";
                currentFilter = "deactive=0 "; 
            }
            else
                currentFilter = (string)Session["cat_filter"];
            //this.scriptLb.Text = currentFilter;
            ShipperParser newParser = new ShipperParser();
            this._dataModel = new ShipperModel(this.gvShippers, @".\SQL2008",
                 1433, "TSQLFundamentals2008","sa", "123456", "Sales.Shippers", newParser);
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

            
        }

        /*protected void loadEmpIDS()
        {
            this.cbManagerID.Items.Add("");
            object[] getIds = this._dataModel.getShipperIDs();
            foreach (object eachItem in getIds)
            {
                this.cbManagerID.Items.Add(eachItem.ToString());
            }
        }*/

        protected void gvShippers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvShippers.SelectedIndex = -1;
            this.txtID.Text = "";
            this.bntDelete.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.gvShippers.PageIndex = e.NewPageIndex;
            this.gvShippers.DataBind();
        }

        protected void clearGVSelection()
        {
            this.gvShippers.SelectedIndex = -1;
            this.btnUpdate.Enabled = false;
            this.bntDelete.Enabled = false;
            this.txtID.Text = "";
        }

        protected void clearFilter()
        {
            string newFilter = "deactive=0 ";
            Session["cat_filter"] = newFilter;
            try
            {
                this._dataModel.resetControl(newFilter);
                this.gvShippers.PageIndex = 0;
                this.gvShippers.DataBind();

                this.txtID.Text = "";

                this.txtName.Text = "";
                this.txtDescription.Text = "";
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
                string newFilter = " ";
                newFilter += this._dataModel.filter(txtName.Text, txtDescription.Text);

                Session["cat_filter"] = newFilter;
                this.gvShippers.DataBind();
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
                this._dataModel.deleteRows(" shipperid=" + ID);
            }
            catch
            {
                
            }
        }

        protected void doUpdate()
        {
            int ID = int.Parse(this.txtID.Text.Trim());
            Response.Redirect("Edit-Shipp.aspx?suppid=" + ID);
        }

        protected void gvShippers_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.bntDelete.Enabled = true;
            this.btnUpdate.Enabled = true;
            int selectedIndex = int.Parse(this.gvShippers.SelectedRow.Cells[1].Text);
            this.txtID.Text = selectedIndex.ToString();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            string newFilter = "deactive=0 ";
            Session["cat_filter"] = newFilter;
            Response.Redirect("Shippers.aspx");
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
            Response.Redirect("Edit-Shipp.aspx");
        }

    }
}
