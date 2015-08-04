using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace abstractModel
{
    public abstract class dataModel<T> : object where T : DataObject
    {
        protected readonly List<T> _data;
        private readonly string _host;
        private readonly int _port;
        private readonly string _dbname;
        private readonly string _username;
        private readonly string _password;

        protected readonly DataObjectParser<T> _parser;

        protected readonly SqlConnection conn;

        private readonly string _tbname;

        protected string Tbname
        {
            get { return _tbname; }
        } 


        public dataModel(string host, int port, string dbname, string username,
                            string password, string table_name,
                            DataObjectParser<T> parser)
        {
            this._host = host;
            this._port = port;
            this._dbname = dbname;
            this._username = username;
            this._password = password;

            this._tbname = table_name;

            this._parser = parser;

            this._data = new List<T>();
            this.conn = this.createConnection();
        }


        protected SqlConnection createConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server="+this._host
                                    +";database="+this._dbname
                                    +";User ID="+this._username
                                    +";Password="+this._password+";";
            return conn;
        }


        protected SqlParameter createSQLParam(string key, SqlDbType dbType, 
                                                object value, int size)
        {
            SqlParameter param = new SqlParameter(key, dbType, size);
            param.Value = value;
            return param;
        }

        protected SqlParameter createSQLParam(string key, SqlDbType dbType, 
                                                    object value)
        {
            SqlParameter param = new SqlParameter(key, dbType);
            param.Value = value;
            return param;
        }

        protected SqlCommand createSQLCommand(string commandText, 
                CommandType commandType, List<SqlParameter> parameters)
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
            SqlCommand cmd = this.createSQLCommand(command);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        protected SqlDataReader getRows()
        {
            return this.getRows("");
        }

        protected int insertNewRow(string[] keys, List<SqlParameter> parameters)
        {
            if (keys.Length != parameters.Count)
                throw new Exception("THE NUMBER OF INSERT KEY DOES NOT EQUAL TO"
                                          + " THE NUMBER OF PARAMETER");

            string commandText = "INSERT INTO " + this._tbname + "(";
            string valueParams = "";

            bool first = true;
            foreach (string aKey in keys)
            {
                if (first == false)
                    commandText += ",";
                else first = false;
                commandText += aKey;
                string currentParam = "@"+aKey;
                valueParams += currentParam;

            }
            commandText += ") VALUES (" + valueParams + ")";

            this.conn.Open();
            SqlCommand cmd = this.createSQLCommand(commandText, CommandType.Text,
                                                        parameters);
            int result = cmd.ExecuteNonQuery();

            this.conn.Close();

            return result;

        }


        protected int updateNewRow(string[] keys, List<SqlParameter> parameters)
        {
            if (keys.Length != parameters.Count)
                throw new Exception("THE NUMBER OF INSERT KEY DOES NOT EQUAL TO"
                                          + " THE NUMBER OF PARAMETER");

            string commandText = "UPDATE " + this._tbname + " SET";
            string valueParams = "";

            bool first = true;
            foreach (string aKey in keys)
            {
                if (first == false)
                    commandText += ",";
                else first = false;
                commandText += aKey + "=";
                string currentParam = "@" + aKey;
                valueParams += currentParam;

            }

            this.conn.Open();
            SqlCommand cmd = this.createSQLCommand(commandText, CommandType.Text,
                                                        parameters);
            int result = cmd.ExecuteNonQuery();

            this.conn.Close();

            return result;

        }




    }
}
