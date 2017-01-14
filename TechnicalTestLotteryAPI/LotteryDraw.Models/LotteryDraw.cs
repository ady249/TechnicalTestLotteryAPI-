using System;
using LotteryDraw.Models.Interfaces;
using LotteryDraw.Models.Interfaces.Attributes.Invariant;
using Newtonsoft.Json;

namespace LotteryDraw.Models
{
    public class LotteryDraw : ILotteryDraw
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfDraw { get; set; }
        public int TotalPrimaryNumbers { get; set; }
        public IRangeInvariant RangePrimary { get; set; }
        public int TotalSecondaryNumbers { get; set; }
        public IRangeInvariant RangeSecondary { get; set; }

        [JsonConstructor]
        public LotteryDraw(RangePrimary rangePrimary, RangeSecondary rangeSecondary)
        {
            RangePrimary = rangePrimary;
            RangeSecondary = rangeSecondary;
        }
    }
}
