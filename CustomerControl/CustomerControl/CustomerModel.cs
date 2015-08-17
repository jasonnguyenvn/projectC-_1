using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using DataModel;
using System.Data;
using System.Windows.Forms;

namespace CustomerControl
{
    public class Customer : BaseDataObject
    {
        private int customerid;

        public int CustomerID
        {
            get { return customerid; }
            set { customerid = value; }
        }

    


        public string Companyname
        {
            get { return companyname; }
            set { companyname = value; }
        }

        private string contactname;

        public string Contactname
        {
            get { return contactname; }
            set { contactname = value; }
        }


        private string companyname;

        public string CompanyName
        {
            get { return companyname; }
            set { companyname = value; }
        }

        private string contacttitle;

        public string ContactTitle
        {
            get { return contacttitle; }
            set { contacttitle = value; }
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

        private string fax;

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

      

        public static readonly string[] Sql_keys =
        {
            "custid",
            "companyname",
            "contactname",
            "contacttitle",
            "address",
            "city",
            "region",
            "postalcode",
            "country",
            "phone",
            "fax"
            
        };

        public override string[] SqlKeys()
        {
            return Customer.Sql_keys;
        }

        public override object[] convertToRow()
        {
            object[] result = {
            this.customerid.ToString(),
            this.companyname,
            this.contactname,
            this.contacttitle,
            this.address,
            this.city,
            this.region,
            this.postalcode,
            this.country,
            this.phone,
            this.fax
           
        };
            return result;
        }

        public override void copyTo(BaseDataObject other)
        {
            if (other is Customer == false)
                throw new Exception("BAD TYPE TO CLONE. Class Customer.");
            Customer otherSupp = (Customer)other;
            otherSupp.customerid = this.customerid;
            otherSupp.companyname = this.companyname;
            otherSupp.contacttitle = this.contacttitle;
            otherSupp.address = this.address;
            otherSupp.city = this.city;
            otherSupp.region = this.region;
            otherSupp.postalcode = this.postalcode;
            otherSupp.country = this.country;
            otherSupp.phone = this.phone;
            otherSupp.fax = this.fax;
           
        }

        public override int getNoOfProp()
        {
            return Customer.Sql_keys.Length;
        }

        public override string getWhereFilterToUpdateSingleRow()
        {
            return " custid= " + this.customerid;
        }

        public Customer()
        {
            this.customerid = -1;
            this.companyname = "";
            this.contactname = "";
            this.contacttitle = "";
            this.address = "";
            this.city = "";
            this.region = "";
            this.postalcode = "";
            this.country = "";
            this.phone = "";
            this.fax = "";
            
        }

        public override string getErrorMessage(int errorCode)
        {
            switch (errorCode)
            {
                case -2: return "Some fields are empty";
            }
            return "";
        }

        public override int isValid()
        {
            if (this.companyname.Equals(""))
                return -2;
            if (this.contactname.Equals(""))
                return -2;
            if (this.contacttitle.Equals(""))
                return -2;
            if (this.address.Equals(""))
                return -2;
            if (this.city.Equals(""))
                return -2;
            /*if (this.region.Equals(""))
                return -2;
            if (this.postalcode.Equals(""))
                return -2;*/
            if (this.country.Equals(""))
                return -2;
            if (this.phone.Equals(""))
                return -2;
            /*if (this.fax.Equals(""))
                return -2;*/
            return 1;
        }

        public override bool Equals(object obj)
        {
            if (obj is Customer == false)
                return false;

            Customer other = (Customer)obj;
            return this.customerid == other.customerid;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override int[] isValid_multi()
        {
            throw new NotImplementedException();
        }
    }

    public class CustomerParser : DataObjectParser<Customer>
    {
        private CustomerModel _dataModel;

        public CustomerModel DataModel
        {
            get { return _dataModel; }
            set { _dataModel = value; }
        }

        public CustomerParser()
        {
            this._dataModel = null;
        }

        public override Customer parse(string[] keys,
                            List<SqlParameter> sqlParams)
        {
            Customer result = new Customer();
            int noOfProp = result.getNoOfProp();
            int noOfKeys = keys.Length;
            if (noOfProp > keys.Length || keys.Length != sqlParams.Count)
                throw new Exception("INVALID INPUT TO PARSE Customer");


            for (int i = 0; i < noOfProp; i++)
            {
                SqlParameter param = sqlParams[i];
                if (keys[i].Equals(param.ParameterName) == false)
                    throw new Exception("INVALID KEY TO PARSE EMPLOYE. "
                                + " KEYNAME: " + param.ParameterName);
                switch (keys[i])
                {
                    case "custid":
                        result.CustomerID = int.Parse(param.Value.ToString());
                        break;
                    case "companyname":
                        result.CompanyName = param.Value.ToString();
                        break;
                    case "contactname":
                        result.Contactname = param.Value.ToString();
                        break;
                    case "contacttitle":
                        result.ContactTitle = param.Value.ToString();
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
                    case "fax":
                        result.Fax = param.Value.ToString();
                        break;
                   
                }
            }

            return result;
        }

        public override string getPrimaryKey()
        {
            return "custid";
        }
    }


    // Hau added new class CustomerModel
    // This is the model to create 
    // a connection between form/webform
    // to Database.
    public class CustomerModel : DataModelWithControl<Customer>
    {

        public CustomerModel(DataGridView control, string host,
            int port, string dbname, string username, string password, string table_name, CustomerParser parser) :
            base(control, host, port, dbname, username, password, table_name, parser)
        {
            this._control.Columns.Clear();
            this._initTable(Customer.Sql_keys);
        }

        public void resetControl()
        {
            this.resetControl("");
        }

        public override List<SqlParameter> SqlParams(Customer item)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            SqlParameter customerID = this.createSQLParam("custid", SqlDbType.Int, item.CustomerID);
            SqlParameter companyName = this.createSQLParam("companyname", SqlDbType.NVarChar, item.CompanyName, 40);
            SqlParameter contactName = this.createSQLParam("contactname", SqlDbType.NVarChar, item.Contactname, 30);
            SqlParameter contactTitle = this.createSQLParam("contacttitle", SqlDbType.NVarChar, item.ContactTitle, 30);
            SqlParameter address = this.createSQLParam("address", SqlDbType.NVarChar, item.Address, 60);
            SqlParameter city = this.createSQLParam("city", SqlDbType.NVarChar, item.City, 15);
            SqlParameter region = this.createSQLParam("region", SqlDbType.NVarChar, item.Region, 15);
            SqlParameter postalCode = this.createSQLParam("postalcode", SqlDbType.NVarChar, item.Postalcode, 10);
            SqlParameter country = this.createSQLParam("country", SqlDbType.NVarChar, item.Country, 15);
            SqlParameter phone = this.createSQLParam("phone", SqlDbType.NVarChar, item.Phone, 24);
            SqlParameter fax = this.createSQLParam("fax", SqlDbType.NVarChar, item.Fax, 24);

            list.Add(customerID);
            list.Add(companyName);
            list.Add(contactName);
            list.Add(contactTitle);
            list.Add(address);
            list.Add(city);
            list.Add(region);
            list.Add(postalCode);
            list.Add(country);
            list.Add(phone);
            list.Add(fax);

            return list;

        }
        /*
        public List<Customer> SafetyDelete(string where_filter)
        {
            List<Customer> deletedList = this.getItems(where_filter);
            if (deletedList.Count <= 0)
                return new List<Customer>();

            foreach (Customer emp in deletedList)
            {
                emp.Continued = false;
                this.updateRow(emp);
                int delIndex = this.Data.IndexOf(emp);
                this.Data.RemoveAt(delIndex);
                this.DataSource.Rows.RemoveAt(delIndex);
            }

            return deletedList;
        }*/

        public void filter(string txtCompName, string txtContname, string txtAddr,
            string txtCity, string cbCountry, string txtPhone, string txtFax)
        {
            string sqlFilter = " d";
            if (txtCompName.Equals("") == false)
            {
                sqlFilter += string.Format(" AND  companyname LIKE '%{0}%' ", txtCompName.Trim());
            }
            if (txtContname.Equals("") == false)
            {
                sqlFilter += string.Format(" AND  contactname LIKE '%{0}%' ", txtContname.Trim());
            }
            if (txtAddr.Equals("") == false)
            {
                sqlFilter += string.Format(" AND  address LIKE '%{0}%' ", txtAddr.Trim());
            }
            if (txtCity.Equals("") == false)
            {
                sqlFilter += string.Format(" AND  city LIKE '%{0}%' ", txtCity.Trim());
            }
            if (cbCountry.Equals("") == false)
            {
                sqlFilter += string.Format(" AND  country LIKE '%{0}%' ", cbCountry.Trim());
            }
            if (txtPhone.Equals("") == false)
            {
                sqlFilter += string.Format(" AND  phone LIKE '%{0}%' ", txtPhone.Trim());
            }
            if (txtFax.Equals("") == false)
            {
                sqlFilter += string.Format(" AND  fax LIKE '%{0}%' ", txtFax.Trim());
            }

            this.resetControl(sqlFilter);

        }
    }


}
