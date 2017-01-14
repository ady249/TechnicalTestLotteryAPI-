using LotteryDraw.Models.Interfaces.Attributes.Covariant;

namespace LotteryDraw.Models.Interfaces.Attributes.Invariant
{
    public interface IDescriptionInvariant : IDescription
    {
        new string Description { get; set; }
    }
}
