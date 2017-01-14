using LotteryDraw.Models.Interfaces.Attributes.Covariant;

namespace LotteryDraw.Models.Interfaces.Attributes.Invariant
{
    public interface ITotalPrimaryNumbersInvariant : ITotalPrimaryNumbers
    {
        new int TotalPrimaryNumbers { get; set; }
    }
}
