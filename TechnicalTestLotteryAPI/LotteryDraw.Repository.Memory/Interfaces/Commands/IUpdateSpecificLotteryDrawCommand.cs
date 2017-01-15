using LotteryDraw.ErrorHandler.Interfaces.Attributes;
using LotteryDraw.Models.Interfaces.Models;

namespace LotteryDraw.Repository.Memory.Interfaces.Commands
{
    public interface IUpdateSpecificLotteryDrawCommand : IHasError, IErrorMessage
    {
        void Execute(ILotteryDrawWithResults data, IWinningNumbers winningNumbers);
    }
}
