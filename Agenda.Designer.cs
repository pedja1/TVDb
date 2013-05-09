namespace TVDb
{
    partial class Agenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Agenda));
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.olvColumn1);
            this.objectListView1.AllColumns.Add(this.olvColumn2);
            this.objectListView1.AllColumns.Add(this.olvColumn3);
            this.objectListView1.AllColumns.Add(this.olvColumn6);
            this.objectListView1.AllColumns.Add(this.olvColumn4);
            this.objectListView1.AllColumns.Add(this.olvColumn5);
            this.objectListView1.AllColumns.Add(this.olvColumn7);
            this.objectListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn6,
            this.olvColumn4,
            this.olvColumn5,
            this.olvColumn7});
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.Location = new System.Drawing.Point(13, 13);
            this.objectListView1.MultiSelect = false;
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(522, 352);
            this.objectListView1.TabIndex = 0;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.DoubleClick += new System.EventHandler(this.objectListView1_DoubleClick);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "seriesName";
            this.olvColumn1.CellPadding = null;
            this.olvColumn1.Text = "Series Name";
            this.olvColumn1.Width = 104;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "episodeName";
            this.olvColumn2.CellPadding = null;
            this.olvColumn2.Groupable = false;
            this.olvColumn2.Sortable = false;
            this.olvColumn2.Text = "Episode Name";
            this.olvColumn2.Width = 101;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "episode";
            this.olvColumn3.CellPadding = null;
            this.olvColumn3.Groupable = false;
            this.olvColumn3.Sortable = false;
            this.olvColumn3.Text = "Episode";
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "season";
            this.olvColumn6.CellPadding = null;
            this.olvColumn6.Groupable = false;
            this.olvColumn6.Sortable = false;
            this.olvColumn6.Text = "Season";
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "airs";
            this.olvColumn4.CellPadding = null;
            this.olvColumn4.Groupable = false;
            this.olvColumn4.Sortable = false;
            this.olvColumn4.Text = "Airs";
            this.olvColumn4.Width = 93;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "episodeId";
            this.olvColumn5.CellPadding = null;
            this.olvColumn5.Groupable = false;
            this.olvColumn5.Sortable = false;
            this.olvColumn5.Text = "Episode ID";
            // 
            // olvColumn7
            // 
            this.olvColumn7.AspectName = "seriesId";
            this.olvColumn7.CellPadding = null;
            this.olvColumn7.Groupable = false;
            this.olvColumn7.Sortable = false;
            this.olvColumn7.Text = "Series Id";
            // 
            // Agenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 377);
            this.Controls.Add(this.objectListView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Agenda";
            this.Text = "Agenda";
            this.Load += new System.EventHandler(this.Agenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private BrightIdeasSoftware.OLVColumn olvColumn7;
    }
}