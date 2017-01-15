using System.Collections.Generic;
using LotteryDraw.Data.Interfaces.Factories;
using LotteryDraw.Models.Interfaces.Models;

namespace LotteryDraw.Repository.Memory.Interfaces
{
    public interface ILotteryDrawWithResultsListFactory : IGenericFactory<IList<ILotteryDrawWithResults>>
    {
    }
}
