using System;
using System.Collections;
using System.Collections.Generic;
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
    public partial class Edit_Emp : System.Web.UI.Page
    {
        EmployeeModel dataModel;
        int empID;
        bool newEmpMode = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                this.txtCountry.DataSource = EmployeeModel.GetCountries();
                this.txtCountry.DataBind();
            }
            this.loadData();
            
        }

        protected void loadData()
        {
            EmployeeParser newParser = new EmployeeParser();
            this.dataModel = new EmployeeModel(@".\SQL2008",
                 1433, "TSQLFundamentals2008", "sa", "123456", "HR.Employees", newParser);
            newParser.DataModel = this.dataModel;

            try
            {
                this.dataModel.resetModel("");
            }
            catch (Exception ex)
            {
                Session["current_error"] = ex.Message;
                Response.Redirect("serverError.aspx");
            }

            if (this.IsPostBack == false)
                this.loadEmpIDS();
            

            if((Request.Params.Get("empid")!=null)) 
            {
                this.empID = int.Parse(Request.Params.Get("empid").Trim());
                this.newEmpMode = false;
                if (this.IsPostBack == true)
                    return;
                
                this.loadEmpData();
                
            }

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

        protected void loadEmpData()
        {
            try
            {
                List<Employee> getFromDB = this.dataModel.getItems("empid=" + this.empID);
                Employee empData = getFromDB[0];
                this.txtEmpID.Text = this.empID.ToString();
                this.txtLastname.Text = empData.Lastname;
                this.txtFirstname.Text = empData.Firstname;
                this.txtTitle.Text = empData.Title;
                this.txtTitleOfCoursy.Text = empData.Titleofcourtesy;
                this.txtBirthday.Text = empData.Birthdate.ToShortDateString();
                this.txtHireday.Text = empData.Hiredate.ToShortDateString();
                this.txtAddress.Text =  Server.HtmlDecode(empData.Address);
                this.txtCity.Text = empData.City;
                this.txtRegion.Text = empData.Region;
                this.txtPostalCode.Text = empData.Postalcode;
                ListItem itm = new ListItem(empData.Country);
                this.txtCountry.SelectedIndex = this.txtCountry.Items.IndexOf(itm);
                this.txtPhone.Text = empData.Phone;

                this.cbManagerID.SelectedIndex = this.dataModel.getIDItemList("HR.Employees", 0, 1).IndexOf(empData.getMrId()) + 1;
            }
            catch (Exception ex)
            {
                Session["current_error"] = ex.Message;
                Response.Redirect("serverError.aspx");
            }
          
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Employee newEmp = new Employee();
            newEmp.Empid = -1;
            newEmp.Lastname = this.txtLastname.Text;
            newEmp.Firstname = this.txtFirstname.Text;
            newEmp.Title = this.txtTitle.Text;
            newEmp.Titleofcourtesy = this.txtTitleOfCoursy.Text;
            try
            {

                newEmp.Birthdate = DateTime.Parse(this.txtBirthday.Text);
                newEmp.Hiredate = DateTime.Parse(this.txtHireday.Text);
            }
            catch
            {
                this.script.Text = "<script>alert(\"INVALID DATE FORMAT AT BIRTHDATE OR HIREDATE\");</script>";
                return;
            }
            newEmp.Address =  Server.HtmlEncode(this.txtAddress.Text);
            newEmp.City = this.txtCity.Text;
            newEmp.Region = this.txtRegion.Text;
            newEmp.Postalcode = this.txtPostalCode.Text;
            newEmp.Country = this.txtCountry.SelectedItem.ToString();
            newEmp.Phone = this.txtPhone.Text;
            try
            {
                string mrid = "";
                if (cbManagerID.SelectedIndex > 0)
                    mrid = this.dataModel.getIDItemList("HR.Employees", 0, 1)[cbManagerID.SelectedIndex - 1].Id.ToString();
                newEmp.Mgrid = int.Parse(mrid);
            }
            catch { newEmp.Mgrid = -1; }
            newEmp.JobStatus = true;

            try
            {

                int check = newEmp.isValid();

                if (check < 0)
                {
                    //MessageBox.Show(newEmp.getErrorMessage(check));
                    this.script.Text = "<script>alert(\""+newEmp.getErrorMessage(check)+"\");</script>";
                    return;
                }
                else
                {
                    if (this.newEmpMode == true)
                        this.dataModel.insertNewRow(newEmp);
                    else
                    {
                        newEmp.Empid = this.empID;
                        this.dataModel.updateRow(newEmp);
                    }

                    
                    //Server.Transfer("Employees.aspx", true);
                }
            }
            catch (Exception ex)
            {
                Session["current_error"] = ex.Message;
                Response.Redirect("serverError.aspx");
            }

            Response.Redirect("Employees.aspx");
        }

    }
}
