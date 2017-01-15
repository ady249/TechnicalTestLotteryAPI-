using System.Collections.Generic;
using LotteryDraw.Models.Interfaces.Models;

namespace LotteryDraw.Models.Models
{
    public class WinningNumbers : IWinningNumbers
    {
        public IEnumerable<int> WinningPrimaryNumbers { get; set; }
        public IEnumerable<int> WinningSecondaryNumbers { get; set; }
    }
}
