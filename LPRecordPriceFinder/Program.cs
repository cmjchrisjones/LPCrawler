using System;

namespace LPRecordPriceFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var sr = new SpreadsheetReader();

            var albums = sr.OpenFile("LP Records For Sale.txt");

            Console.ReadKey();
        }
    }
}
