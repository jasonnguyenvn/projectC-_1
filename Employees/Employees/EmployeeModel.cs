using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Employees
{
    // Hau added new class Employee
    // This class describes Employees.
    public class Employee : BaseDataObject
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

        private bool jobStatus;

        public bool JobStatus
        {
            get { return jobStatus; }
            set { jobStatus = value; }
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
            "postalcode",
            "country",
            "phone",
            "mgrid",
            "jobStatus"
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
                this.mgrid.ToString(),
                this.jobStatus.ToString()
            };
            return result;
        }

        public override void copyTo(BaseDataObject other)
        {
            if (other is Employee == false)
                throw new Exception("BAD TYPE TO CLONE. Class Employee.");
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
            otherEmp.mgrid = this.mgrid;
            otherEmp.jobStatus = this.jobStatus;
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
            if (obj is Employee == false)
                return false;

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
            this.jobStatus = true;
        }

        public override string getErrorMessage(int errorCode)
        {
            switch(errorCode)
            {
                case -1: return "Some fields are empty";
                case -5: return "Employee must be 18 or older";
                
            }
            return "";
        }

        public override int isValid()
        {
            if (this.firstname.Equals("")) 
                return -1;
            if (this.lastname.Equals("")) 
                return -1;
            if (this.title.Equals("")) 
                return -1;
            if (this.titleofcourtesy.Equals("")) 
                return -1;
            if (this.address.Equals("")) 
                return -1;
            if (this.city.Equals("")) 
                return -1;
            if (this.country.Equals("")) 
                return -1;
            if (this.phone.Equals("")) 
                return -1;

            if (DateTime.Now.Year - this.Birthdate.Year < 18)
                return -5;
            

            return 1;

        }

        /*public override string[] getErrorMessage(int[] errorCodes)
        {
            List<string> result = new List<string>();

            foreach (int eachError in errorCodes)
            {
                result.Add(this.getErrorMessage(eachError));
            }

            return result.ToArray();
        }*/

        public override int[] isValid_multi()
        {
            List<int> result = new List<int>();
            

            if (this.firstname.Equals("")) 
                result.Add( -1);
            if (this.lastname.Equals("")) 
                result.Add(-1);
            if (this.title.Equals("")) 
                result.Add( -1);
            if (this.titleofcourtesy.Equals("")) 
                result.Add( -1);
            if (DateTime.Now.Year-this.Birthdate.Year<18) 
                result.Add( -5);
            if (this.address.Equals("")) 
                result.Add( -1);
            if (this.city.Equals("")) 
                result.Add( -1);
            if (this.country.Equals("")) 
                result.Add( -1);
            if (this.phone.Equals("")) 
                result.Add( -1);

            return result.ToArray();
        }
    }

    public class EmployeeParser : DataObjectParser<Employee>
    {
        private EmployeeModel _dataModel;

        public EmployeeModel DataModel
        {
            get { return _dataModel; }
            set { _dataModel = value; }
        }

        public EmployeeParser()
        {
            this._dataModel = null;
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
                    throw new Exception("INVALID KEY TO PARSE EMPLOYEE. "
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
                        try
                        {
                            result.Mgrid = int.Parse(param.Value.ToString());
                        }
                        catch { }
                        break;
                    case "jobStatus":
                        result.JobStatus = param.Value.Equals(true) ? true : false;
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
                Params.Add(param);
            }

            return this.parse(Employee.Sql_keys, Params);
        }

        public override string getPrimaryKey()
        {
            return "empid";
        }
    }


    // Hau added new class EmployeeModel
    // This is the model to create 
    // a connection between form/webform
    // to Database.
    public class EmployeeModel : DataModelWithControl<Employee>
    {
        public EmployeeModel( string host,
            int port, string dbname, string username, string password, string table_name, EmployeeParser parser) :
            base( host, port, dbname, username, password, table_name, parser)
        {
           
        }

        public EmployeeModel(object control,  string host, 
            int port, string dbname, string username, string password, string table_name, EmployeeParser parser) :
            base(control,host, port, dbname, username, password, table_name, parser)

        {
                this._initTable(Employee.Sql_keys);
        }

        

        public override List<SqlParameter> SqlParams(Employee item)
        {
            List<SqlParameter> result = new List<SqlParameter>();

            SqlParameter empid = this.createSQLParam("empid", SqlDbType.Int, item.Empid);
            SqlParameter lastname = this.createSQLParam("lastname", SqlDbType.NVarChar, item.Lastname, 20);
            SqlParameter firstname = this.createSQLParam("firstname", SqlDbType.NVarChar, item.Firstname, 10);
            SqlParameter title = this.createSQLParam("title", SqlDbType.NVarChar, item.Title, 30);
            SqlParameter titleofcourtesy = this.createSQLParam("titleofcourtesy", SqlDbType.VarChar, item.Titleofcourtesy, 25);
            SqlParameter birthdate = this.createSQLParam("birthdate", SqlDbType.DateTime, item.Birthdate);
            SqlParameter hiredate = this.createSQLParam("hiredate", SqlDbType.DateTime, item.Hiredate);
            SqlParameter address = this.createSQLParam("address", SqlDbType.NVarChar, item.Address, 60);
            SqlParameter city = this.createSQLParam("city", SqlDbType.NVarChar, item.City, 15);
            SqlParameter region;
            if(item.Region.Equals(""))
               region = this.createSQLParam("region", SqlDbType.NVarChar,  DBNull.Value, 15);
            else region = this.createSQLParam("region", SqlDbType.NVarChar, item.Region, 15); 
            SqlParameter postalcode;
            if(item.Postalcode.Equals(""))
                postalcode = this.createSQLParam("postalcode", SqlDbType.NVarChar, DBNull.Value, 10);
            else postalcode = this.createSQLParam("postalcode", SqlDbType.NVarChar, item.Postalcode, 10);
            SqlParameter country = this.createSQLParam("country", SqlDbType.NVarChar, item.Country, 15);
            SqlParameter phone = this.createSQLParam("phone",SqlDbType.NVarChar,item.Phone,24);
            SqlParameter mgrid = null;
            SqlParameter jobStatus = this.createSQLParam("jobStatus", SqlDbType.Bit, item.JobStatus);
            if(item.Mgrid>=0)
                mgrid = this.createSQLParam("mgrid", SqlDbType.Int, item.Mgrid);
            else 
                mgrid = this.createSQLParam("mgrid", SqlDbType.Int, DBNull.Value);

            result.Add(empid);
            result.Add(lastname);
            result.Add(firstname);
            result.Add(title);
            result.Add(titleofcourtesy);
            result.Add(birthdate);
            result.Add(hiredate);
            result.Add(address);
            result.Add(city);
            result.Add(region);
            result.Add(postalcode);
            result.Add(country);
            result.Add(phone);
            result.Add(mgrid);
            result.Add(jobStatus);

            return result;
        }

        public void resetControl()
        {

            base.resetControl(" jobStatus='1'");
            
        }

        public override List<Employee> deleteRows(string where_filter)
        {
            try
            {
                return base.deleteRows(where_filter);
            }
            catch
            {
                List<Employee> deletedList = this.getItems(where_filter);
                if (deletedList.Count <= 0)
                    return new List<Employee>();
                foreach (Employee emp in deletedList)
                {

                    emp.JobStatus = false;
                    this.updateRow(emp);
                    int delIndex = this.Data.IndexOf(emp);
                    this.Data.RemoveAt(delIndex);
                    this.DataSource.Rows.RemoveAt(delIndex);
                }
                return deletedList;
            }

            
            
        }

        public string filter(string txtName, string txtTitle, string txtCity,
            string txtRegion, string txtCountry, string txtPhone, string txtManagerID)
        {
            string sqlFilter = "jobStatus=1 ";
            if (txtName.Equals("") == false)
            {
                sqlFilter += string.Format(" AND (lastname LIKE '%{0}%' OR firstname LIKE '%{0}%') ", txtName.Trim());

            }
            if (txtTitle.Equals("") == false)
            {
                sqlFilter += string.Format(" AND title LIKE '%{0}%' ", txtTitle.Trim());
            }
            if (txtCity.Equals("") == false)
            {
                sqlFilter += string.Format(" AND city LIKE '%{0}%' ", txtCity.Trim());
            }
            if (txtRegion.Equals("") == false)
            {
                sqlFilter += string.Format(" AND region LIKE '%{0}%' ", txtRegion.Trim());
            }
            if (txtCountry.Equals("") == false)
            {
                sqlFilter += string.Format(" AND country LIKE '%{0}%' ", txtCountry.Trim());
            }

            if (txtPhone.Equals("") == false)
            {
                sqlFilter += string.Format(" AND phone LIKE '%{0}%' ", txtPhone.Trim());
            }

            if (txtManagerID.Equals("") == false)
            {
                sqlFilter += string.Format(" AND mgrid={0} ", txtManagerID.Trim());
            }

            this.resetControl(sqlFilter);

            return sqlFilter;
            
        }

        /*public object[] getEmployeeIDs()
        {
            List<object> result = new List<object>();

            foreach (Employee item in this.Data)
            {
                result.Add(item.Empid);
            }

            return result.ToArray();
        }*/
    }
}
