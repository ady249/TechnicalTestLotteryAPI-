using System;
using LotteryDraw.Models.Interfaces.Attributes.Covariant;

namespace LotteryDraw.Models.Interfaces.Attributes.Invariant
{
    public interface IDateOfDrawInvariant : IDateOfDraw
    {
        new DateTime DateOfDraw { get; set; }
    }
}
