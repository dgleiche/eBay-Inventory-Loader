using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CSV_Inventory_Bobby
{
    public partial class pref : Form
    {
        private bool errorbool = true;
        private bool revised = true;
        private bool revisei = true;
        private bool usemultiple;
        private double multipleamount;
        private double quantityadd;
        private double quantityminus;
        private double qCapInt;
        private string desHeader = "";
        private string desFooter = "";
        private string titlePrefix = "";
        private string titleSuffix = "";
        private string formStartPrice = "";
        private string formQuantity = "";
        private string formLbs = "";
        private string formOz = "";
        private string formDescription = "";
        private string formTitle = "";
        private string formSku = "";
        private string formSize = "";
        private string formColor = "";
        private string formModel = "";
        public pref()
        {
            InitializeComponent();
            bool errorbool = true;
			bool revised = true;
			bool revisei = true;
			xmlread read = new xmlread();
			System.Collections.Generic.IEnumerator<XNode> enodes = read.read();
			while (enodes.MoveNext())
			{
				XNode current = enodes.Current;
				string result = Regex.Replace(current.ToString(), "<[^>]*>", string.Empty);
				this.listBox1.Items.Add(result);
			}
			enodes.Dispose();
			prefread readp = new prefread();
			System.Collections.Generic.IEnumerator<XNode> error_skip = readp.read("skip", "error");
			string error_skipp = readp.getPropertyValue(error_skip);
			string a;
			if ((a = error_skipp) != null)
			{
				if (!(a == "true"))
				{
					if (a == "false")
					{
						errorbool = false;
					}
				}
				else
				{
					errorbool = true;
				}
			}
			this.errorcheck.Checked = errorbool;
			System.Collections.Generic.IEnumerator<XNode> revisednodes = readp.read("revised", "revise");
			string revisedbool = readp.getPropertyValue(revisednodes);
			string a2;
			if ((a2 = revisedbool) != null)
			{
				if (!(a2 == "true"))
				{
					if (a2 == "false")
					{
						revised = false;
					}
				}
				else
				{
					revised = true;
				}
			}
			this.revisedCheck.Checked = revised;
			System.Collections.Generic.IEnumerator<XNode> reviseinodes = readp.read("revisei", "revise");
			string reviseibool = readp.getPropertyValue(reviseinodes);
			string a3;
			if ((a3 = reviseibool) != null)
			{
				if (!(a3 == "true"))
				{
					if (a3 == "false")
					{
						revisei = false;
					}
				}
				else
				{
					revisei = true;
				}
			}
			this.reviseiCheck.Checked = revisei;
			System.Collections.Generic.IEnumerator<XNode> usemultiplenodes = readp.read("usemultiple", "price");
			string usemultiplebool = readp.getPropertyValue(usemultiplenodes);
			string a4;
			if ((a4 = usemultiplebool) != null)
			{
				if (!(a4 == "true"))
				{
					if (a4 == "false")
					{
						this.usemultiple = false;
					}
				}
				else
				{
					this.usemultiple = true;
				}
			}
			this.useMultipleCheck.Checked = this.usemultiple;
			this.multipleTxt.Enabled = this.usemultiple;
			this.confirmMultipleTxt.Enabled = this.usemultiple;
			System.Collections.Generic.IEnumerator<XNode> multiplenodes = readp.read("multiple", "price");
			this.multipleamount = System.Convert.ToDouble(readp.getPropertyValue(multiplenodes));
			this.multipleTxt.Text = this.multipleamount.ToString();
			this.confirmMultipleTxt.Text = this.multipleamount.ToString();
			System.Collections.Generic.IEnumerator<XNode> quantityAddNodes = readp.read("add", "quantity");
			this.quantityadd = System.Convert.ToDouble(readp.getPropertyValue(quantityAddNodes));
			this.quantityAddTxt.Text = this.quantityadd.ToString();
			System.Collections.Generic.IEnumerator<XNode> quantityMinusNodes = readp.read("minus", "quantity");
			this.quantityminus = System.Convert.ToDouble(readp.getPropertyValue(quantityMinusNodes));
			this.quantityMinusTxt.Text = this.quantityminus.ToString();
            System.Collections.Generic.IEnumerator<XNode> qCapNodes = readp.read("cap", "quantity");
            this.qCapInt = System.Convert.ToDouble(readp.getPropertyValue(qCapNodes));
            this.qCap.Text = this.qCapInt.ToString();
			System.Collections.Generic.IEnumerator<XNode> desHeaderNodes = readp.read("header", "description");
			this.desHeader = readp.getPropertyValue(desHeaderNodes);
			this.descriptionHeaderTxt.Text = WebUtility.HtmlDecode(this.desHeader);
			System.Collections.Generic.IEnumerator<XNode> desFooterNodes = readp.read("footer", "description");
			this.desFooter = readp.getPropertyValue(desFooterNodes);
			this.descriptionFooterTxt.Text = WebUtility.HtmlDecode(this.desFooter);
			System.Collections.Generic.IEnumerator<XNode> titlePrefixNodes = readp.read("prefix", "title");
			this.titlePrefix = readp.getPropertyValue(titlePrefixNodes);
			this.titlePrefixTxt.Text = WebUtility.HtmlDecode(this.titlePrefix);
			System.Collections.Generic.IEnumerator<XNode> titleSuffixNodes = readp.read("suffix", "title");
			this.titleSuffix = readp.getPropertyValue(titleSuffixNodes);
			this.titleSuffixTxt.Text = WebUtility.HtmlDecode(this.titleSuffix);
			System.Collections.Generic.IEnumerator<XNode> formPriceNodes = readp.read("startprice", "format");
			this.formStartPrice = readp.getPropertyValue(formPriceNodes);
			this.formStartPriceTxt.Text = WebUtility.HtmlDecode(this.formStartPrice);
			System.Collections.Generic.IEnumerator<XNode> formQuantityNodes = readp.read("quantity", "format");
			this.formQuantity = readp.getPropertyValue(formQuantityNodes);
			this.formQuantityTxt.Text = WebUtility.HtmlDecode(this.formQuantity);
			System.Collections.Generic.IEnumerator<XNode> formLbsNodes = readp.read("lbs", "format");
			this.formLbs = readp.getPropertyValue(formLbsNodes);
			this.formLbsTxt.Text = WebUtility.HtmlDecode(this.formLbs);
			System.Collections.Generic.IEnumerator<XNode> formOzNodes = readp.read("oz", "format");
			this.formOz = readp.getPropertyValue(formOzNodes);
			this.formOzTxt.Text = WebUtility.HtmlDecode(this.formOz);
			System.Collections.Generic.IEnumerator<XNode> formDescriptionNodes = readp.read("description", "format");
			this.formDescription = readp.getPropertyValue(formDescriptionNodes);
			this.formDesTxt.Text = WebUtility.HtmlDecode(this.formDescription);
			System.Collections.Generic.IEnumerator<XNode> formTitleNodes = readp.read("title", "format");
			this.formTitle = readp.getPropertyValue(formTitleNodes);
			this.formTitleTxt.Text = WebUtility.HtmlDecode(this.formTitle);
			System.Collections.Generic.IEnumerator<XNode> formSkuNodes = readp.read("sku", "format");
			this.formSku = readp.getPropertyValue(formSkuNodes);
			this.formSkuTxt.Text = WebUtility.HtmlDecode(this.formSku);
			System.Collections.Generic.IEnumerator<XNode> formSizeNodes = readp.read("size", "format");
			this.formSize = readp.getPropertyValue(formSizeNodes);
			this.formSizeTxt.Text = WebUtility.HtmlDecode(this.formSize);
			System.Collections.Generic.IEnumerator<XNode> formColorNodes = readp.read("color", "format");
			this.formColor = readp.getPropertyValue(formColorNodes);
			this.formColorTxt.Text = WebUtility.HtmlDecode(this.formColor);
			System.Collections.Generic.IEnumerator<XNode> formModelNodes = readp.read("model", "format");
			this.formModel = readp.getPropertyValue(formModelNodes);
			this.formModelTxt.Text = WebUtility.HtmlDecode(this.formModel);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void errorcheck_CheckedChanged(object sender, System.EventArgs e)
        {
            if (sender is CheckBox)
            {
                CheckBox check = sender as CheckBox;
                this.errorbool = check.Checked;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.button1.Text = "Remove Error " + this.listBox1.SelectedItem.ToString();
            }
            catch (System.Exception)
            {
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                string delete = this.listBox1.SelectedItem.ToString();
                xmldelete dxml = new xmldelete();
                dxml.delete(delete);
                this.listBox1.Items.Remove(delete);
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("An Error is not Selected");
            }
        }

        private void okBtn_Click(object sender, System.EventArgs e)
        {
            this.okClicked();
        }

        private void okBtn2_Click(object sender, System.EventArgs e)
        {
            this.okClicked();
        }

        private void okClicked()
        {
            if (!(this.multipleTxt.Text == this.confirmMultipleTxt.Text))
            {
                MessageBox.Show("The price multiple confirmation does not equal the price multiple");
                return;
            }
            if (this.formStartPriceTxt.Text != "" && this.formQuantityTxt.Text != "" && this.formLbsTxt.Text != "" && this.formDesTxt.Text != "" && this.formTitleTxt.Text != "" && this.formSkuTxt.Text != "" && this.formSizeTxt.Text != "" && this.formColorTxt.Text != "" && this.formModelTxt.Text != "" && this.formStartPriceTxt.Text != " " && this.formQuantityTxt.Text != " " && this.formLbsTxt.Text != " " && this.formDesTxt.Text != " " && this.formTitleTxt.Text != " " && this.formSkuTxt.Text != " " && this.formSizeTxt.Text != " " && this.formColorTxt.Text != " " && this.formModelTxt.Text != " ")
            {
                new prefwrite(this.errorbool.ToString().ToLower(), "error", "skip");
                new prefwrite(this.revised.ToString().ToLower(), "revise", "revised");
                new prefwrite(this.revisei.ToString().ToLower(), "revise", "revisei");
                new prefwrite(this.usemultiple.ToString().ToLower(), "price", "usemultiple");
                new prefwrite(this.multipleTxt.Text, "price", "multiple");
                new prefwrite(this.quantityMinusTxt.Text, "quantity", "minus");
                new prefwrite(this.qCap.Text, "quantity", "cap");
                new prefwrite(this.quantityAddTxt.Text, "quantity", "add");
                new prefwrite(WebUtility.HtmlDecode(this.descriptionHeaderTxt.Text), "description", "header");
                new prefwrite(WebUtility.HtmlDecode(this.descriptionFooterTxt.Text), "description", "footer");
                new prefwrite(WebUtility.HtmlDecode(this.titleSuffixTxt.Text), "title", "suffix");
                new prefwrite(WebUtility.HtmlDecode(this.titlePrefixTxt.Text), "title", "prefix");
                new prefwrite(WebUtility.HtmlDecode(this.formStartPriceTxt.Text), "format", "startprice");
                new prefwrite(WebUtility.HtmlDecode(this.formQuantityTxt.Text), "format", "quantity");
                new prefwrite(WebUtility.HtmlDecode(this.formLbsTxt.Text), "format", "lbs");
                new prefwrite(WebUtility.HtmlDecode(this.formOzTxt.Text), "format", "oz");
                new prefwrite(WebUtility.HtmlDecode(this.formDesTxt.Text), "format", "description");
                new prefwrite(WebUtility.HtmlDecode(this.formTitleTxt.Text), "format", "title");
                new prefwrite(WebUtility.HtmlDecode(this.formSkuTxt.Text), "format", "sku");
                new prefwrite(WebUtility.HtmlDecode(this.formSizeTxt.Text), "format", "size");
                new prefwrite(WebUtility.HtmlDecode(this.formColorTxt.Text), "format", "color");
                new prefwrite(WebUtility.HtmlDecode(this.formModelTxt.Text), "format", "model");
                base.Close();
                return;
            }
            MessageBox.Show("One of the required database format fields is invalid");
        }

        private void revisedCheck_CheckedChanged(object sender, System.EventArgs e)
        {
            if (sender is CheckBox)
            {
                CheckBox check = sender as CheckBox;
                this.revised = check.Checked;
            }
        }

        private void reviseiCheck_CheckedChanged(object sender, System.EventArgs e)
        {
            if (sender is CheckBox)
            {
                CheckBox check = sender as CheckBox;
                this.revisei = check.Checked;
            }
        }

        private void cancelBtn2_Click(object sender, System.EventArgs e)
        {
            base.Close();
        }

        private void cancelBtn_Click(object sender, System.EventArgs e)
        {
            base.Close();
        }

        private void okBtn3_Click(object sender, System.EventArgs e)
        {
            this.okClicked();
        }

        private void cancelBtn3_Click(object sender, System.EventArgs e)
        {
            base.Close();
        }

        private void useMultipleCheck_CheckedChanged(object sender, System.EventArgs e)
        {
            if (sender is CheckBox)
            {
                CheckBox check = sender as CheckBox;
                this.usemultiple = check.Checked;
                this.multipleTxt.Enabled = this.usemultiple;
                this.confirmMultipleTxt.Enabled = this.usemultiple;
                if (!this.usemultiple)
                {
                    this.multipleamount = 1.0;
                    this.confirmMultipleTxt.Text = this.multipleamount.ToString();
                }
                if (this.usemultiple)
                {
                    this.confirmMultipleTxt.Text = "";
                }
                this.multipleTxt.Text = this.multipleamount.ToString();
            }
        }

        private void okBtn4_Click(object sender, System.EventArgs e)
        {
            this.okClicked();
        }

        private void cancelBtn4_Click(object sender, System.EventArgs e)
        {
            base.Close();
        }

        private void okBtn5_Click(object sender, System.EventArgs e)
        {
            this.okClicked();
        }

        private void cancelBtn5_Click(object sender, System.EventArgs e)
        {
            base.Close();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            customcode codecustom = new customcode();
            codecustom.ShowDialog();
        }

        private void okBtn6_Click(object sender, System.EventArgs e)
        {
            this.okClicked();
        }

        private void cancelBtn6_Click(object sender, System.EventArgs e)
        {
            base.Close();
        }

        private void customCodeBtn2_Click(object sender, System.EventArgs e)
        {
            customcode custom = new customcode();
            custom.ShowDialog();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            customcode custm = new customcode();
            custm.ShowDialog();
        }

        private void okBtn7_Click(object sender, System.EventArgs e)
        {
            this.okClicked();
        }

        private void cancelBtn7_Click(object sender, System.EventArgs e)
        {
            base.Close();
        }

        private void quantityMinusTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
