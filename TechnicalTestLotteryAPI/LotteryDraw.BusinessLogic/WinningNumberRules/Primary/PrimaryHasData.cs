using System.Linq;
using LotteryDraw.BusinessLogic.Interfaces;
using LotteryDraw.Models.Interfaces.Models;

namespace LotteryDraw.BusinessLogic.WinningNumberRules.Primary
{
    public class PrimaryHasData : IWinningNumbersRule
    {
        public int Sequence => 1;

        public bool HasError { get; private set; }
        public string ErrorMessage => "Primary winning data has not been provided.";

        public void Execute(ILotteryDrawWithResults lotteryDrawWithResults, IWinningNumbers winningNumbers)
        {
            HasError = lotteryDrawWithResults == null || !(winningNumbers?.WinningPrimaryNumbers?.Any() ?? false);
        }
    }
}
