using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Employee
{
    class Employee
    {
        private int empid;

    }


    class EmployeeModel
    {
        private System.Windows.Forms.DataGridView tableControl;

        internal List<Employee> Data
        {
            get { return _data; }
        }


        public EmployeeModel(System.Windows.Forms.DataGridView control)
        {
            this.tableControl = control;
        }

        // Load data
        private void loadData()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"server=localhost\SQL2008;database=EmployeeDB;integrated security=true";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "SELECT * FROM Employees";
                SqlDataReader dr = cmd.ExecuteReader();
               
                while (dr.Read())
                {
                   /* tblEmpl.Rows.Add(dr[0].ToString(), dr[1].ToString(),
                                    DateTime.Parse(dr[2].ToString()).ToShortDateString(),
                                    dr[3].ToString(), dr[4].ToString(),
                                    dr[5].ToString(), dr[6].ToString(), dr[7].ToString(),
                                    double.Parse(dr[8].ToString()));*/
                    // Tao doi tuong Employee
                    // Dua doi tuong employee vao grid // co ham convert
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // Add
        public void add(Employee newEmp)
        {
        }

        public void update(int index, Employee newData)
        {
        }

        public void delete(int index)
        {
        }
    }
}
