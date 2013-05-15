using BrightIdeasSoftware;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using TVDb.Properties;

namespace TVDb
{
    public partial class MainForm : Form
    {
        private readonly ListViewColumnSorter _lvwColumnSorter;
        SqLiteDatabase _db;
        AlertDialog _alert;
        public MainForm()
        {
            InitializeComponent();
            olvColumn2.Width = Properties.Settings.Default.EpisodeListEpisodeNameColumnWidth;
            olvColumn4.Width = Properties.Settings.Default.EpisodeListSeasonColumnWidth;
            olvColumn1.Width = Properties.Settings.Default.EpisodeListEpisodeNumberColumnWidth;
            olvColumn3.Width = Properties.Settings.Default.EpisodeListAiredColumnWidth;
            olvColumn5.Width = Properties.Settings.Default.EpisodeListRatingColumnWidth;
            olvColumn6.Width = Properties.Settings.Default.EpisodeListEpisodeIdColumnWidth;
            seriesName.Width = Properties.Settings.Default.ShowsListSeriesNameColumnWidth;
            firstAired.Width = Properties.Settings.Default.ShowsListFirstAiredColumnWidth;
            network.Width = Properties.Settings.Default.ShowsListNetworkColumnWidth;
            rating.Width = Properties.Settings.Default.ShowsListRatingColumnWidth;
            status.Width = Properties.Settings.Default.ShowsListStatusColumnWidth;
            runtime.Width = Properties.Settings.Default.ShowsListRuntimeColumnWidth;
            _lvwColumnSorter = new ListViewColumnSorter();
            showsList.ListViewItemSorter = _lvwColumnSorter;
        }


        private void CheckKeys(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Search();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            Cursor = Cursors.WaitCursor;
            var searchForm = new SearchResultsListForm(this, searchBox.Text);
            searchForm.ShowDialog();
            searchBox.Text = "";
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            _db = new SqLiteDatabase();
            if (File.Exists(@"tvdb.db"))
            {
                UpdateShowList();
            }
            else 
            {
                CreateDatabase();
            }
            CheckUpdate(); 

        }

        /*private class ShowsForUpdate
        {
            public string name {get; set;}
            public string id {get; set;}
        }*/

        private void CheckUpdate()
        {
            const string query = "SELECT * FROM series";
            DataTable dt = _db.GetDataTable(query);
            var shows = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drow = dt.Rows[i];
                 DateTime date;
                 if (DateTime.TryParse(drow["updated"].ToString(), out date))
                 {
                     if ((DateTime.Now - DateTime.Parse(drow["updated"].ToString())).Days > 15)
                         shows.Add(drow["series_name"].ToString());
                 }
            }
            if(shows.Count > 0){
                var b = new StringBuilder();
                for (int i = 0; i < shows.Count; i++ )
                {
                    if (i != shows.Count - 1)
                        b.Append(shows[i] + ", ");
                    else
                        b.Append(shows[i]);
                }
                MessageBox.Show("Following Shows havent been updated for more than 15 days:\n"+b.ToString());
            }

        }

        private void CreateDatabase()
        {
            const string createTable = "CREATE TABLE series (_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, series_name TEXT, series_id INTEGER, language TEXT, banner_local TEXT, network TEXT, first_aired TEXT, imdb_id TEXT, banner_url TEXT, overview TEXT, rating DOUBLE, runtime INTEGER, status TEXT, fanart_url TEXT, fanart_local TEXT, poster_url TEXT, poster_local TEXT)";
            try
                {
                    _db.CreateTable(createTable);
                }
                catch (Exception crap)
                {
                    MessageBox.Show(crap.Message);
                }
        }

        public void UpdateShowList() {
            const string query = "SELECT * FROM series";
            DataTable dt = _db.GetDataTable(query);

            showsList.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drow = dt.Rows[i];

                // Only row that have not been deleted
                if (drow.RowState != DataRowState.Deleted)
                {
                    // Define the list items
                    var lvi = new ListViewItem(drow["series_name"].ToString());

                    lvi.SubItems.Add(drow["first_aired"].ToString());
                    lvi.SubItems.Add(drow["network"].ToString());
                    lvi.SubItems.Add(drow["rating"].ToString());
                    lvi.SubItems.Add(drow["status"].ToString());
                    lvi.SubItems.Add(drow["runtime"].ToString());
                    lvi.SubItems.Add(drow["series_id"].ToString());


                    // Add the list items to the ListView
                    if (Properties.Settings.Default.ShowsToDisplay == "Ended" && drow["status"].ToString() == "Ended")
                    {
                        if(drow["hide_from_list"].ToString() == "False" || Properties.Settings.Default.ShowHidden)
                        showsList.Items.Add(lvi);
                    }
                    else if (Properties.Settings.Default.ShowsToDisplay == "Continuing" && drow["status"].ToString() == "Continuing")
                    {
                        if (drow["hide_from_list"].ToString() == "False" || Properties.Settings.Default.ShowHidden)
                        showsList.Items.Add(lvi);
                    }
                    else if (Properties.Settings.Default.ShowsToDisplay == "All")
                    {
                        if (drow["hide_from_list"].ToString() == "False" || Properties.Settings.Default.ShowHidden)
                        showsList.Items.Add(lvi);
                    }
                    
                }
            }
            if(showsList.Items.Count > 0){
            showsList.Items[0].Selected = true;
            }
        }

        public void UpdateEpisodesList(string tableName)
        {
            String query = "SELECT * FROM " + tableName;
            DataTable dt = _db.GetDataTable(query);
            var e = new List<EpisodeListEntry>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drow = dt.Rows[i];
                if(drow["season"].ToString() != "0"){
                e.Add(new EpisodeListEntry(drow["episode_name"].ToString(), int.Parse(drow["episode"].ToString()), int.Parse(drow["season"].ToString()), double.Parse(drow["rating"].ToString()), drow["first_aired"].ToString(), bool.Parse(drow["watched"].ToString()), int.Parse(drow["episode_id"].ToString())));
                }
            }
            e.Reverse();
            objectListView1.SetObjects(e);
        }
        
        private void showsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (showsList.SelectedItems.Count > 0)
            {
                string query = "SELECT * FROM series WHERE series_name = \""+showsList.SelectedItems[0].SubItems[0].Text+"\"";
                DataTable dt = _db.GetDataTable(query);
                DataRow drow = dt.Rows[0];
                overview.Text = drow["overview"].ToString();
                try
                {
                    banner.Image = Image.FromFile(drow["banner_local"].ToString());
                }
                catch(Exception exc){
                    banner.Image = Resources.icon1;
                    Console.WriteLine(exc.Message);
                }
                UpdateEpisodesList("episodes_"+showsList.SelectedItems[0].SubItems[6].Text);
            }
        }


        private void showsList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == _lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                _lvwColumnSorter.Order = _lvwColumnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                _lvwColumnSorter.SortColumn = e.Column;
                _lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            showsList.Sort();
        }

        

        private void searchBox_Click_1(object sender, EventArgs e)
        {
            
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Delete")
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure?","", MessageBoxButtons.YesNo))
                {
                    
                    try
                    {
                        _db.Delete("series", "series_id=" + showsList.SelectedItems[0].SubItems[6].Text);
                        _db.ExecuteNonQuery("DROP TABLE IF EXISTS episodes_" + showsList.SelectedItems[0].SubItems[6].Text);
                        _db.ExecuteNonQuery("DROP TABLE IF EXISTS arts_" + showsList.SelectedItems[0].SubItems[6].Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    UpdateShowList();
                }
                
            }
            
            
              

        }

        private int getCheckedStatus(ItemCheckEventArgs e)
        {
            if (e.NewValue.ToString() == "Checked")
            {
                return 1;
            }
            return 0;
        }

        private void objectListView1_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            int chk = getCheckedStatus(e);

            try
            {
                _db.ExecuteNonQuery("UPDATE episodes_" + showsList.SelectedItems[0].SubItems[6].Text + " SET watched=" + chk + " WHERE episode_id=" + objectListView1.Items[e.Index].SubItems[5].Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void wipeDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show( "Delete All Items From Database?", "Are you sure?", MessageBoxButtons.YesNo))
            {
                if (DialogResult.Yes == MessageBox.Show("Delete All Items From Database?\nThis cannot be undone!", "Are you 100% sure?", MessageBoxButtons.YesNo))
                {
                    Cursor = Cursors.WaitCursor;
                    MessageBox.Show(_db.ClearDb()
                                        ? "Database Cleared Successfuly"
                                        : "Something Went Wrong\nDatabase might be corupted!");
                    UpdateShowList();
                   Cursor = Cursors.Default;
                }
            }
        }

        

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Settings(this).ShowDialog();
        }

        

        

        private void posterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var art = new ArtViewer(showsList.SelectedItems[0].SubItems[6].Text, showsList.SelectedItems[0].Text);
            art.Show();
        }

        private void objectListView1_DoubleClick(object sender, EventArgs e)
        {
            var query = "SELECT * FROM episodes_" + showsList.SelectedItems[0].SubItems[6].Text + " WHERE episode_id=" + objectListView1.SelectedItems[0].SubItems[5].Text;
            var dt = _db.GetDataTable(query);
            var drow = dt.Rows[0];
            MessageBox.Show(drow["overview"].ToString());
            
        }

        private void banner_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            markAll.Text = "Mark all watched";
            markAllSeason.Text = "Mark all watched in "+objectListView1.SelectedItems[0].SubItems[1].Text+". season";
        }

        private void markAll_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            objectListView1.CheckedObjectsEnumerable = objectListView1.Objects;
            Cursor = Cursors.Default;
        }

        private void markAllSeason_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            foreach (var olvi in objectListView1.Items.Cast<OLVListItem>().Where(olvi => olvi.SubItems[1].Text == objectListView1.SelectedItems[0].SubItems[1].Text))
            {
                olvi.Checked = true;
            }
            Cursor = Cursors.Default;
      }

        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "tvdb.db";
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            File.Copy(@"tvdb.db", saveFileDialog1.FileName);
        }

        private void restoreDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("This will overwrite curent database file!\nContinue?", "Restore Database?", MessageBoxButtons.YesNo))
            {
                File.Copy(openFileDialog1.FileName, @"tvdb.db", true);
                UpdateShowList();
            }
        }

        private void upcomingEpisodesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Cursor = Cursors.WaitCursor;
            new Agenda(this).Show();
        }

        private void hideFromListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var query = "SELECT * FROM series WHERE series_id=" + showsList.SelectedItems[0].SubItems[6].Text;
            var dt = _db.GetDataTable(query);
            var drow = dt.Rows[0];
            try
            {
                if (drow["hide_from_list"].ToString() == "False")
                    _db.ExecuteNonQuery("UPDATE series SET hide_from_list=1 WHERE series_id=" + showsList.SelectedItems[0].SubItems[6].Text);
                else
                    _db.ExecuteNonQuery("UPDATE series SET hide_from_list=0 WHERE series_id=" + showsList.SelectedItems[0].SubItems[6].Text);
                
                UpdateShowList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            var query = "SELECT * FROM series WHERE series_id=" + showsList.SelectedItems[0].SubItems[6].Text;
            var dt = _db.GetDataTable(query);
            var drow = dt.Rows[0];
            hideFromListToolStripMenuItem.Text = drow["hide_from_list"].ToString() == "False" ? "Hide From List" : "Show in List";

            ignoreInAgendaToolStripMenuItem.Text = drow["ignore_agenda"].ToString() == "False" ? "Exclude from Agenda" : "Include in Agenda";
            
        }

        private void ignoreInAgendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var query = "SELECT * FROM series WHERE series_id=" + showsList.SelectedItems[0].SubItems[6].Text;
            var dt = _db.GetDataTable(query);
            var drow = dt.Rows[0];
            try
            {
                if (drow["hide_from_list"].ToString() == "False")
                    _db.ExecuteNonQuery("UPDATE series SET ignore_agenda=1 WHERE series_id=" + showsList.SelectedItems[0].SubItems[6].Text);
                else
                    _db.ExecuteNonQuery("UPDATE series SET ignore_agenda=0 WHERE series_id=" + showsList.SelectedItems[0].SubItems[6].Text);
                
                UpdateShowList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
                Properties.Settings.Default.ShowsListSeriesNameColumnWidth = seriesName.Width;
                Properties.Settings.Default.ShowsListFirstAiredColumnWidth = firstAired.Width;
                Properties.Settings.Default.ShowsListNetworkColumnWidth = network.Width;
                Properties.Settings.Default.ShowsListRatingColumnWidth = rating.Width;
                Properties.Settings.Default.ShowsListStatusColumnWidth = status.Width;
                Properties.Settings.Default.ShowsListRuntimeColumnWidth = runtime.Width;
                Properties.Settings.Default.EpisodeListEpisodeNameColumnWidth = olvColumn2.Width;
                Properties.Settings.Default.EpisodeListSeasonColumnWidth = olvColumn4.Width;
                Properties.Settings.Default.EpisodeListEpisodeNumberColumnWidth = olvColumn1.Width;
                Properties.Settings.Default.EpisodeListAiredColumnWidth = olvColumn3.Width;
                Properties.Settings.Default.EpisodeListRatingColumnWidth = olvColumn5.Width;
                Properties.Settings.Default.EpisodeListEpisodeIdColumnWidth = olvColumn6.Width;
                Properties.Settings.Default.Save();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            UpdateShows(showsList.SelectedItems[0].SubItems[6].Text);
            Cursor = Cursors.Default;
            UpdateEpisodesList("episodes_" + showsList.SelectedItems[0].SubItems[6].Text);
        }

        private double getRating(XElement e)
        {

            try
            {
                return (double)e.Element("Rating");
            }
            catch (Exception)
            {
                return 0.0;
            }
        }

        private void UpdateShows(string sId) {
            var seriesId = sId;
            var query = "SELECT * FROM series WHERE series_id=" + seriesId;
            var dt = _db.GetDataTable(query);
            var drow = dt.Rows[0];
            if (!Directory.Exists("temp"))
            {
                Directory.CreateDirectory("temp");
            }
            if (!Directory.Exists("res"))
            {
                Directory.CreateDirectory("res");
            }

            var client = new WebClient();
            client.DownloadFile("http://thetvdb.com/api/" + Constants.ApiKey + "/series/" + seriesId + "/all/" + drow["language"].ToString() + ".zip",
                @"temp/tmp.zip");

            using (var zip = ZipFile.Read("temp/tmp.zip"))
            {
                zip.ExtractAll("temp/");
            }

            var doc = XDocument.Load("temp/en.xml");

            // var names = doc.Descendants("Series");
            var names = from ele in doc.Descendants("Episode")
                        select new
                        {
                            episodeName = (string)ele.Element("EpisodeName") ?? string.Empty,
                            episode = (int)ele.Element("EpisodeNumber"),
                            season = (int)ele.Element("SeasonNumber"),
                            firstAired = (string)ele.Element("FirstAired") ?? string.Empty,
                            imdbId = (string)ele.Element("IMDB_ID") ?? string.Empty,
                            overview = (string)ele.Element("Overview") ?? string.Empty,
                            rating = getRating(ele),
                            episodeId = (int)ele.Element("id")
                        };

            foreach (var n in names)
            {
                try
                {

                    if (_db.EpisodeExists(seriesId, n.episodeId.ToString()))
                    {
                        _db.UpdateEpisode(seriesId, n.episodeId.ToString(), n.episodeName, n.overview, n.firstAired, n.rating.ToString());
                    }
                    else
                    {
                        var edb = new EpisodeDatabaseEntry(n.episodeName, n.episode, n.season, n.rating, n.firstAired, n.imdbId, n.overview, false, n.episodeId);
                        _db.InsertEpisode("episodes_" + seriesId, edb);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            _db.UpdateDate(seriesId, DateTime.Now.ToString());
                
            Directory.Delete(@"temp", true);
        }

        private void updateAllShowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;
            Cursor = Cursors.WaitCursor;
            _alert = new AlertDialog();
            _alert.Show();
            // Start the asynchronous operation.
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            var worker = sender as BackgroundWorker;
            const string query = "SELECT * FROM series";
            var dt = _db.GetDataTable(query);
            var count = dt.Rows.Count;
            for (var i = 0; i < count; i++)
            {
                if (worker != null)
                    worker.ReportProgress((int)((i + 1) / (double)count * 100.0), (dt.Rows[i])["series_name"].ToString() +" "+ (i+1) + "/" + count);
                UpdateShows((dt.Rows[i])["series_id"].ToString());
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _alert.SetLabels("Please wait", "Updating:", (string)e.UserState);
            _alert.SetProgress(e.ProgressPercentage);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _alert.Close();
            Cursor = Cursors.Default;
            UpdateEpisodesList("episodes_" + showsList.SelectedItems[0].SubItems[6].Text);
        }

    }
}
