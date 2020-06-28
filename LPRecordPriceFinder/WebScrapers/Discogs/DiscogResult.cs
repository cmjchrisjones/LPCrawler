using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;

namespace LPRecordPriceFinder.WebScrapers.Discogs {
    public class DiscogResult : DiscogsBase, IScraper {

        public async Task<IDocument> Scrape (RecordInfo recordInfo) {
           System.Console.WriteLine($"Looking at {recordInfo.Album} by {recordInfo.MainArtist} ({recordInfo.CatalogueNumber}) on Discogs");
            var config = Configuration.Default.WithDefaultLoader ();
            var context = BrowsingContext.New (config);

            var document = await context.OpenAsync (this.HomePage);

            Console.WriteLine(document.DocumentElement.OuterHtml);

            return document;
        }
    }
}