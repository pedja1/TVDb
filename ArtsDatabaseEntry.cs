using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVDb
{
    class ArtsDatabaseEntry
    {
        public string BannerLocal { get; set; }

        public ArtsDatabaseEntry( string bannerLocal)
        {
            BannerLocal = bannerLocal;
        }
        public ArtsDatabaseEntry()
        {
        }
    }
}
