using System.Linq;
using LotteryDraw.BusinessLogic.Interfaces;
using LotteryDraw.Models.Interfaces.Models;

namespace LotteryDraw.BusinessLogic.WinningNumberRules.Secondary
{
    public class IsSecondaryWithinRange : IWinningNumbersRule
    {
        private ILotteryDrawWithResults _lotteryDrawWithResults;
        private IWinningNumbers _winningNumbers;

        public int Sequence => 5;

        public bool HasError { get; private set; }
        public string ErrorMessage => $"Secondary winning numbers mismatch. Expected {_lotteryDrawWithResults?.TotalSecondaryNumbers ?? 0} but was given {_winningNumbers?.WinningSecondaryNumbers?.Count() ?? 0}";

        public void Execute(ILotteryDrawWithResults lotteryDrawWithResults, IWinningNumbers winningNumbers)
        {
            _lotteryDrawWithResults = lotteryDrawWithResults;
            _winningNumbers = winningNumbers;

            HasError = lotteryDrawWithResults?.TotalSecondaryNumbers == null ||
                       _lotteryDrawWithResults?.TotalSecondaryNumbers !=
                       winningNumbers?.WinningSecondaryNumbers?.Count();
        }
    }
}
