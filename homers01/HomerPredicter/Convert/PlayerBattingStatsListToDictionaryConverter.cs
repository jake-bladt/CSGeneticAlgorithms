using System;
using System.Collections.Generic;

using HomerPredicter.Models;

namespace HomerPredicter.Convert
{
    public class PlayerBattingStatsListToDictionaryConverter
    {
        public Dictionary<String, PlayerBattingStatisticsByYear> Convert(List<PlayerBattingStatisticsByYear> list)
        {
            var ret = new Dictionary<String, PlayerBattingStatisticsByYear>();
            list.ForEach(stat => ret[stat.PlayerInformation.Key] = stat);
            return ret;
        }
    }
}
