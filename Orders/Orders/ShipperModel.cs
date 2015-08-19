using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DataModel;
using System.Data;

namespace Orders
{
    // Hau added new class Shipper.
    // This class describes Shippers.
    public class Shipper : BaseDataObject
    {


        private int Shipperid;

        public int ShipperID
        {
            get { return Shipperid; }
            set { Shipperid = value; }
        }

        private string companyname;

        public string CompanyName
        {
            get { return companyname; }
            set { companyname = value; }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private bool deactive;

        public bool Deactive
        {
            get { return deactive; }
            set { deactive = value; }
        }



        public static readonly string[] Sql_keys =
        {
            "shipperid",
            "companyname",
            "phone",
            "deactive"
        };

        public override string[] SqlKeys()
        {
            return Shipper.Sql_keys;
        }

        public override object[] convertToRow()
        {
            object[] result = {
                this.Shipperid,
                this.companyname,
                this.phone,
                this.Deactive
            };
            return result;
        }

        public override void copyTo(BaseDataObject other)
        {
            if (other is Shipper == false)
                throw new Exception("BAD TYPE TO CLONE. Class Shipper.");
            Shipper otherEmp = (Shipper)other;
            otherEmp.Shipperid = this.Shipperid;
            otherEmp.companyname = this.companyname;
            otherEmp.phone = this.phone;
            otherEmp.deactive = this.deactive;
        }

        public override int getNoOfProp()
        {
            return Shipper.Sql_keys.Length;
        }

        public override string getWhereFilterToUpdateSingleRow()
        {
            return " shipperid=" + this.Shipperid;
        }

        public override bool Equals(object obj)
        {
            if (obj is Shipper == false)
                return false;
            Shipper other = (Shipper)obj;
            return this.ShipperID == other.ShipperID;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Shipper()
        {
            this.Shipperid = -1;
            this.companyname = "";
            this.phone = "";
            this.deactive = false;
        }

        public override string getErrorMessage(int errorCode)
        {
            switch (errorCode)
            {
                case -2: return "Shipper Name cannot be empty";
            }
            return "";
        }


        // =1 => valid
        // < 0 => error
        public override int isValid()
        {
            if (this.companyname.Equals(""))
                return -2;
            return 1;
        }



        public override int[] isValid_multi()
        {
            throw new NotImplementedException();
        }
    }

    public class ShipperParser : DataObjectParser<Shipper>
    {
        public override string getPrimaryKey()
        {
            return "shipperid";
        }

        private ShipperModel _dataModel;

        public ShipperModel DataModel
        {
            get { return _dataModel; }
            set { _dataModel = value; }
        }

        public ShipperParser()
        {

        }

        public override Shipper parse(string[] keys,
                            List<SqlParameter> sqlParams)
        {
            Shipper result = new Shipper();
            int noOfProp = result.getNoOfProp();
            int noOfKeys = keys.Length;
            if (noOfProp > keys.Length || keys.Length != sqlParams.Count)
                throw new Exception("INVALID INPUT TO PARSE Shipper");


            for (int i = 0; i < noOfProp; i++)
            {
                SqlParameter param = sqlParams[i];
                if (keys[i].Equals(param.ParameterName) == false)
                    throw new Exception("INVALID KEY TO PARSE Shipper. "
                                + " KEYNAME: " + param.ParameterName);
                switch (keys[i])
                {
                    case "shipperid":
                        result.ShipperID = int.Parse(param.Value.ToString());
                        break;
                    case "companyname":
                        result.CompanyName = param.Value.ToString();
                        break;
                    case "phone":
                        result.Phone = param.Value.ToString();
                        break;

                    case "deactive":
                        result.Deactive = bool.Parse(param.Value.ToString());
                        break;
                }
            }

            return result;
        }

    }


    // Hau added new class ShipperModel
    // This is the model to create 
    // a connection between form/webform
    // to Database.
    public class ShipperModel : DataModelWithControl<Shipper>
    {
        public override List<Shipper> deleteRows(string where_filter)
        {
            try
            {
                return base.deleteRows(where_filter);
            }
            catch
            {
                List<Shipper> deletedList = this.getItems(where_filter);
                if (deletedList.Count <= 0)
                    return new List<Shipper>();
                foreach (Shipper emp in deletedList)
                {

                    emp.Deactive = true;
                    this.updateRow(emp);
                    int delIndex = this.Data.IndexOf(emp);
                    this.Data.RemoveAt(delIndex);
                    this.DataSource.Rows.RemoveAt(delIndex);
                }
                return deletedList;
            }

        }



        public string filter(string txtCatName, string txtDescription)
        {
            string sqlFilter = " deactive=0 ";
            if (txtCatName.Equals("") == false)
            {
                sqlFilter += string.Format(" AND  companyname LIKE '%{0}%' ", txtCatName.Trim());
            }
            if (txtDescription.Equals("") == false)
            {
                sqlFilter += string.Format(" AND  description LIKE '%{0}%' ", txtDescription.Trim());
            }


            this.resetControl(sqlFilter);

            return sqlFilter;

        }

        public ShipperModel(string host,
            int port, string dbname, string username, string password, string table_name, ShipperParser parser) :
            base(host, port, dbname, username, password, table_name, parser)
        {
        }

        public ShipperModel(object control, string host,
            int port, string dbname, string username, string password, string table_name, ShipperParser parser) :
            base(control, host, port, dbname, username, password, table_name, parser)
        {
            this._initTable(Shipper.Sql_keys);
        }


        public void resetControl()
        {
            this.resetControl(" deactive=0");
        }

        private void _initTable()
        {
            this._control.Columns.Clear();
            this._initTable(Shipper.Sql_keys);
        }

        public override List<SqlParameter> SqlParams(Shipper item)
        {
            SqlParameter ID = this.createSQLParam("shipperid", SqlDbType.Int, item.ShipperID);
            SqlParameter Name = this.createSQLParam("companyname", SqlDbType.NVarChar, item.CompanyName, 40);
            SqlParameter phone = this.createSQLParam("phone", SqlDbType.NVarChar, item.Phone, 24);
            SqlParameter Deactive = this.createSQLParam("deactive", SqlDbType.Bit, item.Deactive);

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(ID);
            list.Add(Name);
            list.Add(phone);
            list.Add(Deactive);

            return list;

        }

    }
}
