using LotteryDraw.Models.Interfaces.Attributes.Invariant;

namespace LotteryDraw.Models.Models
{
    public class RangePrimary : IRangeInvariant
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
    }
}
