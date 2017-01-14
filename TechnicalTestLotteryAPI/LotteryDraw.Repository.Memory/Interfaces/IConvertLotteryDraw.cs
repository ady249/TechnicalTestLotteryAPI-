using LotteryDraw.Models.Interfaces.Models;

namespace LotteryDraw.Repository.Memory.Interfaces
{
    public interface IConvertLotteryDraw
    {
        ILotteryDrawWithResults Convert(ILotteryDraw data);
    }
}
