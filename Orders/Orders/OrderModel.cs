using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Orders
{
   

    public class OrderModel : DataModelWithControl<Order>
    {
        private OrderDetailModel _detailModel;

        public OrderDetailModel DetailModel
        {
            get { return _detailModel; }
            set { _detailModel = value; }
        }

        public OrderModel(DataGridView control, DataGridView deltail_control,
             string host,  int port, string dbname, string username, string password, 
             string table_name, string detail_tb_name, OrderParser parser) :
            // init parent
            base(control,host, port, dbname, username, password, table_name, parser)

        {
            this._initTable();

            Order.OrderItemParser newParser = new Order.OrderItemParser();
            this._detailModel = new OrderDetailModel(deltail_control, host, port, dbname,
                                    username, password, detail_tb_name, newParser);
            newParser.DataModel = this._detailModel;                    
        }

        public void resetControl()
        {
            this.resetControl("");
        }

        private void _initTable()
        {
            this._control.Columns.Clear();
            this._initTable(Order.Sql_keys);
        }

        public override List<SqlParameter> SqlParams(Order item)
        {
            List<SqlParameter> resultList = new List<SqlParameter>();

            SqlParameter orderid = this.createSQLParam("orderid", SqlDbType.Int, item.Orderid);
            resultList.Add(orderid);

            SqlParameter custid;
            if (item.Custid == -2905)
                custid = this.createSQLParam("custid", SqlDbType.Int, DBNull.Value);
            else
                custid = this.createSQLParam("custid", SqlDbType.Int, item.Custid);

            resultList.Add(custid);

            SqlParameter orderdate = this.createSQLParam("orderdate", SqlDbType.DateTime, item.Orderdate);
            resultList.Add(orderdate);

            SqlParameter requireddate = this.createSQLParam("requireddate", SqlDbType.DateTime, item.Requireddate);
            resultList.Add(requireddate);

            SqlParameter shippedate = this.createSQLParam("shippeddate", SqlDbType.DateTime, item.Shippeddate);
            resultList.Add(shippedate);

            SqlParameter shipperid = this.createSQLParam("shipperid", SqlDbType.Int, item.Shipperid);
            resultList.Add(shipperid);

            SqlParameter shipname;
            if (item.Shipname.Equals(""))
                shipname = this.createSQLParam("shipname", SqlDbType.NVarChar, DBNull.Value);
            else
                shipname = this.createSQLParam("shipname", SqlDbType.NVarChar, item.Shipname);

            SqlParameter address = this.createSQLParam("shipaddress", SqlDbType.NVarChar, item.Shipaddress, 60);
            resultList.Add(address);

            SqlParameter city = this.createSQLParam("shipcity", SqlDbType.NVarChar, item.Shipcity, 15);
            resultList.Add(city);

            SqlParameter region;
            if (item.Shipregion.Equals(""))
                region = this.createSQLParam("shipregion", SqlDbType.NVarChar, DBNull.Value, 15);
            else region = this.createSQLParam("shipregion", SqlDbType.NVarChar, item.Shipregion, 15);
            resultList.Add(region);

            SqlParameter postalcode;
            if (item.Shippostalcode.Equals(""))
                postalcode = this.createSQLParam("shippostalcode", SqlDbType.NVarChar, DBNull.Value, 10);
            else postalcode = this.createSQLParam("shippostalcode", SqlDbType.NVarChar, item.Shippostalcode, 10);
            resultList.Add(postalcode);
            
            SqlParameter country = this.createSQLParam("shipcountry", SqlDbType.NVarChar, item.Shipcountry, 15);
            resultList.Add(country);


            return resultList;

        }


        public class OrderDetailModel : DataModelWithControl<Order.OrderItem>
        {
            private int _orderid = -1;

            public int OrderID
            {
                get { return _orderid; }
                set { _orderid = value; }
            }

            public OrderDetailModel( DataGridView control, string host, 
                int port, string dbname, string username, string password, 
                string table_name, Order.OrderItemParser parser) :
                // init parent
                base(control, host, port, dbname, username, password, table_name, parser)
            {
                this._control.Columns.Clear();
                this._initTable(Order.OrderItem.Sql_keys);
            }

            public void resetControl()
            {
                this.resetControl("orderid="+this._orderid);
            }

            public override List<SqlParameter> SqlParams(Order.OrderItem item)
            {
                List<SqlParameter> resultList = new List<SqlParameter>();

                SqlParameter orderid = this.createSQLParam("orderid", SqlDbType.Int, item.Orderid);
                resultList.Add(orderid);

                SqlParameter productid = this.createSQLParam("productid", SqlDbType.Int, item.Productid);
                resultList.Add(productid);

                SqlParameter unitprice = this.createSQLParam("unitprice", SqlDbType.Money, item.Uinitprice);
                resultList.Add(unitprice);

                SqlParameter qty = this.createSQLParam("qty", SqlDbType.SmallInt, item.Qty);
                resultList.Add(qty);

                SqlParameter discount = this.createSQLParam("discount", SqlDbType.Decimal, item.Discount.ToString());
                resultList.Add(discount);

                return resultList;

            }
        }
    }
}
