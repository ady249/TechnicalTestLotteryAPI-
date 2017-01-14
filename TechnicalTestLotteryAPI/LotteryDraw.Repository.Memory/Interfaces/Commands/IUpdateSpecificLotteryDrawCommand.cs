using LotteryDraw.Models.Interfaces.Models;
using LotteryDraw.Repository.Memory.Interfaces.Commands.Base;

namespace LotteryDraw.Repository.Memory.Interfaces.Commands
{
    public interface IUpdateSpecificLotteryDrawCommand : ICommand
    {
        void Execute(ILotteryDrawWithResults data, IWinningNumbers winningNumbers);
    }
}
