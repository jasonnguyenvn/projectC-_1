using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Suppliers.Properties;

namespace Suppliers
{
    public partial class Suppliers : UserControl
    {
        public Suppliers()
        {
            InitializeComponent();
            this._initModel();
        }
        private SupplierModel dataModel;
        protected void _initModel()
        {
            Settings  setting = new Settings();

            SupplierParser newParser = new SupplierParser();

            dataModel = new SupplierModel(
                                this.gvSuppliers,
                                setting.DB_HOST,
                                setting.DB_PORT,
                                setting.DB_NAME,
                                setting.DB_USER,
                                setting.DB_PASS,
                                "Production.Suppliers",
                                newParser);
            dataModel = new SupplierModel(this.gvSuppliers, ".\\SQL2008", setting.DB_PORT, setting.DB_NAME, setting.DB_USER, setting.DB_PASS, "Production.Suppliers", newParser);

            newParser.DataModel = dataModel;

            dataModel.resetControl();
        }
    }
}
