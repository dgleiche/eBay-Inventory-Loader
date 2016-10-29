using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace CSV_Inventory_Bobby
{
    class prefread
    {
        public System.Collections.Generic.IEnumerator<XNode> read(string tag, string property)
        {
            System.Collections.Generic.IEnumerator<XNode> result;
            try
            {
                string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                XDocument doc = XDocument.Load(path + "\\pref.xml");
                System.Collections.Generic.IEnumerable<XNode> nodes = doc.XPathSelectElements("preferences/" + property + "/" + tag);
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

        public string getPropertyValue(System.Collections.Generic.IEnumerator<XNode> enodes)
        {
            if (!enodes.MoveNext())
            {
                enodes.Dispose();
                return null;
            }
            XNode current = enodes.Current;
            return Regex.Replace(current.ToString(), "<[^>]*>", string.Empty);
        }
    }
}
