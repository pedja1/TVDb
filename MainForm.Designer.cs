namespace TVDb
{
    partial class MainForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("No Shows");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.searchBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.showsList = new System.Windows.Forms.ListView();
            this.seriesName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.firstAired = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.network = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rating = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.runtime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hideFromListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ignoreInAgendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.markAll = new System.Windows.Forms.ToolStripMenuItem();
            this.markAllSeason = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.overview = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wipeDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upcomingEpisodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateAllShowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.banner = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.banner)).BeginInit();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Location = new System.Drawing.Point(537, 14);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(288, 20);
            this.searchBox.TabIndex = 1;
            this.searchBox.Text = "Search TV Shows";
            this.searchBox.Click += new System.EventHandler(this.searchBox_Click_1);
            this.searchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckKeys);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 41);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(842, 474);
            this.splitContainer1.SplitterDistance = 425;
            this.splitContainer1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.showsList);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 467);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TV Shows";
            // 
            // showsList
            // 
            this.showsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.showsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.seriesName,
            this.firstAired,
            this.network,
            this.rating,
            this.status,
            this.runtime});
            this.showsList.ContextMenuStrip = this.contextMenuStrip1;
            this.showsList.FullRowSelect = true;
            this.showsList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.showsList.Location = new System.Drawing.Point(7, 19);
            this.showsList.MultiSelect = false;
            this.showsList.Name = "showsList";
            this.showsList.Size = new System.Drawing.Size(405, 442);
            this.showsList.TabIndex = 0;
            this.showsList.UseCompatibleStateImageBehavior = false;
            this.showsList.View = System.Windows.Forms.View.Details;
            this.showsList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.showsList_ColumnClick);
            this.showsList.SelectedIndexChanged += new System.EventHandler(this.showsList_SelectedIndexChanged);
            // 
            // seriesName
            // 
            this.seriesName.Text = "Series Name";
            // 
            // firstAired
            // 
            this.firstAired.Text = "First Aired";
            // 
            // network
            // 
            this.network.Text = "Network";
            // 
            // rating
            // 
            this.rating.Text = "Rating";
            // 
            // status
            // 
            this.status.Text = "Status";
            // 
            // runtime
            // 
            this.runtime.Text = "Runtime";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.hideFromListToolStripMenuItem,
            this.ignoreInAgendaToolStripMenuItem,
            this.posterToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(234, 114);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // hideFromListToolStripMenuItem
            // 
            this.hideFromListToolStripMenuItem.Name = "hideFromListToolStripMenuItem";
            this.hideFromListToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.hideFromListToolStripMenuItem.Text = "Hide From List";
            this.hideFromListToolStripMenuItem.Click += new System.EventHandler(this.hideFromListToolStripMenuItem_Click);
            // 
            // ignoreInAgendaToolStripMenuItem
            // 
            this.ignoreInAgendaToolStripMenuItem.Name = "ignoreInAgendaToolStripMenuItem";
            this.ignoreInAgendaToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.ignoreInAgendaToolStripMenuItem.Text = "Ignore In Agenda";
            this.ignoreInAgendaToolStripMenuItem.Click += new System.EventHandler(this.ignoreInAgendaToolStripMenuItem_Click);
            // 
            // posterToolStripMenuItem
            // 
            this.posterToolStripMenuItem.Name = "posterToolStripMenuItem";
            this.posterToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.posterToolStripMenuItem.Text = "Arts(Banners, Posters, Fanarts)";
            this.posterToolStripMenuItem.Click += new System.EventHandler(this.posterToolStripMenuItem_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Size = new System.Drawing.Size(413, 474);
            this.splitContainer2.SplitterDistance = 286;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.objectListView1);
            this.groupBox2.Location = new System.Drawing.Point(4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 279);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Episodes";
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.olvColumn2);
            this.objectListView1.AllColumns.Add(this.olvColumn4);
            this.objectListView1.AllColumns.Add(this.olvColumn1);
            this.objectListView1.AllColumns.Add(this.olvColumn3);
            this.objectListView1.AllColumns.Add(this.olvColumn5);
            this.objectListView1.AllColumns.Add(this.olvColumn6);
            this.objectListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListView1.CheckBoxes = true;
            this.objectListView1.CheckedAspectName = "Watched";
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn2,
            this.olvColumn4,
            this.olvColumn1,
            this.olvColumn3,
            this.olvColumn5,
            this.olvColumn6});
            this.objectListView1.ContextMenuStrip = this.contextMenuStrip2;
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.Location = new System.Drawing.Point(6, 19);
            this.objectListView1.MultiSelect = false;
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.ShowGroups = false;
            this.objectListView1.Size = new System.Drawing.Size(394, 254);
            this.objectListView1.TabIndex = 3;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.objectListView1_ItemCheck_1);
            this.objectListView1.DoubleClick += new System.EventHandler(this.objectListView1_DoubleClick);
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "EpisodeName";
            this.olvColumn2.CellPadding = null;
            this.olvColumn2.CheckBoxes = true;
            this.olvColumn2.Sortable = false;
            this.olvColumn2.Text = "Episode Name";
            this.olvColumn2.UseInitialLetterForGroup = true;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "Season";
            this.olvColumn4.CellPadding = null;
            this.olvColumn4.DisplayIndex = 3;
            this.olvColumn4.Sortable = false;
            this.olvColumn4.Text = "Season";
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Episode";
            this.olvColumn1.CellPadding = null;
            this.olvColumn1.Sortable = false;
            this.olvColumn1.Text = "Episode";
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "FirstAired";
            this.olvColumn3.CellPadding = null;
            this.olvColumn3.DisplayIndex = 1;
            this.olvColumn3.Sortable = false;
            this.olvColumn3.Text = "Aired";
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "Rating";
            this.olvColumn5.CellPadding = null;
            this.olvColumn5.Sortable = false;
            this.olvColumn5.Text = "Rating";
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "EpisodeId";
            this.olvColumn6.CellPadding = null;
            this.olvColumn6.Sortable = false;
            this.olvColumn6.Text = "Episode ID";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markAll,
            this.markAllSeason});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(214, 48);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            // 
            // markAll
            // 
            this.markAll.Name = "markAll";
            this.markAll.Size = new System.Drawing.Size(213, 22);
            this.markAll.Text = "Mark All Watched";
            this.markAll.Click += new System.EventHandler(this.markAll_Click);
            // 
            // markAllSeason
            // 
            this.markAllSeason.Name = "markAllSeason";
            this.markAllSeason.Size = new System.Drawing.Size(213, 22);
            this.markAllSeason.Text = "Mark All Watched(Season)";
            this.markAllSeason.Click += new System.EventHandler(this.markAllSeason_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.overview);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.banner);
            this.groupBox3.Location = new System.Drawing.Point(4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(406, 177);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Details";
            // 
            // overview
            // 
            this.overview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.overview.Location = new System.Drawing.Point(10, 119);
            this.overview.Name = "overview";
            this.overview.Size = new System.Drawing.Size(390, 52);
            this.overview.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Overview";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(866, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "SQLite Database(\"*.db\")|*.db";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "tvdb.db";
            this.openFileDialog1.Filter = "SQLite Database(\"*.db\")|*.db";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(831, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wipeDatabaseToolStripMenuItem,
            this.backupDatabaseToolStripMenuItem,
            this.restoreDatabaseToolStripMenuItem});
            this.fileToolStripMenuItem.Image = global::TVDb.Properties.Resources.shortcut_folder;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // wipeDatabaseToolStripMenuItem
            // 
            this.wipeDatabaseToolStripMenuItem.Image = global::TVDb.Properties.Resources.clear;
            this.wipeDatabaseToolStripMenuItem.Name = "wipeDatabaseToolStripMenuItem";
            this.wipeDatabaseToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.wipeDatabaseToolStripMenuItem.Text = "Wipe Database";
            this.wipeDatabaseToolStripMenuItem.Click += new System.EventHandler(this.wipeDatabaseToolStripMenuItem_Click);
            // 
            // backupDatabaseToolStripMenuItem
            // 
            this.backupDatabaseToolStripMenuItem.Image = global::TVDb.Properties.Resources.backup;
            this.backupDatabaseToolStripMenuItem.Name = "backupDatabaseToolStripMenuItem";
            this.backupDatabaseToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.backupDatabaseToolStripMenuItem.Text = "Backup Database";
            this.backupDatabaseToolStripMenuItem.Click += new System.EventHandler(this.backupDatabaseToolStripMenuItem_Click);
            // 
            // restoreDatabaseToolStripMenuItem
            // 
            this.restoreDatabaseToolStripMenuItem.Image = global::TVDb.Properties.Resources.restore;
            this.restoreDatabaseToolStripMenuItem.Name = "restoreDatabaseToolStripMenuItem";
            this.restoreDatabaseToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.restoreDatabaseToolStripMenuItem.Text = "Restore Database";
            this.restoreDatabaseToolStripMenuItem.Click += new System.EventHandler(this.restoreDatabaseToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.upcomingEpisodesToolStripMenuItem,
            this.updateAllShowsToolStripMenuItem});
            this.toolsToolStripMenuItem.Image = global::TVDb.Properties.Resources.shortcut_appdrawer;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::TVDb.Properties.Resources.settings;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // upcomingEpisodesToolStripMenuItem
            // 
            this.upcomingEpisodesToolStripMenuItem.Name = "upcomingEpisodesToolStripMenuItem";
            this.upcomingEpisodesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.upcomingEpisodesToolStripMenuItem.Text = "Agenda";
            this.upcomingEpisodesToolStripMenuItem.Click += new System.EventHandler(this.upcomingEpisodesToolStripMenuItem_Click);
            // 
            // updateAllShowsToolStripMenuItem
            // 
            this.updateAllShowsToolStripMenuItem.Name = "updateAllShowsToolStripMenuItem";
            this.updateAllShowsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.updateAllShowsToolStripMenuItem.Text = "Update All Shows";
            this.updateAllShowsToolStripMenuItem.Click += new System.EventHandler(this.updateAllShowsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Image = global::TVDb.Properties.Resources.help;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::TVDb.Properties.Resources.info;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::TVDb.Properties.Resources.exclude_active;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Image = global::TVDb.Properties.Resources.reload;
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // banner
            // 
            this.banner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.banner.Cursor = System.Windows.Forms.Cursors.Default;
            this.banner.InitialImage = null;
            this.banner.Location = new System.Drawing.Point(7, 20);
            this.banner.Name = "banner";
            this.banner.Size = new System.Drawing.Size(393, 74);
            this.banner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.banner.TabIndex = 0;
            this.banner.TabStop = false;
            this.banner.Click += new System.EventHandler(this.banner_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 527);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "TVDb";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.banner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView showsList;
        private System.Windows.Forms.ColumnHeader seriesName;
        private System.Windows.Forms.ColumnHeader firstAired;
        private System.Windows.Forms.ColumnHeader network;
        private System.Windows.Forms.ColumnHeader rating;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.PictureBox banner;
        private System.Windows.Forms.ColumnHeader runtime;
        private System.Windows.Forms.Label overview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private System.Windows.Forms.ToolStripMenuItem posterToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wipeDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upcomingEpisodesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem markAll;
        private System.Windows.Forms.ToolStripMenuItem markAllSeason;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem hideFromListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ignoreInAgendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateAllShowsToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

