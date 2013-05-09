using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVDb
{
    class ArtsDatabaseEntry
    {
        private string _bannerLocal;

        public string bannerLocal { get { return _bannerLocal; } set { _bannerLocal = value; } }

        public ArtsDatabaseEntry( string bannerLocal)
        {
            this._bannerLocal = bannerLocal;
        }
        public ArtsDatabaseEntry()
        {
        }
    }
}
