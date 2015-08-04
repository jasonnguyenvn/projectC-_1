using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace abstractModel
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

        public void updateData()
        {
            this.conn.Open();
            SqlDataReader dr = this.getRows();

            this._data.Clear();
            this._control.Rows.Clear();

            while (dr.Read())
            {
                T temp = this._parser.parse(dr);
                this._data.Add(temp);
                this._control.Rows.Add(temp.convertToRow());
            }

            dr.Close();
            this.conn.Close();
        }

    }
}
