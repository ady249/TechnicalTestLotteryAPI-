using System.Collections.Generic;

namespace LotteryDraw.Models.Interfaces.Attributes.Invariant
{
    public interface IWinningSecondaryNumbersInvariant
    {
        IEnumerable<int> WinningSecondaryNumbers { get; set; }
    }
}
