using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Productions
{
    public partial class products : UserControl
    {
        public products()
        {
            InitializeComponent();
            this._initModel();
        }


        private ProductModel dataModel;
        protected void _initModel()
        {
            Productions.Properties.Settings setting = new Productions.Properties.Settings();

            ProductParser newParser = new ProductParser();

            dataModel = new ProductModel(
                                this.gvProducts, 
                                setting.DB_HOST, 
                                setting.DB_PORT, 
                                setting.DB_NAME, 
                                setting.DB_USER, 
                                setting.DB_PASS, 
                                "Production.Products", 
                                newParser);
            
            dataModel = new ProductModel(this.gvProducts, ".\\SQL2008", setting.DB_PORT, setting.DB_NAME, setting.DB_USER, setting.DB_PASS, "Production.Products", newParser);
            
            newParser.DataModel = dataModel;

            dataModel.resetControl();
        }
    }
}
