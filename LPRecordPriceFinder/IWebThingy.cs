using System;
using System.Collections.Generic;
using System.Text;

namespace LPRecordPriceFinder
{
    public interface IWebThingy
    {
        string Homepage { get; set; }

        string SearchElement { get; set; }

        string TracebackURL { get; set; }

    }
}
