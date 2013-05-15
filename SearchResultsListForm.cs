using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TVDb
{
    public partial class SearchResultsListForm : Form
    {
        SqLiteDatabase _db;
        public SearchResultsListForm()
        {
            InitializeComponent();
        }

        readonly MainForm _mainForm;
        string _result;
        List<SearchResultsEntry> _namesList;
        ProgressDialog _pd;
        SearchResultsEntry _selectedItem;
        readonly string _query;

        public SearchResultsListForm(MainForm mainForm, string query)
        {
            _query = query;
            _mainForm = mainForm;

            InitializeComponent();

        }

        private void SearchResultsListForm_Load(object sender, EventArgs e)
        {
            _db = new SqLiteDatabase();
            _result = HttpHelper.HttpGet("http://thetvdb.com/api/GetSeries.php?seriesname="+_query);
            //Console.WriteLine(result);
            _namesList = new List<SearchResultsEntry>();
            XDocument doc = XDocument.Parse(_result);

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
                
                _namesList.Add(new SearchResultsEntry(n.seriesName, n.lang, n.overview, n.id));
                
            }
            searchResults.Items.Clear();
            foreach (ListViewItem item in _namesList.Select(s => new ListViewItem(s.GetName())))
            {
                searchResults.Items.Add(item);
            }
            _mainForm.Cursor = Cursors.Default;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void workerCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
                // Close the AlertForm
                _pd.Close();
            }
        }
        private void ok_Click(object sender, EventArgs e)
        {


            if (backgroundWorker1.IsBusy != true && searchResults.SelectedItems.Count > 0)
            {

                if (_db.ShowExists(searchResults.SelectedItems[0].Text) == false)
                {
                    // create a new instance of the alert form
                    _pd = new ProgressDialog();
                    // event handler for the Cancel button in AlertForm
                    _pd.Canceled += workerCancel_Click;
                    _pd.Show();
                    // Start the asynchronous operation.
                    backgroundWorker1.RunWorkerAsync();
                }
                else {
                    MessageBox.Show("Show Already Exists");
                }
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
                searchResultsPlot.Text = _namesList[index[0]].GetOverview();
                _selectedItem = _namesList[index[0]];
            }
           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var sName = "";
            var worker = sender as BackgroundWorker;

            //Step1 Create temp directory if doesnt exists
            
            if(!Directory.Exists("temp"))
            {
                Directory.CreateDirectory("temp");
            }
            if (!Directory.Exists("res"))
            {
                Directory.CreateDirectory("res");
            }

            //Step2 Download series info zip file
            worker.ReportProgress(15);
            var client = new WebClient();
            client.DownloadFile("http://thetvdb.com/api/" + Constants.ApiKey + "/series/" + _selectedItem.GetSeriesId() + "/all/" + _selectedItem.GetLang() + ".zip",
                @"temp/tmp.zip");

            //Step3 Extract xmls
            worker.ReportProgress(30);
            using (var zip = ZipFile.Read("temp/tmp.zip"))
            {
                zip.ExtractAll("temp/");
            }

            //Step4 Add series information to database
            worker.ReportProgress(45);

            var doc = XDocument.Load("temp/en.xml");

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
                client.DownloadFile("http://thetvdb.com/banners/"+n.banner,
                @"res/"+n.seriesName+"_banner.jpg");
                client.DownloadFile("http://thetvdb.com/banners/" + n.fanart,
                @"res/" + n.seriesName + "_fanart.jpg");
                client.DownloadFile("http://thetvdb.com/banners/" + n.poster,
                @"res/" + n.seriesName + "_poster.jpg");
                var sdb = new SeriesDatabaseEntry(n.seriesName, n.firstAired, n.imdbId, n.overview, n.rating, n.id, n.lang,
                    "res/" + n.seriesName + "_banner.jpg", "http://thetvdb.com/banners/" + n.banner, "res/" + n.seriesName + "_poster.jpg", "http://thetvdb.com/banners/" + n.poster,
                    "res/" + n.seriesName + "_fanart.jpg", "http://thetvdb.com/banners/" + n.fanart, n.network, n.runtime, n.status, false, false, DateTime.Now.ToString());
               
                
                sName = n.id.ToString();
                CreateArtsTable(sName);
                var adb = new ArtsDatabaseEntry(
                    "res/" + n.seriesName + "_banner.jpg");
                var adb2 = new ArtsDatabaseEntry("res/" + n.seriesName + "_poster.jpg");
                var adb3 = new ArtsDatabaseEntry(
                    "res/" + n.seriesName + "_fanart.jpg");
                try
                {
                    _db.InsertSeries(sdb);
                }
                catch (Exception crap)
                {
                    MessageBox.Show(crap.Message);
                }
                try
                {
                    _db.InsertArts(adb, "arts_"+sName);
                    _db.InsertArts(adb2, "arts_" + sName);
                    _db.InsertArts(adb3, "arts_" + sName);
                }
                catch (Exception crap)
                {
                    MessageBox.Show(crap.Message);
                }
                
            }
            
            //Step5 Create table for episodes
            worker.ReportProgress(60);
            CreateEpisodesTable(sName);
            

            //Step6 Add episodes info to database
            worker.ReportProgress(75);

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

            foreach (var edb in names1.Select(n => new EpisodeDatabaseEntry(n.episodeName, n.episode, n.season, n.rating, n.firstAired, n.imdbId, n.overview, false, n.episodeId)))
            {
                try
                {
                    _db.InsertEpisode("episodes_"+sName, edb);
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
            catch(Exception){
                return 0.0;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _pd.Message = "In progress, please wait... " + e.ProgressPercentage.ToString() + "%";
            _pd.ProgressValue = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            
            if (e.Cancelled)
            {
                Message("Interrupted!");
            }
            else if (e.Error != null)
            {
                Message("Error: " + e.Error.Message);
            }
            else
            {
                Message("Series Added Successufly!");
            }
            
        }

        private void Message(string text)
        {
            if (DialogResult.OK != MessageBox.Show(text)) return;
            _mainForm.UpdateShowList();
            if (Directory.Exists("temp"))
            {
                Directory.Delete(@"temp", true);
            }
            _pd.Close();
            Close();
        }
        private void CreateArtsTable(string seriesName)
        {
            var createTable = "CREATE TABLE " + "arts_" + seriesName + "("
                        + "_id" + " INTEGER PRIMARY KEY,"
                        + "image" + " TEXT"
                        +
                        ")";
            try
            {
                _db.CreateTable(createTable);
            }
            catch (Exception crap)
            {
                MessageBox.Show(crap.Message);
            }
        }
        private void CreateEpisodesTable(string seriesName)
        {
            String createTable = "CREATE TABLE " + "episodes_" + seriesName  + "("
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
                _db.CreateTable(createTable);
            }
            catch (Exception crap)
            {
                MessageBox.Show(crap.Message);
            }
        }
    }
}
