using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVDb.Properties;

namespace TVDb
{
    public partial class MainForm : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        SQLiteDatabase db;
        public MainForm()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.showsList.ListViewItemSorter = lvwColumnSorter;
        }


        private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                search();
            }
        }
        private void searchBox_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            SearchResultsListForm searchForm = new SearchResultsListForm(this, searchBox.Text);
            searchForm.ShowDialog();
            searchBox.Text = "";
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db = new SQLiteDatabase();
            if (File.Exists(@"tvdb.db"))
            {
                updateShowList();
            }
            else 
            {
                createDatabase();
            }
            

        }

        private void createDatabase() {
            
                String CREATE_TABLE = "CREATE TABLE series (_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, series_name TEXT, series_id INTEGER, language TEXT, banner_local TEXT, network TEXT, first_aired TEXT, imdb_id TEXT, banner_url TEXT, overview TEXT, rating DOUBLE, runtime INTEGER, status TEXT, fanart_url TEXT, fanart_local TEXT, poster_url TEXT, poster_local TEXT)";
                try
                {
                    db.createTable(CREATE_TABLE);
                }
                catch (Exception crap)
                {
                    MessageBox.Show(crap.Message);
                }
            
        }

        public void updateShowList() {
            DataTable dt;
            String query = "SELECT * FROM series";
            dt = db.GetDataTable(query);

            showsList.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drow = dt.Rows[i];

                // Only row that have not been deleted
                if (drow.RowState != DataRowState.Deleted)
                {
                    // Define the list items
                    ListViewItem lvi = new ListViewItem(drow["series_name"].ToString());

                    lvi.SubItems.Add(drow["first_aired"].ToString());
                    lvi.SubItems.Add(drow["network"].ToString());
                    lvi.SubItems.Add(drow["rating"].ToString());
                    lvi.SubItems.Add(drow["status"].ToString());
                    lvi.SubItems.Add(drow["runtime"].ToString());
                    lvi.SubItems.Add(drow["series_id"].ToString());


                    // Add the list items to the ListView
                    if (Properties.Settings.Default.ShowsToDisplay == "Ended" && drow["status"].ToString() == "Ended")
                    {
                        if(drow["hide_from_list"].ToString() == "False" || Properties.Settings.Default.ShowHidden == true)
                        showsList.Items.Add(lvi);
                    }
                    else if (Properties.Settings.Default.ShowsToDisplay == "Continuing" && drow["status"].ToString() == "Continuing")
                    {
                        if (drow["hide_from_list"].ToString() == "False" || Properties.Settings.Default.ShowHidden == true)
                        showsList.Items.Add(lvi);
                    }
                    else if (Properties.Settings.Default.ShowsToDisplay == "All")
                    {
                        if (drow["hide_from_list"].ToString() == "False" || Properties.Settings.Default.ShowHidden == true)
                        showsList.Items.Add(lvi);
                    }
                    
                }
            }
            if(showsList.Items.Count > 0){
            showsList.Items[0].Selected = true;
            }
        }

        public void updateEpisodesList(string tableName)
        {
            DataTable dt;
            String query = "SELECT * FROM " + tableName;
            dt = db.GetDataTable(query);
            List<EpisodeListEntry> e = new List<EpisodeListEntry>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drow = dt.Rows[i];
                if(drow["season"].ToString() != "0"){
                e.Add(new EpisodeListEntry(drow["episode_name"].ToString(), int.Parse(drow["episode"].ToString()), int.Parse(drow["season"].ToString()), double.Parse(drow["rating"].ToString()), drow["first_aired"].ToString(), bool.Parse(drow["watched"].ToString()), int.Parse(drow["episode_id"].ToString())));
                }
            }
            
            this.objectListView1.SetObjects(e);
        }
        
        private void showsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = showsList.SelectedIndices;

            if (showsList.SelectedItems.Count > 0)
            {
                DataTable dt;
                String query = "SELECT * FROM series WHERE series_name = \""+showsList.SelectedItems[0].SubItems[0].Text+"\"";
                dt = db.GetDataTable(query);
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
                updateEpisodesList("episodes_"+showsList.SelectedItems[0].SubItems[6].Text);
            }
        }

        private void first_aired_Click(object sender, EventArgs e)
        {

        }

        private void showsList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.showsList.Sort();
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
                    SQLiteDatabase db = new SQLiteDatabase();
                    try
                    {
                        db.Delete("series", "series_id=" + showsList.SelectedItems[0].SubItems[6].Text);
                        db.ExecuteNonQuery("DROP TABLE IF EXISTS episodes_" + showsList.SelectedItems[0].SubItems[6].Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    updateShowList();
                }
                
            }
            else if (e.ClickedItem.Text == "View Poster")
            {
                try
                {
                    Process.Start(@"res\" + showsList.SelectedItems[0].Text + "_poster.jpg");
                    
                }
                catch(Exception ex){
                    MessageBox.Show(ex.Message);
                }
            }
            else if (e.ClickedItem.Text == "View Banner")
            {
                try
                {
                    Process.Start(@"res\" + showsList.SelectedItems[0].Text + "_banner.jpg");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (e.ClickedItem.Text == "View Fanart")
            {
                try
                {
                    Process.Start(@"res\" + showsList.SelectedItems[0].Text + "_fanart.jpg");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
              

        }

        private int getCheckedStatus(ItemCheckEventArgs e)
        {
            if (e.NewValue.ToString() == "Checked")
            {
                return 1;
            }
            else {
                return 0;
            }
            
        }

        private void objectListView1_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            int chk = getCheckedStatus(e);

            try
            {
                db.ExecuteNonQuery("UPDATE episodes_" + showsList.SelectedItems[0].SubItems[6].Text + " SET watched=" + chk + " WHERE episode_id=" + objectListView1.Items[e.Index].SubItems[5].Text);
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
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    if (db.ClearDB())
                    {
                        MessageBox.Show("Database Cleared Successfuly");
                    }
                    else {
                        MessageBox.Show("Something Went Wrong\nDatabase might be corupted!");
                    }
                    updateShowList();
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                }
            }
        }

        

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Settings(this).ShowDialog();
        }

        

        

        private void posterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArtViewer art = new ArtViewer(showsList.SelectedItems[0].SubItems[6].Text, showsList.SelectedItems[0].Text);
            art.Show();
        }

        private void objectListView1_DoubleClick(object sender, EventArgs e)
        {
            DataTable dt;
            String query = "SELECT * FROM episodes_" + showsList.SelectedItems[0].SubItems[6].Text + " WHERE episode_id=" + objectListView1.SelectedItems[0].SubItems[5].Text;
            dt = db.GetDataTable(query);
            DataRow drow = dt.Rows[0];
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
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.objectListView1.CheckedObjectsEnumerable = this.objectListView1.Objects;
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void markAllSeason_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            foreach (OLVListItem olvi in objectListView1.Items)
            {
                if (olvi.SubItems[1].Text == objectListView1.SelectedItems[0].SubItems[1].Text)
                {
                    olvi.Checked = true;
                }
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
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
                updateShowList();
            }
        }

        private void upcomingEpisodesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            new Agenda(this).Show();
        }

        private void hideFromListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt;
            String query = "SELECT * FROM series WHERE series_id=" + showsList.SelectedItems[0].SubItems[6].Text;
            dt = db.GetDataTable(query);
            DataRow drow = dt.Rows[0];
            try
            {
                if (drow["hide_from_list"].ToString() == "False")
                    db.ExecuteNonQuery("UPDATE series SET hide_from_list=1 WHERE series_id=" + showsList.SelectedItems[0].SubItems[6].Text);
                else
                    db.ExecuteNonQuery("UPDATE series SET hide_from_list=0 WHERE series_id=" + showsList.SelectedItems[0].SubItems[6].Text);
                
                updateShowList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            DataTable dt;
            String query = "SELECT * FROM series WHERE series_id=" + showsList.SelectedItems[0].SubItems[6].Text;
            dt = db.GetDataTable(query);
            DataRow drow = dt.Rows[0];
            if (drow["hide_from_list"].ToString() == "False")
                hideFromListToolStripMenuItem.Text = "Hide From List";
            else
                hideFromListToolStripMenuItem.Text = "Show in List";

            if (drow["ignore_agenda"].ToString() == "False")
                ignoreInAgendaToolStripMenuItem.Text = "Ignore in Agenda";
            else
                ignoreInAgendaToolStripMenuItem.Text = "Include in Agenda";
            
            
        }

        private void ignoreInAgendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt;
            String query = "SELECT * FROM series WHERE series_id=" + showsList.SelectedItems[0].SubItems[6].Text;
            dt = db.GetDataTable(query);
            DataRow drow = dt.Rows[0];
            try
            {
                if (drow["hide_from_list"].ToString() == "False")
                    db.ExecuteNonQuery("UPDATE series SET ignore_agenda=1 WHERE series_id=" + showsList.SelectedItems[0].SubItems[6].Text);
                else
                    db.ExecuteNonQuery("UPDATE series SET ignore_agenda=0 WHERE series_id=" + showsList.SelectedItems[0].SubItems[6].Text);
                
                updateShowList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
