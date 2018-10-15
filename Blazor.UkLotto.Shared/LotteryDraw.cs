using System;

namespace Blazor.UkLotto.Shared
{
    public class LotteryDraw
    {
        public int Number { get; set; }

        public DateTime Date { get; set; }

        public string MachineName { get; set; }

        public LotteryBall[] Balls { get; set; }

        public LotteryBall BonusBall { get; set; }
    }
}
