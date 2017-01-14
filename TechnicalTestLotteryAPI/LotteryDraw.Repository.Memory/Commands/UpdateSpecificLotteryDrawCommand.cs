using System.Linq;
using LotteryDraw.Models.Interfaces.Models;
using LotteryDraw.Repository.Memory.Interfaces.Commands;
using LotteryDraw.Tracer.Interfaces;

namespace LotteryDraw.Repository.Memory.Commands
{
    public class UpdateSpecificLotteryDrawCommand : IUpdateSpecificLotteryDrawCommand
    {
        private readonly ITracer _tracer;
        public bool HasError { get; private set; }
        public string ErrorMessage { get; }
        public object Value { get; }

        public UpdateSpecificLotteryDrawCommand(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void Execute(ILotteryDrawWithResults data, IWinningNumbers winningNumbers)
        {
            data?.GetType().GetProperties().Where(x => x.CanWrite).ToList().ForEach(x => x.SetValue(winningNumbers, x.Name));
        }
    }
}
