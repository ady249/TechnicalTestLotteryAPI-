using System.Collections.Generic;
using LotteryDraw.Models.Interfaces.Models;

namespace LotteryDraw.Models.Interfaces.Storage
{
    public interface IStorageList
    {
        IList<ILotteryDrawWithResults> Storage { get; }
    }
}
