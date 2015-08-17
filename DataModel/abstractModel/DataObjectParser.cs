using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataModel 
{
    public abstract class DataObjectParser<T> : object where T : BaseDataObject
    {
        public abstract T parse(string[] keys, List<SqlParameter> sqlParams);

        public  T parse( System.Data.SqlClient.SqlDataReader dr)
        {
            List<string> keys = new List<string>();
            int count = dr.FieldCount;
            List<SqlParameter> Params = new List<SqlParameter>();
            for (int i = 0; i < count; i++)
            {
                string currentK = dr.GetName(i);
                keys.Add(currentK);
                SqlParameter param = new SqlParameter(currentK, dr.GetValue(i));
                Params.Add(param);
            }

            return this.parse(keys.ToArray(), Params);
        }
        
        // d
        public abstract string getPrimaryKey();
    }
}
