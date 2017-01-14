using LotteryDraw.Models.Interfaces.Models;

namespace LotteryDraw.Repository.Interfaces.Methods
{
    public interface ICreateLotteryDraw
    {
        void CreateLotteryDrawEntry(ILotteryDraw data);
    }
}
