using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Base_Intefaces
{
    public interface BaseControlInteface
    {
        bool isLoaded();
        void setLoadStatus(bool status);
        void resetControl();
        void resetData();
        string getName();
        Control getThis(); 
    }

    public interface ControlInteface<T, N> : BaseControlInteface
            where N:DataModel.BaseDataObject 
            where T : DataModel.DataModelWithControl<N>
    {
        T getDataModel();
        
    }
}
