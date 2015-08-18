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
using Productions;
using System.Collections.Generic;

namespace WebForms
{
    public partial class Products : System.Web.UI.Page
    {
        private ProductModel _dataModel;
        private List<Control> textboxs;

        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();
            this.textboxs = new List<Control>();
            this.textboxs.Add(txtName);
            //this.textboxs.Add(txtDescription);
        }

        protected void loadData()
        {
            string currentFilter ;
            if (IsPostBack == false)
            {
                Session["pro_filter"] = "";
                currentFilter = "";

            }
            else
                currentFilter = (string)Session["pro_filter"];
            //this.scriptLb.Text = currentFilter;
            ProductParser newParser = new ProductParser();
            this._dataModel = new ProductModel(this.gvProducts, @".\SQL2008",
                 1433, "TSQLFundamentals2008","sa", "123456", "Production.Products", newParser);
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

            catList = new List<object>();
            suppList = new List<object>();
            catList.Add("");
            suppList.Add("");
            catList.AddRange(_dataModel.getIDItemList("Production.Categories", 0, 1, " deactive=0").ToArray());
            suppList.AddRange(_dataModel.getIDItemList("Production.Suppliers", 0, 1, " deactive=0").ToArray());
            if (IsPostBack == false)
            {
                this.cbCatID.DataSource = catList;
                this.cbCatID.DataBind();
                this.cbSupplierID.DataSource = suppList;
                this.cbSupplierID.DataBind();

            }


        }


        List<object> catList;
        List<object> suppList;
        /*protected void loadEmpIDS()
        {
            this.cbManagerID.Items.Add("");
            object[] getIds = this._dataModel.getProductIDs();
            foreach (object eachItem in getIds)
            {
                this.cbManagerID.Items.Add(eachItem.ToString());
            }
        }*/

        protected void gvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvProducts.SelectedIndex = -1;
            this.txtID.Text = "";
            this.bntDelete.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.gvProducts.PageIndex = e.NewPageIndex;
            this.gvProducts.DataBind();
        }

        protected void clearGVSelection()
        {
            this.gvProducts.SelectedIndex = -1;
            this.btnUpdate.Enabled = false;
            this.bntDelete.Enabled = false;
            this.txtID.Text = "";
        }

        protected void clearFilter()
        {
            string newFilter = "";
            Session["pro_filter"] = newFilter;
            try
            {
                this._dataModel.resetControl(newFilter);
                this.gvProducts.PageIndex = 0;
                this.gvProducts.DataBind();

                this.txtID.Text = "";

                this.txtName.Text = "";
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
                int supID = -1, catID = -1;
                if (this.cbSupplierID.SelectedIndex > 0)
                {
                    supID = ((ProductModel.IdItem) this.suppList[cbSupplierID.SelectedIndex ]).Id;
                }
                if (this.cbCatID.SelectedIndex > 0)
                {
                    catID = ((ProductModel.IdItem) this.catList[cbCatID.SelectedIndex ]).Id;
                }
                newFilter += this._dataModel.filter(txtName.Text, supID, catID,
                                            this.txtUnitPrice.Text, this.checkDiscontinue.Checked);

                Session["pro_filter"] = newFilter;
                this.gvProducts.DataBind();
            }
            catch (Exception ex)
            {
                Session["current_error"] = ex.Message;
                Response.Redirect("serverError.aspx");
            }
        }

        protected void doDelete()
        {
            int IdToDelete = -1;
            try
            {
                IdToDelete = int.Parse(this.txtID.Text.Trim());
                this._dataModel.deleteRows("productid=" + IdToDelete);
                this.clearGVSelection();
                return;
            }
            catch
            {
                string mess = "THISP PRODUCT CANNOT BE DELETE BECAUSE IT IS IN SOME ORDERS! Please choose update & discontinue it!";
                this.scriptLb.Text = "<script>alert(\"" + mess + "\");window.location.assign(\"Products.aspx\")</script>";
            }

            
        }



        protected void doUpdate()
        {
            int ID = int.Parse(this.txtID.Text.Trim());
            Response.Redirect("Edit-Pro.aspx?proid=" + ID);
        }

        protected void gvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.bntDelete.Enabled = true;
            this.btnUpdate.Enabled = true;
            int selectedIndex = int.Parse(this.gvProducts.SelectedRow.Cells[1].Text);
            this.txtID.Text = selectedIndex.ToString();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            string newFilter = "";
            Session["pro_filter"] = newFilter;
            Response.Redirect("Products.aspx");
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
            Response.Redirect("Edit-Pro.aspx");
        }

    }
}
