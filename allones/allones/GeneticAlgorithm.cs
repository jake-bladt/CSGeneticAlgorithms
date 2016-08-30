using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allones
{
    public class GeneticAlgorithm
    {
        public int PopulationSize { get; protected set;  }
        public double MutationRate { get; protected set;  }
        public double CrossoverRate { get; protected set;  }
        public int ElitismCount { get; protected set; }

        public GeneticAlgorithm(int ps, double mr, double cr, int ec)
        {
            PopulationSize = ps;
            MutationRate = mr;
            CrossoverRate = cr;
            ElitismCount = ec;
        }

    }
}
