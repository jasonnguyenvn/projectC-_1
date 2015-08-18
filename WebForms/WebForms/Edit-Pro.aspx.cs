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
    public partial class Edit_Pro : System.Web.UI.Page
    {
        ProductModel dataModel;
        int proID;
        bool newEmpMode = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.loadData();
        }

        protected void loadData()
        {
            ProductParser newParser = new ProductParser();
            this.dataModel = new ProductModel(@".\SQL2008",
                 1433, "TSQLFundamentals2008", "sa", "123456", "Production.Products", newParser);
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
            catList = new List<object>();
            suppList = new List<object>();
            catList.Add("");
            suppList.Add("");
            catList.AddRange(dataModel.getIDItemList("Production.Categories", 0, 1, " deactive=0").ToArray());
            suppList.AddRange(dataModel.getIDItemList("Production.Suppliers", 0, 1, " deactive=0").ToArray());
            if (IsPostBack == false)
            {
                this.cbCatID.DataSource = catList;
                this.cbCatID.DataBind();
                this.cbSupplierID.DataSource = suppList;
                this.cbSupplierID.DataBind();

            }

            if ((Request.Params.Get("proid") != null))
            {
                this.proID = int.Parse(Request.Params.Get("proid").Trim());
                this.newEmpMode = false;
                if (this.IsPostBack == true)
                    return;

                this.loadSuppData();

            }


        }


        List<object> catList;
        List<object> suppList;

        /*protected void loadEmpIDS()
        {
            this.cbManagerID.Items.Add("");
            object[] getIds = this.dataModel.getIDItemArray("HR.Products",0,1);
            foreach (object eachItem in getIds)
            {
                this.cbManagerID.Items.Add(eachItem.ToString());
            }
        }*/

        protected void loadSuppData()
        {
            try
            {
                List<Product> getFromDB = this.dataModel.getItems("productid=" + this.proID);

                Product dataObj = getFromDB[0];
                this.txtName.Text = dataObj.ProductName;
                this.txtUnitPrice.Text = dataObj.UnitPrice.ToString();
                this.checkDiscontinue.Checked = dataObj.Discontinued;

                ProductModel.IdItem tmp = new ProductModel.IdItem();
                tmp.Id = dataObj.SupplierID;
                int index = this.suppList.IndexOf(tmp);
                this.cbSupplierID.SelectedIndex = index;

                tmp.Id = dataObj.CategoryID;
                index = this.catList.IndexOf(tmp);
                this.cbCatID.SelectedIndex = index;
            }
            catch (Exception ex)
            {
                Session["current_error"] = ex.Message;
                Response.Redirect("serverError.aspx");
            }
          
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Product dataObj = new Product();
            dataObj.ProductID = -1;
            dataObj.ProductName = this.txtName.Text;
            int supID = -1, catID = -1;
            if (this.cbSupplierID.SelectedIndex > 0)
            {
                supID = ((ProductModel.IdItem)this.suppList[cbSupplierID.SelectedIndex]).Id;
            }
            if (this.cbCatID.SelectedIndex > 0)
            {
                catID = ((ProductModel.IdItem)this.catList[cbCatID.SelectedIndex ]).Id;
            }

            dataObj.CategoryID = catID;
            dataObj.SupplierID = supID;
            try
            {
                dataObj.UnitPrice = float.Parse(this.txtUnitPrice.Text);
            }
            catch
            {
                this.script.Text = "<script>alert(\"INALID UNIT PIRCE VALUE\");</script>";
                return;
            }
            dataObj.Discontinued = this.checkDiscontinue.Checked;
            

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
                        dataObj.ProductID = this.proID;
                        this.dataModel.updateRow(dataObj);
                    }

                    
                    //Server.Transfer("Products.aspx", true);
                }
            }
            catch (Exception ex)
            {
                Session["current_error"] = ex.Message;
                Response.Redirect("serverError.aspx");
            }

            Response.Redirect("Products.aspx");
        }

    }
}
