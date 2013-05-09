using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVDb
{
    public partial class Agenda : Form
    {
        MainForm mainForm;
        SQLiteDatabase db;

        public Agenda(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void Agenda_Load(object sender, EventArgs e)
        {
            db = new SQLiteDatabase();
            updateList();
            
        }

        private void updateList(){
            DataTable dt;
            String query = "SELECT * FROM series";
            dt = db.GetDataTable(query);
            List<AgendaListEntry> e = new List<AgendaListEntry>();
            List<Series> series = new List<Series>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drow = dt.Rows[i];
                series.Add(new Series(drow["series_name"].ToString(), drow["series_id"].ToString(), bool.Parse(drow["ignore_agenda"].ToString())));
                
            }
            foreach(Series s in series){
                DataTable dt2;
                String query2 = "SELECT * FROM episodes_"+s.seriesId;
                dt2 = db.GetDataTable(query2);
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    DataRow drow = dt2.Rows[i];
                    if(drow["season"].ToString() != "0" && s.ignore == false){
                        DateTime date;
                        if(DateTime.TryParse(drow["first_aired"].ToString(), out date)){
                            if(DateTime.Parse(drow["first_aired"].ToString()) >= DateTime.Now  || drow["watched"].ToString() == "False"){
                                e.Add(new AgendaListEntry(s.seriesId, s.seriesName, drow["episode_name"].ToString(), drow["episode"].ToString(), drow["season"].ToString(), drow["first_aired"].ToString(), drow["episode_id"].ToString()));
                            }
                        }
                    }
                }
                
            }

            this.objectListView1.SetObjects(e);
            mainForm.Cursor = System.Windows.Forms.Cursors.Default;
        }

        class Series
        {
            private string _seriesName;
            private string _seriesId;
            private bool _ignore;

            public string seriesName { get { return _seriesName; } set { _seriesName = value; } }
            public string seriesId { get { return _seriesId; } set { _seriesId = value; } }
            public bool ignore { get { return _ignore; } set { _ignore = value; } }

            public Series(string seriesName, string seriesId, bool ignore)
            {
                this._seriesId = seriesId;
                this._seriesName = seriesName;
                this._ignore = ignore;
            }
            
        }

        private void objectListView1_DoubleClick(object sender, EventArgs e)
        {
            DataTable dt;
            String query = "SELECT * FROM episodes_" + objectListView1.SelectedItems[0].SubItems[6].Text + " WHERE episode_id=" + objectListView1.SelectedItems[0].SubItems[5].Text;
            dt = db.GetDataTable(query);
            DataRow drow = dt.Rows[0];
            MessageBox.Show(drow["overview"].ToString());
        }
    }
}
