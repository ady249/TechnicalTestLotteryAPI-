using System.Collections.Generic;
using LotteryDraw.Models.Interfaces.Models;

namespace LotteryDraw.Models.Interfaces.Response
{
    public interface ISimpleResponseWithData : ISimpleResponse
    {
        IEnumerable<ILotteryDrawWithResults> LotteryDraws { get; }
    }
}
