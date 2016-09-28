using System;
using System.Collections.Generic;

using Shouldly;
using Xunit;

using HomerPredicter.Models;
using HomerPredicter.Prediction;

namespace HomerPredicter.Tests
{
    public class PredictiveAlgorithmTests
    {
        static double[] OnlyLastYear = new double[] { 1.0, 0.0, 0.0 };
        static double[] EquallyImportant = new double[] { 1.0, 1.0, 1.0 };
        static double[] PrettyImportant = new double[] { 1.0, 0.9, 0.8 };
        static double[] NotVeryImportant = new double[] { 1.0, 0.5, 0.25 };

        static PlayerBattingStatisticsByYear Rookie = null;
        static PlayerBattingStatisticsByYear SteadyPower = null;
        static PlayerBattingStatisticsByYear NeverHomers = null;
        static PlayerBattingStatisticsByYear ErraticPower = null;
        static PlayerBattingStatisticsByYear UpAndComing = null;

        static PredictiveAlgorithmTests()
        {
            Rookie = new PlayerBattingStatisticsByYear
            {
                PlayerInformation = new PlayerInfo { Key = "ROOKIE" },
                BattingByYear = new Dictionary<int, BattingStatistics>
                {
                    { 2015, new BattingStatistics { HomeRuns = 20 } },
                    { 2016, new BattingStatistics { HomeRuns = 31 } }
                }
            };

            SteadyPower = new PlayerBattingStatisticsByYear
            {
                PlayerInformation = new PlayerInfo { Key = "STEADY" },
                BattingByYear = new Dictionary<int, BattingStatistics>
                {
                    { 2013, new BattingStatistics { HomeRuns = 40 } },
                    { 2014, new BattingStatistics { HomeRuns = 40 } },
                    { 2015, new BattingStatistics { HomeRuns = 40 } },
                    { 2016, new BattingStatistics { HomeRuns = 40 } }
                }
            };

            NeverHomers = new PlayerBattingStatisticsByYear
            {
                PlayerInformation = new PlayerInfo { Key = "NEVER" },
                BattingByYear = new Dictionary<int, BattingStatistics>
                {
                    { 2013, new BattingStatistics { HomeRuns = 0 } },
                    { 2014, new BattingStatistics { HomeRuns = 0 } },
                    { 2015, new BattingStatistics { HomeRuns = 0 } },
                    { 2016, new BattingStatistics { HomeRuns = 0 } }
                }
            };

            ErraticPower = new PlayerBattingStatisticsByYear
            {
                PlayerInformation = new PlayerInfo { Key = "RATIC" },
                BattingByYear = new Dictionary<int, BattingStatistics>
                {
                    { 2013, new BattingStatistics { HomeRuns = 17 } },
                    { 2014, new BattingStatistics { HomeRuns = 49 } },
                    { 2015, new BattingStatistics { HomeRuns = 33 } },
                    { 2016, new BattingStatistics { HomeRuns = 33 } }
                }
            };

            UpAndComing = new PlayerBattingStatisticsByYear
            {
                PlayerInformation = new PlayerInfo { Key = "STEADY" },
                BattingByYear = new Dictionary<int, BattingStatistics>
                {
                    { 2013, new BattingStatistics { HomeRuns = 10 } },
                    { 2014, new BattingStatistics { HomeRuns = 20 } },
                    { 2015, new BattingStatistics { HomeRuns = 30 } },
                    { 2016, new BattingStatistics { HomeRuns = 40 } }
                }
            };

        }

        [Fact]
        public void TestRookieOnSingleYear()
        {
            var algo = new PredictiveAlgorithm(OnlyLastYear);
            var hrs = algo.PredictHomerunsForYear(2016, Rookie);
            hrs.ShouldBe(20.0, 0.01);
        }

        [Fact]
        public void TestRookieOnEqualWeighting()
        {
            var algo = new PredictiveAlgorithm(EquallyImportant);
            var hrs = algo.PredictHomerunsForYear(2016, Rookie);
            hrs.ShouldBe(20.0, 0.01);
        }

        [Fact]
        public void TestRookieOnPrettyImportant()
        {
            var algo = new PredictiveAlgorithm(PrettyImportant);
            var hrs = algo.PredictHomerunsForYear(2016, Rookie);
            hrs.ShouldBe(20.0, 0.01);
        }

        [Fact]
        public void TestRookieOnLowWeighting()
        {
            var algo = new PredictiveAlgorithm(NotVeryImportant);
            var hrs = algo.PredictHomerunsForYear(2016, Rookie);
            hrs.ShouldBe(20.0, 0.01);
        }

        [Fact]
        public void TestNoPowerOnSingleYear()
        {
            var algo = new PredictiveAlgorithm(OnlyLastYear);
            var hrs = algo.PredictHomerunsForYear(2016, NeverHomers);
            hrs.ShouldBe(0.0, 0.01);
        }

        [Fact]
        public void TestNoPowerOnEqualWeighting()
        {
            var algo = new PredictiveAlgorithm(EquallyImportant);
            var hrs = algo.PredictHomerunsForYear(2016, NeverHomers);
            hrs.ShouldBe(0.0, 0.01);
        }

        [Fact]
        public void TestNoPowerOnPrettyImportant()
        {
            var algo = new PredictiveAlgorithm(PrettyImportant);
            var hrs = algo.PredictHomerunsForYear(2016, NeverHomers);
            hrs.ShouldBe(0.0, 0.01);
        }

        [Fact]
        public void TestNoPowerOnLowWeighting()
        {
            var algo = new PredictiveAlgorithm(NotVeryImportant);
            var hrs = algo.PredictHomerunsForYear(2016, NeverHomers);
            hrs.ShouldBe(0.0, 0.01);
        }

        [Fact]
        public void TestSteadyPowerOnSingleYear()
        {
            var algo = new PredictiveAlgorithm(OnlyLastYear);
            var hrs = algo.PredictHomerunsForYear(2016, SteadyPower);
            hrs.ShouldBe(40.0, 0.01);
        }

        [Fact]
        public void TestSteadyPowerOnEqualWeighting()
        {
            var algo = new PredictiveAlgorithm(EquallyImportant);
            var hrs = algo.PredictHomerunsForYear(2016, SteadyPower);
            hrs.ShouldBe(40.0, 0.01);
        }

        [Fact]
        public void TestSteadyPowerOnPrettyImportant()
        {
            var algo = new PredictiveAlgorithm(PrettyImportant);
            var hrs = algo.PredictHomerunsForYear(2016, SteadyPower);
            hrs.ShouldBe(40.0, 0.01);
        }

        [Fact]
        public void TestSteadyPowerOnLowWeighting()
        {
            var algo = new PredictiveAlgorithm(NotVeryImportant);
            var hrs = algo.PredictHomerunsForYear(2016, SteadyPower);
            hrs.ShouldBe(40.0, 0.01);
        }

        [Fact]
        public void TestErraticPowerOnSingleYear()
        {
            var algo = new PredictiveAlgorithm(OnlyLastYear);
            var hrs = algo.PredictHomerunsForYear(2016, ErraticPower);
            hrs.ShouldBe(33.0, 0.01);
        }

        [Fact]
        public void TestErraticPowerOnEqualWeighting()
        {
            var algo = new PredictiveAlgorithm(EquallyImportant);
            var hrs = algo.PredictHomerunsForYear(2016, ErraticPower);
            hrs.ShouldBe(33.0, 0.01);
        }

        [Fact]
        public void TestErraticPowerOnPrettyImportant()
        {
            var algo = new PredictiveAlgorithm(PrettyImportant);
            var hrs = algo.PredictHomerunsForYear(2016, ErraticPower);
            hrs.ShouldBe(33.59, 0.01);
        }

        [Fact]
        public void TestErraticPowerOnLowWeighting()
        {
            var algo = new PredictiveAlgorithm(NotVeryImportant);
            var hrs = algo.PredictHomerunsForYear(2016, ErraticPower);
            hrs.ShouldBe(35.29, 0.01);
        }


    }
}
