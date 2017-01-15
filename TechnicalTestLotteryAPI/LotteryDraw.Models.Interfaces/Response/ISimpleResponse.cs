using LotteryDraw.ErrorHandler.Interfaces.Attributes;

namespace LotteryDraw.Models.Interfaces.Response
{
    public interface ISimpleResponse : IIsSuccessful, IHasError, IErrorMessage
    {
    }
}
