using LotteryDraw.Models.Interfaces.Attributes.Invariant;

namespace LotteryDraw.Models.Interfaces
{
    public interface ILotteryDraw : INameInvariant, IDescriptionInvariant, IDateOfDrawInvariant,
        ITotalPrimaryNumbersInvariant, IRangePrimaryInvariant, ITotalSecondaryNumbersInvariant,
        IRangeSecondaryInvariant
    {
    }
}
