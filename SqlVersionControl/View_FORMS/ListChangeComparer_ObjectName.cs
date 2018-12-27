
using System.Collections.Generic;
using View_FORMS.Data;

namespace View_FORMS
{
    class ListChangeComparer_ObjectName:IEqualityComparer<tbl_ListChange>
    {
        public bool Equals(tbl_ListChange x, tbl_ListChange y)
        {
            return x.ObjectName == y.ObjectName;
        }

        public int GetHashCode(tbl_ListChange obj)
        {
            return obj.ObjectName.GetHashCode();
        }
    }
}
