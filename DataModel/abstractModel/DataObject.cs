using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataModel
{
    public abstract class BaseDataObject : object
    {
        public abstract object[] convertToRow();
        public abstract int getNoOfProp();
        public abstract string[] SqlKeys();
        //public abstract List<SqlParameter> SqlParams();
        public abstract void copyTo(BaseDataObject other);
        public abstract string getWhereFilterToUpdateSingleRow();

        public abstract int isValid();
        public abstract string getErrorMessage(int errorCode);

        public abstract int[] isValid_multi();
        public abstract string[] getErrorMessage(int[] errorCodes);

    }
}
