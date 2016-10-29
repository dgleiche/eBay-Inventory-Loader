namespace CSV_Inventory_Bobby
{
    partial class images
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(images));
            this.bWork3 = new System.ComponentModel.BackgroundWorker();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.bWork2 = new System.ComponentModel.BackgroundWorker();
            this.progressTxt = new System.Windows.Forms.Label();
            this.bWork = new System.ComponentModel.BackgroundWorker();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.rmvbtn = new System.Windows.Forms.Button();
            this.addbtn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // bWork3
            // 
            this.bWork3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWork3_DoWork);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(149, 199);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 25;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // bWork2
            // 
            this.bWork2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWork2_DoWork);
            // 
            // progressTxt
            // 
            this.progressTxt.AutoSize = true;
            this.progressTxt.Location = new System.Drawing.Point(112, 122);
            this.progressTxt.Name = "progressTxt";
            this.progressTxt.Size = new System.Drawing.Size(38, 13);
            this.progressTxt.TabIndex = 24;
            this.progressTxt.Text = "Ready";
            // 
            // bWork
            // 
            this.bWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWork_DoWork);
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(27, 141);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(215, 23);
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBar.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(341, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 22;
            this.label1.Text = "Images";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(38, 199);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 21;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // rmvbtn
            // 
            this.rmvbtn.Location = new System.Drawing.Point(149, 252);
            this.rmvbtn.Name = "rmvbtn";
            this.rmvbtn.Size = new System.Drawing.Size(75, 23);
            this.rmvbtn.TabIndex = 20;
            this.rmvbtn.Text = "Remove Image";
            this.rmvbtn.UseVisualStyleBackColor = true;
            this.rmvbtn.Click += new System.EventHandler(this.rmvbtn_Click);
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(38, 252);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(75, 23);
            this.addbtn.TabIndex = 19;
            this.addbtn.Text = "Add";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // listView1
            // 
            this.listView1.LargeImageList = this.imageList;
            this.listView1.Location = new System.Drawing.Point(275, 50);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(225, 225);
            this.listView1.SmallImageList = this.imageList;
            this.listView1.TabIndex = 18;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // images
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 292);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.progressTxt);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.rmvbtn);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "images";
            this.Text = "Manually Add/Edit Images";
            this.Load += new System.EventHandler(this.images_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bWork3;
        private System.Windows.Forms.Button cancelBtn;
        private System.ComponentModel.BackgroundWorker bWork2;
        private System.Windows.Forms.Label progressTxt;
        private System.ComponentModel.BackgroundWorker bWork;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button rmvbtn;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList;
    }
}