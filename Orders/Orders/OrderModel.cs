using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Web.UI.WebControls;

namespace Orders
{
   

    public class OrderModel : DataModelWithControl<Order>
    {
        public void deleteRow(int orderID)
        {
            String command = "Delete_Order";
            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(this.createSQLParam("orderid", SqlDbType.Int, orderID));
            this.conn.Open();
            try
            {
                SqlCommand cm = this.createSQLCommand(command, CommandType.StoredProcedure, param);
                cm.ExecuteNonQuery();

                
            }
            catch (Exception ex)
            {
                throw new Exception("CANNOT DELETE ORDER " + ex.Message);

            }
            finally
            {
                this.conn.Close();
                Order get = new Order();
                get.Orderid = orderID;
                this.DataSource.Rows.RemoveAt(this.Data.IndexOf(get));
                this.Data.Remove(get);
                this.DetailModel.OrderID = -1;
                this.DetailModel.resetControl();
            }
        }

        private OrderDetailModel _detailModel;

        public OrderDetailModel DetailModel
        {
            get { return _detailModel; }
        }

        public OrderModel(object control, 
             string host,  int port, string dbname, string username, string password, 
             string table_name, string detail_tb_name, OrderParser parser) :
            // init parent
            base(control,host, port, dbname, username, password, table_name, parser)

        {
            this._initTable();

            Order.OrderItemParser newParser = new Order.OrderItemParser();
            this._detailModel = new OrderDetailModel(host, port, dbname,
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

        public override Order insertNewRow(Order newItem)
        {
            Order result = base.insertNewRow(newItem);

            _detailModel.OrderID = result.Orderid;
            _detailModel.resetModel();

            Order.OrderItem[] items = new Order.OrderItem[newItem.OrderItems.Count];
            newItem.OrderItems.CopyTo(items);
            result.OrderItems.AddRange(items);

            try
            {
                foreach (Order.OrderItem eachItem in items)
                {
                    eachItem.Orderid = result.Orderid;
                    _detailModel.insertNewRow(eachItem);
                }
            }
            catch(Exception ex)
            {
                this.deleteRows("orderid=" + result.Orderid);
                throw new Exception("EXCEPTION THROWED WHEN INSERT NEW ORDER: " + ex.Message);
            }

            return result;
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

            SqlParameter empid = this.createSQLParam("empid", SqlDbType.Int, item.Empid);
            resultList.Add(empid);

            SqlParameter orderdate = this.createSQLParam("orderdate", SqlDbType.DateTime, item.Orderdate);
            resultList.Add(orderdate);

            SqlParameter requireddate = this.createSQLParam("requireddate", SqlDbType.DateTime, item.Requireddate);
            resultList.Add(requireddate);

            SqlParameter shippedate;
            if(item.isShipped==false)
                shippedate = this.createSQLParam("shippeddate", SqlDbType.DateTime, DBNull.Value);
            else 
                shippedate = this.createSQLParam("shippeddate", SqlDbType.DateTime, item.Shippeddate);
            resultList.Add(shippedate);

            SqlParameter shipperid =  this.createSQLParam("shipperid", SqlDbType.Int, item.Shipperid);
            resultList.Add(shipperid);

            SqlParameter freight = this.createSQLParam("freight", SqlDbType.Money, item.Freight);
            resultList.Add(freight);

            SqlParameter shipname;
            if (item.Shipname.Equals(""))
                shipname = this.createSQLParam("shipname", SqlDbType.NVarChar, DBNull.Value);
            else
                shipname = this.createSQLParam("shipname", SqlDbType.NVarChar, item.Shipname);
            resultList.Add(shipname);

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

            public void setNewControl(object con)
            {
                this._datasource = new DataTable();
                if (con is DataGridView)
                {
                    this._control = (DataGridView)con;
                    this._control.DataSource = this._datasource;
                }
                if (con is GridView)
                {
                    this._webControl = (GridView)con;
                    this._webControl.DataSource = this._datasource;
                }
                this._initTable(Order.OrderItem.Sql_keys);
                this.resetControl();
            }

            public OrderDetailModel( string host,
                int port, string dbname, string username, string password,
                string table_name, Order.OrderItemParser parser) :
                // init parent
                base(host, port, dbname, username, password, table_name, parser)
            {
                //this._control.Columns.Clear();
                //this._initTable(Order.OrderItem.Sql_keys);
            }

            public OrderDetailModel(object control, string host, 
                int port, string dbname, string username, string password, 
                string table_name, Order.OrderItemParser parser) :
                // init parent
                base(control, host, port, dbname, username, password, table_name, parser)
            {
                this._control.Columns.Clear();
                this._initTable(Order.OrderItem.Sql_keys);
            }

            public void resetModel()
            {
                base.resetModel("orderid=" + this._orderid);
            }

            public void resetControl()
            {
                if (this._orderid >= 0)
                    this.resetControl("orderid=" + this._orderid);
                else
                    this.DataSource.Rows.Clear();
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

                SqlParameter discount = this.createSQLParam("discount", SqlDbType.Decimal, item.Discount);
                resultList.Add(discount);

                return resultList;

            }


            
            
        }
    }
}
