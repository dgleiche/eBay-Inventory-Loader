using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace CSV_Inventory_Bobby
{
    class imagewrite
    {
        public imagewrite(string file, string model)
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            XDocument doc = new XDocument();
            doc = XDocument.Load(path + "\\images.xml");
            XElement parent = doc.XPathSelectElement("images");
            XElement image = new XElement("image", file);
            XName name = "model";
            XAttribute att = new XAttribute(name, model);
            image.Add(att);
            parent.Add(image);
            doc.Save(path + "\\images.xml");
        }
    }
}
