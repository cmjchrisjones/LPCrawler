using System.Threading.Tasks;
using AngleSharp.Dom;
using LPRecordPriceFinder;

public interface IScraper { 
    public Task<IDocument> Scrape (RecordInfo recordInfo);
}