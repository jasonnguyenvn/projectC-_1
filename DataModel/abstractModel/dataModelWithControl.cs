using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataModel
{
    class dataModelWithControl<T> : dataModel<T> where T : DataObject
    {
        protected readonly DataGridView _control;

        public dataModelWithControl(string host, int port, string dbname, 
                        string username, string password, string table_name,
            DataObjectParser<T> parser) :
            // init parent's part
            base(host, port, dbname, username, password, table_name, parser)
        {
        }

        public dataModelWithControl(DataGridView control, 
                                    DataGridViewColumn [] columns, 
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
            this._control.Columns.AddRange(columns);
        }

        public void resetControl()
        {
            this.conn.Open();
            SqlDataReader dr = this.getRows();

            this.Data.Clear();
            this._control.Rows.Clear();

            while (dr.Read())
            {
                T temp = this._parser.parse(dr);
                this.Data.Add(temp);
                this._control.Rows.Add(temp.convertToRow());
            }

            dr.Close();
            this.conn.Close();
        }

        public int updateRow(int index, T updateData)
        {
            string where_filter = updateData.getWhereFilterToUpdateSingleRow();
            string[] keys = updateData.SqlKeys();
            List<SqlParameter> getParams = updateData.SqlParams();
            List<T> result = base.updateRows(keys, getParams, where_filter);
            if (result.Count < 0)
                return -1;

            this.commitUpdate(index, result[0]);

            return 1;
        }

        public T insertNewRow(T newItem)
        {
            string[] keys = newItem.SqlKeys();
            List<SqlParameter> getParams = newItem.SqlParams();
            T result = this.insertNewRow(keys, getParams);
            if (result == null)
                return null;
            this._control.Rows.Add(result.convertToRow());

            return result;
        }

        protected void commitUpdate(int index, T item)
        {
            DataGridViewRow updateRow = this._control.Rows[index];
            object[] data = item.convertToRow();
            int noOfProp = item.getNoOfProp();
            for (int i = 0; i < noOfProp; i++)
            {
                updateRow.Cells[i].Value = data[i].ToString();
            }
        }

    }
}
