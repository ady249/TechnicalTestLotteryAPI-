using System.Collections.Generic;

namespace LotteryDraw.Models.Interfaces.Attributes.Covariant
{
    public interface IWinningPrimaryNumbers
    {
        IEnumerable<int> WinningPrimaryNumbers { get; }
    }
}
