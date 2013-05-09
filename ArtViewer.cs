using Ionic.Zip;
using Manina.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TVDb
{
    public partial class ArtViewer : Form
    {
        string seriesId;
        string seriesName;
        public ArtViewer()
        {
            InitializeComponent();
        }

        public ArtViewer(string seriesId, string seriesName)
        {
            InitializeComponent();
            this.seriesId = seriesId;
            this.seriesName = seriesName;
        }

        private void ArtViewer_Load(object sender, EventArgs e)
        {

            showSaved();
            
        }

        private void showSaved() {
            this.imageListView1.ShowCheckBoxes = false;
            SQLiteDatabase db = new SQLiteDatabase();
            DataTable dt;
            String query = "SELECT * FROM arts_" + seriesId;
            try
            {
                dt = db.GetDataTable(query);
                imageListView1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow drow = dt.Rows[i];
                    ImageListViewItem img1 = new ImageListViewItem();
                    img1.FileName = @drow["image"].ToString();
                    this.imageListView1.Items.AddRange(new ImageListViewItem[] { img1 });
                }
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
                String CREATE_TABLE = "CREATE TABLE " + "arts_" + seriesId + "("
                            + "_id" + " INTEGER PRIMARY KEY,"
                            + "image" + " TEXT"
                            +
                            ")";
                ArtsDatabaseEntry adb = new ArtsDatabaseEntry(
                    "res/" + seriesName + "_banner.jpg");
                ArtsDatabaseEntry adb2 = new ArtsDatabaseEntry("res/" + seriesName + "_poster.jpg");
                ArtsDatabaseEntry adb3 = new ArtsDatabaseEntry(
                    "res/" + seriesName + "_fanart.jpg");
                try
                {
                    db.createTable(CREATE_TABLE);
                    db.InsertArts(adb, "arts_" + seriesId);
                    db.InsertArts(adb2, "arts_" + seriesId);
                    db.InsertArts(adb3, "arts_" + seriesId);
                    showSaved();
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
            
            BackgroundWorker worker = sender as BackgroundWorker;
            if (!System.IO.Directory.Exists("temp"))
            {
                System.IO.Directory.CreateDirectory("temp");
            }
            WebClient Client = new WebClient();
            Client.DownloadFile("http://thetvdb.com/api/" + Constants.api_key + "/series/" + seriesId + "/all/en.zip",
                @"temp/tmp.zip");
            using (ZipFile zip = ZipFile.Read("temp/tmp.zip"))
            {
                zip.ExtractAll("temp/");
            }
            XDocument doc = XDocument.Load("temp/banners.xml");

            var names = from ele in doc.Descendants("Banner")
                        select new
                        {
                            url = (string)ele.Element("BannerPath"),
                            type = (string)ele.Element("BannerType")
                        };

            foreach (var n in names)
            {
                if(n.type != "season"){
                    if(e.Argument.ToString() == "0"){
                        if (n.type != "fanart" && n.type != "poster")
                        {
                            Client.DownloadFile("http://thetvdb.com/banners/" + n.url,
                                @"temp/" + Path.GetFileName(n.url));

                            ImageListViewItem img = new ImageListViewItem();
                            img.FileName = @"temp/" + Path.GetFileName(n.url);
                            worker.ReportProgress(0, img);
                        }
                    }
                    else if (e.Argument.ToString() == "1")
                    {
                        if (n.type != "fanart" && n.type != "series")
                        {
                            Client.DownloadFile("http://thetvdb.com/banners/" + n.url,
                                @"temp/" + Path.GetFileName(n.url));

                            ImageListViewItem img = new ImageListViewItem();
                            img.FileName = @"temp/" + Path.GetFileName(n.url);
                            worker.ReportProgress(0, img);
                        }
                    }
                    else if (e.Argument.ToString() == "2")
                    {
                        if (n.type != "series" && n.type != "poster")
                        {
                            Client.DownloadFile("http://thetvdb.com/banners/" + n.url,
                                @"temp/" + Path.GetFileName(n.url));

                            ImageListViewItem img = new ImageListViewItem();
                            img.FileName = @"temp/" + Path.GetFileName(n.url);
                            worker.ReportProgress(0, img);
                        }
                    }
                }
                
            }
            
        }

       
            
        

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.imageListView1.Items.Add((ImageListViewItem)e.UserState);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Done");
            enableButtons();
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            startWorker(0);
        }

        private void ArtViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            wipeTempDir();
        }

        private void wipeTempDir() {
            if (System.IO.Directory.Exists("temp"))
            {
                try
                {
                    Directory.Delete(@"temp", true);
                }
                catch(Exception e) {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {
            startWorker(1);
        }

        private void startWorker(int code) {

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.imageListView1.ShowCheckBoxes = true;
            disableButtons();
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
            startWorker(2);
        }

        private void enableButtons() {
            downloadBanners.Enabled = true;
            downloadPosters.Enabled = true;
            downloadFanarts.Enabled = true;
            save.Enabled = true;
            saved.Enabled = true;
        }
        private void disableButtons()
        {
            downloadBanners.Enabled = false;
            downloadPosters.Enabled = false;
            downloadFanarts.Enabled = false;
            save.Enabled = false;
            saved.Enabled = false;
        }

        private void saved_Click(object sender, EventArgs e)
        {
            showSaved();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            SQLiteDatabase db = new SQLiteDatabase();
            foreach(ImageListViewItem i in imageListView1.CheckedItems){
                File.Copy(i.FileName, @"res/"+Path.GetFileName(i.FileName));
                try{
                    db.InsertArts(new ArtsDatabaseEntry("res/" + Path.GetFileName(i.FileName)), "arts_" + seriesId);
                }
                catch(Exception ex){
                    MessageBox.Show(ex.Message);
                }
            }
            showSaved();
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
        
    }
}
