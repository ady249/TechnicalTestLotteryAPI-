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
            var sourceData = value as ILotteryDraw;
            var datawithResults = _factory();

            foreach (var data in datawithResults.GetType().GetProperties().Where(x => x.CanWrite))
            {
                var sourceField =
                    sourceData?.GetType().GetProperties().FirstOrDefault(x => x.Name == data.Name)?.GetValue(sourceData);

                data.SetValue(datawithResults, sourceField);
            }

            Value = datawithResults;
        }
    }
}
