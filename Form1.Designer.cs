namespace CSV_Inventory_Bobby
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.csvloader = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.filepreferences = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.imagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.autoBtn = new System.Windows.Forms.Button();
            this.fileopen = new System.Windows.Forms.ToolStripMenuItem();
            this.outBtn = new System.Windows.Forms.Button();
            this.totalitem = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.currentitem = new System.Windows.Forms.Label();
            this.menufile = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bWork = new System.ComponentModel.BackgroundWorker();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.csvbut = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // csvloader
            // 
            this.csvloader.Filter = "CSV Files (*.csv)|*.csv|Excel Files (*.xls)|*.xls|Text Files (*.txt)|*.txt|All Fi" +
                "les (*.*)|*.*";
            this.csvloader.Title = "CSV Datafeed Chooser";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(39, 278);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 23);
            this.button2.TabIndex = 27;
            this.button2.Text = "Log In";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // filepreferences
            // 
            this.filepreferences.Name = "filepreferences";
            this.filepreferences.Size = new System.Drawing.Size(143, 22);
            this.filepreferences.Text = "Preferences";
            this.filepreferences.Click += new System.EventHandler(this.filepreferences_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(163, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Fee for this Session:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(371, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imagesToolStripMenuItem
            // 
            this.imagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.toolStripMenuItem1});
            this.imagesToolStripMenuItem.Name = "imagesToolStripMenuItem";
            this.imagesToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.imagesToolStripMenuItem.Text = "Images";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.addToolStripMenuItem.Text = "Manually Add/Edit ";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(193, 22);
            this.toolStripMenuItem1.Text = "Automatically Add/Edit";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // autoBtn
            // 
            this.autoBtn.Location = new System.Drawing.Point(235, 278);
            this.autoBtn.Name = "autoBtn";
            this.autoBtn.Size = new System.Drawing.Size(123, 23);
            this.autoBtn.TabIndex = 23;
            this.autoBtn.Text = "Exit Auto Mode";
            this.autoBtn.UseVisualStyleBackColor = true;
            this.autoBtn.Click += new System.EventHandler(this.autoBtn_Click);
            // 
            // fileopen
            // 
            this.fileopen.Name = "fileopen";
            this.fileopen.Size = new System.Drawing.Size(143, 22);
            this.fileopen.Text = "Open";
            this.fileopen.Click += new System.EventHandler(this.fileopen_Click);
            // 
            // outBtn
            // 
            this.outBtn.Location = new System.Drawing.Point(141, 278);
            this.outBtn.Name = "outBtn";
            this.outBtn.Size = new System.Drawing.Size(75, 23);
            this.outBtn.TabIndex = 28;
            this.outBtn.Text = "Log Out";
            this.outBtn.UseVisualStyleBackColor = true;
            this.outBtn.Click += new System.EventHandler(this.outBtn_Click);
            // 
            // totalitem
            // 
            this.totalitem.AutoSize = true;
            this.totalitem.Location = new System.Drawing.Point(525, 247);
            this.totalitem.Name = "totalitem";
            this.totalitem.Size = new System.Drawing.Size(35, 13);
            this.totalitem.TabIndex = 21;
            this.totalitem.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(502, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "of";
            // 
            // currentitem
            // 
            this.currentitem.AutoSize = true;
            this.currentitem.Location = new System.Drawing.Point(463, 247);
            this.currentitem.Name = "currentitem";
            this.currentitem.Size = new System.Drawing.Size(35, 13);
            this.currentitem.TabIndex = 19;
            this.currentitem.Text = "label3";
            // 
            // menufile
            // 
            this.menufile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileopen,
            this.filepreferences});
            this.menufile.Name = "menufile";
            this.menufile.Size = new System.Drawing.Size(35, 20);
            this.menufile.Text = "File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Running Fee Amount:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "label1";
            // 
            // bWork
            // 
            this.bWork.WorkerSupportsCancellation = true;
            this.bWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWork_DoWork);
            this.bWork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bWork_RunWorkerCompleted);
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(222, 238);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(225, 23);
            this.pBar.Step = 1;
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBar.TabIndex = 18;
            // 
            // csvbut
            // 
            this.csvbut.Location = new System.Drawing.Point(39, 238);
            this.csvbut.Name = "csvbut";
            this.csvbut.Size = new System.Drawing.Size(90, 23);
            this.csvbut.TabIndex = 15;
            this.csvbut.Text = "Choose CSV ";
            this.csvbut.UseVisualStyleBackColor = true;
            this.csvbut.Click += new System.EventHandler(this.csvbut_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Azure;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menufile,
            this.imagesToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(591, 24);
            this.menu.TabIndex = 22;
            this.menu.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AcceptButton = this.csvbut;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 313);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.autoBtn);
            this.Controls.Add(this.outBtn);
            this.Controls.Add(this.totalitem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.currentitem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.csvbut);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "Form1";
            this.Text = "DIG Productions CSV Inventory Loader for Bobby";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog csvloader;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem filepreferences;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem imagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button autoBtn;
        private System.Windows.Forms.ToolStripMenuItem fileopen;
        private System.Windows.Forms.Button outBtn;
        private System.Windows.Forms.Label totalitem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label currentitem;
        private System.Windows.Forms.ToolStripMenuItem menufile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker bWork;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Button csvbut;
        private System.Windows.Forms.MenuStrip menu;
    }
}

