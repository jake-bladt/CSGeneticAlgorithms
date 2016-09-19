using System;

namespace allones
{
    public class Individual
    {
        public int[] Chromosomes { get; set; }
        public double Fitness { get; set; }
        public int ChromosomeLength { get
            {
                return Chromosomes.Length;
            } }

        public Individual(int[] chromosomes)
        {
            Chromosomes = chromosomes;
            Fitness = -1.0;
        }

        public Individual(int chromosomeLength)
        {
            Chromosomes = new int[chromosomeLength];
            // Randomly choose 1s and 0s
            for(int i = 0; i < chromosomeLength; i++)
            {
                Chromosomes[i] = new Random().NextDouble() >= 0.5 ? 1 : 0;
            }
        }


    }
}
