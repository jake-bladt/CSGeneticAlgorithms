using System;

using HomerPredicter.Models;

namespace HomerPredicter.Prediction
{
    public class PredictiveAlgorithm
    {
        protected double[] _Weights;

        // In this first iteration, the only information the predictive algorithm will use is the number of home runs 
        // hit in previous years and the only tool it will apply is weighted average.
        //
        // The weight of the 0th year previous will always be 1.00.
        public PredictiveAlgorithm(double[] weights)
        {
            _Weights = weights;
        }

        public double PredictHomerunsForYear(int year, PlayerBattingStatisticsByYear stats)
        {
            var totalWeight = 0.0;
            double totalEstimate = 0.0;
            for (int i = 0; i < _Weights.Length; i++)
            {
                var targetYear = year - i - 1;
                if (stats.BattingByYear.ContainsKey(targetYear))
                {
                    totalEstimate += stats.BattingByYear[year - i - 1].HomeRuns * _Weights[i];
                    totalWeight += _Weights[i];
                }
            }
            return totalEstimate / totalWeight;
        }

    }
}
