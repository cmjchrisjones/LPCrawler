using System.Threading.Tasks;
using AngleSharp.Dom;
using LPRecordPriceFinder;
using System.Runtime.InteropServices;

public interface IScraper { 
    public Task<IDocument> Scrape (RecordInfo recordInfo, OSPlatform platform);
}