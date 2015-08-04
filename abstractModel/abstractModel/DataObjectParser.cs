using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace abstractModel 
{
    public abstract class DataObjectParser<T> : object where T : DataObject
    {
        public abstract T parse(SqlDataReader dr);

    }
}
