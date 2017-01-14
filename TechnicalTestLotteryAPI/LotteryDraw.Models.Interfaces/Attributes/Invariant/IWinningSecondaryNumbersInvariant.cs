using System.Collections.Generic;
using LotteryDraw.Models.Interfaces.Attributes.Covariant;

namespace LotteryDraw.Models.Interfaces.Attributes.Invariant
{
    public interface IWinningSecondaryNumbersInvariant : IWinningSecondaryNumbers
    {
        new IEnumerable<int> WinningSecondaryNumbers { get; set; }
    }
}
