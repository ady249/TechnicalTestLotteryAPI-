using LotteryDraw.Models.Interfaces.Attributes.Covariant;

namespace LotteryDraw.Models.Interfaces.Attributes.Invariant
{
    public interface ITotalSecondaryNumbersInvariant : ITotalSecondaryNumbers
    {
        new int TotalSecondaryNumbers { get; set; }
    }
}
