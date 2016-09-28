using System;
using System.Collections.Generic;
using System.Linq;

namespace homers01
{
    public class CsvBattingStatsReader : BaseLahmanCSVReader
    {
        public List<BattingStatistics> GetBattingStatistics(string filePath, int mostRecentYear, int yearsBack)
        {
            var ret = new List<BattingStatistics>();

            var startYear = mostRecentYear - yearsBack;
            var allStats = ParseFile(filePath);
            allStats.ForEach(line =>
            {
                var lineYear = Int32.Parse(line["yearID"]);
                if(lineYear <= mostRecentYear && lineYear >= startYear)
                {
                    var lineStat = new BattingStatistics
                    {
                        Year = lineYear,
                        PlayerKey = line["playerID"],
                        HomeRuns = Int32.Parse(line["HR"])
                    };
                    ret.Add(lineStat);
                }
            });

            return ret;
        }


    }
}
