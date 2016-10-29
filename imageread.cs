using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace CSV_Inventory_Bobby
{
    class imageread
    {
        public string imagepath
        {
            get;
            set;
        }

        public System.Collections.Generic.IEnumerator<XNode> read()
        {
            System.Collections.Generic.IEnumerator<XNode> result;
            try
            {
                string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                XDocument doc = XDocument.Load(path + "\\images.xml");
                XElement parent = doc.XPathSelectElement("images");
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

        public bool contains(System.Collections.Generic.IEnumerator<XNode> enodes, string imagemodel)
        {
            while (enodes.MoveNext())
            {
                XNode current = enodes.Current;
                XElement element = (XElement)current;
                XName name = "model";
                string model = element.Attribute(name).ToString();
                string modelstring = Regex.Replace(model, "model=", string.Empty);
                modelstring = Regex.Replace(modelstring, "[\"]", string.Empty);
                modelstring = "digprod_" + modelstring;
                model = modelstring;
                string result = Regex.Replace(current.ToString(), "<[^>]*>", string.Empty);
                this.imagepath = result;
                imagemodel = imagemodel.ToLower();
                model = model.ToLower();
                if (model == imagemodel)
                {
                    return true;
                }
            }
            enodes.Dispose();
            return false;
        }
    }
}
