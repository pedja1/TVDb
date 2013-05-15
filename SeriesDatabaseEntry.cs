namespace TVDb
{
    class SeriesDatabaseEntry
    {
        public string SeriesName { get; set; }
        public string FirstAired { get; set; }
        public string ImdbId { get; set; }
        public string Overview { get; set; }
        public double Rating { get; set; }
        public int SeriesId { get; set; }
        public string Language { get; set; }
        public string BannerLocal { get; set; }
        public string BannerUrl { get; set; }
        public string FanartLocal { get; set; }
        public string FanartUrl { get; set; }
        public string PosterLocal { get; set; }
        public string PosterUrl { get; set; }
        public string Network { get; set; }
        public int Runtime { get; set; }
        public string Status { get; set; }
        public bool Ignore { get; set; }
        public bool Hide { get; set; }
        public string Updated { get; set; }

        public SeriesDatabaseEntry(string seriesName, string firstAired, string imdbId, string overview, 
            double rating, int seriesId, string language, string bannerLocal, string bannerUrl,
            string posterLocal, string posterUrl, string fanartLocal, string fanartUrl, string network, 
            int runtime, string status, bool ignore, bool hide, string updated)
        {
            SeriesName = seriesName;
            Overview = overview;
            FirstAired = firstAired;
            ImdbId = imdbId;
            Rating = rating;
            SeriesId = seriesId;
            Language = language;
            BannerLocal = bannerLocal;
            BannerUrl = bannerUrl;
            PosterLocal = posterLocal;
            PosterUrl = posterUrl;
            FanartLocal = fanartLocal;
            FanartUrl = fanartUrl;
            Network = network;
            Runtime = runtime;
            Status = status;
            Ignore = ignore;
            Hide = hide;
            Updated = updated;
        }
        public SeriesDatabaseEntry()
        {
        }
    }
}
