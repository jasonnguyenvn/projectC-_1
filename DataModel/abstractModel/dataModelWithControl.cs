using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataModel
{
    public abstract class DataModelWithControl<T> : AbstractDataModel<T> where T : DataObject
    {
        protected readonly DataGridView _control;

        public DataModelWithControl(string host, int port, string dbname, 
                        string username, string password, string table_name,
            DataObjectParser<T> parser) :
            // init parent's part
            base(host, port, dbname, username, password, table_name, parser)
        {
            this._control = null;
        }

        public DataModelWithControl(DataGridView control,  
                                    string host, 
                                    int port, 
                                    string dbname,  
                                    string username, 
                                    string password, 
                                    string table_name,
                                    DataObjectParser<T> parser) :
            // init parent's part
            base(host, port, dbname, username, password, table_name, parser)
        {
            this._control = control;
        }

        public void resetControl()
        {
            if (this._control == null)
                throw new Exception("THIS MODEL HAVE NOT SET A CONTROL YET!");

            base.resetModel();
            this._control.Rows.Clear();
            foreach (T item in this.Data)
            {
                this._control.Rows.Add(item.convertToRow());
            }
        }

        public T updateRow( T updateData)
        {
            string where_filter = updateData.getWhereFilterToUpdateSingleRow();
            string[] keys = updateData.SqlKeys();
            List<SqlParameter> getParams = this.SqlParams(updateData);
            List<T> result = this.updateRows(keys, getParams, where_filter);

            if (result == null)
                return null;
            
            T updateItem = result[0];

            return updateItem;
        }

        //Hau
        public override List<T> updateRows(string[] keys, List<SqlParameter> parameters, string where_filter)
        {
            List<T> result = base.updateRows(keys, parameters, where_filter);
            if (result.Count < 0)
                return null;

            if (this._control != null)
            {
                foreach (T updateItem in result)
                {
                    int index = this.Data.IndexOf(updateItem);
                    this.commitUpdate(index);
                }
            }

            return result;
        }


        public T insertNewRow(T newItem)
        {
            string[] keys = newItem.SqlKeys();
            List<SqlParameter> getParams = this.SqlParams(newItem);

            return this.insertNewRow(keys, getParams);
        }

        public override T insertNewRow(string[] keys, List<SqlParameter> parameters)
        {
            T result = base.insertNewRow(keys, parameters);
            if (result == null)
                return null;

            if (this._control != null)
                this._control.Rows.Add(result.convertToRow());

            return result;
        }

        public T commitUpdate(int index)
        {
            if (this._control == null)
                throw new Exception("THIS MODEL HAVE NOT SET A CONTROL YET!");

            T item = this.Data[index];
            DataGridViewRow updateRow = this._control.Rows[index];
            object[] data = item.convertToRow();
            int noOfProp = item.getNoOfProp();
            for (int i = 0; i < noOfProp; i++)
            {
                updateRow.Cells[i].Value = data[i].ToString();
            }

            return item;
        }

        public override List<T> deleteRows(string where_filter)
        {
            List<T> deletedList = this.getItems(where_filter);
            if (deletedList.Count <= 0)
                return new List<T>();

            string commandText = "DELETE FROM " + this.Tbname;
            if (where_filter.Equals("") == false)
                commandText += " WHERE " + where_filter;

            this.conn.Open();
            SqlCommand cmd = this.createSQLCommand(commandText);
            int result = cmd.ExecuteNonQuery();
            this.conn.Close();

            if (result <= 0)
                return new List<T>();

            int index = this.Data.IndexOf(deletedList[0]);
            int rangeToDelete = deletedList.Count;
            this.Data.RemoveRange(index, rangeToDelete);
            rangeToDelete += index;
            for(int i=index; i<rangeToDelete; i++)
            {
                this._control.Rows.RemoveAt(i);
            }

            return deletedList;
        }

    }
}
