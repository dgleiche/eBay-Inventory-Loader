using System;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace CSV_Inventory_Bobby
{
    public partial class alert : Form
    {
        private AutoResetEvent _waitHandle = new AutoResetEvent(false);
        private bool yesclicked;
        public bool isChecked;
        private int elapsed = 30;
        private System.Timers.Timer timerClock = new System.Timers.Timer();
        public bool auto
        {
            get;
            set;
        }

        public alert()
        {
            InitializeComponent();
            this.auto = false;
            this.timerClock.Elapsed += new ElapsedEventHandler(OnTimer);
            this.timerClock.Interval = 1000.0;
            this.timerClock.Enabled = true;
        }

        public void OnTimer(object source, ElapsedEventArgs e)
        {
            this.elapsed--;
            Invoke(new MethodInvoker(setTimeTxt));
            if (this.elapsed <= 0)
            {
                this.auto = true;
                this.timerClock.Enabled = false;
                this._waitHandle.Set();
                base.Invoke(new MethodInvoker(close));
            }
        }

        private void setTimeTxt()
        {
            timeTxt.Text = this.elapsed.ToString();
        }

        private void close()
        {
            this.Close();
        }

        private void alert_Load(object sender, EventArgs e)
        {

        }

        public void Show(string text)
        {
            this.label1.Text = text;
            this.ShowDialog();
        }

        public bool Show(string text, bool yesno)
        {
            label1.Text = text;
            if (yesno)
            {
                button1.Text = "No";
                button2.Visible = true;
                button2.Text = "Yes";
            }
            this.ShowDialog();
            _waitHandle.WaitOne();
            return yesclicked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _waitHandle.Set();
            timerClock.Enabled = false;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yesclicked = true;
            _waitHandle.Set();
            timerClock.Enabled = false;
            this.Close();
        }

        private void againcheck_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                CheckBox check = sender as CheckBox;
                if (check.Checked)
                {
                    isChecked = true;
                    return;
                }
                isChecked = false;
            }
        }

        public bool getChecked()
        {
            return isChecked;
        }
    }
}
