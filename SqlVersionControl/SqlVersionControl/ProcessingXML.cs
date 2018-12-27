using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace SqlVersionControl
{
    public class ProcessingXml
    {
        public static string ExtractCommandString(string xmlString)
        {
            XElement xmlTree;

            using (TextReader sr = new StringReader(xmlString))
            {
                xmlTree = XElement.Load(sr);
            }

            var elemets = xmlTree.Elements();
            var commandNode = elemets.FirstOrDefault(x => x.Name == "TSQLCommand");
            var commandText = commandNode.Elements().FirstOrDefault(x => x.Name == "CommandText");

            return commandText.Value;
        }
    }
}
