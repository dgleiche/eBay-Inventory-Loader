using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CSV_Inventory_Bobby
{
    public partial class Form1 : Form
    {
        private double runningfee;
        private double sessionfee;
        private int prodamount;
        private int current;
        private bool auto;
        private bool errorbool = true;
        private bool revised = true;
        private bool revisei = true;
        private double multiple = 1.0;
        private double quantityAdd;
        private double quantityMinus;
        private double qCapInt;
        private string desHeader = "";
        private string desFooter = "";
        private string titlePrefix = "";
        private string titleSuffix = "";
        private string suffix = "";
        private string prefix = "";
        private string footer = "";
        private string header = "";
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
        private string formStartPrice2 = "";
        private string formQuantity2 = "";
        private string formLbs2 = "";
        private string formOz2 = "";
        private string formDescription2 = "";
        private string formTitle2 = "";
        private string formSku2 = "";
        private string formSize2 = "";
        private string formColor2 = "";
        private string formModel2 = "";
        private string token;
        private string userID;
        public static ApiContext apiContext;
        private bool fetched;
        private SiteCodeType country;
        private bool stopWork;

        public Form1()
        {
            InitializeComponent();
            this.autoBtn.Enabled = false;
            Form1.apiContext = Form1.GetApiContext();
            this.outBtn.Enabled = false;
        }

        private static ApiContext GetApiContext()
        {
            if (Form1.apiContext != null)
            {
                return Form1.apiContext;
            }
            Form1.apiContext = new ApiContext();
            Form1.apiContext.SoapApiServerUrl = ConfigurationManager.AppSettings["Environment.ApiServerUrl"];
            ApiCredential apiCredential = new ApiCredential();
            ApiAccount account = new ApiAccount("CREDENTIALS");
            apiCredential.ApiAccount = account;
            Form1.apiContext.ApiCredential = apiCredential;
            Form1.apiContext.Site = SiteCodeType.US;
            Form1.apiContext.SignInUrl = "https://signin.ebay.com/ws/eBayISAPI.dll?SignIn";
            Form1.apiContext.EPSServerUrl = "https://api.ebay.com/ws/api.dll";
            return Form1.apiContext;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.xmlExist();
            this.label1.Text = "$" + this.runningfee.ToString();
            this.label5.Text = "$" + this.sessionfee.ToString();
            this.pBar.Minimum = 0;
            this.pBar.Maximum = 3000;
            this.pBar.Value = 0;
            this.pBar.Visible = true;
            this.currentitem.Text = this.current.ToString();
            this.totalitem.Text = this.prodamount.ToString();
            this.init();
        }

        private void csvbut_Click(object sender, EventArgs e)
        {
            if (this.fetched)
            {
                DialogResult result = this.csvloader.ShowDialog();
                if (result == DialogResult.OK)
                {
                    try
                    {
                        using (CachedCsvReader csv = new CachedCsvReader(new System.IO.StreamReader(this.csvloader.FileName), true))
                        {
                            while (csv.ReadNextRecord())
                            {
                                this.prodamount++;
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message);
                    }
                    this.pBar.Visible = true;
                    this.pBar.Maximum = this.prodamount;
                    this.totalitem.Text = this.prodamount.ToString();
                    this.bWork.RunWorkerAsync();
                    return;
                }
            }
            else
            {
                MessageBox.Show("You must first log in");
            }
        }

        private void fileopen_Click(object sender, EventArgs e)
        {
            if (this.fetched)
            {
                DialogResult result = this.csvloader.ShowDialog();
                if (result == DialogResult.OK)
                {
                    try
                    {
                        using (CachedCsvReader csv = new CachedCsvReader(new System.IO.StreamReader(this.csvloader.FileName), true))
                        {
                            while (csv.ReadNextRecord())
                            {
                                this.prodamount++;
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message);
                    }
                    this.pBar.Visible = true;
                    this.pBar.Maximum = this.prodamount;
                    this.totalitem.Text = this.prodamount.ToString();
                    this.bWork.RunWorkerAsync();
                    return;
                }
            }
            else
            {
                MessageBox.Show("You must first log in");
            }
        }

        public void update()
        {
            this.pBar.Value++;
            this.current++;
            this.currentitem.Text = this.current.ToString();
            this.label1.Text = "$" + this.runningfee.ToString();
            this.label5.Text = "$" + this.sessionfee.ToString();
        }

        private void bWork_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.sessionfee = 0.0;
                using (CachedCsvReader csv = new CachedCsvReader(new System.IO.StreamReader(this.csvloader.FileName), true))
                {
                    int arg_2C_0 = csv.FieldCount;
                    csv.GetFieldHeaders();
                    base.Invoke(new MethodInvoker(this.DisableButton));
                    while (csv.ReadNextRecord())
                    {
                        if (!this.stopWork)
                        {
                            if (this.desHeader == null)
                            {
                                this.desHeader = " ";
                            }
                            if (this.desFooter == null)
                            {
                                this.desFooter = " ";
                            }
                            if (this.titlePrefix == null)
                            {
                                this.titlePrefix = " ";
                            }
                            if (this.titleSuffix == null)
                            {
                                this.titleSuffix = " ";
                            }
                            prefread read = new prefread();
                            System.Collections.Generic.IEnumerator<XNode> enodes = read.read("code", "codes");
                            this.titlePrefix = this.prefix;
                            this.titleSuffix = this.suffix;
                            this.desFooter = this.footer;
                            this.desHeader = this.header;
                            this.formStartPrice2 = this.formStartPrice;
                            this.formQuantity2 = this.formQuantity;
                            this.formLbs2 = this.formLbs;
                            this.formOz2 = this.formOz;
                            this.formDescription2 = this.formDescription;
                            this.formTitle2 = this.formTitle;
                            this.formSku2 = this.formSku;
                            this.formSize2 = this.formSize;
                            this.formColor2 = this.formColor;
                            this.formModel2 = this.formModel;
                            while (enodes.MoveNext())
                            {
                                XNode current = enodes.Current;
                                XElement element = current as XElement;
                                XAttribute col = new XAttribute(element.Attribute("column"));
                                string result = Regex.Replace(current.ToString(), "<[^>]*>", string.Empty);
                                int column = System.Convert.ToInt32(col.Value);
                                column--;
                                this.desHeader = Regex.Replace(this.desHeader, result, csv[column]);
                                this.titlePrefix = Regex.Replace(this.titlePrefix, result, csv[column]);
                                this.titleSuffix = Regex.Replace(this.titleSuffix, result, csv[column]);
                                this.desFooter = Regex.Replace(this.desFooter, result, csv[column]);
                                this.formStartPrice2 = Regex.Replace(this.formStartPrice2, result, csv[column]);
                                this.formQuantity2 = Regex.Replace(this.formQuantity2, result, csv[column]);
                                this.formLbs2 = Regex.Replace(this.formLbs2, result, csv[column]);
                                this.formOz2 = Regex.Replace(this.formOz2, result, csv[column]);
                                this.formDescription2 = Regex.Replace(this.formDescription2, result, csv[column]);
                                this.formTitle2 = Regex.Replace(this.formTitle2, result, csv[column]);
                                this.formSku2 = Regex.Replace(this.formSku2, result, csv[column]);
                                this.formSize2 = Regex.Replace(this.formSize2, result, csv[column]);
                                this.formColor2 = Regex.Replace(this.formColor2, result, csv[column]);
                                this.formModel2 = Regex.Replace(this.formModel2, result, csv[column]);
                            }
                            if (this.formSku != " " && this.formSku != "" && this.formSku != null && this.formQuantity != "" && this.formQuantity != " ")
                            {
                                if (this.formSku2 != " " && this.formSku2 != "" && this.formSku2 != null && this.formQuantity2 != "" && this.formQuantity2 != " ")
                                {
                                    if (!this.auto)
                                    {
                                        base.Invoke(new MethodInvoker(this.disableAuto));
                                        this.auto = false;
                                    }
                                    else
                                    {
                                        base.Invoke(new MethodInvoker(this.enableAuto));
                                        this.auto = true;
                                    }
                                    eBayup ebay = new eBayup(this.token, this.country);
                                    ebay.auto = this.auto;
                                    if (!this.auto)
                                    {
                                        ebay.auto = this.errorbool;
                                    }
                                    double startprice;
                                    if (csv[11] == "Panty Hose and Hosiery")
                                    {
                                        string msrp = csv[6].Replace("$", string.Empty);
                                        startprice = System.Convert.ToDouble(msrp) * System.Convert.ToDouble(csv[8]) - 0.01;
                                    }
                                    else
                                    {
                                        startprice = System.Convert.ToDouble(this.formStartPrice2);
                                        startprice *= this.multiple;
                                    }
                                    int quantity = System.Convert.ToInt32(this.formQuantity2);
                                    quantity -= System.Convert.ToInt32(this.quantityMinus);
                                    quantity += System.Convert.ToInt32(this.quantityAdd);
                                    if (quantity > qCapInt)
                                    {
                                        quantity = Convert.ToInt32(qCapInt);
                                    }
                                    double weight = System.Convert.ToDouble(this.formLbs2);
                                    if (this.formOz2 != null && this.formOz2 != "" && this.formOz2 != " ")
                                    {
                                        weight += System.Convert.ToDouble(this.formOz2) / 16.0;
                                    }
                                    if (weight == 0.0)
                                    {
                                        weight = 0.25;
                                    }
                                    weight += 0.2;
                                    weight = System.Math.Ceiling(weight * 100.0) / 100.0;
                                    double weightpoundsnotuse = System.Math.Truncate(weight);
                                    int weightpounds = System.Convert.ToInt32(weightpoundsnotuse);
                                    double weightozdecimal = weight - (double)weightpounds;
                                    weightozdecimal *= 16.0;
                                    double weightoznotuse = System.Math.Truncate(weightozdecimal);
                                    double differenceoz = weightozdecimal - weightoznotuse;
                                    bool roundup = false;
                                    if (differenceoz > 0.0)
                                    {
                                        roundup = true;
                                    }
                                    if (roundup)
                                    {
                                        weightoznotuse += 1.0;
                                    }
                                    if (weightoznotuse >= 16.0)
                                    {
                                        weightpounds++;
                                        weightoznotuse = 0.0;
                                    }
                                    int weightoz = System.Convert.ToInt32(weightoznotuse);
                                    string model = "digprod_" + this.formModel2;
                                    string description = this.desHeader + "<br />";
                                    description += this.formDescription2;
                                    description += this.desFooter;
                                    string title = string.Concat(new string[]
									{
										this.titlePrefix, 
										" ", 
										this.formTitle2, 
										" ", 
										this.titleSuffix
									});
                                    string sku = this.formSku2;
                                    string size = this.formSize2;
                                    string color = this.formColor2;
                                    string modelwo = this.formModel2;
                                    ebay.revised = this.revised;
                                    ebay.revisei = this.revisei;
                                    string call = ebay.Execute(title, sku, description, startprice, quantity, size, color, model, weightpounds, weightoz, modelwo);
                                    if (call == "close")
                                    {
                                        base.Invoke(new MethodInvoker(this.closeform));
                                    }
                                    else
                                    {
                                        if (!(call == "error") && !(call == "skip"))
                                        {
                                            this.runningfee += ebay.getFee();
                                            this.sessionfee += ebay.getFee();
                                        }
                                    }
                                    if (!ebay.auto)
                                    {
                                        base.Invoke(new MethodInvoker(this.disableAuto));
                                        this.auto = false;
                                    }
                                    else
                                    {
                                        if (!this.errorbool)
                                        {
                                            base.Invoke(new MethodInvoker(this.enableAuto));
                                            this.auto = true;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("ERROR: Your datafeed format is invalid. You may correct this in File->Preferences");
                                base.Invoke(new MethodInvoker(this.EnableButton));
                                base.Invoke(new MethodInvoker(this.Reset));
                                this.stopWork = true;
                            }
                            base.Invoke(new MethodInvoker(this.update));
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void enableAuto()
        {
            this.autoBtn.Enabled = true;
        }

        private void disableAuto()
        {
            this.autoBtn.Enabled = false;
        }

        private void bWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.stopWork = false;
            base.Invoke(new MethodInvoker(this.EnableButton));
            base.Invoke(new MethodInvoker(this.Reset));
        }

        private void Reset()
        {
            this.pBar.Value = 0;
            this.current = 0;
            this.currentitem.Text = this.current.ToString();
            this.prodamount = 0;
            this.totalitem.Text = this.prodamount.ToString();
        }

        private void DisableButton()
        {
            this.csvbut.Enabled = false;
            this.fileopen.Enabled = false;
            this.outBtn.Enabled = false;
        }

        private void EnableButton()
        {
            this.csvbut.Enabled = true;
            this.fileopen.Enabled = true;
            if (!this.button2.Enabled)
            {
                this.outBtn.Enabled = true;
            }
        }

        private void closeform()
        {
            if (this.bWork.IsBusy)
            {
                this.stopWork = true;
            }
        }

        private void filepreferences_Click(object sender, EventArgs e)
        {
            pref preform = new pref();
            preform.ShowDialog();
            this.init();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            images imagefrm = new images();
            imagefrm.ShowDialog();
            this.init();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            autoImage aImage = new autoImage();
            aImage.ShowDialog();
        }

        private void autoBtn_Click(object sender, EventArgs e)
        {
            this.auto = false;
            this.autoBtn.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.bWork.IsBusy)
            {
                this.stopWork = true;
            }
        }

        private void xmlExist()
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string filename = "pref.xml";
            path = System.IO.Path.Combine(path, filename);
            if (!System.IO.File.Exists(path))
            {
                System.IO.File.WriteAllText(path, "<?xml version=\"1.0\" encoding=\"utf-8\" ?><preferences><error><skip>true</skip></error><revise><revised>false</revised><revisei>false</revisei></revise><price><usemultiple>false</usemultiple><multiple>1.00</multiple></price><quantity><add>0</add><minus>0</minus><cap>0</cap></quantity><description><header><![CDATA[ ]]></header><footer><![CDATA[ ]]></footer></description><codes></codes><title><prefix><![CDATA[ ]]></prefix><suffix><![CDATA[ ]]></suffix></title><format><startprice><![CDATA[ ]]></startprice><quantity><![CDATA[ ]]></quantity><lbs><![CDATA[ ]]></lbs><oz><![CDATA[ ]]></oz><description><![CDATA[ ]]></description><title><![CDATA[ ]]></title><sku><![CDATA[ ]]></sku><size><![CDATA[ ]]></size><color><![CDATA[ ]]></color><model><![CDATA[ ]]></model></format></preferences>");
            }
            path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            filename = "errors.xml";
            path = System.IO.Path.Combine(path, filename);
            if (!System.IO.File.Exists(path))
            {
                System.IO.File.WriteAllText(path, "<?xml version=\"1.0\" encoding=\"utf-8\" ?><errors><error></error></errors>");
            }
            path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            filename = "images.xml";
            path = System.IO.Path.Combine(path, filename);
            if (!System.IO.File.Exists(path))
            {
                System.IO.File.WriteAllText(path, "<?xml version=\"1.0\" encoding=\"utf-8\" ?><images></images>");
            }
        }

        private void init()
        {
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
                        this.errorbool = false;
                    }
                }
                else
                {
                    this.errorbool = true;
                }
            }
            System.Collections.Generic.IEnumerator<XNode> revisednodes = readp.read("revised", "revise");
            string revisedbool = readp.getPropertyValue(revisednodes);
            string a2;
            if ((a2 = revisedbool) != null)
            {
                if (!(a2 == "true"))
                {
                    if (a2 == "false")
                    {
                        this.revised = false;
                    }
                }
                else
                {
                    this.revised = true;
                }
            }
            System.Collections.Generic.IEnumerator<XNode> reviseinodes = readp.read("revisei", "revise");
            string reviseibool = readp.getPropertyValue(reviseinodes);
            string a3;
            if ((a3 = reviseibool) != null)
            {
                if (!(a3 == "true"))
                {
                    if (a3 == "false")
                    {
                        this.revisei = false;
                    }
                }
                else
                {
                    this.revisei = true;
                }
            }
            System.Collections.Generic.IEnumerator<XNode> multiplenodes = readp.read("multiple", "price");
            this.multiple = System.Convert.ToDouble(readp.getPropertyValue(multiplenodes));
            System.Collections.Generic.IEnumerator<XNode> quantityAddNodes = readp.read("add", "quantity");
            this.quantityAdd = System.Convert.ToDouble(readp.getPropertyValue(quantityAddNodes));
            System.Collections.Generic.IEnumerator<XNode> quantityMinusNodes = readp.read("minus", "quantity");
            this.quantityMinus = System.Convert.ToDouble(readp.getPropertyValue(quantityMinusNodes));
            System.Collections.Generic.IEnumerator<XNode> qCapNodes = readp.read("cap", "quantity");
            this.qCapInt = System.Convert.ToDouble(readp.getPropertyValue(qCapNodes));
            System.Collections.Generic.IEnumerator<XNode> desHeaderNodes = readp.read("header", "description");
            this.desHeader = WebUtility.HtmlDecode(readp.getPropertyValue(desHeaderNodes));
            this.header = this.desHeader;
            System.Collections.Generic.IEnumerator<XNode> desFooterNodes = readp.read("footer", "description");
            this.desFooter = WebUtility.HtmlDecode(readp.getPropertyValue(desFooterNodes));
            this.footer = this.desFooter;
            System.Collections.Generic.IEnumerator<XNode> titlePrefixNodes = readp.read("prefix", "title");
            this.titlePrefix = WebUtility.HtmlDecode(readp.getPropertyValue(titlePrefixNodes));
            System.Collections.Generic.IEnumerator<XNode> titleSuffixNodes = readp.read("suffix", "title");
            this.prefix = this.titlePrefix;
            this.titleSuffix = WebUtility.HtmlDecode(readp.getPropertyValue(titleSuffixNodes));
            this.suffix = this.titleSuffix;
            System.Collections.Generic.IEnumerator<XNode> formPriceNodes = readp.read("startprice", "format");
            this.formStartPrice = WebUtility.HtmlDecode(readp.getPropertyValue(formPriceNodes));
            System.Collections.Generic.IEnumerator<XNode> formQuantityNodes = readp.read("quantity", "format");
            this.formQuantity = WebUtility.HtmlDecode(readp.getPropertyValue(formQuantityNodes));
            System.Collections.Generic.IEnumerator<XNode> formLbsNodes = readp.read("lbs", "format");
            this.formLbs = WebUtility.HtmlDecode(readp.getPropertyValue(formLbsNodes));
            System.Collections.Generic.IEnumerator<XNode> formOzNodes = readp.read("oz", "format");
            this.formOz = WebUtility.HtmlDecode(readp.getPropertyValue(formOzNodes));
            System.Collections.Generic.IEnumerator<XNode> formDescriptionNodes = readp.read("description", "format");
            this.formDescription = WebUtility.HtmlDecode(readp.getPropertyValue(formDescriptionNodes));
            System.Collections.Generic.IEnumerator<XNode> formTitleNodes = readp.read("title", "format");
            this.formTitle = WebUtility.HtmlDecode(readp.getPropertyValue(formTitleNodes));
            System.Collections.Generic.IEnumerator<XNode> formSkuNodes = readp.read("sku", "format");
            this.formSku = WebUtility.HtmlDecode(readp.getPropertyValue(formSkuNodes));
            System.Collections.Generic.IEnumerator<XNode> formSizeNodes = readp.read("size", "format");
            this.formSize = WebUtility.HtmlDecode(readp.getPropertyValue(formSizeNodes));
            System.Collections.Generic.IEnumerator<XNode> formColorNodes = readp.read("color", "format");
            this.formColor = WebUtility.HtmlDecode(readp.getPropertyValue(formColorNodes));
            System.Collections.Generic.IEnumerator<XNode> formModelNodes = readp.read("model", "format");
            this.formModel = WebUtility.HtmlDecode(readp.getPropertyValue(formModelNodes));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.token = this.logon();
            if (this.fetched)
            {
                Form1.apiContext.ApiCredential.eBayToken = this.token;
                this.country = this.getCountry();
                Form1.apiContext.Site = this.country;
            }
        }

        private string logon()
        {
            string result;
            try
            {
                signin sign = new signin(Form1.apiContext);
                sign.ShowDialog();
                this.fetched = sign.fetched;
                if (this.fetched)
                {
                    this.userID = sign.userID;
                    this.outBtn.Enabled = true;
                    this.button2.Enabled = false;
                    this.button2.Text = "Logged on";
                    result = sign.token;
                }
                else
                {
                    result = null;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
                result = null;
            }
            return result;
        }

        private SiteCodeType getCountry()
        {
            SiteCodeType result;
            try
            {
                GetUserCall getUser = new GetUserCall(Form1.apiContext);
                getUser.Execute();
                result = getUser.ApiResponse.User.Site;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
                result = SiteCodeType.US;
            }
            return result;
        }

        private void outBtn_Click(object sender, EventArgs e)
        {
            this.logout();
        }

        private void logout()
		{
			try
			{
				RevokeTokenCall call = new RevokeTokenCall(Form1.apiContext);
				call.Execute();
				this.outBtn.Enabled = false;
				this.button2.Enabled = true;
				this.token = null;
				Form1.apiContext.ApiCredential.eBayToken = this.token;
				this.fetched = false;
				this.button2.Text = "Log in";
			}
			catch (System.Exception ex)
			{
				MessageBox.Show("ERROR: " + ex.Message);
			}
		}

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.fetched)
            {
                try
                {
                    RevokeTokenCall call = new RevokeTokenCall(Form1.apiContext);
                    call.Execute();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message);
                }
            }
        }
    }
}
