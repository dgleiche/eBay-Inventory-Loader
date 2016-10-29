using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace CSV_Inventory_Bobby
{
    class prefremove
    {
        public prefremove(string code)
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            XmlDocument doc = new XmlDocument();
            doc.Load(path + "\\pref.xml");
            XmlNodeList nodes = doc.SelectNodes("preferences/codes/code[text()='" + code + "']");
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                nodes[i].ParentNode.RemoveChild(nodes[i]);
            }
            doc.Save(path + "\\pref.xml");
        }
    }
}
