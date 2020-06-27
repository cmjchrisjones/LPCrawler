using System;
using System.Collections.Generic;
using System.Text;

namespace LPRecordPriceFinder
{
    public interface IDiscogs : IWebThingy
    {
        DiscogsPricing Pricing { get; set; }
    }
}
