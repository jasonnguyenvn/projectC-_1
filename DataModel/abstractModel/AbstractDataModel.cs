using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace DataModel
{
    public abstract class AbstractDataModel<T> : object where T : BaseDataObject
    {
        private readonly List<T> _data;

        public List<T> Data
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

        public void resetModel(string filter)
        {
            this.conn.Open();
            try
            {
                SqlDataReader dr = this.getRows(filter);

                this._data.Clear();

                while (dr.Read())
                {
                    T temp = this._parser.parse(dr);
                    this._data.Add(temp);
                }

                dr.Close();
            }
            catch(Exception ex)
            {
                throw new Exception("Reset model exception: "+ex.Message);
            }
            finally
            {
                this.conn.Close();
            }
        }


        protected SqlConnection createConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server="+this._host
                                    +";database="+this._dbname
                                    + ";uid=" + this._username
                                    +";pwd="+this._password;
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
            List<T> result = new List<T>();
            try
            {
                this.conn.Open();
                SqlDataReader dr = this.getRows(where_filter);
                
                while (dr.Read())
                {
                    T temp = this._parser.parse(dr);
                    result.Add(this.Data[this._data.IndexOf(temp)]);
                }

                dr.Close();

            }
            catch(Exception ex)
            {
                throw new Exception("Get rows exception: "+ex.Message);
            }
            finally
            {
                this.conn.Close();
            }

            return result;
        }

        private SqlDataReader getRows(string where_filter)
        {
            string command = "SELECT * FROM " + this._tbname;
            if (where_filter.Equals("") == false)
                command += " WHERE " + where_filter;
            SqlDataReader dr;
    
            SqlCommand cmd = this.createSQLCommand(command);
            dr = cmd.ExecuteReader();
      
            return dr;
        }

        private SqlDataReader getRows()
        {
            return this.getRows("");
        }

        public virtual T insertNewRow(string[] keys, List<SqlParameter> parameters)
        {
            if (keys.Length != parameters.Count)
                throw new Exception("THE NUMBER OF INSERT KEY DOES NOT EQUAL TO"
                                          + " THE NUMBER OF PARAMETER");

            string commandText = "INSERT INTO " + this._tbname + " (";
            string valueParams = "";

            bool first = true;
            SqlParameter changeIndex = null;
            for (int i=0; i<keys.Length; i++)
            {
                string aKey = keys[i];
                if (aKey == this._parser.getPrimaryKey())
                {
                    changeIndex = parameters[i];
                    continue;
                }

                if (first == false)
                {
                    commandText += ",";
                    valueParams += " , ";
                }
                else first = false;
                commandText += aKey;
                string currentParam = "@"+aKey;
                valueParams += currentParam;

            }
            commandText += ")  OUTPUT INSERTED." + this._parser.getPrimaryKey() + "  VALUES (" + valueParams + ")";

            T newItem;
            try
            {
                this.conn.Open();
                SqlCommand cmd = this.createSQLCommand(commandText, CommandType.Text,
                                                            parameters);
            

                int result = (int)cmd.ExecuteScalar();


                if (result < 0)
                    return null;

                changeIndex.Value = result;
                newItem = this._parser.parse(keys, parameters);
                this._data.Add(newItem);
            }
            catch(Exception ex)
            {
                throw new Exception("Insert Exception: "+ex);
            }
            finally
            {
                this.conn.Close();
            }

            return newItem;

        }


        public virtual List<T> updateRows(string[] keys, List<SqlParameter> parameters, string where_filter)
        {
            if (keys.Length != parameters.Count)
                throw new Exception("THE NUMBER OF INSERT KEY DOES NOT EQUAL TO"
                                          + " THE NUMBER OF PARAMETER");

            string commandText = "UPDATE " + this._tbname + " SET ";

            bool first = true;
            foreach (string aKey in keys)
            {
                if (aKey == this._parser.getPrimaryKey())
                    continue;

                if (first == false)
                    commandText += ",";
                else first = false;
                commandText += aKey + "="+ "@" + aKey;

            }

            if (where_filter.Equals("") == false)
                commandText += " WHERE " + where_filter;

            List<T> resultList = new List<T>();
            try
            {
                this.conn.Open();
                SqlCommand cmd = this.createSQLCommand(commandText, CommandType.Text,
                                                            parameters);

                               

                int result = cmd.ExecuteNonQuery();


                if (result <= 0)
                    return new List<T>();

                
            }
            catch(Exception ex)
            {
                throw new Exception("Update exception: "+ex.Message);
            }
            finally
            {
                this.conn.Close();
            }

            try
            {
                resultList = this.getItems(where_filter);
                if (resultList.Count < 0)
                    throw new Exception("DATA MODEL INVALID");
                foreach (T anItem in resultList)
                {
                    T updateNew = this._parser.parse(keys, parameters);
                    updateNew.copyTo(anItem);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unkonw exception: " + ex.Message);
            }

            
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

           
            int result = 0;
            try
            {
                this.conn.Open();
                SqlCommand cmd = this.createSQLCommand(commandText);

                result = cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception("Delete exception: "+ex.Message);
            }
            finally
            {
                this.conn.Close();
            }

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
