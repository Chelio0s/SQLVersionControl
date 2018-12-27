using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace View_FORMS
{
public class CommandLines
    {

        public  int LineNumber { get; set; }
        public string LineString { get; set; }

        public override string ToString()
        {
            return LineString;
        }
    }

}
