using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace CSV_Inventory_Bobby
{
    class xmldelete
    {
        public void delete(string record)
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            XmlDocument doc = new XmlDocument();
            doc.Load(path + "\\errors.xml");
            XmlNodeList nodes = doc.SelectNodes("errors/error[text()='" + record + "']");
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                nodes[i].ParentNode.RemoveChild(nodes[i]);
            }
            doc.Save(path + "\\errors.xml");
        }
    }
}
