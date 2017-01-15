using LotteryDraw.BusinessLogic.Interfaces;
using LotteryDraw.Models.Interfaces.Models;

namespace LotteryDraw.BusinessLogic.WinningNumberRules.Primary
{
    public class IsPrimaryWithinBounds : IWinningNumbersRule
    {
        public int Sequence => 3;

        public bool HasError { get; private set; }
        public string ErrorMessage { get; private set; }

        public void Execute(ILotteryDrawWithResults lotteryDrawWithResults, IWinningNumbers winningNumbers)
        {
            HasError = lotteryDrawWithResults == null || winningNumbers?.WinningPrimaryNumbers == null;
            if (HasError)
                return;

            var pointer = 0;

            foreach (var result in winningNumbers.WinningPrimaryNumbers)
            {
                HasError = result < (lotteryDrawWithResults.RangePrimary?.Minimum ?? 0) ||
                           result > (lotteryDrawWithResults.RangePrimary?.Maximum ?? 0);

                var isOutsideMinimum = result < (lotteryDrawWithResults.RangePrimary?.Minimum ?? 0);

                if (HasError)
                {
                    ErrorMessage =
                        $"Primary numbers value {result} @ position {pointer} is outside the {(isOutsideMinimum ? "minimum" : "maximum")} bounds of {(isOutsideMinimum ? lotteryDrawWithResults.RangePrimary?.Minimum ?? 0 : lotteryDrawWithResults.RangePrimary?.Maximum ?? 0)}";
                    break;
                }

                pointer++;
            }
        }
    }
}

