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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace TVDb
{
    public partial class SearchResultsListForm : Form
    {
        SQLiteDatabase db;
        public SearchResultsListForm()
        {
            InitializeComponent();
        }

        MainForm mainForm;
        string result;
        List<SearchResultsEntry> namesList;
        ProgressDialog pd;
        SearchResultsEntry selectedItem;
        string query;

        public SearchResultsListForm(MainForm mainForm, string query)
        {
            this.query = query;
            this.mainForm = mainForm;

            InitializeComponent();

        }

        private void SearchResultsListForm_Load(object sender, EventArgs e)
        {
            db = new SQLiteDatabase();
            result = HttpHelper.HttpGet("http://thetvdb.com/api/GetSeries.php?seriesname="+query);
            //Console.WriteLine(result);
            namesList = new List<SearchResultsEntry>();
            XDocument doc = XDocument.Parse(result);

           // var names = doc.Descendants("Series");
            var names = from ele in doc.Descendants("Series")
                      select new
                      {
                          seriesName = (string)ele.Element("SeriesName"),
                          overview = (string)ele.Element("Overview"),
                          lang = (string)ele.Element("language"),
                          id = (int)ele.Element("seriesid")
                      };
            
            foreach (var n in names)
            {
                
                namesList.Add(new SearchResultsEntry(n.seriesName, n.lang, n.overview, n.id));
                
            }
            searchResults.Items.Clear();
            foreach(SearchResultsEntry s in namesList){
                ListViewItem item = new ListViewItem(s.getName());
                
                //item.SubItems.Add(s.getOverview());
                searchResults.Items.Add(item);
            }
            mainForm.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void workerCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
                // Close the AlertForm
                pd.Close();
            }
        }
        private void ok_Click(object sender, EventArgs e)
        {
            //TODO Download and store show information in DB
           // this.Close();


            if (backgroundWorker1.IsBusy != true && searchResults.SelectedItems.Count > 0)
            {
                // create a new instance of the alert form
                pd = new ProgressDialog();
                // event handler for the Cancel button in AlertForm
                pd.Canceled += new EventHandler<EventArgs>(workerCancel_Click);
                pd.Show();
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
            else {
                MessageBox.Show("You must select a show to add!");
            }
        }
        
        private void searchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
           // namesList.
            var index = searchResults.SelectedIndices;

            if (searchResults.SelectedItems.Count > 0)
            {
                searchResultsPlot.Text = namesList[index[0]].getOverview();
                selectedItem = namesList[index[0]];
            }
           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //TODO download selected show info and store in database
            string sName = "";

            
            
            BackgroundWorker worker = sender as BackgroundWorker;
            Console.WriteLine("DoWork");

            //Step1 Create temp directory if doesnt exists
            
            if(!System.IO.Directory.Exists("temp"))
            {
                System.IO.Directory.CreateDirectory("temp");
            }
            if (!System.IO.Directory.Exists("res"))
            {
                System.IO.Directory.CreateDirectory("res");
            }

            //Step2 Download series info zip file
            worker.ReportProgress(15);
            WebClient Client = new WebClient();
            Client.DownloadFile("http://thetvdb.com/api/" + Constants.api_key + "/series/" + selectedItem.getSeriesId() + "/all/" + selectedItem.getLang() + ".zip",
                @"temp/tmp.zip");

            //Step3 Extract xmls
            worker.ReportProgress(30);
            using (ZipFile zip = ZipFile.Read("temp/tmp.zip"))
            {
                zip.ExtractAll("temp/");
            }

            //Step4 Add series information to database
            worker.ReportProgress(45);

            XDocument doc = XDocument.Load("temp/en.xml");

            var names = from ele in doc.Descendants("Series")
                        select new
                        {
                            seriesName = (string)ele.Element("SeriesName"),
                            overview = (string)ele.Element("Overview"),
                            lang = (string)ele.Element("Language"),
                            id = (int)ele.Element("id"),
                            firstAired = (string)ele.Element("FirstAired"),
                            imdbId = (string)ele.Element("IMDB_ID"),
                            network = (string)ele.Element("Network"),
                            rating = (double)ele.Element("Rating"),
                            runtime = (int)ele.Element("Runtime"),
                            status = (string)ele.Element("Status"),
                            banner = (string)ele.Element("banner"),
                            fanart = (string)ele.Element("fanart"),
                            poster = (string)ele.Element("poster")
                        };
            
            foreach (var n in names)
            {
                Client.DownloadFile("http://thetvdb.com/banners/"+n.banner,
                @"res/"+n.seriesName+"_banner.jpg");
                Client.DownloadFile("http://thetvdb.com/banners/" + n.fanart,
                @"res/" + n.seriesName + "_fanart.jpg");
                Client.DownloadFile("http://thetvdb.com/banners/" + n.poster,
                @"res/" + n.seriesName + "_poster.jpg");
                SeriesDatabaseEntry sdb = new SeriesDatabaseEntry(n.seriesName, n.firstAired, n.imdbId, n.overview, n.rating, n.id, n.lang,
                    "res/" + n.seriesName + "_banner.jpg", "http://thetvdb.com/banners/" + n.banner, "res/" + n.seriesName + "_poster.jpg", "http://thetvdb.com/banners/" + n.poster,
                    "res/" + n.seriesName + "_fanart.jpg", "http://thetvdb.com/banners/" + n.fanart, n.network, n.runtime, n.status, false, false);
               
                
                sName = n.id.ToString();
                createArtsTable(sName);
                ArtsDatabaseEntry adb = new ArtsDatabaseEntry(
                    "res/" + n.seriesName + "_banner.jpg");
                ArtsDatabaseEntry adb2 = new ArtsDatabaseEntry("res/" + n.seriesName + "_poster.jpg");
                ArtsDatabaseEntry adb3 = new ArtsDatabaseEntry(
                    "res/" + n.seriesName + "_fanart.jpg");
                try
                {
                    db.InsertSeries(sdb);
                }
                catch (Exception crap)
                {
                    MessageBox.Show(crap.Message);
                }
                try
                {
                    db.InsertArts(adb, "arts_"+sName);
                    db.InsertArts(adb2, "arts_" + sName);
                    db.InsertArts(adb3, "arts_" + sName);
                }
                catch (Exception crap)
                {
                    MessageBox.Show(crap.Message);
                }
                
            }
            
            //Step5 Create table for episodes
            worker.ReportProgress(60);
            createEpisodesTable(sName);
            

            //Step6 Add episodes info to database
            worker.ReportProgress(75);
            XDocument doc1 = XDocument.Load("temp/en.xml");

            // var names = doc.Descendants("Series");
            var names1 = from ele in doc.Descendants("Episode")
                        select new
                        {
                            episodeName = (string)ele.Element("EpisodeName") ?? string.Empty,
                            episode = (int)ele.Element("EpisodeNumber") ,
                            season = (int)ele.Element("SeasonNumber"),
                            firstAired = (string)ele.Element("FirstAired") ?? string.Empty,
                            imdbId = (string)ele.Element("IMDB_ID") ?? string.Empty,
                            overview = (string)ele.Element("Overview") ?? string.Empty,
                            rating = getRating(ele),
                            episodeId = (int)ele.Element("id")
                        };

            foreach (var n in names1)
            {
                EpisodeDatabaseEntry edb = new EpisodeDatabaseEntry(n.episodeName, n.episode, n.season, n.rating, n.firstAired, n.imdbId, n.overview, false, n.episodeId);
                try
                {
                    db.InsertEpisode("episodes_"+sName, edb);
                }
                catch (Exception crap)
                {
                    MessageBox.Show(crap.Message);
                }

            }
            //Step7 dELETE temp folder
            worker.ReportProgress(90);
            Directory.Delete(@"temp", true);
            worker.ReportProgress(100);
        }

        private double getRating(XElement e){
            
            try {
                return (double)e.Element("Rating");
            }
            catch(Exception ex){
                return 0.0;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pd.Message = "In progress, please wait... " + e.ProgressPercentage.ToString() + "%";
            pd.ProgressValue = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            
            if (e.Cancelled == true)
            {
                message("Interrupted!");
            }
            else if (e.Error != null)
            {
                message("Error: " + e.Error.Message);
            }
            else
            {
                message("Series Added Successufly!");
            }
            
        }

        private void message(string text)
        {
            if (DialogResult.OK == MessageBox.Show(text))
            {
                mainForm.updateShowList();
                if (System.IO.Directory.Exists("temp"))
                {
                    Directory.Delete(@"temp", true);
                }
                pd.Close();
                this.Close();
            }
        }
        private void createArtsTable(string seriesName)
        {
            String CREATE_TABLE = "CREATE TABLE " + "arts_" + seriesName + "("
                        + "_id" + " INTEGER PRIMARY KEY,"
                        + "image" + " TEXT"
                        +
                        ")";
            try
            {
                db.createTable(CREATE_TABLE);
            }
            catch (Exception crap)
            {
                MessageBox.Show(crap.Message);
            }
        }
        private void createEpisodesTable(string seriesName)
        {
            String CREATE_TABLE = "CREATE TABLE " + "episodes_" + seriesName  + "("
                        + "_id" + " INTEGER PRIMARY KEY,"
                        + "episode" + " INTEGER,"
                        + "season" + " INTEGER,"
                        + "episode_name" + " TEXT,"
                        + "first_aired" + " TEXT,"
                        + "imdb_id" + " TEXT,"
                        + "overview" + " TEXT,"
                        + "rating" + " DOUBLE,"
                        + "watched" + " BOOLEAN,"
                        + "episode_id" + " INTEGER"
                        +
                        ")";
            try
            {
                db.createTable(CREATE_TABLE);
            }
            catch (Exception crap)
            {
                MessageBox.Show(crap.Message);
            }
        }
    }
}
