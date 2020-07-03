namespace LPRecordPriceFinder.WebScrapers.Discogs
{
    public abstract class DiscogsBase : ISiteSettings
    {
        public string HomePage => "https://www.discogs.com";

        public string SearchElement => "q";
    }
}