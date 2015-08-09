using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using System.Data.SqlClient;

namespace Employees
{
    // Hau added new class Employee
    // This class describes Employees.
    public class Employee : DataObject
    {
        private int empid;

        public int Empid
        {
            get { return empid; }
            set { empid = value; }
        }

        private string lastname;

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        private string firstname;

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string titleofcourtesy;

        public string Titleofcourtesy
        {
            get { return titleofcourtesy; }
            set { titleofcourtesy = value; }
        }

        private DateTime birthdate;

        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

        private DateTime hiredate;

        public DateTime Hiredate
        {
            get { return hiredate; }
            set { hiredate = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private string region;

        public string Region
        {
            get { return region; }
            set { region = value; }
        }

        private string postalcode;

        public string Postalcode
        {
            get { return postalcode; }
            set { postalcode = value; }
        }

        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private int mgrid;

        public int Mgrid
        {
            get { return mgrid; }
            set { mgrid = value; }
        }

        public static readonly string[] Sql_keys =
        {
            "empid",
            "lastname",
            "firstname",
            "title",
            "titleofcourtesy",
            "birthdate",
            "hiredate",
            "address",
            "city",
            "region",
            "postatalcode",
            "country",
            "phone",
            "mgrid"
        };

        public override string[] SqlKeys()
        {
            return Employee.Sql_keys;
        }

        public override object[] convertToRow()
        {
            object [] result = {
                this.empid.ToString(),
                this.lastname,
                this.firstname,
                this.title,
                this.titleofcourtesy,
                this.birthdate.ToShortDateString(),
                this.hiredate.ToShortDateString(),
                this.address,
                this.city,
                this.region,
                this.postalcode,
                this.country,
                this.phone,
                this.mgrid.ToString()
            };
            return result;
        }

        public override void copyTo(DataObject other)
        {
            Employee otherEmp = (Employee) other;
            otherEmp.empid = this.empid;
            otherEmp.lastname = this.lastname;
            otherEmp.firstname = this.firstname;
            otherEmp.title = this.title;
            otherEmp.titleofcourtesy = this.titleofcourtesy;
            otherEmp.birthdate = this.birthdate;
            otherEmp.hiredate = this.hiredate;
            otherEmp.address = this.address;
            otherEmp.city = this.city;
            otherEmp.region = this.region;
            otherEmp.postalcode = this.postalcode;
            otherEmp.country = this.country;
            otherEmp.phone = this.phone;
        }

        public override int getNoOfProp()
        {
            return Employee.Sql_keys.Length;
        }

        public override string getWhereFilterToUpdateSingleRow()
        {
            return " empid=" + this.empid;
        }

        public override bool Equals(object obj)
        {
            Employee other = (Employee)obj;
            return this.Empid == other.Empid;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Employee()
        {
            this.empid = -1;
            this.lastname = "";
            this.firstname = "";
            this.title = "";
            this.titleofcourtesy = "";
            this.birthdate = DateTime.Today;
            this.hiredate = DateTime.Today;
            this.address = "";
            this.city = "";
            this.region = "";
            this.postalcode = "";
            this.country = "";
            this.phone = "";
            this.mgrid = -1;
        }

        public override string getErrorMessage(int errorCode)
        {
            throw new NotImplementedException();
        }

        public override int isValid()
        {
            throw new NotImplementedException();
        }
    }

    public class EmployeeParser : DataObjectParser<Employee>
    {
        private EmployeeModel _dataModel;

        public EmployeeParser(EmployeeModel dataModel)
        {
            this._dataModel = dataModel;
        }

        public override Employee parse(string[] keys, 
                            List<SqlParameter> sqlParams)
        {
            Employee result = new Employee();
            int noOfProp = result.getNoOfProp();
            int noOfKeys = keys.Length;
            if (noOfProp > keys.Length || keys.Length!=sqlParams.Count)
                throw new Exception("INVALID INPUT TO PARSE EMPLOYEE");


            for (int i = 0; i < noOfProp; i++)
            {
                SqlParameter param = sqlParams[i];
                if(keys[i].Equals(param.ParameterName)==false)
                    throw new Exception("INVALID KEY TO PARSE EMPLOYE. "
                                + " KEYNAME: " + param.ParameterName );
                switch (keys[i])
                {
                    case "empid":
                        result.Empid = int.Parse(param.Value.ToString());
                        break;
                    case "lastname":
                        result.Lastname = param.Value.ToString();
                        break;
                    case "firstname":
                        result.Firstname = param.Value.ToString();
                        break;
                    case "title":
                        result.Title = param.Value.ToString();
                        break;
                    case "titleofcourtesy":
                        result.Titleofcourtesy = param.Value.ToString();
                        break;
                    case "birthdate":
                        result.Birthdate = DateTime.Parse( param.Value.ToString() );
                        break;
                    case "hiredate":
                        result.Hiredate = DateTime.Parse( param.Value.ToString() );
                        break;
                    case "address":
                        result.Address = param.Value.ToString();
                        break;
                    case "city":
                        result.City = param.Value.ToString();
                        break;
                    case "region":
                        result.Region = param.Value.ToString();
                        break;
                    case "postalcode":
                        result.Postalcode = param.Value.ToString();
                        break;
                    case "country":
                        result.Country = param.Value.ToString();
                        break;
                    case "phone":
                        result.Phone = param.Value.ToString();
                        break;
                    case "mgrid":
                        result.Mgrid = int.Parse(param.Value.ToString());
                        break;
                }
            }

            return result;
        }

        public override Employee parse(System.Data.SqlClient.SqlDataReader dr)
        {
            int count = dr.FieldCount;
            List<SqlParameter> Params = new List<SqlParameter>();
            for (int i = 0; i < count; i++)
            {
                SqlParameter param = new SqlParameter(dr.GetName(i), dr.GetValue(i));
            }

            return this.parse(Employee.Sql_keys, Params);
        }

        public override string getPrimaryKey()
        {
            throw new NotImplementedException();
        }
    }


    // Hau added new class EmployeeModel
    // This is the model to create 
    // a connection between form/webform
    // to Database.
    public class EmployeeModel : DataModelWithControl<Employee>
    {
        private void _initTable()
        {
            string[] keys = Employee.Sql_keys;
            foreach (string aKey in keys)
            {
                System.Windows.Forms.DataGridViewColumn column;
                column = new System.Windows.Forms.DataGridViewTextBoxColumn();
                column.HeaderText = aKey;
                column.Name = "cl_" + aKey;
                column.SortMode = System.Windows.Forms
                                    .DataGridViewColumnSortMode
                                    .NotSortable;
                this._control.Columns.Add(column);
            }
        }

        public override List<SqlParameter> SqlParams(Employee item)
        {
            throw new NotImplementedException();
        }
    }
}
