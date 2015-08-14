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

namespace WebForms
{
    public partial class Employees : System.Web.UI.Page
    {
        private EmployeeModel dataModel;

        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();
        }

        protected void loadData()
        {
            if (Session["emp_filter"] == null)
                Session["emp_filter"] = "jobStatus=1 ";

            string currentFilter = (string)Session["emp_filter"];

            EmployeeParser newParser = new EmployeeParser();
            this.dataModel = new EmployeeModel(this.gvEmployees, @".\SQL2008",
                 1433, "TSQLFundamentals2008","sa", "123456", "HR.Employees", newParser);
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

        protected void gvEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvEmployees.PageIndex = e.NewPageIndex;
            this.gvEmployees.DataBind();
        }

        protected void clearGVSelection()
        {
            this.gvEmployees.SelectedIndex = -1;
            this.btnUpdate.Enabled = false;
            this.bntDelete.Enabled = false;
            
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
                this.txtCountry.Text = "";
                this.txtPhone.Text = "";
                this.txtManagerID.Text = "";
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
                string newFilter = "jobStatus=1 ";
                newFilter += this.dataModel.filter(txtName.Text, txtTitle.Text, txtCity.Text,
                    txtRegion.Text, txtCountry.Text, txtPhone.Text, txtManagerID.Text);

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
            this.bntDelete.Enabled = true;
            this.btnUpdate.Enabled = true;
            int selectedIndex = int.Parse(this.gvEmployees.SelectedRow.Cells[1].Text);
            this.txtID.Text = selectedIndex.ToString();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.clearGVSelection();
            this.clearFilter();
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
