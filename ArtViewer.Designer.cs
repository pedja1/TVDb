namespace TVDb
{
    partial class ArtViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArtViewer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.downloadBanners = new System.Windows.Forms.ToolStripDropDownButton();
            this.downloadPosters = new System.Windows.Forms.ToolStripDropDownButton();
            this.downloadFanarts = new System.Windows.Forms.ToolStripDropDownButton();
            this.save = new System.Windows.Forms.ToolStripDropDownButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imageListView1 = new Manina.Windows.Forms.ImageListView();
            this.saved = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadBanners,
            this.downloadPosters,
            this.downloadFanarts,
            this.save,
            this.saved});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(790, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // downloadBanners
            // 
            this.downloadBanners.Image = ((System.Drawing.Image)(resources.GetObject("downloadBanners.Image")));
            this.downloadBanners.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.downloadBanners.Name = "downloadBanners";
            this.downloadBanners.Size = new System.Drawing.Size(135, 22);
            this.downloadBanners.Text = "Download Banners";
            this.downloadBanners.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // downloadPosters
            // 
            this.downloadPosters.Image = ((System.Drawing.Image)(resources.GetObject("downloadPosters.Image")));
            this.downloadPosters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.downloadPosters.Name = "downloadPosters";
            this.downloadPosters.Size = new System.Drawing.Size(131, 22);
            this.downloadPosters.Text = "Download Posters";
            this.downloadPosters.Click += new System.EventHandler(this.toolStripDropDownButton2_Click);
            // 
            // downloadFanarts
            // 
            this.downloadFanarts.Image = ((System.Drawing.Image)(resources.GetObject("downloadFanarts.Image")));
            this.downloadFanarts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.downloadFanarts.Name = "downloadFanarts";
            this.downloadFanarts.Size = new System.Drawing.Size(131, 22);
            this.downloadFanarts.Text = "Download Fanarts";
            this.downloadFanarts.Click += new System.EventHandler(this.toolStripDropDownButton3_Click);
            // 
            // save
            // 
            this.save.Image = global::TVDb.Properties.Resources.blue_sd;
            this.save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(150, 22);
            this.save.Text = "Save Checked Images";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Click Download Banners, Download Posters or Download Fanarts to download more";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Downloaded Images are displayed below";
            // 
            // imageListView1
            // 
            this.imageListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageListView1.ColumnHeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.imageListView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imageListView1.GroupHeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.imageListView1.Location = new System.Drawing.Point(13, 54);
            this.imageListView1.MultiSelect = false;
            this.imageListView1.Name = "imageListView1";
            this.imageListView1.PersistentCacheFile = "";
            this.imageListView1.PersistentCacheSize = ((long)(100));
            this.imageListView1.Size = new System.Drawing.Size(765, 495);
            this.imageListView1.TabIndex = 0;
            this.imageListView1.ItemClick += new Manina.Windows.Forms.ItemClickEventHandler(this.imageListView1_ItemClick);
            // 
            // saved
            // 
            this.saved.Image = ((System.Drawing.Image)(resources.GetObject("saved.Image")));
            this.saved.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saved.Name = "saved";
            this.saved.Size = new System.Drawing.Size(136, 22);
            this.saved.Text = "View Saved Images";
            this.saved.Click += new System.EventHandler(this.saved_Click);
            // 
            // ArtViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.imageListView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ArtViewer";
            this.Text = "ArtViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArtViewer_FormClosing);
            this.Load += new System.EventHandler(this.ArtViewer_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Manina.Windows.Forms.ImageListView imageListView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton downloadBanners;
        private System.Windows.Forms.ToolStripDropDownButton downloadPosters;
        private System.Windows.Forms.ToolStripDropDownButton downloadFanarts;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripDropDownButton save;
        private System.Windows.Forms.ToolStripDropDownButton saved;

    }
}