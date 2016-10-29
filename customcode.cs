using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CSV_Inventory_Bobby
{
    public partial class customcode : Form
    {
        private ListView.SelectedListViewItemCollection collection;
        private int collectionCount;
        private System.Collections.IEnumerator collectioner;
        private System.Collections.IEnumerator collectionern;
        private ListViewItem rmvItem; 
        public customcode()
        {
            InitializeComponent();
            prefread read = new prefread();
            System.Collections.Generic.IEnumerator<XNode> enodes = read.read("code", "codes");
            while (enodes.MoveNext())
            {
                XNode current = enodes.Current;
                XElement element = current as XElement;
                XAttribute col = new XAttribute(element.Attribute("column"));
                string result = Regex.Replace(current.ToString(), "<[^>]*>", string.Empty);
                this.codeView.Items.Add(result + " " + col.ToString());
            }
        }

        private void customcode_Load(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (this.codeTxt.Text != "" && this.codeTxt.Text != " " && this.columnTxt.Text != "" && this.columnTxt.Text != " ")
            {
                try
                {
                    string code = "{" + this.codeTxt.Text + "}";
                    int column = System.Convert.ToInt32(this.columnTxt.Text);
                    new prefwrite(code, "codes", "code", "column", column.ToString());
                    prefread read = new prefread();
                    System.Collections.Generic.IEnumerator<XNode> enodes = read.read("code", "codes");
                    this.codeView.Clear();
                    while (enodes.MoveNext())
                    {
                        XNode current = enodes.Current;
                        XElement element = current as XElement;
                        XAttribute col = new XAttribute(element.Attribute("column"));
                        string result = Regex.Replace(current.ToString(), "<[^>]*>", string.Empty);
                        this.codeView.Items.Add(result + " " + col.ToString());
                    }
                    return;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.ToString());
                    return;
                }
            }
            MessageBox.Show("You must specify a value for the code and the column");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.collection = this.codeView.SelectedItems;
            this.collectionCount = this.collection.Count;
            this.collectioner = this.collection.GetEnumerator();
            this.collectionern = this.collection.GetEnumerator();
            if (this.collectionCount == 0)
            {
                MessageBox.Show("No Codes Selected");
                return;
            }
            while (this.collectioner.MoveNext())
            {
                ListViewItem item = (ListViewItem)this.collectioner.Current;
                string model = item.Text;
                model = Regex.Match(model, "{[^}]*}").ToString();
                new prefremove(model);
                this.rmvItem = item;
                this.rmvItem.Remove();
            }
        }
    }
}
