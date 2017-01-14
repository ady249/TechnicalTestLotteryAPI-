using LotteryDraw.Models.Interfaces.Models;

namespace LotteryDraw.Repository.Interfaces.Methods
{
    public interface IUpdateLotteryDraw
    {
        void Update(IWinningNumbers winningNumbers, string name);
    }
}
