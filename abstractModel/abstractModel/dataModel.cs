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
        private string _host;
        private int _port;
        private string _dbname;
        private string _username;
        private string _password;

        protected SqlConnection conn;

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
            this.conn = this.createConnect();
        }


        protected SqlConnection createConnect()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"server="+this._host
                                    +";database="+this._dbname
                                    +";User ID="+this._username
                                    +";Password="+this._password+";";
            return conn;
        }


        protected SqlParameter createSQLParam(string key, SqlDbType dbType, object value, int size)
        {
            SqlParameter param = new SqlParameter(key, dbType, size);
            param.Value = value;
            return param;
        }

        protected SqlParameter createSQLParam(string key, SqlDbType dbType, object value)
        {
            SqlParameter param = new SqlParameter(key, dbType);
            param.Value = value;
            return param;
        }

        protected SqlCommand createSQLCommand(string commandText, CommandType commandType, List<SqlParameter> parameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.conn;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;

            if(parameters!=null)
            {
                foreach (SqlParameter param in parameters)
                {
                    cmd.Parameters.Add(param);
                }
            }

            return cmd;
        }

        protected SqlCommand createSQLCommand(string commandText)
        {
            return this.createSQLCommand(commandText, CommandType.Text, null);
        }


        protected SqlDataReader getRows(string where_filter)
        {
            string command = "SELECT * FROM " + this._tbname;
            if (where_filter.Equals("") == false)
                command += " WHERE " + where_filter;
            this.conn.Open();
            SqlCommand cmd = this.createSQLCommand(command);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Close();
            this.conn.Close();
            return dr;
        }

        protected SqlDataReader getRows()
        {
            return this.getRows("");
        }


    }
}
