using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace CSV_Inventory_Bobby
{
    class prefwrite
    {
        public prefwrite(string value, string type, string tag)
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            XDocument doc = new XDocument();
            doc = XDocument.Load(path + "\\pref.xml");
            XElement parent = doc.XPathSelectElement("preferences/" + type + "/" + tag);
            parent.Value = value;
            doc.Save(path + "\\pref.xml");
        }

        public prefwrite(string value, string type, string tag, string attribute, string attributevalue)
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            XDocument doc = new XDocument();
            doc = XDocument.Load(path + "\\pref.xml");
            XElement parent = doc.XPathSelectElement("preferences/" + type);
            XAttribute att = new XAttribute(attribute, attributevalue);
            XElement newElement = new XElement(tag, value);
            newElement.Add(att);
            parent.Add(newElement);
            doc.Save(path + "\\pref.xml");
        }
    }
}
