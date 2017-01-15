using LotteryDraw.Models.Interfaces.Models;

namespace LotteryDraw.Repository.Interfaces.Methods
{
    public interface IUpdateLotteryDraw
    {
        void Update(string name, IWinningNumbers winningNumbers);
    }
}
