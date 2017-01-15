using System.Linq;
using LotteryDraw.BusinessLogic.Interfaces;
using LotteryDraw.Models.Interfaces.Models;

namespace LotteryDraw.BusinessLogic.WinningNumberRules.Secondary
{
    public class SecondaryHasData : IWinningNumbersRule
    {
        public int Sequence => 4;

        public bool HasError { get; private set; }
        public string ErrorMessage => "Secondary winning data has not been provided.";

        public void Execute(ILotteryDrawWithResults lotteryDrawWithResults, IWinningNumbers winningNumbers)
        {
            HasError = lotteryDrawWithResults == null || !(winningNumbers?.WinningSecondaryNumbers?.Any() ?? false);
        }
    }
}
