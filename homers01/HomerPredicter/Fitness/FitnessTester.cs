using System;
using System.Collections.Generic;
using System.Linq;

using HomerPredicter.Convert;
using HomerPredicter.Models;
using HomerPredicter.Prediction;

namespace HomerPredicter.Fitness
{
    public class FitnessTester
    {
        // The fitness of an algorithm is a measure of how close to the actual number of home runs hit in the most recent year
        // the algorithm would have predicted given numbers from previous years. 
        public double GetFitness(Dictionary<String, double> predictions, List<PlayerBattingStatisticsByYear> stats, int mostRecentYear)
        {
            var statsDict = new PlayerBattingStatsListToDictionaryConverter().Convert(stats);

            double offBy = 0.0;
            double totalRange = 0.0;

            predictions.ToList().ForEach(kvp =>
            {
                var playerId = kvp.Key;
                var predictedHRs = kvp.Value;
                if(statsDict.ContainsKey(playerId) && statsDict[playerId].BattingByYear.ContainsKey(mostRecentYear))
                {
                    var actualHRs = statsDict[playerId].BattingByYear[mostRecentYear].HomeRuns;
                    totalRange += Math.Max(predictedHRs, actualHRs);
                    offBy += Math.Abs(predictedHRs - actualHRs);
                }
            });

            // For really egregious predicitions, off-by can be greater than the total range, leading to a negative fitness number.
            // This is fine.
            return 100.0 * (totalRange - offBy) / totalRange;
        }
    }
}
