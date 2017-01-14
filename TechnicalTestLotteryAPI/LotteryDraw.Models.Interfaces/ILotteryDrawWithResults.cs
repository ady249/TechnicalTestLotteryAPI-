using LotteryDraw.Models.Interfaces.Attributes.Invariant;

namespace LotteryDraw.Models.Interfaces
{
    public interface ILotteryDrawWithResults : ILotteryDraw, IWinningPrimaryNumbersInvariant,
        IWinningSecondaryNumbersInvariant
    {
    }
}
