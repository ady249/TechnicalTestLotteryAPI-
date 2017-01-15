using LotteryDraw.Command.Interfaces.Attributes;
using LotteryDraw.ErrorHandler.Interfaces.Attributes;
using LotteryDraw.Models.Interfaces.Models;

namespace LotteryDraw.BusinessLogic.Interfaces
{
    public interface IRule : ISequence, IHasError, IErrorMessage
    {
        void Execute(ILotteryDrawWithResults lotteryDrawWithResults, IWinningNumbers winningNumbers);
    }
}
