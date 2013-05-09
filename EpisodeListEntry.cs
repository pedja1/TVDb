using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVDb
{
    class EpisodeListEntry
    {
        //Feelds
        private string _episodeName;
        private int _episode;
        private int _season;
        private string _firstAired;
        private double _rating;
        private bool _watched;
        private int _episodeId;

        //parameters
        public string episodeName { get { return _episodeName; } set { _episodeName = value; } }
        public int episode { get { return _episode; } set { _episode = value; } }
        public int season { get { return _season; } set { _season = value; } }
        public string firstAired { get { return _firstAired; } set { _firstAired = value; } }
        public double rating { get { return _rating; } set { _rating = value; } }
        public bool watched { get { return _watched; } set { _watched = value; } }
        public int episodeId { get { return _episodeId; } set { _episodeId = value; } }
        //Constructors
        public EpisodeListEntry()
        {
        }
        public EpisodeListEntry(string episodeName, int episode, int season, double rating, string firstAired, bool watched, int episodeId)
        {
            this._episodeName = episodeName;
            this._episode = episode;
            this._firstAired = firstAired;
            this._season = season;
            this._rating = rating;
            this._watched = watched;
            this._episodeId = episodeId;
        }
        
        
    }
}
