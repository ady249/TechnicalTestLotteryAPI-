using System;
using System.Collections.Generic;
using LotteryDraw.Models.Interfaces;
using LotteryDraw.Models.Interfaces.Models;

namespace LotteryDraw.Repository.Interfaces.Methods
{
    public interface IReadLotteryDraw
    {
        IEnumerable<ILotteryDrawWithResults> Get(DateTime date);
    }
}
