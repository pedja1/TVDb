namespace TVDb
{
    class EpisodeDatabaseEntry
    {
        //Feelds

        //parameters
        public string EpisodeName { get; set; }
        public int Episode { get; set; }
        public int Season { get; set; }
        public string FirstAired { get; set; }
        public string ImdbId { get; set; }
        public string Overview { get; set; }
        public double Rating { get; set; }
        public bool Watched { get; set; }
        public int EpisodeId { get; set; }
        //Constructors
        public EpisodeDatabaseEntry()
        {
        }
        public EpisodeDatabaseEntry(string episodeName, int episode, int season, double rating, string firstAired, string imdbId, string overview, bool watched, int episodeId)
        {
            EpisodeName = episodeName;
            Episode = episode;
            FirstAired = firstAired;
            Season = season;
            Rating = rating;
            Overview = overview;
            ImdbId = imdbId;
            Watched = watched;
            EpisodeId = episodeId;
        }
        
        
    }
}
