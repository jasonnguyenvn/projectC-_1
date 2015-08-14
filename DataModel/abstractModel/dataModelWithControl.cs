using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data;

namespace DataModel
{
    public abstract class DataModelWithControl<T> : AbstractDataModel<T> where T : BaseDataObject
    {
        protected readonly GridView _webControl;
        protected readonly DataGridView _control;
        private readonly DataTable _datasource;

        public DataTable DataSource
        {
            get { return _datasource; }
        }

        public DataModelWithControl(string host, int port, string dbname, 
                        string username, string password, string table_name,
            DataObjectParser<T> parser) :
            // init parent's part
            base(host, port, dbname, username, password, table_name, parser)
        {
            this._control = null;
        }

        public DataModelWithControl(object control,  
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
            this._datasource = new DataTable();
            if (control is DataGridView)
            {
                this._control = (DataGridView)control;
                this._control.DataSource = this._datasource;
            }
            else
            {
                if (control is GridView)
                {
                    this._webControl = (GridView)control;
                    this._webControl.DataSource = this._datasource;
                    this._webControl.AutoGenerateSelectButton = true;
                    this._webControl.AllowPaging = true;
                }
                else
                    throw new Exception("INVALID CONTROL OBJECT");
            }

        }


        protected virtual void _initTable(string[] keys)
        {
            this.DataSource.Columns.Clear();

            foreach (string aKey in keys)
            {
                DataColumn column;
                column = new System.Data.DataColumn();
                column.Caption = aKey;
                column.ColumnName = aKey;
                this.DataSource.Columns.Add(column);
            }

            if (this._control != null)
            {
                foreach (System.Windows.Forms.DataGridViewColumn col in this._control.Columns)
                {
                    col.SortMode = System.Windows.Forms
                                        .DataGridViewColumnSortMode
                                        .NotSortable;
                }
            }

        }
     
        public virtual void resetControl(string filter)
        {
            if (this._control == null && this._webControl==null)
                throw new Exception("THIS MODEL HAVE NOT SET A CONTROL YET!");

            /*if (this._webControl != null)
            {
                this.resetForWebcontrol();
                return;
            }*/

            base.resetModel(filter);
            this._datasource.Rows.Clear();
            foreach (T item in this.Data)
            {
                this._datasource.Rows.Add(item.convertToRow());
            }

            if (this._webControl != null)
                this._webControl.DataBind();
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

            if (this._webControl != null)
                this._webControl.DataBind();

            return result;
        }


        public virtual T insertNewRow(T newItem)
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

            /*if (this._webControl != null)
            {
                this.resetForWebcontrol();
                return result;
            }*/
            if (this._webControl == null && this._control == null)
                return result;

            this._datasource.Rows.Add(result.convertToRow());

            if (this._webControl != null)
                this._webControl.DataBind();

            return result;
        }

        public T commitUpdate(int index)
        {
            if (this._control == null && this._webControl == null)
                throw new Exception("THIS MODEL HAVE NOT SET A CONTROL YET!");

            T item = this.Data[index];

            /*if (this._webControl != null)
            {
                this.resetForWebcontrol();
                return item;
            }*/

            DataRow updateRow = this._datasource.Rows[index];
            object[] data = item.convertToRow();
            int noOfProp = item.getNoOfProp();
            for (int i = 0; i < noOfProp; i++)
            {
                updateRow.SetField(i, data[i]);
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
            int result = 0;
            try
            {

                result = cmd.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("Delete exception");
            }
            finally
            {
                this.conn.Close();
            }


            if (result <= 0)
                return new List<T>();

            if (this._control == null && this._webControl == null)
                return deletedList;

            /*if (this._webControl != null)
            {
                this.resetForWebcontrol();
                return deletedList;
            }*/

            /*if (this._control == null && this._webControl==null)
                return deletedList;*/

            int index = this.Data.IndexOf(deletedList[0]);
            int rangeToDelete = deletedList.Count;
            this.Data.RemoveRange(index, rangeToDelete);
            rangeToDelete += index;
            for(int i=index; i<rangeToDelete; i++)
            {
                this._datasource.Rows.RemoveAt(i);
            }

            if (this._webControl != null)
                this._webControl.DataBind();

            return deletedList;
        }

    }
}
