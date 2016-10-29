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
    public partial class images : Form
    {
        private int totalnum;
        private ListView.SelectedListViewItemCollection collection;
        private int collectionCount;
        private System.Collections.IEnumerator collectioner;
        private System.Collections.IEnumerator collectionern;
        private ListViewItem rmvItem;
        private string addItemText
        {
            get;
            set;
        }
        private string addItemImageKey
        {
            get;
            set;
        }
        private string imageListModel
        {
            get;
            set;
        }
        private Image imageListImage
        {
            get;
            set;
        }

        public images()
        {
            InitializeComponent();
            this.bWork2.RunWorkerAsync();
        }

        private void images_Load(object sender, EventArgs e)
        {

        }

        private void rmvbtn_Click(object sender, EventArgs e)
        {
            this.collection = this.listView1.SelectedItems;
            this.collectionCount = this.collection.Count;
            this.collectioner = this.collection.GetEnumerator();
            this.collectionern = this.collection.GetEnumerator();
            this.bWork3.RunWorkerAsync();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            addimagefrm addfrm = new addimagefrm();
            addfrm.ShowDialog();
            this.bWork.RunWorkerAsync();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void bWork3_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.collectionCount == 0)
            {
                MessageBox.Show("No Images Selected");
                return;
            }
            while (this.collectionern.MoveNext())
            {
                this.totalnum++;
            }
            base.Invoke(new MethodInvoker(this.initPBar));
            base.Invoke(new MethodInvoker(this.progressTxtRemoving));
            while (this.collectioner.MoveNext())
            {
                ListViewItem item = (ListViewItem)this.collectioner.Current;
                string model = item.Text;
                imagedelete delete = new imagedelete();
                delete.delete(model);
                this.rmvItem = item;
                base.Invoke(new MethodInvoker(this.removeItem));
                base.Invoke(new MethodInvoker(this.update));
            }
            base.Invoke(new MethodInvoker(this.initReset));
        }

        private void bWork2_DoWork(object sender, DoWorkEventArgs e)
        {
            base.Invoke(new MethodInvoker(this.progressTxtPopulating));
            imageread read = new imageread();
            System.Collections.Generic.IEnumerator<XNode> enodes = read.read();
            while (enodes.MoveNext())
            {
                this.totalnum++;
            }
            enodes.Dispose();
            System.Collections.Generic.IEnumerator<XNode> enodes2 = read.read();
            base.Invoke(new MethodInvoker(this.initPBar));
            while (enodes2.MoveNext())
            {
                XNode current = enodes2.Current;
                XElement element = (XElement)current;
                XName name = "model";
                string model = element.Attribute(name).ToString();
                string result = Regex.Replace(current.ToString(), "<[^>]*>", string.Empty);
                this.imageListImage = Image.FromFile(result);
                this.imageListModel = model;
                base.Invoke(new MethodInvoker(this.addImage));
                string modelstring = Regex.Replace(model, "model=", string.Empty);
                modelstring = Regex.Replace(modelstring, "[\"]", string.Empty);
                this.addItemText = modelstring;
                this.addItemImageKey = model;
                base.Invoke(new MethodInvoker(this.addItem));
                base.Invoke(new MethodInvoker(this.update));
            }
            enodes2.Dispose();
            base.Invoke(new MethodInvoker(this.initReset));
        }

        private void removeItem()
        {
            this.rmvItem.Remove();
        }

        private void update()
        {
            this.pBar.Value++;
        }

        private void addItem()
        {
            this.listView1.Items.Add(this.addItemText, this.addItemImageKey);
        }

        private void addImage()
        {
            this.imageList.Images.Add(this.imageListModel, this.imageListImage);
        }

        private void progressTxtPopulating()
        {
            this.progressTxt.Text = "Populating";
            this.addbtn.Enabled = false;
            this.rmvbtn.Enabled = false;
            this.okBtn.Enabled = false;
        }

        private void progressTxtRemoving()
        {
            this.progressTxt.Text = "Removing";
            this.addbtn.Enabled = false;
            this.rmvbtn.Enabled = false;
            this.okBtn.Enabled = false;
        }

        private void initPBar()
        {
            this.pBar.Value = 0;
            this.pBar.Maximum = this.totalnum;
        }

        private void initReset()
        {
            this.pBar.Value = 0;
            this.pBar.Maximum = 0;
            this.totalnum = 0;
            this.progressTxt.Text = "Ready";
            this.addbtn.Enabled = true;
            this.rmvbtn.Enabled = true;
            this.okBtn.Enabled = true;
        }

        private void progressTxtAdding()
        {
            this.progressTxt.Text = "Adding";
            this.addbtn.Enabled = false;
            this.rmvbtn.Enabled = false;
            this.okBtn.Enabled = false;
        }

        private void clearList()
        {
            this.listView1.Clear();
            this.pBar.Maximum = 0;
            this.pBar.Value = 0;
            this.totalnum = 0;
            this.progressTxtPopulating();
        }

        private void bWork_DoWork(object sender, DoWorkEventArgs e)
        {
            base.Invoke(new MethodInvoker(this.clearList));
            base.Invoke(new MethodInvoker(this.progressTxtPopulating));
            imageread readi = new imageread();
            System.Collections.Generic.IEnumerator<XNode> enodesi = readi.read();
            System.Collections.Generic.IEnumerator<XNode> enodesin = readi.read();
            while (enodesin.MoveNext())
            {
                this.totalnum++;
            }
            enodesin.Dispose();
            base.Invoke(new MethodInvoker(this.initPBar));
            while (enodesi.MoveNext())
            {
                XNode current = enodesi.Current;
                XElement element = (XElement)current;
                XName name = "model";
                string model = element.Attribute(name).ToString();
                string result = Regex.Replace(current.ToString(), "<[^>]*>", string.Empty);
                Image image = Image.FromFile(result);
                this.imageListModel = model;
                this.imageListImage = image;
                base.Invoke(new MethodInvoker(this.addImage));
                string modelstring = Regex.Replace(model, "model=", string.Empty);
                modelstring = Regex.Replace(modelstring, "[\"]", string.Empty);
                this.addItemText = modelstring;
                this.addItemImageKey = model;
                base.Invoke(new MethodInvoker(this.addItem));
                base.Invoke(new MethodInvoker(this.update));
            }
            enodesi.Dispose();
            base.Invoke(new MethodInvoker(this.initReset));
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}
