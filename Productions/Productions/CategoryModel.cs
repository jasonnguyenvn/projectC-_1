using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DataModel;
using System.Windows.Forms;
using System.Data;

namespace Productions
{
    // Hau added new class Category.
    // This class describes Categorys.
    public class Category : BaseDataObject
    {
       

        private int categoryid;

        public int CategoryID
        {
            get { return categoryid; }
            set { categoryid = value; }
        }

        private string categoryname;

        public string CategoryName
        {
            get { return categoryname; }
            set { categoryname = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private bool deactive;

        public bool Deactive
        {
            get { return deactive; }
            set { deactive = value; }
        }

        

        public static readonly string[] Sql_keys =
        {
            "categoryid",
            "categoryname",
            "description",
            "deactive"
        };

        public override string[] SqlKeys()
        {
            return Category.Sql_keys;
        }

        public override object[] convertToRow()
        {
            object[] result = {
                this.categoryid,
                this.categoryname,
                this.description,
                this.Deactive
            };
            return result;
        }

        public override void copyTo(BaseDataObject other)
        {
            if (other is Category == false)
                throw new Exception("BAD TYPE TO CLONE. Class Category.");
            Category otherEmp = (Category)other;
            otherEmp.categoryid = this.categoryid;
            otherEmp.categoryname = this.categoryname;
            otherEmp.description = this.description;
            otherEmp.deactive = this.deactive;
        }

        public override int getNoOfProp()
        {
            return Category.Sql_keys.Length;
        }

        public override string getWhereFilterToUpdateSingleRow()
        {
            return " categoryid=" + this.categoryid;
        }

        public override bool Equals(object obj)
        {
            if (obj is Category == false)
                return false;
            Category other = (Category)obj;
            return this.CategoryID == other.CategoryID;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Category()
        {
            this.categoryid = -1;
            this.categoryname = "";
            this.description = "";
            this.deactive = false;
        }

        public override string getErrorMessage(int errorCode)
        {
            switch(errorCode){
                case -2: return "Category Name cannot be empty";
            }
            return "";
        }


        // =1 => valid
        // < 0 => error
        public override int isValid()
        {
            if (this.categoryname.Equals(""))
                return -2;
            return 1;
        }



        public override int[] isValid_multi()
        {
            throw new NotImplementedException();
        }
    }

    public class CategoryParser : DataObjectParser<Category>
    {
        public override string getPrimaryKey()
        {
            return "categoryid";
        }

        private CategoryModel _dataModel;

        public CategoryModel DataModel
        {
            get { return _dataModel; }
            set { _dataModel = value; }
        }

        public CategoryParser()
        {
           
        }

        public override Category parse(string[] keys,
                            List<SqlParameter> sqlParams)
        {
            Category result = new Category();
            int noOfProp = result.getNoOfProp();
            int noOfKeys = keys.Length;
            if (noOfProp > keys.Length || keys.Length != sqlParams.Count)
                throw new Exception("INVALID INPUT TO PARSE Category");


            for (int i = 0; i < noOfProp; i++)
            {
                SqlParameter param = sqlParams[i];
                if (keys[i].Equals(param.ParameterName) == false)
                    throw new Exception("INVALID KEY TO PARSE Category. "
                                + " KEYNAME: " + param.ParameterName);
                switch (keys[i])
                {
                    case "categoryid":
                        result.CategoryID = int.Parse(param.Value.ToString());
                        break;
                    case "categoryname":
                        result.CategoryName = param.Value.ToString();
                        break;
                    case "description":
                        result.Description = param.Value.ToString();
                        break;

                    case "deactive":
                        result.Deactive = bool.Parse(param.Value.ToString());
                        break;
                }
            }

            return result;
        }
        
    }


    // Hau added new class CategoryModel
    // This is the model to create 
    // a connection between form/webform
    // to Database.
    public class CategoryModel : DataModelWithControl<Category>
    {
        public Category SafeDelete(int catID)
        {
            Category get = this.getItems(" categoryid=" + catID)[0];


            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(this.createSQLParam("categoryid", SqlDbType.Int, catID));

            string command = "Safe_Delete_Cat";

            this.conn.Open();
            try
            {
                SqlCommand cmd = this.createSQLCommand(command, CommandType.StoredProcedure, paramList);
                int result = cmd.ExecuteNonQuery();
                if (result <= 0)
                    get = null;
            }
            catch (Exception ex)
            {
                throw new Exception("DATABASE ERROR. COULD NOT SAFE DELETE SUPPLIER. " + ex.Message);
            }
            finally
            {
                this.conn.Close();
                this.DataSource.Rows.RemoveAt(this.Data.IndexOf(get));
                this.Data.Remove(get);
                if (this._webControl != null)
                    this._webControl.DataBind();
            }

            return get;
        }

        public Category BadDelete(int suppID)
        {
            Category get = this.getItems(" categoryid=" + suppID)[0];
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(this.createSQLParam("categoryid", SqlDbType.Int, suppID));

            string command = "Delete_Cat";

            this.conn.Open();
            try
            {
                SqlCommand cmd = this.createSQLCommand(command, CommandType.StoredProcedure, param);
                int result = cmd.ExecuteNonQuery();
                if (result <= 0)
                    get = null;
            }
            catch (Exception ex)
            {
                throw new Exception("DATABASE ERROR. COULD NOT DELETE CATEGORY. " + ex.Message);
            }
            finally
            {
                this.conn.Close();
                this.DataSource.Rows.RemoveAt(this.Data.IndexOf(get));
                this.Data.Remove(get);
                if (this._webControl != null)
                    this._webControl.DataBind();
            }

            return get;
        }


        public string filter(string txtCatName, string txtDescription)
        {
            string sqlFilter = " deactive=0 ";
            if (txtCatName.Equals("") == false)
            {
                sqlFilter += string.Format(" AND  categoryname LIKE '%{0}%' ", txtCatName.Trim());
            }
            if (txtDescription.Equals("") == false)
            {
                sqlFilter += string.Format(" AND  description LIKE '%{0}%' ", txtDescription.Trim());
            }
            

            this.resetControl(sqlFilter);

            return sqlFilter;

        }

        public CategoryModel(string host,
            int port, string dbname, string username, string password, string table_name, CategoryParser parser) :
            base(host, port, dbname, username, password, table_name, parser)
        {
        }

        public CategoryModel(object control,  string host, 
            int port, string dbname, string username, string password, string table_name, CategoryParser parser) :
            base(control,host, port, dbname, username, password, table_name, parser)

        {
            this._initTable(Category.Sql_keys);
        }


        public void resetControl()
        {
            this.resetControl(" deactive=0");
        }

        private void _initTable()
        {
            this._control.Columns.Clear();
            this._initTable(Category.Sql_keys);
        }

        public override List<SqlParameter> SqlParams(Category item)
        {
            SqlParameter ID = this.createSQLParam("categoryid", SqlDbType.Int, item.CategoryID);
            SqlParameter Name = this.createSQLParam("categoryname", SqlDbType.VarChar, item.CategoryName, 15);
            SqlParameter Description = this.createSQLParam("description", SqlDbType.NVarChar, item.Description, 200);
            SqlParameter Deactive = this.createSQLParam("deactive", SqlDbType.Bit, item.Deactive);

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(ID);
            list.Add(Name);
            list.Add(Description);
            list.Add(Deactive);

            return list;

        }
    }
}
