using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVDb
{
    class AgendaListEntry
    {
        //Feelds
        private string _seriesName;
        private string _seriesId;
        private string _episodeName;
        private string _episode;
        private string _season;
        private string _airs;
        private string _episodeId;

        //parameters
        public string seriesId { get { return _seriesId; } set { _seriesId = value; } }
        public string seriesName { get { return _seriesName; } set { _seriesName = value; } }
        public string episodeName { get { return _episodeName; } set { _episodeName = value; } }
        public string episode { get { return _episode; } set { _episode = value; } }
        public string season { get { return _season; } set { _season = value; } }
        public string airs { get { return _airs; } set { _airs = value; } }
        public string episodeId { get { return _episodeId; } set { _episodeId = value; } }
        //Constructors
        public AgendaListEntry()
        {
        }
        public AgendaListEntry(string seriesId, string seriesName, string episodeName, string episode, string season, string airs, string episodeId)
        {
            this._seriesId = seriesId;
            this._seriesName = seriesName;
            this._episodeName = episodeName;
            this._episode = episode;
            this._airs = airs;
            this._season = season;
            this._episodeId = episodeId;
        }
        
        
    }
}
