using System;
using System.Collections.Generic;

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



    }
}
