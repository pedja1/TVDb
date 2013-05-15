namespace TVDb
{
    class SearchResultsEntry
    {
        readonly string _name;
        readonly string _lang;
        readonly string _overview;
        readonly int _seriesId;

        public SearchResultsEntry(string name, string lang, string overview, int seriesId) {
            _name = name;
            _overview = overview;
            _lang= lang;
            _seriesId = seriesId;
        }

        public string GetName() {
            return _name;
        }
        public string GetLang()
        {
            return _lang;
        }
        public string GetOverview()
        {
            return _overview;
        }
        public int GetSeriesId() 
        {
            return _seriesId;
        }
    }
}
