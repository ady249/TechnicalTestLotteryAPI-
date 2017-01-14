using LotteryDraw.Data.Interfaces.Attributes;
using LotteryDraw.ErrorHandler.Interfaces.Attributes;

namespace LotteryDraw.Repository.Memory.Interfaces.Commands.Base
{
    public interface ICommand : IHasError, IErrorMessage, IValue
    {
    }
}
