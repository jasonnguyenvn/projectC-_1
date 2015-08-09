using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DataModel;
using System.Windows.Forms;

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
            "fax"
        };

        public override string[] SqlKeys()
        {
            return Supplier.Sql_keys;
        }

        public override object[] convertToRow()
        {
            object[] result = {
                this.supplierid.ToString(),
                this.companyname,
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
            Supplier otherEmp = (Supplier)other;
            otherEmp.supplierid = this.supplierid;
            otherEmp.companyname = this.companyname;
            otherEmp.contacttitle = this.contacttitle;
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
            throw new NotImplementedException();
        }

        public override int isValid()
        {
            throw new NotImplementedException();
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

        public override Supplier parse(System.Data.SqlClient.SqlDataReader dr)
        {
            int count = dr.FieldCount;
            List<SqlParameter> Params = new List<SqlParameter>();
            for (int i = 0; i < count; i++)
            {
                SqlParameter param = new SqlParameter(dr.GetName(i), dr.GetValue(i));
                Params.Add(param);
            }

            return this.parse(Supplier.Sql_keys, Params);
        }

        public override string getPrimaryKey()
        {
            throw new NotImplementedException();
        }
    }


    // Hau added new class SupplierModel
    // This is the model to create 
    // a connection between form/webform
    // to Database.
    public class SupplierModel : DataModelWithControl<Supplier>
    {

        public SupplierModel(DataGridView control, string host, 
            int port, string dbname, string username, string password, string table_name, SupplierParser parser) :
            base(control,host, port, dbname, username, password, table_name, parser)

        {
            this._initTable();
        }


        private void _initTable()
        {
            string[] keys = Supplier.Sql_keys;
            this._control.Columns.Clear();
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

        public override List<SqlParameter> SqlParams(Supplier item)
        {
            throw new NotImplementedException();
        }
    }
}
