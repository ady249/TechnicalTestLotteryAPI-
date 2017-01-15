using System.Linq;
using LotteryDraw.BusinessLogic.Interfaces;
using LotteryDraw.Models.Interfaces.Models;

namespace LotteryDraw.BusinessLogic.WinningNumberRules.Primary
{
    public class IsPrimaryWithinRange : IWinningNumbersRule
    {
        private ILotteryDrawWithResults _lotteryDrawWithResults;
        private IWinningNumbers _winningNumbers;

        public int Sequence => 2;

        public bool HasError { get; private set; }
        public string ErrorMessage => $"Primary winning numbers mismatch. Expected {_lotteryDrawWithResults?.TotalPrimaryNumbers ?? 0} but was given {_winningNumbers?.WinningPrimaryNumbers?.Count() ?? 0}";

        public void Execute(ILotteryDrawWithResults lotteryDrawWithResults, IWinningNumbers winningNumbers)
        {
            _lotteryDrawWithResults = lotteryDrawWithResults;
            _winningNumbers = winningNumbers;

            HasError = lotteryDrawWithResults?.TotalPrimaryNumbers == null ||
                       _lotteryDrawWithResults?.TotalPrimaryNumbers !=
                       winningNumbers?.WinningPrimaryNumbers?.Count();
        }
    }
}
