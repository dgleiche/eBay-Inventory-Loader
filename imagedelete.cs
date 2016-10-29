using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace CSV_Inventory_Bobby
{
    class imagedelete
    {
        public void delete(string model)
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            XmlDocument doc = new XmlDocument();
            doc.Load(path + "\\images.xml");
            XmlNodeList nodes = doc.SelectNodes("images/image[@model='" + model + "']");
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                nodes[i].ParentNode.RemoveChild(nodes[i]);
            }
            doc.Save(path + "\\images.xml");
        }
    }
}
