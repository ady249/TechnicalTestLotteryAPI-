using System.Collections.Generic;
using LotteryDraw.ErrorHandler.Interfaces.Attributes;
using LotteryDraw.Models.Interfaces.Models;
using LotteryDraw.Models.Interfaces.Response;

namespace LotteryDraw.Models.Models.Response
{
    public class SimpleResponseWithData : ISimpleResponseWithData
    {
        public bool IsSuccessful => !HasError;

        public bool HasError { get; }
        public string ErrorMessage { get; }

        public IEnumerable<ILotteryDrawWithResults> LotteryDraws { get; }

        public SimpleResponseWithData(IHasError hasError, IErrorMessage errorMessage, IEnumerable<ILotteryDrawWithResults> lotteryDraws)
        {
            HasError = hasError.HasError;
            ErrorMessage = HasError ? errorMessage.ErrorMessage : null;

            LotteryDraws = lotteryDraws;
        }
    }
}
