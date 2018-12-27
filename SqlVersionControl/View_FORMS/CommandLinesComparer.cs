using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace View_FORMS
{
    class CommandLinesComparer : IEqualityComparer<CommandLines>
    {
        public bool Equals(CommandLines x, CommandLines y)
        {
            return x.LineString == y.LineString;
        }

        public int GetHashCode(CommandLines obj)
        {
           return  obj.LineString.GetHashCode();
        }
    }
}
