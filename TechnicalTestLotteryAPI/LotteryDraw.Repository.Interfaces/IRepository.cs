using LotteryDraw.ErrorHandler.Interfaces.Attributes;
using LotteryDraw.Repository.Interfaces.Methods;

namespace LotteryDraw.Repository.Interfaces
{
    public interface IRepository : IHasError, IErrorMessage, ICreateLotteryDraw, IReadLotteryDraw, IUpdateLotteryDraw, IDeleteLotteryDraw
    {
    }
}
