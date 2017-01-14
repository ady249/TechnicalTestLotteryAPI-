using LotteryDraw.Models.Interfaces.Attributes.Covariant;

namespace LotteryDraw.Models.Interfaces.Attributes.Invariant
{
    public interface IRangeMaximumInvariant : IRangeMaximum
    {
        new int Maximum { get; set; }
    }
}
