using LotteryDraw.Models.Interfaces.Attributes.Covariant;

namespace LotteryDraw.Models.Interfaces.Attributes.Invariant
{
    public interface INameInvariant : IName
    {
        new string Name { get; set; }
    }
}
