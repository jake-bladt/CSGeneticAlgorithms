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

            // Create one predicter for testing.
            var algo = new PredictiveAlgorithm(new double[] { 1.0, 0.5, 0.25 });
            var runner = new AlgorithmRunner(algo);
            var hrPredictions = runner.PredictForYear(currentYear, groupedBattingStats);

            var tester = new FitnessTester();
            var fitness = tester.GetFitness(hrPredictions, groupedBattingStats, currentYear);
            Console.WriteLine(String.Format("{0} is {1}% accurate.",  algo.ToString(), fitness.ToString("#0.00")));

            Console.ReadLine();
        }
    }
}
