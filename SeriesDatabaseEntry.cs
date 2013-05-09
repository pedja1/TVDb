using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVDb
{
    class SeriesDatabaseEntry
    {
        private string _seriesName;
        private string _firstAired;
        private string _imdbId;
        private string _overview;
        private double _rating;
        private int _seriesId;
        private string _language;
        private string _bannerLocal;
        private string _bannerUrl;
        private string _fanartLocal;
        private string _fanartUrl;
        private string _posterLocal;
        private string _posterUrl;
        private string _network;
        private int _runtime;
        private string _status;
        private bool _ignore;
        private bool _hide;

        public string seriesName { get { return _seriesName; } set { _seriesName = value; } }
        public string firstAired { get { return _firstAired; } set { _firstAired = value; } }
        public string imdbId { get { return _imdbId; } set { _imdbId = value; } }
        public string overview { get { return _overview; } set { _overview = value; } }
        public double rating { get { return _rating; } set { _rating = value; } }
        public int seriesId { get { return _seriesId; } set { _seriesId = value; } }
        public string language { get { return _language; } set { _language = value; } }
        public string bannerLocal { get { return _bannerLocal; } set { _bannerLocal = value; } }
        public string bannerUrl { get { return _bannerUrl; } set { _bannerUrl = value; } }
        public string fanartLocal { get { return _fanartLocal; } set { _fanartLocal = value; } }
        public string fanartUrl { get { return _fanartUrl; } set { _fanartUrl = value; } }
        public string posterLocal { get { return _posterLocal; } set { _posterLocal = value; } }
        public string posterUrl { get { return _posterUrl; } set { _posterUrl = value; } }
        public string network { get { return _network; } set { _network = value; } }
        public int runtime { get { return _runtime; } set { _runtime = value; } }
        public string status { get { return _status; } set { _status = value; } }
        public bool ignore { get { return _ignore; } set { _ignore = value; } }
        public bool hide { get { return _hide; } set { _hide = value; } }

        public SeriesDatabaseEntry(string seriesName, string firstAired, string imdbId, string overview, 
            double rating, int seriesId, string language, string bannerLocal, string bannerUrl,
            string posterLocal, string posterUrl, string fanartLocal, string fanartUrl, string network, 
            int runtime, string status, bool ignore, bool hide)
        {
            this._seriesName = seriesName;
            this._overview = overview;
            this._firstAired = firstAired;
            this._imdbId = imdbId;
            this._rating = rating;
            this._seriesId = seriesId;
            this._language = language;
            this._bannerLocal = bannerLocal;
            this._bannerUrl = bannerUrl;
            this._posterLocal = posterLocal;
            this._posterUrl = posterUrl;
            this._fanartLocal = fanartLocal;
            this._fanartUrl = fanartUrl;
            this._network = network;
            this._runtime = runtime;
            this._status = status;
            this._ignore = ignore;
            this._hide = hide;
        }
        public SeriesDatabaseEntry()
        {
        }
    }
}
