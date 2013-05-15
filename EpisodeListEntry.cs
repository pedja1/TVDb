namespace TVDb
{
    class EpisodeListEntry
    {
        //parameters
        public string EpisodeName { get; set; }
        public int Episode { get; set; }
        public int Season { get; set; }
        public string FirstAired { get; set; }
        public double Rating { get; set; }
        public bool Watched { get; set; }
        public int EpisodeId { get; set; }
        //Constructors
        public EpisodeListEntry()
        {
        }
        public EpisodeListEntry(string episodeName, int episode, int season, double rating, string firstAired, bool watched, int episodeId)
        {
            EpisodeName = episodeName;
            Episode = episode;
            FirstAired = firstAired;
            Season = season;
            Rating = rating;
            Watched = watched;
            EpisodeId = episodeId;
        }
        
        
    }
}
