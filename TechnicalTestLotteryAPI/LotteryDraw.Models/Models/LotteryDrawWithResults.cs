using System;
using System.Collections.Generic;
using LotteryDraw.Models.Interfaces.Attributes.Invariant;
using LotteryDraw.Models.Interfaces.Models;

namespace LotteryDraw.Models.Models
{
    public class LotteryDrawWithResults : ILotteryDrawWithResults
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfDraw { get; set; }
        public int TotalPrimaryNumbers { get; set; }
        public IRangeInvariant RangePrimary { get; set; }
        public int TotalSecondaryNumbers { get; set; }
        public IRangeInvariant RangeSecondary { get; set; }
        public IEnumerable<int> WinningPrimaryNumbers { get; set; }
        public IEnumerable<int> WinningSecondaryNumbers { get; set; }
    }
}
