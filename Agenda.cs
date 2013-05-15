using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TVDb
{
    public partial class Agenda : Form
    {
        readonly MainForm _mainForm;
        SqLiteDatabase _db;

        public Agenda(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void Agenda_Load(object sender, EventArgs e)
        {
            _db = new SqLiteDatabase();
            UpdateList();
            
        }

        private void UpdateList(){
            const string query = "SELECT * FROM series";
            var dt = _db.GetDataTable(query);
            var e = new List<AgendaListEntry>();
            var series = new List<Series>();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var drow = dt.Rows[i];
                series.Add(new Series(drow["series_name"].ToString(), drow["series_id"].ToString(), bool.Parse(drow["ignore_agenda"].ToString())));
                
            }
            foreach(Series s in series){
                var query2 = "SELECT * FROM episodes_"+s.SeriesId;
                var dt2 = _db.GetDataTable(query2);
                for (var i = 0; i < dt2.Rows.Count; i++)
                {
                    var drow = dt2.Rows[i];
                    if (drow["season"].ToString() == "0" || s.Ignore) continue;
                    DateTime date;
                    if (!DateTime.TryParse(drow["first_aired"].ToString(), out date)) continue;
                    if(DateTime.Parse(drow["first_aired"].ToString()) >= DateTime.Now  || drow["watched"].ToString() == "False"){
                        e.Add(new AgendaListEntry(s.SeriesId, s.SeriesName, drow["episode_name"].ToString(), drow["episode"].ToString(), drow["season"].ToString(), drow["first_aired"].ToString(), drow["episode_id"].ToString()));
                    }
                }
                
            }

            objectListView1.SetObjects(e);
            _mainForm.Cursor = Cursors.Default;
        }

        class Series
        {
            public string SeriesName { get; private set; }
            public string SeriesId { get; private set; }
            public bool Ignore { get; private set; }

            public Series(string seriesName, string seriesId, bool ignore)
            {
                SeriesId = seriesId;
                SeriesName = seriesName;
                Ignore = ignore;
            }
            
        }

        private void objectListView1_DoubleClick(object sender, EventArgs e)
        {
            var query = "SELECT * FROM episodes_" + objectListView1.SelectedItems[0].SubItems[6].Text + " WHERE episode_id=" + objectListView1.SelectedItems[0].SubItems[5].Text;
            var dt = _db.GetDataTable(query);
            var drow = dt.Rows[0];
            MessageBox.Show(drow["overview"].ToString());
        }
    }
}
