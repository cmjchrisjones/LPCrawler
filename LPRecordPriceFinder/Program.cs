using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using LPRecordPriceFinder.WebScrapers.Discogs;

namespace LPRecordPriceFinder {
    class Program {
        static async Task Main (string[] args) {
            var isOSX = RuntimeInformation.IsOSPlatform (OSPlatform.OSX);
            OSPlatform platform;
            if (RuntimeInformation.IsOSPlatform (OSPlatform.OSX)) {
                platform = OSPlatform.OSX;
            }
            if (RuntimeInformation.IsOSPlatform (OSPlatform.Windows)) {
                platform = OSPlatform.Windows;
            }
            if (RuntimeInformation.IsOSPlatform (OSPlatform.Linux)) {
                platform = OSPlatform.Linux;
            }

            Console.WriteLine ($"Current: {RuntimeInformation.OSDescription}");
            Console.WriteLine ($"Current: {RuntimeInformation.OSArchitecture}");
            Console.WriteLine ($"Is It OSX?: {isOSX}");
            var sr = new SpreadsheetReader ();

            var albums = sr.OpenFile ("LP Records For Sale.txt");
            DoTheDiscogAsync (albums[4], platform);
        }
        public static async Task DoTheDiscogAsync (RecordInfo recordInfo, OSPlatform platform) {
            var x = new DiscogResult ();

            await Task.Run (() => x.Scrape (recordInfo, platform));
        }
    }
}