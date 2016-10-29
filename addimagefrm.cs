using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSV_Inventory_Bobby
{
    public partial class addimagefrm : Form
    {
        public addimagefrm()
        {
            InitializeComponent();
        }

        private void addimagefrm_Load(object sender, EventArgs e)
        {

        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.imageTxt.Text = this.openFileDialog1.FileName;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (this.modelTxt.Text != string.Empty && this.imageTxt.Text != string.Empty)
            {
                if (!System.IO.File.Exists(this.imageTxt.Text))
                {
                    MessageBox.Show("The File " + this.imageTxt.Text + " Doesn't Exist");
                    return;
                }
                bool valid = true;
                try
                {
                    Image.FromFile(this.imageTxt.Text);
                }
                catch (System.OutOfMemoryException)
                {
                    MessageBox.Show("That is not a valid image");
                    valid = false;
                }
                if (valid)
                {
                    new imagewrite(this.imageTxt.Text, this.modelTxt.Text);
                    this.Close();
                    return;
                }
            }
            else
            {
                MessageBox.Show("The model# and/or image location have not been specified");
            }
        }

    }
}
