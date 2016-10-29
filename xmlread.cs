using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace CSV_Inventory_Bobby
{
    class xmlread
    {
        public System.Collections.Generic.IEnumerator<XNode> read()
        {
            System.Collections.Generic.IEnumerator<XNode> result;
            try
            {
                string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                XDocument doc = XDocument.Load(path + "\\errors.xml");
                XElement parent = doc.XPathSelectElement("errors");
                System.Collections.Generic.IEnumerable<XNode> nodes = parent.Nodes();
                System.Collections.Generic.IEnumerator<XNode> enodes = nodes.GetEnumerator();
                result = enodes;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                result = null;
            }
            return result;
        }

        public bool contains(System.Collections.Generic.IEnumerator<XNode> enodes, string error)
        {
            while (enodes.MoveNext())
            {
                XNode current = enodes.Current;
                string result = Regex.Replace(current.ToString(), "<[^>]*>", string.Empty);
                error = Regex.Replace(error, "<[^>]*>", string.Empty);
                if (result == error)
                {
                    return true;
                }
            }
            enodes.Dispose();
            return false;
        }
    }
}
