using System;
using System.Threading.Tasks;
using LPRecordPriceFinder.WebScrapers.Discogs;

namespace LPRecordPriceFinder {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");

            var sr = new SpreadsheetReader ();

            var albums = sr.OpenFile ("LP Records For Sale.txt");
            DoTheDiscogAsync(albums[4]);

            Console.Write ("Press a key");
            Console.Read();

        }

        public static async Task DoTheDiscogAsync(RecordInfo recordInfo){
            var x = new DiscogResult();
            
            await Task.Run(() => x.Scrape(recordInfo));
        }
    }
}