using System;
using System.Collections.Generic;

using HomerPredicter.Models;
using HomerPredicter.Prediction;

namespace HomerPredicter.Fitness
{
    public class FitnessTestRunner
    {
        public void Run(List<PlayerBattingStatisticsByYear> stats, int year, Action<String> reportingCallback)
        {
            var pop = new Population();
            reportingCallback("Full population generated.");

            var tester = new FitnessTester();
            double bestFitness = double.MinValue;

            pop.ForEach(algo =>
            {
                var runner = new AlgorithmRunner(algo);
                var predictions = runner.PredictForYear(year, stats);
                var fitness = tester.GetFitness(predictions, stats, year);
                if(fitness > bestFitness)
                {
                    bestFitness = fitness;
                    reportingCallback(String.Format("{0} is {1}% accurate.", algo.ToString(), fitness.ToString("#0.00")));
                }
            });

            reportingCallback("Done.");

        }
    }
}
