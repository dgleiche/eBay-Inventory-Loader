using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CSV_Inventory_Bobby
{
    public partial class signin : Form
    {
        private ApiContext apiContext;
        private string sess;
        private string sesswo;
        public string token
        {
            get;
            set;
        }
        public bool fetched
        {
            get;
            set;
        }
        public string userID
        {
            get;
            set;
        }
        public signin(ApiContext context)
        {
            InitializeComponent();
            this.apiContext = context;
        }

        private void signin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.apiContext.RuName = "CONFIDENTIAL";
            GetSessionIDCall call = new GetSessionIDCall(this.apiContext);
            call.ApiRequest = new GetSessionIDRequestType
            {
                Version = "557",
                RuName = "CONFIDENTIAL"
            };
            call.Execute();
            GetSessionIDResponseType response = new GetSessionIDResponseType();
            response = call.ApiResponse;
            string session = Uri.EscapeUriString(response.SessionID);
            this.sess = session;
            this.sesswo = response.SessionID;
            string sUrl = "https://signin.ebay.com/ws/eBayISAPI.dll?SignIn&runame=CONFIDENTIAL&sessid=" + this.sess;
            ProcessStartInfo startInfo = new ProcessStartInfo("IExplore.exe", sUrl);
            Process.Start(startInfo);
            this.statusTxt.Text = "Ready";
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void grantBtn_Click(object sender, EventArgs e)
        {
            FetchTokenCall fetch = new FetchTokenCall(this.apiContext);
            fetch.ApiRequest = new FetchTokenRequestType
            {
                Version = "613",
                SessionID = this.sesswo
            };
            fetch.Execute();
            FetchTokenResponseType fresponse = new FetchTokenResponseType();
            fresponse = fetch.ApiResponse;
            this.token = fresponse.eBayAuthToken;
            this.fetched = true;
            this.userID = fresponse.RecipientUserID;
            base.Close();
        }
    }
}
