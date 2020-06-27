using System;
using System.Collections.Generic;
using System.Text;

namespace LPRecordPriceFinder
{
    public class Discogs : IDiscogs
    {
        public DiscogsPricing Price { get; set; }

        public DiscogsPricing Pricing { get; set; }

        public string TracebackURL { get; set; }

        public string SearchElement { get; set; } = "search_q";
        public string Homepage { get; set; } = "https://www.discogs.com/";
    }
}
