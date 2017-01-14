using System.Collections.Generic;
using LotteryDraw.Models.Interfaces.Attributes.Covariant;

namespace LotteryDraw.Models.Interfaces.Attributes.Invariant
{
    public interface IWinningPrimaryNumbersInvariant : IWinningPrimaryNumbers
    {
        new IEnumerable<int> WinningPrimaryNumbers { get; set; }
    }
}
