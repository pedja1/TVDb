using Ionic.Zip;
using Manina.Windows.Forms;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TVDb
{
    public partial class ArtViewer : Form
    {
        readonly string _seriesId;
        readonly string _seriesName;
        public ArtViewer()
        {
            InitializeComponent();
        }

        public ArtViewer(string seriesId, string seriesName)
        {
            InitializeComponent();
            _seriesId = seriesId;
            _seriesName = seriesName;
        }

        private void ArtViewer_Load(object sender, EventArgs e)
        {

            ShowSaved();
            
        }

        private void ShowSaved() {
            imageListView1.ShowCheckBoxes = false;
            var db = new SqLiteDatabase();
            var query = "SELECT * FROM arts_" + _seriesId;
            try
            {
                var dt = db.GetDataTable(query);
                imageListView1.Items.Clear();
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow drow = dt.Rows[i];
                    var img1 = new ImageListViewItem {FileName = @drow["image"].ToString()};
                    imageListView1.Items.AddRange(new[] { img1 });
                }
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
                var createTable = "CREATE TABLE " + "arts_" + _seriesId + "("
                            + "_id" + " INTEGER PRIMARY KEY,"
                            + "image" + " TEXT"
                            +
                            ")";
                var adb = new ArtsDatabaseEntry(
                    "res/" + _seriesName + "_banner.jpg");
                var adb2 = new ArtsDatabaseEntry("res/" + _seriesName + "_poster.jpg");
                var adb3 = new ArtsDatabaseEntry(
                    "res/" + _seriesName + "_fanart.jpg");
                try
                {
                    db.CreateTable(createTable);
                    db.InsertArts(adb, "arts_" + _seriesId);
                    db.InsertArts(adb2, "arts_" + _seriesId);
                    db.InsertArts(adb3, "arts_" + _seriesId);
                    ShowSaved();
                }
                catch (Exception crap)
                {
                    MessageBox.Show(crap.Message);
                }
            }
            
        }

        private void imageListView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Process.Start(@e.Item.FileName.ToString().Replace("/","\\"));
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            var worker = sender as BackgroundWorker;
            if (!Directory.Exists("temp"))
            {
                Directory.CreateDirectory("temp");
            }
            var client = new WebClient();
            client.DownloadFile("http://thetvdb.com/api/" + Constants.ApiKey + "/series/" + _seriesId + "/all/en.zip",
                @"temp/tmp.zip");
            using (var zip = ZipFile.Read("temp/tmp.zip"))
            {
                zip.ExtractAll("temp/");
            }
            var doc = XDocument.Load("temp/banners.xml");

            var names = from ele in doc.Descendants("Banner")
                        select new
                        {
                            url = (string)ele.Element("BannerPath"),
                            type = (string)ele.Element("BannerType")
                        };

            foreach (var n in names.Where(n => n.type != "season"))
            {
                switch (e.Argument.ToString())
                {
                    case "0":
                        if (n.type != "fanart" && n.type != "poster")
                        {
                            client.DownloadFile("http://thetvdb.com/banners/" + n.url,
                                                @"temp/" + Path.GetFileName(n.url));

                            var img = new ImageListViewItem {FileName = @"temp/" + Path.GetFileName(n.url)};
                            if (worker != null) worker.ReportProgress(0, img);
                        }
                        break;
                    case "1":
                        if (n.type != "fanart" && n.type != "series")
                        {
                            client.DownloadFile("http://thetvdb.com/banners/" + n.url,
                                                @"temp/" + Path.GetFileName(n.url));

                            var img = new ImageListViewItem {FileName = @"temp/" + Path.GetFileName(n.url)};
                            if (worker != null) worker.ReportProgress(0, img);
                        }
                        break;
                    case "2":
                        if (n.type != "series" && n.type != "poster")
                        {
                            client.DownloadFile("http://thetvdb.com/banners/" + n.url,
                                                @"temp/" + Path.GetFileName(n.url));

                            var img = new ImageListViewItem {FileName = @"temp/" + Path.GetFileName(n.url)};
                            if (worker != null) worker.ReportProgress(0, img);
                        }
                        break;
                }
            }
            
        }

       
            
        

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           imageListView1.Items.Add((ImageListViewItem)e.UserState);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Done");
            EnableButtons();
            Cursor = Cursors.Default;
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            StartWorker(0);
        }

        private void ArtViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            wipeTempDir();
        }

        private void wipeTempDir()
        {
            if (!Directory.Exists("temp")) return;
            try
            {
                Directory.Delete(@"temp", true);
            }
            catch(Exception e) {
                MessageBox.Show(e.Message);
            }
        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {
            StartWorker(1);
        }

        private void StartWorker(int code) {

            Cursor = Cursors.WaitCursor;
            imageListView1.ShowCheckBoxes = true;
            DisableButtons();
            imageListView1.Items.Clear();
            wipeTempDir();
            if (backgroundWorker1.IsBusy != true)
            {
                // create a new instance of the alert form
                //pd = new ProgressDialog();
                // event handler for the Cancel button in AlertForm
                //pd.Canceled += new EventHandler<EventArgs>(workerCancel_Click);
                // pd.Show();
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync(code);
            }
            
        }

        private void toolStripDropDownButton3_Click(object sender, EventArgs e)
        {
            StartWorker(2);
        }

        private void EnableButtons() {
            downloadBanners.Enabled = true;
            downloadPosters.Enabled = true;
            downloadFanarts.Enabled = true;
            save.Enabled = true;
            saved.Enabled = true;
        }
        private void DisableButtons()
        {
            downloadBanners.Enabled = false;
            downloadPosters.Enabled = false;
            downloadFanarts.Enabled = false;
            save.Enabled = false;
            saved.Enabled = false;
        }

        private void saved_Click(object sender, EventArgs e)
        {
            ShowSaved();
        }

        private void save_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var db = new SqLiteDatabase();
            foreach(var i in imageListView1.CheckedItems){
                File.Copy(i.FileName, @"res/"+Path.GetFileName(i.FileName));
                try{
                    db.InsertArts(new ArtsDatabaseEntry("res/" + Path.GetFileName(i.FileName)), "arts_" + _seriesId);
                }
                catch(Exception ex){
                    MessageBox.Show(ex.Message);
                }
            }
            ShowSaved();
            Cursor = Cursors.Default;
        }
        
    }
}
