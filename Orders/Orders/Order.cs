using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using System.Data.SqlClient;

namespace Orders
{
    public class Order : BaseDataObject
    {
        private bool _shipped = true;

        public bool isShipped
        {
            get { return _shipped; }
            set { _shipped = value; }
        }

        private readonly List<OrderItem> orderItems;

        public List<OrderItem> OrderItems
        {
            get { return orderItems; }
        }

        public Order()
        {
            this.orderItems = new List<OrderItem>();
        }

        private int orderid;

        public int Orderid
        {
            get { return orderid; }
            set { orderid = value; }
        }

        private int custid;

        public int Custid
        {
            get { return custid; }
            set { custid = value; }
        }

        private int empid;

        public int Empid
        {
            get { return empid; }
            set { empid = value; }
        }

        private DateTime orderdate;

        public DateTime Orderdate
        {
            get { return orderdate; }
            set { orderdate = value; }
        }

        private DateTime requireddate;

        public DateTime Requireddate
        {
            get { return requireddate; }
            set { requireddate = value; }
        }

        private DateTime shippeddate;

        public DateTime Shippeddate
        {
            get { return shippeddate; }
            set { shippeddate = value; }
        }

        private int shipperid;

        public int Shipperid
        {
            get { return shipperid; }
            set { shipperid = value; }
        }

        private string freight;

        public string Freight
        {
            get { return freight; }
            set { freight = value; }
        }

        private string shipname;

        public string Shipname
        {
            get { return shipname; }
            set { shipname = value; }
        }

        private string shipaddress;

        public string Shipaddress
        {
            get { return shipaddress; }
            set { shipaddress = value; }
        }

        private string shipcity;

        public string Shipcity
        {
            get { return shipcity; }
            set { shipcity = value; }
        }

        private string shipregion;

        public string Shipregion
        {
            get { return shipregion; }
            set { shipregion = value; }
        }

        private string shippostalcode;

        public string Shippostalcode
        {
            get { return shippostalcode; }
            set { shippostalcode = value; }
        }

        private string shipcountry;

        public string Shipcountry
        {
            get { return shipcountry; }
            set { shipcountry = value; }
        }

        public static readonly string[] Sql_keys =
        {
            "orderid",
            "custid",
            "empid",
            "orderdate",
            "requireddate",
            "shippeddate",
            "shipperid",
            "freight",
            "shipname",
            "shipaddress",
            "shipcity",
            "shipregion",
            "shippostalcode",
            "shipcountry"
        };

        public override string[] SqlKeys()
        {
            return Sql_keys;
        }

        public override object[] convertToRow()
        {
            string shippedDate = "NOT SHIPPED YET";
            if (this.isShipped == true)
                shippedDate = this.shippeddate.ToShortDateString();
            object [] result = {
                this.orderid,
                this.custid,
                this.empid,
                this.orderdate.ToShortDateString(),
                this.requireddate.ToShortDateString(),
                shippedDate,
                this.shipperid,
                this.freight,
                this.shipname,
                this.shipaddress,
                this.shipcity,
                this.shipregion,
                this.shippostalcode,
                this.shipcountry
            };

            return result;
        }

        public override void copyTo(BaseDataObject other)
        {
            if (other is Order == false)
                throw new Exception("BAD REQUEST. INVALID DATE TYPE. METHOD: Order.CopyTo");

            Order cast = (Order)other;

            cast.orderid = this.orderid;
            cast.custid = this.custid;
            cast.empid = this.empid;
            cast.orderdate = this.orderdate;
            cast.requireddate = this.requireddate;
            cast.shippeddate = this.shippeddate;
            cast.shipperid = this.shipperid;
            cast.freight = this.freight;
            cast.shipname = this.shipname;
            cast.shipaddress = this.shipaddress;
            cast.shipcity = this.shipcity;
            cast.shipregion = this.shipregion;
            cast.shippostalcode = this.shippostalcode;
            cast.shipcountry = this.shipcountry;

        }
        public override int getNoOfProp()
        {
            return Sql_keys.Length;
        }

        public override string getWhereFilterToUpdateSingleRow()
        {
            return " orderid=" + this.orderid;
        }

        public override int isValid()
        {
            if (custid < 0 && custid!=-2905)
                return -1;
            if (empid < 0)
                return -2;
            if (requireddate.CompareTo(orderdate) < 0)
                return -3;
            if (shippeddate.CompareTo(orderdate) < 0)
                return -4;
            if (shipperid < 0)
                return -5;
            if(freight.Equals(""))
                return -6;
            if (shipaddress.Equals(""))
                return -6;
            if (shipcity.Equals(""))
                return -6;
            if (shipcountry.Equals(""))
                return -6;
            return 1;
        }

        public override int[] isValid_multi()
        {
            List<int> result = new List<int>();
            if (custid < 0 && custid!=-2905)
                result.Add(-1);
            if (empid < 0)
                result.Add(-2);
            if (requireddate.CompareTo(orderdate) < 0)
                result.Add(-3);
            if (shippeddate.CompareTo(orderdate) < 0)
                result.Add(-4);
            if (shipperid < 0)
                result.Add(-5);
            if (freight.Equals(""))
                result.Add(-6);
            if (shipname.Equals(""))
                result.Add(-6);
            if (shipaddress.Equals(""))
                result.Add(-6);
            if (shipcity.Equals(""))
                result.Add(-6);
            if (shipcountry.Equals(""))
                result.Add(-6);
            return result.ToArray() ;
        }

        public override string getErrorMessage(int errorCode)
        {
            switch (errorCode)
            {
                case -1: return "INVALID CUSTOMER ID";
                case -2: return "INVALID EMPLOYEE ID";
                case -3: return "INVALID REQUIRED DATE";
                case -4: return "INVALID SHIPPED DATE";
                case -5: return "INVALID FREIGHT VALUE";
                case -6: return "THIS FIELD CANNOT BE EMPTY";
            }

            return "";
        }

        public override bool Equals(object obj)
        {
            if (obj is Order == false)
                return false;

            Order other = (Order)obj;
            return this.Orderid == other.Orderid;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public class OrderItem : BaseDataObject
        {
            private int orderid;

            public int Orderid
            {
                get { return orderid; }
                set { orderid = value; }
            }

            private int productid;

            public int Productid
            {
                get { return productid; }
                set { productid = value; }
            }

            private string uinitprice;

            public string Uinitprice
            {
                get { return uinitprice; }
                set { uinitprice = value; }
            }

            private int qty;

            public int Qty
            {
                get { return qty; }
                set { qty = value; }
            }

            private float discount;

            public float Discount
            {
                get { return discount; }
                set { discount = value; }
            }


            public static readonly string[] Sql_keys =
            {
                "orderid",
                "productid",
                "unitprice",
                "qty",
                "discount"
            };

            public override string[] SqlKeys()
            {
                return Sql_keys;
            }

            public override object[] convertToRow()
            {
               object [] result = {
                   this.orderid,
                   this.productid,
                   this.uinitprice,
                   this.qty,
                   this.discount
               };

                return result;
            }

            public override void copyTo(BaseDataObject other)
            {
                if (other is OrderItem == false)
                    throw new Exception("BAD REQUEST. INVALID DATE TYPE. METHOD: OrderItem.CopyTo");

                OrderItem cast = (OrderItem)other;

                cast.orderid = this.orderid;
                cast.productid = this.productid;
                cast.uinitprice = this.uinitprice;
                cast.qty = this.qty;
                cast.discount = this.discount;

            }

            public override string getErrorMessage(int errorCode)
            {
                switch (errorCode)
                {
                    case -1:
                        return "INVALID ORDER ID";
                    case -2:
                        return "INVALID PRODUCT ID";
                    case -3:
                        return "INVALID UNIT PRICE";
                    case -4:
                        return "QUANTITY MUST BE HIGHER THAN 0";
                    case -5:
                        return "INVALID DISCOUNT";
                }
                return "";
            }

            public override int getNoOfProp()
            {
                return Sql_keys.Length;
            }

            public override string getWhereFilterToUpdateSingleRow()
            {
                return " orderid=" + this.orderid + " AND productid=" + this.productid;
            }

            public override int isValid()
            {
                if (orderid < 0)
                    return -1;
                if (productid < 0)
                    return -2;
                if (this.uinitprice.Equals(""))
                    return -3;
                if (qty < 1)
                    return -4;
                if (discount < 0.0)
                    return -5;
                return 1;
            }

            public override int[] isValid_multi()
            {
                List<int> result = new List<int>();
                if (orderid < 0)
                    result.Add(-1);
                if (productid < 0)
                    result.Add(-2);
                if (this.uinitprice.Equals(""))
                    result.Add(-3);
                if (qty < 1)
                    result.Add(-4);
                if (discount < 0.0)
                    result.Add(-5);
                return result.ToArray();
            }

            public override bool Equals(object obj)
            {
                if (obj is OrderItem == false)
                    return false;

                OrderItem other = (OrderItem)obj;
                return this.Orderid == other.Orderid 
                    && this.productid == other.productid;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

        public class OrderItemParser : DataObjectParser<OrderItem>
        {
            private OrderModel.OrderDetailModel _dataModel;

            public OrderModel.OrderDetailModel DataModel
            {
                get { return _dataModel; }
                set { _dataModel = value; }
            }


            public override string getPrimaryKey()
            {
                return "";
            }

            public override OrderItem parse(string[] keys, List<System.Data.SqlClient.SqlParameter> sqlParams)
            {
                OrderItem result = new OrderItem();
                int noOfProp = result.getNoOfProp();
                int noOfKeys = keys.Length;
                if (noOfProp > keys.Length || keys.Length != sqlParams.Count)
                    throw new Exception("INVALID INPUT TO PARSE OrderItem");


                for (int i = 0; i < noOfProp; i++)
                {
                    SqlParameter param = sqlParams[i];
                    if (keys[i].Equals(param.ParameterName) == false)
                        throw new Exception("INVALID KEY TO PARSE OrderItem. "
                                    + " KEYNAME: " + param.ParameterName);
                    switch (keys[i])
                    {
                        case "orderid":
                            result.Orderid = int.Parse(param.Value.ToString());
                            break;
                        case "productid":
                            result.Productid = int.Parse(param.Value.ToString());
                            break;
                        case "unitprice":
                            result.Uinitprice = param.Value.ToString();
                            break;
                        case "qty":
                            result.Qty = int.Parse(param.Value.ToString());
                            break;
                        case "discount":
                            result.Discount = float.Parse(param.Value.ToString());
                            break;
                        default:
                            throw new Exception("INVALID SQL KEY: " + keys[i]);
                    }
                }

                return result;
            }

            public override OrderItem parse(System.Data.SqlClient.SqlDataReader dr)
            {
                int count = dr.FieldCount;
                List<SqlParameter> Params = new List<SqlParameter>();
                for (int i = 0; i < count; i++)
                {
                    SqlParameter param = new SqlParameter(dr.GetName(i), dr.GetValue(i));
                    Params.Add(param);
                }

                return this.parse(OrderItem.Sql_keys, Params);
            }
        }
    }


    public class OrderParser : DataObjectParser<Order>
    {
        private OrderModel _dataModel;

        public OrderModel DataModel
        {
            get { return _dataModel; }
            set { _dataModel = value; }
        }

        public override string getPrimaryKey()
        {
            return "orderid";
        }

        public override Order parse(string[] keys, List<System.Data.SqlClient.SqlParameter> sqlParams)
        {
            Order result = new Order();
            int noOfProp = result.getNoOfProp();
            int noOfKeys = keys.Length;
            if (noOfProp > keys.Length || keys.Length != sqlParams.Count)
                throw new Exception("INVALID INPUT TO PARSE OrderItem");


            for (int i = 0; i < noOfProp; i++)
            {
                SqlParameter param = sqlParams[i];
                if (keys[i].Equals(param.ParameterName) == false)
                    throw new Exception("INVALID KEY TO PARSE OrderItem. "
                                + " KEYNAME: " + param.ParameterName);
                switch (keys[i])
                {
                    case "orderid":
                        result.Orderid = int.Parse(param.Value.ToString());
                        break;
                    case "custid":
                        result.Custid = int.Parse(param.Value.ToString());
                        break;
                    case "empid":
                        result.Empid = int.Parse(param.Value.ToString());
                        break;
                    case "orderdate":
                        try
                        {
                            result.Orderdate = DateTime.Parse(param.Value.ToString());
                        }
                        catch
                        {
                            throw new Exception(keys[i]+"INVALID DATE STRING: " + param.Value.ToString());
                        }
                        break;
                    case "requireddate":
                        try
                        {
                            result.Requireddate = DateTime.Parse(param.Value.ToString());
                        }
                        catch
                        {
                            throw new Exception(keys[i] + " INVALID DATE STRING: " + param.Value.ToString());
                        }
                        break;
                    case "shippeddate":
                        try
                        {
                            result.Shippeddate = DateTime.Parse(param.Value.ToString());
                        }
                        catch
                        {
                            result.Shippeddate = DateTime.Now;
                            result.isShipped = false;
                        }
                        break;
                    case "shipperid":
                        result.Shipperid = int.Parse(param.Value.ToString());
                        break;
                    case "freight":
                        result.Freight = param.Value.ToString();
                        break;
                    case "shipname":
                        result.Shipname = param.Value.ToString();
                        break;
                    case "shipaddress":
                        result.Shipaddress = param.Value.ToString();
                        break;
                    case "shipcity":
                        result.Shipcity = param.Value.ToString();
                        break;
                    case "shipregion":
                        result.Shipregion = param.Value.ToString();
                        break;
                    case "shippostalcode":
                        result.Shippostalcode = param.Value.ToString();
                        break;
                    case "shipcountry":
                        result.Shipcountry = param.Value.ToString();
                        break;
                    default:
                        throw new Exception("INVALID SQL KEY: " + keys[i]);
                }
            }

            return result;
        }

        public override Order parse(System.Data.SqlClient.SqlDataReader dr)
        {
            int count = dr.FieldCount;
            List<SqlParameter> Params = new List<SqlParameter>();
            for (int i = 0; i < count; i++)
            {
                SqlParameter param = new SqlParameter(dr.GetName(i), dr.GetValue(i));
                Params.Add(param);
            }

            return this.parse(Order.Sql_keys, Params);
        }
    }
}
