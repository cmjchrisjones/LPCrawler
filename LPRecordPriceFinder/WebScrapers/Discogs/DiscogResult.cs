using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System;
using System.Threading.Tasks;

namespace LPRecordPriceFinder.WebScrapers.Discogs
{
    public class DiscogResult : DiscogsBase, IScraper
    {

        public async Task<IDocument> Scrape(RecordInfo recordInfo)
        {
            System.Console.WriteLine($"Looking at {recordInfo.Album} by {recordInfo.MainArtist} ({recordInfo.CatalogueNumber}) on Discogs");
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            var document = await context.OpenAsync(this.HomePage);

            Console.WriteLine(document.DocumentElement.OuterHtml);

            var form = document.QuerySelector<IHtmlFormElement>("form");
            var result = await form.SubmitAsync(new { q = recordInfo.CatalogueNumber });

            //var queryInput = form.Elements[this.SearchElement] as IHtmlInputElement;
            //if(queryInput != null)
            //{
            //    queryInput.Value = recordInfo.CatalogueNumber;
            //}


            if (form != null && result != null)
            {
                // Take a screenshot

                var fileName = $"{recordInfo.Album}-by-{recordInfo.MainArtist}-catNo-{recordInfo.CatalogueNumber.Replace('\\', '-').Replace('/','-')}.png";
                ScreenshotHelper.TakesScreenshot(result.DocumentUri, fileName, false);
            }
            return document;


        }
    }
}