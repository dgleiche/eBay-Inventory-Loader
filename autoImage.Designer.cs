namespace CSV_Inventory_Bobby
{
    partial class autoImage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(autoImage));
            this.okBtn = new System.Windows.Forms.Button();
            this.progressTxt = new System.Windows.Forms.Label();
            this.bWork = new System.ComponentModel.BackgroundWorker();
            this.bWork2 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bWork3 = new System.ComponentModel.BackgroundWorker();
            this.addBtn = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.rmvbtn = new System.Windows.Forms.Button();
            this.browseBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dirTxt = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(254, 281);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 30;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // progressTxt
            // 
            this.progressTxt.AutoSize = true;
            this.progressTxt.Location = new System.Drawing.Point(98, 96);
            this.progressTxt.Name = "progressTxt";
            this.progressTxt.Size = new System.Drawing.Size(0, 13);
            this.progressTxt.TabIndex = 28;
            // 
            // bWork
            // 
            this.bWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWork_DoWork);
            // 
            // bWork2
            // 
            this.bWork2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWork2_DoWork);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(334, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(17, 115);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(215, 23);
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBar.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "The file name will be assumed the model number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "This will add all the eBay accepted images in the directory.";
            // 
            // bWork3
            // 
            this.bWork3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWork3_DoWork);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(168, 231);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 24;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Directory";
            // 
            // rmvbtn
            // 
            this.rmvbtn.Location = new System.Drawing.Point(418, 281);
            this.rmvbtn.Name = "rmvbtn";
            this.rmvbtn.Size = new System.Drawing.Size(75, 23);
            this.rmvbtn.TabIndex = 22;
            this.rmvbtn.Text = "Remove Image";
            this.rmvbtn.UseVisualStyleBackColor = true;
            this.rmvbtn.Click += new System.EventHandler(this.rmvbtn_Click);
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(168, 265);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 21;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // dirTxt
            // 
            this.dirTxt.Location = new System.Drawing.Point(17, 266);
            this.dirTxt.Name = "dirTxt";
            this.dirTxt.Size = new System.Drawing.Size(141, 20);
            this.dirTxt.TabIndex = 20;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(269, 47);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(225, 225);
            this.listView1.SmallImageList = this.imageList;
            this.listView1.StateImageList = this.imageList;
            this.listView1.TabIndex = 19;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(329, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 18;
            this.label1.Text = "Images";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // autoImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 314);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.progressTxt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rmvbtn);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.dirTxt);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "autoImage";
            this.Text = "Auto Image";
            this.Load += new System.EventHandler(this.autoImage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label progressTxt;
        private System.ComponentModel.BackgroundWorker bWork;
        private System.ComponentModel.BackgroundWorker bWork2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker bWork3;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button rmvbtn;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox dirTxt;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
    }
}