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
            EmployeeParser newParser = new EmployeeParser();
            this.dataModel = new EmployeeModel(this.gvEmployees, @".\SQL2008",
                 1433, "TSQLFundamentals2008","sa", "123456", "HR.Employees", newParser);
            newParser.DataModel = this.dataModel;
            try
            {
                this.dataModel.resetControl();
            }
            catch
            {
            }
        }

        protected void gvEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvEmployees.PageIndex = e.NewPageIndex;
            this.gvEmployees.DataBind();
        }
    }
}
