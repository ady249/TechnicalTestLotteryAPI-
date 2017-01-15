using System.Collections.Generic;

namespace LotteryDraw.Models.Interfaces.Attributes.Invariant
{
    public interface IWinningPrimaryNumbersInvariant
    {
        IEnumerable<int> WinningPrimaryNumbers { get; set; }
    }
}
