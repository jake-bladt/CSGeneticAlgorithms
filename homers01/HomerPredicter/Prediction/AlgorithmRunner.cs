using System;
using System.Collections.Generic;
using System.Linq;

using HomerPredicter.Models;

namespace HomerPredicter.Prediction
{
    public class AlgorithmRunner
    {
        protected PredictiveAlgorithm _Algo;

        public AlgorithmRunner(PredictiveAlgorithm algo)
        {
            _Algo = algo;
        }

        public Dictionary<String, double> PredictForYear(int year, List<PlayerBattingStatisticsByYear> stats)
        {
            var ret = new Dictionary<String, double>();

            stats.ForEach(stat =>
            {
                var newHRs = _Algo.PredictHomerunsForYear(year, stat);
                ret[stat.PlayerInformation.Key] = newHRs;
            });

            return ret;
        }

    }
}
