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
using Productions;

namespace WebForms
{
    public partial class Edit_Cat : System.Web.UI.Page
    {
        CategoryModel dataModel;
        int suppID;
        bool newEmpMode = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.loadData();
        }

        protected void loadData()
        {
            CategoryParser newParser = new CategoryParser();
            this.dataModel = new CategoryModel(@".\SQL2008",
                 1433, "TSQLFundamentals2008", "sa", "123456", "Production.Categories", newParser);
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

            /*if (this.IsPostBack == false)
                this.loadEmpIDS();*/


            if ((Request.Params.Get("suppid") != null)) 
            {
                this.suppID = int.Parse(Request.Params.Get("suppid").Trim());
                this.newEmpMode = false;
                if (this.IsPostBack == true)
                    return;
                
                this.loadSuppData();
                
            }

        }

        /*protected void loadEmpIDS()
        {
            this.cbManagerID.Items.Add("");
            object[] getIds = this.dataModel.getIDItemArray("HR.Categorys",0,1);
            foreach (object eachItem in getIds)
            {
                this.cbManagerID.Items.Add(eachItem.ToString());
            }
        }*/

        protected void loadSuppData()
        {
            try
            {
                List<Category> getFromDB = this.dataModel.getItems("categoryid=" + this.suppID);

                Category catData = getFromDB[0];
                this.txtCatID.Text = catData.CategoryID.ToString();
                this.txtCatName.Text = catData.CategoryName;
                this.txtDescription.Text = Server.HtmlDecode(catData.Description);
                /*this.txtSuppID.Text = suppData.CategoryID.ToString();
                this.txtCompanyName.Text = suppData.CompanyName;
                this.txtContactName.Text = suppData.Contactname;
                this.txtTitle.Text = suppData.ContactTitle;fff
                this.txtAddress.Text = suppData.Address;
                this.txtCity.Text = suppData.City;
                this.txtRegion.Text = suppData.Address;
                this.txtPostalCode.Text = suppData.Postalcode;
                this.txtCountry.Text = suppData.Country;
                this.txtPhone.Text = suppData.Phone;
                this.txtFax.Text = suppData.Fax;*/
            }
            catch (Exception ex)
            {
                Session["current_error"] = ex.Message;
                Response.Redirect("serverError.aspx");
            }
          
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Category dataObj = new Category();
            dataObj.CategoryName = this.txtCatName.Text;
            dataObj.Description = this.txtDescription.Text;
            /*dataObj.CategoryID = -1;
            dataObj.CompanyName = this.txtCompanyName.Text;
            dataObj.Contactname = this.txtContactName.Text;
            dataObj.ContactTitle = this.txtTitle.Text;
            dataObj.Address = this.txtAddress.Text;
            dataObj.City = this.txtCity.Text;
            dataObj.Region = this.txtRegion.Text;
            dataObj.Postalcode = this.txtPostalCode.Text;
            dataObj.Country = this.txtCountry.Text;
            dataObj.Phone = this.txtPhone.Text;
            dataObj.Fax = this.txtFax.Text;*/

            try
            {

                int check = dataObj.isValid();

                if (check < 0)
                {
                    //MessageBox.Show(newEmp.getErrorMessage(check));
                    this.script.Text = "<script>alert(\""+dataObj.getErrorMessage(check)+"\");</script>";
                    return;
                }
                else
                {
                    if (this.newEmpMode == true)
                        this.dataModel.insertNewRow(dataObj);
                    else
                    {
                        dataObj.CategoryID = this.suppID;
                        this.dataModel.updateRow(dataObj);
                    }

                    
                    //Server.Transfer("Categorys.aspx", true);
                }
            }
            catch (Exception ex)
            {
                Session["current_error"] = ex.Message;
                Response.Redirect("serverError.aspx");
            }

            Response.Redirect("Categories.aspx");
        }

    }
}
