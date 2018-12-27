using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlVersionControl;

namespace View_FORMS.Data
{
    partial class tbl_ListChange
    {
        private int n = 0;
        public string CommandString { get { return ProcessingXml.ExtractCommandString(XMLChange); } }
        public List<CommandLines> Lines
        {
            get
            {
                var l = CommandString.Split('\n').Select(x => new CommandLines()
                {
                    LineNumber = n++,
                    LineString = x
                }).ToList();
                n = 0;
                return l;
            }
        }
    }
}
