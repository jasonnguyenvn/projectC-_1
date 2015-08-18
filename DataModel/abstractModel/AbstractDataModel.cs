using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using System.Diagnostics;

using System.Globalization;

namespace DataModel
{
    public abstract class AbstractDataModel<T> : object where T : BaseDataObject
    {

        public static List<string> GetCountries()
        {

            List<string> list = new List<string>();
            

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures | CultureTypes.SpecificCultures);

            foreach (CultureInfo info in cultures)
            {
                if(info.Name.Equals(""))
                    continue;
                //RegionInfo info2 = new RegionInfo(info.LCID);
                RegionInfo info2 = new RegionInfo(info.Name);

                if (!list.Contains(info2.EnglishName))
                {

                    list.Add(info2.EnglishName);

                }

            }
            list.Sort();
            list.Insert(0, "");
            return list;
        }


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

        public DataObjectParser<T> Parser
        {
            get { return _parser; }
        } 


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
            SqlDataReader dr = null;
            try
            {
                this.conn.Open();
                dr = this.getRows(where_filter);
                
                while (dr.Read())
                {
                    T temp = this._parser.parse(dr);
                    result.Add(this.Data[this.Data.IndexOf(temp)]);
                }

                

            }
            catch(Exception ex)
            {
                throw new Exception("Get rows exception: "+ex.Message);
            }
            finally
            {
                if(dr!=null)
                    dr.Close();
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
            commandText += ") ";

            if (this._parser.getPrimaryKey().Equals("") == false)
                commandText += "  OUTPUT INSERTED." + this._parser.getPrimaryKey();

            commandText +=  "  VALUES (" + valueParams + ")";

            T newItem;
            try
            {
                this.conn.Open();
                SqlCommand cmd = this.createSQLCommand(commandText, CommandType.Text,
                                                            parameters);
                int result;
                if (this._parser.getPrimaryKey().Equals("") == false)
                {
                    result = (int)cmd.ExecuteScalar();
                    changeIndex.Value = result;
                }
                else
                    result = cmd.ExecuteNonQuery();
                if (result < 0)
                    return null;
               
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

        public class IdItem
        {
            public IdItem()
            {
            }

            public IdItem(int id, string showText)
            {
                this._id = id;
                this._showText = showText;
            }

            private int _id;

            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }

            private string _showText;

            public string ShowText
            {
                get { return _showText; }
                set { _showText = value; }
            }

            public override string ToString()
            {
                return this._showText;
            }

            public override bool Equals(object obj)
            {
                if (obj is IdItem == false)
                    return false;

                IdItem cast = (IdItem)obj;

                return this._id == cast._id;

            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

        public List<IdItem> getIDItemList(string tbName, int keyIndex, int showIndex, string filter)
        {
            List<IdItem> result = new List<IdItem>();

            this.conn.Open();
            SqlDataReader dr = null;

            try
            {
                string command = "SELECT * FROM " + tbName;
                SqlCommand cmd = this.createSQLCommand(command);
                if (filter.Equals("") == false)
                    command += " WHERE " + filter;

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = int.Parse(dr.GetValue(keyIndex).ToString());
                    string showText = id + " - " + dr.GetValue(showIndex).ToString();

                    IdItem item = new IdItem(id, showText);
                    result.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("GET ID LIST EXCEPTION: " + ex.Message + " ; TB_NAME: " + tbName);
            }
            finally
            {
                if (dr != null)
                    dr.Close();
                this.conn.Close();
            }

            return result;
        }

        public List<IdItem> getIDItemList(string tbName, int keyIndex, int showIndex)
        {
            return this.getIDItemList(tbName, keyIndex, showIndex, "");
        }

        public object[] getIDItemArray(string tbName, int keyIndex, int showIndex)
        {
            return this.getIDItemList(tbName, keyIndex, showIndex).ToArray();
        }

        public List<object> getIDList(string tbName, int keyIndex)
        {
            List<object> result = new List<object>();

            this.conn.Open();
            SqlDataReader dr = null;

            try
            {
                string command = "SELECT * FROM " + tbName;
                SqlCommand cmd = this.createSQLCommand(command);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int get = int.Parse(dr.GetValue(keyIndex).ToString());
                    result.Add(get);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("GET ID LIST EXCEPTION: " + ex.Message + " ; TB_NAME: " + tbName);
            }
            finally
            {
                if (dr != null)
                    dr.Close();
                this.conn.Close();
            }

            return result;
        }

        public object [] getIDArray(string tbName, int keyIndex)
        {
            return this.getIDList(tbName, keyIndex).ToArray();
        }

        public abstract List<SqlParameter> SqlParams(T item);

    }
   
}
