using LotteryDraw.Repository.Interfaces.Methods;

namespace LotteryDraw.Repository.Interfaces
{
    public interface IRepository : ICreateLotteryDraw, IReadLotteryDraw, IUpdateLotteryDraw, IDeleteLotteryDraw
    {
    }
}
