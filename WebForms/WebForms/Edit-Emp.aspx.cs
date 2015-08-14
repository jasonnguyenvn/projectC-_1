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
            this.loadData();
        }

        protected void loadData()
        {
            EmployeeParser newParser = new EmployeeParser();
            this.dataModel = new EmployeeModel(@".\SQL2008",
                 1433, "TSQLFundamentals2008", "sa", "123456", "HR.Employees", newParser);
            newParser.DataModel = this.dataModel;

            /*try
            {
                this.dataModel.resetModel("");
            }
            catch (Exception ex)
            {
                Session["current_error"] = ex.Message;
                Response.Redirect("serverError.aspx");
            }*/

            

            if((Request.Params.Get("empid")!=null)) 
            {
                this.empID = int.Parse(Request.Params.Get("empid").Trim());
                this.newEmpMode = false;
                if (this.IsPostBack == true)
                    return;
                
                this.loadEmpData();
                
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
                this.txtAddress.Text = empData.Address;
                this.txtCity.Text = empData.City;
                this.txtRegion.Text = empData.Region;
                this.txtPostalCode.Text = empData.Postalcode;
                this.txtCountry.Text = empData.Country;
                this.txtPhone.Text = empData.Phone;
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
            newEmp.Birthdate = DateTime.Parse( this.txtBirthday.Text);
            newEmp.Hiredate = DateTime.Parse( this.txtHireday.Text);
            newEmp.Address = this.txtAddress.Text;
            newEmp.City = this.txtCity.Text;
            newEmp.Region = this.txtRegion.Text;
            newEmp.Postalcode = this.txtPostalCode.Text;
            newEmp.Country = this.txtCountry.Text;
            newEmp.Phone = this.txtPhone.Text;
            try
            {
                newEmp.Mgrid = int.Parse(this.txtManagerID.Text);
            }
            catch { newEmp.Mgrid = -1; }
            newEmp.JobStatus = true;

            try
            {

                int check = newEmp.isValid();

                if (check < 0)
                {
                    //MessageBox.Show(newEmp.getErrorMessage(check));

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
