using System;
using System.Collections.Generic;

namespace HomerPredicter.Models
{
    public class PlayerBattingStatisticsByYear
    {
        public PlayerBattingStatisticsByYear()
        {
            BattingByYear = new Dictionary<int, BattingStatistics>();
        }

        public PlayerInfo PlayerInformation { get; set; }
        public Dictionary<int, BattingStatistics> BattingByYear { get; set; }
    }
}
