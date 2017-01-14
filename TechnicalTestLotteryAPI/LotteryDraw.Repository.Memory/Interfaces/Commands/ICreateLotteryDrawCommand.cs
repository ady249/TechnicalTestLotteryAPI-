using LotteryDraw.Command.Interfaces.Methods;
using LotteryDraw.Repository.Memory.Interfaces.Commands.Base;

namespace LotteryDraw.Repository.Memory.Interfaces.Commands
{
    public interface ICreateLotteryDrawCommand : ICommand, IExecuteWithValue
    {
    }
}
