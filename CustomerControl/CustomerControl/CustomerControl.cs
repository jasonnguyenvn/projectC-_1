using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomerControl
{
    public partial class CustomerControl : UserControl
    {
        public CustomerControl()
        {
            InitializeComponent();
            //this.gvCustomers.ContextMenuStrip = this.GridViewMenu;
            Settings setting = new Settings();

            try
            {
                CustomerParser newParser = new CustomerParser();

                dataModel = new CustomerModel(
                                    this.gvCustomers,
                                    setting.DB_HOST,
                                    setting.DB_PORT,
                                    setting.DB_NAME,
                                    setting.DB_USER,
                                    setting.DB_PASS,
                                    "Sales.Customers",
                                    newParser);
                //dataModel = new CustomerModel(this.gvCustomers, ".\\SQL2008", setting.DB_PORT, setting.DB_NAME, setting.DB_USER, setting.DB_PASS, "HR.Customers", newParser);

                newParser.DataModel = dataModel;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this._initModel();
        }

        public CustomerControl(string host, int port, string dbname, string username,
            string password, string table_name, CustomerParser parser)
        {
            this.InitializeComponent();

            

            CustomerParser newParser = new CustomerParser();
            try
            {
                dataModel = new CustomerModel(
                                    this.gvCustomers,
                                    host,
                                    port,
                                    dbname,
                                    username,
                                    password,
                                    "Sales.Customers",
                                    newParser);
                newParser.DataModel = dataModel;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            this._initModel();
        }

        protected void _initModel()
        {
            this.gvCustomers.Columns.Clear();

            try
            {
                dataModel.resetControl();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private CustomerModel dataModel;

        public CustomerModel DataModel
        {
            get { return dataModel; }
        }
       

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
