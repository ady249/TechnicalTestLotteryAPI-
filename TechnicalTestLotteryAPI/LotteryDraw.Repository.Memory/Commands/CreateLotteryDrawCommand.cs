using System;
using System.Linq;
using LotteryDraw.Models.Interfaces.Models;
using LotteryDraw.Repository.Memory.Interfaces.Commands;

namespace LotteryDraw.Repository.Memory.Commands
{
    public class CreateLotteryDrawCommand : ICreateLotteryDrawCommand
    {
        private readonly Func<ILotteryDrawWithResults> _factory;
        public bool HasError => (Value as ILotteryDrawWithResults)?.Name == null;
        public string ErrorMessage => "Unable to convert data";

        public object Value { get; private set; }

        public CreateLotteryDrawCommand(Func<ILotteryDrawWithResults> factory)
        {
            _factory = factory;
        }

        public void Execute(object value)
        {
            var data = value as ILotteryDraw;
            var datawithResults = _factory();
            datawithResults?.GetType().GetProperties().Where(x => x.CanWrite).ToList().ForEach(x => x.SetValue(data, x.Name));

            Value = datawithResults;
        }
    }
}
