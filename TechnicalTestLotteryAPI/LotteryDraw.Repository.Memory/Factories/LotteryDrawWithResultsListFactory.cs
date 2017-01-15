using System.Collections.Generic;
using LotteryDraw.Models.Interfaces.Models;
using LotteryDraw.Repository.Memory.Interfaces;

namespace LotteryDraw.Repository.Memory.Factories
{
    public class LotteryDrawWithResultsListFactory : ILotteryDrawWithResultsListFactory
    {
        public IList<ILotteryDrawWithResults> Create()
        {
            return new List<ILotteryDrawWithResults>();
        }
    }
}
