using System;
using System.Configuration;
using System.IO;

namespace homers01
{
    class Program
    {
        static void Main(string[] args)
        {
            var battingStatsPath = Path.Combine("stats", "Batting.csv");
            var currentYear = Int32.Parse(ConfigurationManager.AppSettings["homers.mostCurrentYear"]);
            var yearsBack = Int32.Parse(ConfigurationManager.AppSettings["homers.yearsBack"]);

            var battingReader = new CsvBattingStatsReader();
            var battingStats = battingReader.GetBattingStatistics(battingStatsPath, currentYear, yearsBack);
            var statCount = battingStats.Count;
            Console.WriteLine(String.Format("{0} stat lines found.", statCount.ToString("#,##0")));

            Console.ReadLine();
        }
    }
}
