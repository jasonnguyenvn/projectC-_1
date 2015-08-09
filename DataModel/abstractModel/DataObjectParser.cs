using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataModel 
{
    public abstract class DataObjectParser<T> : object where T : DataObject
    {
        public abstract T parse(SqlDataReader dr);
        public abstract T parse(string[] keys, List<SqlParameter> sqlParams);
        // d
        public abstract string getPrimaryKey();
    }
}
