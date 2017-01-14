using System.Collections.Generic;

namespace LotteryDraw.Models.Interfaces.Attributes.Covariant
{
    public interface IWinningSecondaryNumbers
    {
        IEnumerable<int> WinningSecondaryNumbers { get; }
    }
}
