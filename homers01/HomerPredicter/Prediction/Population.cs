using System;
using System.Collections.Generic;

namespace HomerPredicter.Prediction
{
    public class Population : List<PredictiveAlgorithm>
    {
        public Population() : base()
        {
            for(int i = 0; i <= 100; i++)
            {
                for(int j = 0; j <= 100; j++)
                {
                    var newAlgo = new PredictiveAlgorithm(new double[] { 100.0, i / 100.0, j / 100.0 });
                    this.Add(newAlgo);
                }
            }
        }
    }
}
