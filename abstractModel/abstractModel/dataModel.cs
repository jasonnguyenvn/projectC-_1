using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace abstractModel
{
    public class dataModel<T>
    {
        private List<T> _data;
        protected string _host;
        protected int _port;
        protected string _dbname;
        protected string _username;
        protected string _password;

        private readonly string _tbname;

        protected string Tbname
        {
            get { return _tbname; }
        } 


        public dataModel(string host, int port, string dbname, string username, string password, string table_name)
        {
            this._host = host;
            this._port = port;
            this._dbname = dbname;
            this._username = username;
            this._password = password;

            this._tbname = table_name;

            this._data = new List<T>();
        }


        protected SqlConnection connect()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"server="+this._host
                                    +";database="+this._dbname
                                    +";User ID="+this._username
                                    +";Password="+this._password+";";
            conn.Open();
            return conn;
        }


        private SqlParameter createSQLParam(string key, SqlDbType dbType, object value, int size)
        {
            SqlParameter param = new SqlParameter(key, dbType, size);
            param.Value = value;
            return param;
        }

        private SqlParameter createSQLParam(string key, SqlDbType dbType, object value)
        {
            SqlParameter param = new SqlParameter(key, dbType);
            param.Value = value;
            return param;
        }

    }
}
