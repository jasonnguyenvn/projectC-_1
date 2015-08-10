using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DataModel;
using System.Windows.Forms;
using System.Data;

namespace Productions
{
    // Hau added new class Product
    // This class describes Products.
    public class Product : BaseDataObject
    {
        private int productid;

        public int ProductID
        {
            get { return productid; }
            set { productid = value; }
        }

        private string productname;

        public string ProductName
        {
            get { return productname; }
            set { productname = value; }
        }

        private int supplierid;

        public int SupplierID
        {
            get { return supplierid; }
            set { supplierid = value; }
        }

        private int categoryid;

        public int CategoryID
        {
            get { return categoryid; }
            set { categoryid = value; }
        }

        private string unitprice;

        public string UnitPrice
        {
            get { return unitprice; }
            set { unitprice = value; }
        }

        private bool discontinued;

        public bool Discontinued
        {
            get { return discontinued; }
            set { discontinued = value; }
        }

        public static readonly string[] Sql_keys =
        {
            "productid",
            "productname",
            "supplierid",
            "categoryid",
            "unitprice",
            "discontinued"
        };

        public override string[] SqlKeys()
        {
            return Product.Sql_keys;
        }

        public override object[] convertToRow()
        {
            object[] result = {
                this.productid.ToString(),
                this.productname,
                this.supplierid.ToString(),
                this.categoryid.ToString(),
                this.unitprice,
                this.discontinued == true ?
                    "1" : "0"
            };
            return result;
        }

        public override void copyTo(BaseDataObject other)
        {
            Product otherEmp = (Product)other;
            otherEmp.productid = this.productid;
            otherEmp.productname = this.productname;
            otherEmp.supplierid = this.supplierid;
            otherEmp.categoryid = this.categoryid;
            otherEmp.unitprice = this.unitprice;
            otherEmp.discontinued = this.discontinued;
        }

        public override int getNoOfProp()
        {
            return Product.Sql_keys.Length;
        }

        public override string getWhereFilterToUpdateSingleRow()
        {
            return " productid=" + this.productid;
        }

        public override bool Equals(object obj)
        {
            Product other = (Product)obj;
            return this.ProductID == other.ProductID;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Product()
        {
            this.productid = -1;
            this.productname = "";
            this.supplierid = -1;
            this.categoryid = -1;
            this.unitprice = "";
            this.discontinued = true;
        }

        public override string getErrorMessage(int errorCode)
        {
            switch (errorCode)
            {
                case -2: return "Product Name cannot be empty";
            }
            return "";
        }

        public override int isValid()
        {
            if (this.productname.Equals(""))
                return -2;
            if (this.supplierid.Equals(""))
                return -3;
            if (this.categoryid.Equals(""))
                return -4;
            if (this.unitprice.Equals(""))
                return -5;
         
            return 1;
        }
    }

    public class ProductParser : DataObjectParser<Product>
    {
        public override string getPrimaryKey()
        {
            return "productid";
        }


        private ProductModel _dataModel;

        public ProductModel DataModel
        {
            get { return _dataModel; }
            set { _dataModel = value; }
        }

        public ProductParser()
        {
           
        }

        public override Product parse(string[] keys,
                            List<SqlParameter> sqlParams)
        {
            Product result = new Product();
            int noOfProp = result.getNoOfProp();
            int noOfKeys = keys.Length;
            if (noOfProp > keys.Length || keys.Length != sqlParams.Count)
                throw new Exception("INVALID INPUT TO PARSE Product");


            for (int i = 0; i < noOfProp; i++)
            {
                SqlParameter param = sqlParams[i];
                if (keys[i].Equals(param.ParameterName) == false)
                    throw new Exception("INVALID KEY TO PARSE EMPLOYE. "
                                + " KEYNAME: " + param.ParameterName);
                switch (keys[i])
                {
                    case "productid":
                        result.ProductID = int.Parse(param.Value.ToString());
                        break;
                    case "productname":
                        result.ProductName = param.Value.ToString();
                        break;
                    case "categoryid":
                        result.CategoryID = int.Parse(param.Value.ToString());
                        break;
                    case "supplierid":
                        result.SupplierID = int.Parse(param.Value.ToString());
                        break;
                    case "unitprice":
                        result.UnitPrice = param.Value.ToString();
                        break;
                    case "discontinued":
                        string get = param.Value.ToString();
                        if (get == "1")
                            result.Discontinued = true;
                        else result.Discontinued = false;
                        break;
                }
            }

            return result;
        }

        public override Product parse(System.Data.SqlClient.SqlDataReader dr)
        {
            int count = dr.FieldCount;
            List<SqlParameter> Params = new List<SqlParameter>();
            for (int i = 0; i < count; i++)
            {
                SqlParameter param = new SqlParameter(dr.GetName(i), dr.GetValue(i));
                Params.Add(param);
            }

            return this.parse(Product.Sql_keys, Params);
        }
    }


    // Hau added new class ProductModel
    // This is the model to create 
    // a connection between form/webform
    // to Database.
    public class ProductModel : DataModelWithControl<Product>
    {
         public ProductModel(DataGridView control,  string host,
            int port, string dbname, string username, string password, string table_name, ProductParser parser) :
            base(control, host, port, dbname,username, password, table_name, parser)

        {
            this._initTable();
        }

        private void _initTable()
        {
            string[] keys = Product.Sql_keys;
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

        public override List<SqlParameter> SqlParams(Product item)
        {
            SqlParameter ID = this.createSQLParam("productid", SqlDbType.Int, item.ProductID);
            SqlParameter Name = this.createSQLParam("productname", SqlDbType.NVarChar, item.ProductName, 40);
            SqlParameter supID = this.createSQLParam("supplierid", SqlDbType.Int, item.SupplierID);
            SqlParameter catID = this.createSQLParam("categoryid", SqlDbType.Int, item.CategoryID);
            SqlParameter UnitPrice = this.createSQLParam("unitprice", SqlDbType.Money, item.UnitPrice);
            SqlParameter Discontinued  =   this.createSQLParam("discontinued", SqlDbType.Bit, item.Discontinued);

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(ID);
            list.Add(Name);
            list.Add(supID);
            list.Add(catID);
            list.Add(UnitPrice);
            list.Add(Discontinued);

            return list;
        }
    }

}
