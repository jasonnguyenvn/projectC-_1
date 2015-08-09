using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Employees.Properties;

namespace Employees
{
    public partial class Employees : UserControl
    {
        private EmployeeModel dataModel;
        public Employees()
        {
            InitializeComponent();
            this._initModel();
        }

        protected void _initModel()
        {
            Settings setting = new Settings();

            EmployeeParser newParser = new EmployeeParser();

            dataModel = new EmployeeModel(
                                this.gvEmployees,
                                setting.DB_HOST,
                                setting.DB_PORT,
                                setting.DB_NAME,
                                setting.DB_USER,
                                setting.DB_PASS,
                                "HR.Employees",
                                newParser);
            dataModel = new EmployeeModel(this.gvEmployees, ".\\SQL2008", setting.DB_PORT, setting.DB_NAME, setting.DB_USER, setting.DB_PASS, "HR.Employees", newParser);

            newParser.DataModel = dataModel;

            dataModel.resetControl();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
