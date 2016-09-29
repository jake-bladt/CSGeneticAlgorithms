using System;
using System.Configuration;
using System.IO;

using HomerPredicter.StatReaders;
using HomerPredicter.StatManagers;

using HomerPredicter.Fitness;
using HomerPredicter.Prediction;

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
            var battingStatMan = new BattingStatisticsManager();
            var groupedBattingStats = battingStatMan.SortBattingStatistics(battingStats);

            Console.WriteLine(String.Format("{0} stat lines found for {1} players.", 
                battingStats.Count.ToString("#,##0"), groupedBattingStats.Count.ToString("#,##0")));

            // Test the whole population at 1% intervals.
            var pop = new Population();
            var runner = new FitnessTestRunner();
            runner.Run(groupedBattingStats, currentYear, OutputMessage);

            Console.ReadLine();
        }

        static void OutputMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
