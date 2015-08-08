using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Productions
{
    public partial class catelogies : UserControl
    {
        private CategoryModel datamodel;

        public catelogies()
        {
            InitializeComponent();
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"server=HAUNVCSE61546\SQL2008;Database=EmployeeDB;uid=sa;pwd=123456";
                con.Open();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            this._initModel();
        }

        protected void _initModel()
        {
            Productions.Properties.Settings setting = new Productions.Properties.Settings();

            CategoryParser newParser = new CategoryParser();
            
            

            //datamodel = new CategoryModel(this.gvCategories, setting.DB_HOST, setting.DB_PORT, setting.DB_NAME, setting.DB_USER, setting.DB_PASS, "Production.Categories", newParser);
            datamodel = new CategoryModel(this.gvCategories, ".\\SQL2008", setting.DB_PORT, setting.DB_NAME, setting.DB_USER, setting.DB_PASS, "Production.Categories", newParser);
            
            newParser.DataModel = datamodel;

            datamodel.resetControl();
        }

        private void btnCaAdd_Click(object sender, EventArgs e)
        {
            Category newCat = new Category();
            newCat.CategoryID = -1;
            newCat.CategoryName = txtCaName.Text;
            newCat.Description = rtxtDescription.Text;

            int check = newCat.isValid();

            if (check < -1)
            {
                MessageBox.Show(newCat.getErrorMessage(check));
            }
            else {
                this.datamodel.insertNewRow(newCat);
                //this.datamodel.resetControl();
                MessageBox.Show("Completed");
            }
        }
    }
}
