using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CSV_Inventory_Bobby
{
    public partial class autoImage : Form
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
        public autoImage()
        {
            InitializeComponent();
            this.bWork2.RunWorkerAsync();
        }

        private void autoImage_Load(object sender, EventArgs e)
        {

        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.dirTxt.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void rmvbtn_Click(object sender, EventArgs e)
        {
            this.collection = this.listView1.SelectedItems;
            this.collectionCount = this.collection.Count;
            this.collectioner = this.collection.GetEnumerator();
            this.collectionern = this.collection.GetEnumerator();
            this.bWork3.RunWorkerAsync();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            this.bWork.RunWorkerAsync();
        }

        private bool predicate_FileMatch(string fileName)
        {
            return fileName.EndsWith(".jpg") || fileName.EndsWith(".jpeg") || fileName.EndsWith(".tif") || fileName.EndsWith(".tiff") || fileName.EndsWith(".bmp") || fileName.EndsWith(".png") || fileName.EndsWith(".gif");
        }

        private string GetFileName(string szPath)
        {
            Regex r = new Regex("\\w+[.]\\w+$+");
            return r.Match(szPath).Value;
        }

        private void bWork_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!(this.dirTxt.Text != string.Empty))
            {
                MessageBox.Show("Directory not Specified");
                return;
            }
            if (System.IO.Directory.Exists(this.dirTxt.Text))
            {
                string dir = this.dirTxt.Text;
                string[] array = System.Array.FindAll<string>(System.IO.Directory.GetFiles(dir, "*"), new System.Predicate<string>(this.predicate_FileMatch));
                for (int i = 0; i < array.Length; i++)
                {
                    string arg_63_0 = array[i];
                    this.totalnum++;
                }
                base.Invoke(new MethodInvoker(initPBar));
                base.Invoke(new MethodInvoker(progressTxtAdding));
                string[] array2 = System.Array.FindAll<string>(System.IO.Directory.GetFiles(dir, "*"), new System.Predicate<string>(this.predicate_FileMatch));
                for (int j = 0; j < array2.Length; j++)
                {
                    string file = array2[j];
                    string model = System.IO.Path.GetFileNameWithoutExtension(file);
                    model.ToLower();
                    string modelelliesox = "digprod_" + model;
                    imageread read = new imageread();
                    System.Collections.Generic.IEnumerator<XNode> enodes = read.read();
                    if (!read.contains(enodes, modelelliesox))
                    {
                        new imagewrite(file, model);
                    }
                    Invoke(new MethodInvoker(update));
                }
                Invoke(new MethodInvoker(clearList));
                Invoke(new MethodInvoker(progressTxtPopulating));
                imageread readi = new imageread();
                System.Collections.Generic.IEnumerator<XNode> enodesi = readi.read();
                System.Collections.Generic.IEnumerator<XNode> enodesin = readi.read();
                while (enodesin.MoveNext())
                {
                    this.totalnum++;
                }
                enodesin.Dispose();
                Invoke(new MethodInvoker(initPBar));
                while (enodesi.MoveNext())
                {
                    XNode current = enodesi.Current;
                    XElement element = (XElement)current;
                    XName name = "model";
                    string model2 = element.Attribute(name).ToString();
                    string result = Regex.Replace(current.ToString(), "<[^>]*>", string.Empty);
                    Image image = Image.FromFile(result);
                    this.imageListModel = model2;
                    this.imageListImage = image;
                    Invoke(new MethodInvoker(addImage));
                    string modelstring = Regex.Replace(model2, "model=", string.Empty);
                    modelstring = Regex.Replace(modelstring, "[\"]", string.Empty);
                    this.addItemText = modelstring;
                    this.addItemImageKey = model2;
                    Invoke(new MethodInvoker(addItem));
                    Invoke(new MethodInvoker(update));
                }
                enodesi.Dispose();
                Invoke(new MethodInvoker(initReset));
                return;
            }
            MessageBox.Show("The Directory " + this.dirTxt.Text + " Does not Exist");
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
                Invoke(new MethodInvoker(addImage));
                string modelstring = Regex.Replace(model, "model=", string.Empty);
                modelstring = Regex.Replace(modelstring, "[\"]", string.Empty);
                addItemText = modelstring;
                addItemImageKey = model;
                Invoke(new MethodInvoker(addItem));
                Invoke(new MethodInvoker(update));
            }
            enodes2.Dispose();
            Invoke(new MethodInvoker(initReset));
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
			Invoke(new MethodInvoker(initPBar));
			Invoke(new MethodInvoker(progressTxtRemoving));
			while (this.collectioner.MoveNext())
			{
				ListViewItem item = (ListViewItem)this.collectioner.Current;
				string model = item.Text;
				imagedelete delete = new imagedelete();
				delete.delete(model);
				this.rmvItem = item;
				Invoke(new MethodInvoker(removeItem));
				Invoke(new MethodInvoker(update));
			}
			Invoke(new MethodInvoker(initReset));
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
            this.addBtn.Enabled = false;
            this.rmvbtn.Enabled = false;
            this.okBtn.Enabled = false;
        }

        private void progressTxtRemoving()
        {
            this.progressTxt.Text = "Removing";
            this.addBtn.Enabled = false;
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
            this.addBtn.Enabled = true;
            this.rmvbtn.Enabled = true;
            this.okBtn.Enabled = true;
        }

        private void progressTxtAdding()
        {
            this.progressTxt.Text = "Adding";
            this.addBtn.Enabled = false;
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

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
