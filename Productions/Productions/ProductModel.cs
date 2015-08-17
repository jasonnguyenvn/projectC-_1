﻿using System;
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

        private float unitprice;

        public float UnitPrice
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
            if(other is Product == false)
                throw new Exception("BAD TYPE TO CLONE. Class Product.");
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
            if (obj is Product == false)
                return false;
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
            this.unitprice = 0.0f;
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

        public override int[] isValid_multi()
        {
            throw new NotImplementedException();
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
                        result.UnitPrice = float.Parse(param.Value.ToString());
                        break;
                    case "discontinued":
                        if (param.Value.Equals(true))
                            result.Discontinued = true;
                        else result.Discontinued = false;
                        break;
                }
            }

            return result;
        }
    }


    // Hau added new class ProductModel
    // This is the model to create 
    // a connection between form/webform
    // to Database.
    public class ProductModel : DataModelWithControl<Product>
    {

        public string filter(string txtName, int txtSupplierID, int txtCategoryID, string txtUnitPrice, bool discontinue)
        {
            string sqlFilter = "";
            if (discontinue == true)
                sqlFilter = " discontinued=1";
            else
                sqlFilter = " discontinued=0";
            if (txtName.Equals("") == false)
            {
                sqlFilter += string.Format(" AND  productname LIKE '%{0}%' ", txtName.Trim());
            }
            if (txtSupplierID>=0)
            {
                sqlFilter += string.Format(" AND  supplierid=%{0}% ", txtSupplierID);
            }
            if (txtCategoryID>=0)
            {
                sqlFilter += string.Format(" AND  categoryid=%{0}% ", txtCategoryID);
            }
            if (txtUnitPrice.Equals("") == false)
            {
                sqlFilter += string.Format(" AND  unitprice LIKE '%{0}%' ", txtUnitPrice.Trim());
            }


            this.resetControl(sqlFilter);

            return sqlFilter;

        }


         public ProductModel(DataGridView control,  string host,
            int port, string dbname, string username, string password, string table_name, ProductParser parser) :
            base(control, host, port, dbname,username, password, table_name, parser)

        {
            this._initTable();
        }

        public void resetControl()
        {
            this.resetControl("");
        }

        private void _initTable()
        {
            this._control.Columns.Clear();
            this._initTable(Product.Sql_keys);

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
