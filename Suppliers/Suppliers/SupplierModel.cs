using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DataModel;
using System.Windows.Forms;
using System.Data;

namespace Suppliers
{
    // Hau added new class Supplier
    // This class describes Suppliers.
    public class Supplier : BaseDataObject
    {
        private int supplierid;

        public int SupplierID
        {
            get { return supplierid; }
            set { supplierid = value; }
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

        private bool deactive;

        public bool Deactive
        {
            get { return deactive; }
            set { deactive = value; }
        }

        public static readonly string[] Sql_keys =
        {
            "supplierid",
            "companyname",
            "contactname",
            "contacttitle",
            "address",
            "city",
            "region",
            "postalcode",
            "country",
            "phone",
            "fax",
            "deactive"
        };

        public override string[] SqlKeys()
        {
            return Supplier.Sql_keys;
        }

        public override object[] convertToRow()
        {
            object[] result = {
                this.supplierid,
                this.companyname,
                this.contactname,
                this.contacttitle,
                this.address,
                this.city,
                this.region,
                this.postalcode,
                this.country,
                this.phone,
                this.fax,
                this.deactive.ToString()
            };
            return result;
        }

        public override void copyTo(BaseDataObject other)
        {
            if (other is Supplier == false)
                throw new Exception("BAD TYPE TO CLONE. Class Supplier.");
            Supplier otherSupp = (Supplier)other;
            otherSupp.supplierid = this.supplierid;
            otherSupp.companyname = this.companyname;
            otherSupp.contacttitle = this.contacttitle;
            otherSupp.address = this.address;
            otherSupp.city = this.city;
            otherSupp.region = this.region;
            otherSupp.postalcode = this.postalcode;
            otherSupp.country = this.country;
            otherSupp.phone = this.phone;
            otherSupp.fax = this.fax;
            otherSupp.deactive = this.deactive;
        }

        public override int getNoOfProp()
        {
            return Supplier.Sql_keys.Length;
        }

        public override string getWhereFilterToUpdateSingleRow()
        {
            return " supplierid=" + this.supplierid;
        }

        public override bool Equals(object obj)
        {
            if (obj is  Supplier == false)
                return false;

            Supplier other = (Supplier)obj;
            return this.SupplierID == other.SupplierID;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Supplier()
        {
            this.supplierid = -1;
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
            this.deactive = false;
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


        public override int[] isValid_multi()
        {
            List<int> result = new List<int>();
            if (this.companyname.Equals(""))
                result.Add(-2);
            if (this.contactname.Equals(""))
                result.Add(-2);
            if (this.contacttitle.Equals(""))
                result.Add(-2);
            if (this.address.Equals(""))
               result.Add(-2);
            if (this.city.Equals(""))
                result.Add(-2);
            /*if (this.region.Equals(""))
                return -2;
            if (this.postalcode.Equals(""))
                return -2;*/
            if (this.country.Equals(""))
                result.Add(-2);
            if (this.phone.Equals(""))
                result.Add(-2);
            /*if (this.fax.Equals(""))
                return -2;*/
            return result.ToArray();
        }
    }

    public class SupplierParser : DataObjectParser<Supplier>
    {
        private SupplierModel _dataModel;

        public SupplierModel DataModel
        {
            get { return _dataModel; }
            set { _dataModel = value; }
        }

        public SupplierParser()
        {
            this._dataModel = null;
        }

        public override Supplier parse(string[] keys,
                            List<SqlParameter> sqlParams)
        {
            Supplier result = new Supplier();
            int noOfProp = result.getNoOfProp();
            int noOfKeys = keys.Length;
            if (noOfProp > keys.Length || keys.Length != sqlParams.Count)
                throw new Exception("INVALID INPUT TO PARSE Supplier");


            for (int i = 0; i < noOfProp; i++)
            {
                SqlParameter param = sqlParams[i];
                if (keys[i].Equals(param.ParameterName) == false)
                    throw new Exception("INVALID KEY TO PARSE EMPLOYE. "
                                + " KEYNAME: " + param.ParameterName);
                switch (keys[i])
                {
                    case "supplierid":
                        result.SupplierID = int.Parse(param.Value.ToString());
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
                    case "deactive":
                        result.Deactive = param.Value.Equals(true) ? true : false;
                        break;
                }
            }

            return result;
        }

        public override string getPrimaryKey()
        {
            return "supplierid";
        }
    }


    // Hau added new class SupplierModel
    // This is the model to create 
    // a connection between form/webform
    // to Database.
    public class SupplierModel : DataModelWithControl<Supplier>
    {
        public SupplierModel( string host,
            int port, string dbname, string username, string password, string table_name, SupplierParser parser) :
            base(host, port, dbname, username, password, table_name, parser)
        {
        }


        public SupplierModel(object control, string host, 
            int port, string dbname, string username, string password, string table_name, SupplierParser parser) :
            base(control,host, port, dbname, username, password, table_name, parser)

        {
            this._initTable(Supplier.Sql_keys);
        }

        public void resetControl()
        {
            this.resetControl(" deactive=0");
        }

        public override List<SqlParameter> SqlParams(Supplier item)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            SqlParameter supplierID = this.createSQLParam("supplierid",SqlDbType.Int,item.SupplierID);
            SqlParameter companyName = this.createSQLParam("companyname", SqlDbType.NVarChar, item.CompanyName,40);
            SqlParameter contactName = this.createSQLParam("contactname", SqlDbType.NVarChar, item.Contactname,30);
            SqlParameter contactTitle = this.createSQLParam("contacttitle", SqlDbType.NVarChar, item.ContactTitle,30);
            SqlParameter address = this.createSQLParam("address", SqlDbType.NVarChar, item.Address,60);
            SqlParameter city = this.createSQLParam("city", SqlDbType.NVarChar, item.City,15);

            SqlParameter region;
            if (item.Region.Equals(""))
                region = this.createSQLParam("region", SqlDbType.NVarChar, DBNull.Value, 15);
            else region = this.createSQLParam("region", SqlDbType.NVarChar, item.Region, 15);
            SqlParameter postalcode;
            if (item.Postalcode.Equals(""))
                postalcode = this.createSQLParam("postalcode", SqlDbType.NVarChar, DBNull.Value, 10);
            else postalcode = this.createSQLParam("postalcode", SqlDbType.NVarChar, item.Postalcode, 10);

            SqlParameter country = this.createSQLParam("country", SqlDbType.NVarChar, item.Country,15);
            SqlParameter phone = this.createSQLParam("phone", SqlDbType.NVarChar, item.Phone,24);

            SqlParameter fax;
            if(item.Fax.Equals(""))
                 fax = this.createSQLParam("fax", SqlDbType.NVarChar, DBNull.Value, 24);
            else fax = this.createSQLParam("fax", SqlDbType.NVarChar, item.Fax, 24);

            SqlParameter deactive = this.createSQLParam("deactive", SqlDbType.Bit, item.Deactive);

            list.Add(supplierID);
            list.Add(companyName);
            list.Add(contactName);
            list.Add(contactTitle);
            list.Add(address);
            list.Add(city);
            list.Add(region);
            list.Add(postalcode);
            list.Add(country);
            list.Add(phone);
            list.Add(fax);
            list.Add(deactive);

            return list;

        }

        public Supplier SafeDelete(int suppID)
        {
            List<Supplier> tmp = this.getItems(" supplierid=" + suppID);
            if (tmp.Count <= 0)
                return null;
            Supplier get = tmp[0];
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(this.createSQLParam("supplierid", SqlDbType.Int, suppID));

            string command = "Safe_Delete_Supp";

            this.conn.Open();
            try
            {
                SqlCommand cmd = this.createSQLCommand(command, CommandType.StoredProcedure, param);
                int result = cmd.ExecuteNonQuery();
                if (result <= 0)
                    get = null;
            }
            catch (Exception ex)
            {
                throw new Exception("DATABASE ERROR. COULD NOT SAFE DELETE SUPPLIER. " + ex.Message);
            }
            finally
            {
                this.conn.Close();
                this.DataSource.Rows.RemoveAt(this.Data.IndexOf(get));
                this.Data.Remove(get);
                if (this._webControl != null)
                    this._webControl.DataBind();
            }

            return get;
        }

        public Supplier BadDelete(int suppID)
        {
            List<Supplier> tmp = this.getItems(" supplierid=" + suppID);
            if (tmp.Count <= 0)
                return null;
            Supplier get = tmp[0];

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(this.createSQLParam("supplierid", SqlDbType.Int, suppID));

            string command = "Delete_Supp";

            this.conn.Open();
            try
            {
                SqlCommand cmd = this.createSQLCommand(command, CommandType.StoredProcedure, param);
                int result =  cmd.ExecuteNonQuery();
                if (result <= 0)
                    get = null;
            }
            catch (Exception ex)
            {
                throw new Exception("DATABASE ERROR. COULD NOT DELETE SUPPLIER. " + ex.Message);
            }
            finally
            {
                this.conn.Close();
                this.DataSource.Rows.RemoveAt(this.Data.IndexOf(get));
                this.Data.Remove(get);
                if (this._webControl != null)
                    this._webControl.DataBind();
            }

            return get;
        }

        public string filter(string txtCompName, string txtContname, string txtAddr,
            string txtCity, string cbCountry, string txtPhone, string txtFax)
        {
            string sqlFilter = " deactive=0 ";
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

            return sqlFilter;
            
        }
    }
}
