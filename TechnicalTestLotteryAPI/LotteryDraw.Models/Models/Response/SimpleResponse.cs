using LotteryDraw.ErrorHandler.Interfaces.Attributes;
using LotteryDraw.Models.Interfaces.Response;

namespace LotteryDraw.Models.Models.Response
{
    public class SimpleResponse : ISimpleResponse
    {
        public bool IsSuccessful => !HasError;

        public bool HasError { get; }
        public string ErrorMessage { get; }

        public SimpleResponse(IHasError hasError, IErrorMessage errorMessage)
        {
            HasError = hasError.HasError;
            ErrorMessage = HasError ? errorMessage.ErrorMessage : null;
        }
    }
}
