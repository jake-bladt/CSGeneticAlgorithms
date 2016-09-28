using System;
using System.Collections.Generic;
using System.Linq;

using HomerPredicter.Models;

namespace HomerPredicter.StatManagers
{
    public class BattingStatisticsManager
    {
        public List<PlayerBattingStatisticsByYear> SortBattingStatistics(List<BattingStatistics> stats)
        {
            var ret = new List<PlayerBattingStatisticsByYear>();
            var batByPlayer = stats.GroupBy(bs => bs.PlayerKey);
            batByPlayer.ToList().ForEach((grp) =>
            {
                var player = new PlayerInfo { Key = grp.Key };
                var statSet = new PlayerBattingStatisticsByYear { PlayerInformation = player };
                grp.ToList().ForEach(bs => statSet.BattingByYear[bs.Year] = bs);
                ret.Add(statSet);
            });

            return ret;
        }
    }

}
