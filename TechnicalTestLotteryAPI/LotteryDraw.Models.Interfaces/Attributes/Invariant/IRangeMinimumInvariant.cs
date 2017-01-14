using LotteryDraw.Models.Interfaces.Attributes.Covariant;

namespace LotteryDraw.Models.Interfaces.Attributes.Invariant
{
    public interface IRangeMinimumInvariant : IRangeMinimum
    {
        new int Minimum { get; set; }
    }
}
