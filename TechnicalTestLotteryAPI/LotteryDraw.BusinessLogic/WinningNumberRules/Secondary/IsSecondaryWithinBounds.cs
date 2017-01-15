using LotteryDraw.BusinessLogic.Interfaces;
using LotteryDraw.Models.Interfaces.Models;

namespace LotteryDraw.BusinessLogic.WinningNumberRules.Secondary
{
    public class IsSecondaryWithinBounds : IWinningNumbersRule
    {
        public int Sequence => 6;

        public bool HasError { get; private set; }
        public string ErrorMessage { get; private set; }

        public void Execute(ILotteryDrawWithResults lotteryDrawWithResults, IWinningNumbers winningNumbers)
        {
            HasError = lotteryDrawWithResults == null || winningNumbers?.WinningSecondaryNumbers == null;
            if (HasError)
                return;

            var pointer = 0;

            foreach (var result in winningNumbers.WinningSecondaryNumbers)
            {
                HasError = result < (lotteryDrawWithResults.RangeSecondary?.Minimum ?? 0) ||
                           result > (lotteryDrawWithResults.RangeSecondary?.Maximum ?? 0);

                var isOutsideMinimum = result < (lotteryDrawWithResults.RangeSecondary?.Minimum ?? 0);

                if (HasError)
                {
                    ErrorMessage =
                        $"Secondary numbers value {result} @ position {pointer} is outside the {(isOutsideMinimum ? "minimum" : "maximum")} bounds of {(isOutsideMinimum ? lotteryDrawWithResults.RangeSecondary?.Minimum ?? 0 : lotteryDrawWithResults.RangeSecondary?.Maximum ?? 0)}";
                    break;
                }

                pointer++;
            }
        }
    }
}

