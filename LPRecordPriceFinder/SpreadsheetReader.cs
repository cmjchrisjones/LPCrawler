using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LPRecordPriceFinder
{
    public class SpreadsheetReader
    {
        // Open the file
        public List<RecordInfo> OpenFile(string file)
        {
            var lineNumber = 0;
            var validRecordCount = 0;

            var validAlbumInfoList = new List<RecordInfo>();

            using (var reader = new StreamReader($"{file}"))
            {

                Console.WriteLine("\t BOX # \t Artist \t ALBUM \t Catalogue Number");
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split("\t");

                    if (HasCatalogNumber(values[6]))
                    {
                        var album = new RecordInfo
                        {
                            BoxNumber = values[0],
                            MainArtist = values[1],
                            Album = values[3],
                            CatalogueNumber = values[6]
                        };
                        validAlbumInfoList.Add(album);
                        validRecordCount++;
                        Console.WriteLine($"{lineNumber.ToString().PadLeft(3, '0')} - {album.BoxNumber} - {album.CatalogueNumber} by {album.MainArtist} : {album.Album}");

                    }
                    lineNumber++;
                }
            }
            Console.WriteLine($"Finished - total records with catalogue numbers = {validRecordCount}/{lineNumber}");
            return validAlbumInfoList;
        }

        public bool HasCatalogNumber(string v)
        {
            return !string.IsNullOrEmpty(v);
        }
    }
}