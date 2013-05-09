using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVDb
{
    class SearchResultsEntry
    {

        string name;
        string lang;
        string overview;
        int seriesId;

        public SearchResultsEntry(string name, string lang, string overview, int seriesId) {
            this.name = name;
            this.overview = overview;
            this.lang= lang;
            this.seriesId = seriesId;
        }

        public string getName() {
            return name;
        }
        public string getLang()
        {
            return lang;
        }
        public string getOverview()
        {
            return overview;
        }
        public int getSeriesId() 
        {
            return seriesId;
        }
    }
}
