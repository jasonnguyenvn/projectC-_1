using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace DataModel
{
    public abstract class AbstractDataModel<T> : object where T : DataObject
    {
        private readonly List<T> _data;

        protected List<T> Data
        {
            get { return _data; }
        } 



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


        public AbstractDataModel(string host, int port, string dbname, string username,
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

        public void resetModel()
        {
            this.conn.Open();
            SqlDataReader dr = this.getRows();

            this._data.Clear();

            while (dr.Read())
            {
                T temp = this._parser.parse(dr);
                this._data.Add(temp);
            }

            dr.Close();
            this.conn.Close();
        }


        protected SqlConnection createConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server="+this._host
                                    +";database="+this._dbname
                                    + ";uid=" + this._username
                                    +";pwd="+this._password+";";
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

        public List<T> getItems(string where_filter)
        {
            this.conn.Open();
            SqlDataReader dr = this.getRows();

            List<T> result = new List<T>();

            while (dr.Read())
            {
                T temp = this._parser.parse(dr);
                result.Add(temp);
            }

            dr.Close();
            this.conn.Close();

            return result;
        }

        public SqlDataReader getRows(string where_filter)
        {
            string command = "SELECT * FROM " + this._tbname;
            if (where_filter.Equals("") == false)
                command += " WHERE " + where_filter;
            SqlCommand cmd = this.createSQLCommand(command);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public SqlDataReader getRows()
        {
            return this.getRows("");
        }

        public virtual T insertNewRow(string[] keys, List<SqlParameter> parameters)
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

            if (result <= 0)
                return null;

            T newItem = this._parser.parse(keys, parameters);
            this._data.Add(newItem);

            return newItem;

        }


        public virtual List<T> updateRows(string[] keys, List<SqlParameter> parameters, string where_filter)
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

            if (where_filter.Equals("") == false)
                commandText += " WHERE " + where_filter;

            this.conn.Open();
            SqlCommand cmd = this.createSQLCommand(commandText, CommandType.Text,
                                                        parameters);
            int result = cmd.ExecuteNonQuery();
            this.conn.Close();

            if (result <= 0)
                return new List<T>();

            List<T> resultList = this.getItems(where_filter);
            if (resultList.Count < 0)
                throw new Exception("DATA MODEL INVALID");

            return resultList;

        }

        public virtual List<T> deleteRows(string where_filter)
        {
            List<T> deletedList = this.getItems(where_filter);
            if (deletedList.Count <= 0)
                return new List<T>();

            string commandText = "DELETE FROM " + this._tbname;
            if (where_filter.Equals("") == false)
                commandText += " WHERE " + where_filter;

            this.conn.Open();
            SqlCommand cmd = this.createSQLCommand(commandText);
            int result = cmd.ExecuteNonQuery();
            this.conn.Close();

            if (result <= 0)
                return new List<T>();

            int index = this._data.IndexOf(deletedList[0]);
            int rangeToDelete = deletedList.Count;
            this._data.RemoveRange(index, rangeToDelete);

            return deletedList;
        }

        public abstract List<SqlParameter> SqlParams(T item);

    }
}
