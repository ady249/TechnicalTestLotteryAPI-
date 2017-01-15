using System.Collections.Generic;
using System.Linq;
using LotteryDraw.BusinessLogic.Interfaces;
using LotteryDraw.Models.Interfaces.Models;
using LotteryDraw.Repository.Memory.Interfaces.Commands;
using LotteryDraw.Tracer.Interfaces;

namespace LotteryDraw.Repository.Memory.Commands
{
    public class UpdateSpecificLotteryDrawCommand : IUpdateSpecificLotteryDrawCommand
    {
        private readonly ITracer _tracer;
        private readonly List<IWinningNumbersRule> _rules;
        public bool HasError { get; private set; }
        public string ErrorMessage { get; private set; }

        public UpdateSpecificLotteryDrawCommand(ITracer tracer, IEnumerable<IWinningNumbersRule> rules )
        {
            _tracer = tracer;
            _rules = rules.OrderBy(x => x.Sequence).ToList();
        }

        public void Execute(ILotteryDrawWithResults data, IWinningNumbers winningNumbers)
        {
            _rules?.ForEach(x => x.Execute(data, winningNumbers));
            HasError = _rules?.Any(x => x.HasError) ?? false;

            if (HasError)
            {
                ErrorMessage = _rules?.FirstOrDefault(x => x.HasError)?.ErrorMessage;

                _rules?.ForEach(x => _tracer.WriteLine($"Rule {x.Sequence}: {x.GetType().Name}; HasError: {x.HasError}; ErrorMessage: {x.ErrorMessage}"));
                
                return;
            }

            foreach (var field in winningNumbers.GetType().GetProperties().Where(x => x.CanWrite))
            {
                 var destination = data?.GetType()
                    .GetProperties()
                    .FirstOrDefault(x => x.Name == field.Name);

                destination?.SetValue(data, field.GetValue(winningNumbers));
            }
        }
    }
}
