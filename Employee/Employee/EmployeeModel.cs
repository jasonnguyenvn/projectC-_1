using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;

namespace Employee
{
    class Employee : DataObject
    {
        public override string[] SqlKeys()
        {
            throw new NotImplementedException();
        }

        public override List<System.Data.SqlClient.SqlParameter> SqlParams()
        {
            throw new NotImplementedException();
        }

        public override object[] convertToRow()
        {
            throw new NotImplementedException();
        }

        public override void copyTo(DataObject other)
        {
            throw new NotImplementedException();
        }

        public override int getNoOfProp()
        {
            throw new NotImplementedException();
        }

        public override string getWhereFilterToUpdateSingleRow()
        {
            throw new NotImplementedException();
        }
    }


    class EmployeeModel
    {
        
    }
}
