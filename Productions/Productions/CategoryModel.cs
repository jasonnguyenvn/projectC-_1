using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DataModel;

namespace Categoryions
{
    // Hau added new class Category
    // This class describes Categorys.
    public class Category : DataObject
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

        

        public static readonly string[] Sql_keys =
        {
            "categoryid",
            "categoryname",
            "description"
        };

        public override string[] SqlKeys()
        {
            return Category.Sql_keys;
        }

        public override object[] convertToRow()
        {
            object[] result = {
                this.categoryid.ToString(),
                this.categoryname,
                this.description
            };
            return result;
        }

        public override void copyTo(DataObject other)
        {
            Category otherEmp = (Category)other;
            otherEmp.categoryid = this.categoryid;
            otherEmp.categoryname = this.categoryname;
            otherEmp.description = this.description;
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
        }

        public override string getErrorMessage(int errorCode)
        {
            throw new NotImplementedException();
        }

        public override int isValid()
        {
            throw new NotImplementedException();
        }
    }

    public class CategoryParser : DataObjectParser<Category>
    {
        private CategoryModel _dataModel;

        public CategoryParser(CategoryModel dataModel)
        {
            this._dataModel = dataModel;
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
                    throw new Exception("INVALID KEY TO PARSE EMPLOYE. "
                                + " KEYNAME: " + param.ParameterName);
                switch (keys[i])
                {
                    case "categoryid":
                        result.CategoryID = int.Parse(param.Value.ToString());
                        break;
                    case "categoryname":
                        result.CategoryName = param.Value.ToString();
                        break;
                    case "discription":
                        result.Description = param.Value.ToString();
                        break;
                }
            }

            return result;
        }

        public override Category parse(System.Data.SqlClient.SqlDataReader dr)
        {
            int count = dr.FieldCount;
            List<SqlParameter> Params = new List<SqlParameter>();
            for (int i = 0; i < count; i++)
            {
                SqlParameter param = new SqlParameter(dr.GetName(i), dr.GetValue(i));
            }

            return this.parse(Category.Sql_keys, Params);
        }
    }


    // Hau added new class CategoryModel
    // This is the model to create 
    // a connection between form/webform
    // to Database.
    public class CategoryModel : DataModelWithControl<Category>
    {
        private void _initTable()
        {
            string[] keys = Category.Sql_keys;
            foreach (string aKey in keys)
            {
                System.Windows.Forms.DataGridViewColumn column;
                column = new System.Windows.Forms.DataGridViewTextBoxColumn();
                column.HeaderText = aKey;
                column.Name = "cl_" + aKey;
                column.SortMode = System.Windows.Forms
                                    .DataGridViewColumnSortMode
                                    .NotSortable;
                this._control.Columns.Add(column);
            }
        }

        public override List<SqlParameter> SqlParams(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
