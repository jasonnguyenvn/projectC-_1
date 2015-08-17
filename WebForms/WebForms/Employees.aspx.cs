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
using Employees;
using System.Collections.Generic;

namespace WebForms
{
    public partial class Employees : System.Web.UI.Page
    {
        private EmployeeModel dataModel;
        private List<Control> textboxs;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                this.txtCountry.DataSource = EmployeeModel.GetCountries();
                this.txtCountry.DataBind();
            }

            loadData();
            this.textboxs = new List<Control>();
            this.textboxs.Add(txtName);
            this.textboxs.Add(txtTitle);
            this.textboxs.Add(txtCity);
            this.textboxs.Add(txtRegion);
            this.textboxs.Add(txtCountry);
            this.textboxs.Add(txtPhone);
            this.textboxs.Add(cbManagerID);
        }

        protected void loadData()
        {
            string currentFilter ;
            if (IsPostBack == false)
            {
                Session["emp_filter"] = "jobStatus=1 ";
                currentFilter = "jobStatus=1 "; 
            }
            else
                currentFilter = (string)Session["emp_filter"];
            //this.scriptLb.Text = currentFilter;
            EmployeeParser newParser = new EmployeeParser();
            this.dataModel = new EmployeeModel(this.gvEmployees, @".\SQL2008",
                 1433, "TSQLFundamentals2008","sa", "123456", "HR.Employees", newParser);
            newParser.DataModel = this.dataModel;
            try
            {
                this.dataModel.resetControl(currentFilter);
                if (this.IsPostBack == false)
                    this.loadEmpIDS();
            }
            catch(Exception ex)
            {
                Session["current_error"] = ex.Message;
                Response.Redirect("serverError.aspx");
            }

            
        }

        protected void gvEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvEmployees.SelectedIndex = -1;
            this.txtID.Text = "";
            this.bntDelete.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.gvEmployees.PageIndex = e.NewPageIndex;
            this.gvEmployees.DataBind();
        }

        protected void loadEmpIDS()
        {
            this.cbManagerID.Items.Add("");
            object[] getIds = this.dataModel.getIDItemArray("HR.Employees",0,1);
            foreach (object eachItem in getIds)
            {
                this.cbManagerID.Items.Add(eachItem.ToString());
            }
        }

        protected void clearGVSelection()
        {
            this.gvEmployees.SelectedIndex = -1;
            this.btnUpdate.Enabled = false;
            this.bntDelete.Enabled = false;
            this.txtID.Text = "";
        }

        protected void clearFilter()
        {
            string newFilter = "jobStatus=1 ";
            Session["emp_filter"] = newFilter;
            try
            {
                this.dataModel.resetControl(newFilter);
                this.gvEmployees.PageIndex = 0;
                this.gvEmployees.DataBind();

                this.txtID.Text = "";

                this.txtName.Text = "";
                this.txtTitle.Text = "";
                this.txtCity.Text = "";
                this.txtRegion.Text = "";
                this.txtPostalCode.Text = "";
                this.txtCountry.SelectedIndex = 0;
                this.txtPhone.Text = "";
                this.cbManagerID.Text = "";
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
                string mrid = "";
                if(cbManagerID.SelectedIndex>0)
                    mrid = this.dataModel.getIDItemList("HR.Employees", 0, 1)[cbManagerID.SelectedIndex-1].Id.ToString();
                string newFilter = " ";
                newFilter += this.dataModel.filter(txtName.Text, txtTitle.Text, txtCity.Text,
                    txtRegion.Text, txtCountry.Text, txtPhone.Text, mrid);

                Session["emp_filter"] = newFilter;
                this.gvEmployees.DataBind();
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
                this.dataModel.deleteRows(" empid=" + ID);
                this.gvEmployees.DataBind();
                this.clearGVSelection();
            }
            catch (Exception ex)
            {
                Session["current_error"] = ex.Message;
                Response.Redirect("serverError.aspx");
            }
        }

        

        protected void doUpdate()
        {
            int ID = int.Parse(this.txtID.Text.Trim());
            Response.Redirect("Edit-Emp.aspx?empid=" + ID);
        }

        protected void gvEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            this.txtID.Text = "";
            this.bntDelete.Enabled = true;
            this.btnUpdate.Enabled = true;
            int selectedIndex = int.Parse(this.gvEmployees.SelectedRow.Cells[1].Text);
            this.txtID.Text = selectedIndex.ToString();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            string newFilter = "jobStatus=1 ";
            Session["emp_filter"] = newFilter;
            Response.Redirect("Employees.aspx");
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
