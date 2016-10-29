using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace CSV_Inventory_Bobby
{
    class xmlwrite
    {
        public xmlwrite(string title)
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            XDocument doc = new XDocument();
            doc = XDocument.Load(path + "\\errors.xml");
            XElement parent = doc.XPathSelectElement("errors");
            XElement error = new XElement("error", title);
            parent.Add(error);
            doc.Save(path + "\\errors.xml");
        }
    }
}
