using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using LotteryDraw.Models.Interfaces.Models;
using LotteryDraw.Repository.Interfaces;
using LotteryDraw.Repository.Memory.Interfaces.Commands;

namespace LotteryDraw.Repository.Memory
{
    public class Repository : IRepository
    {
        private readonly ICreateLotteryDrawCommand _createLotteryDrawCommand;
        private readonly IUpdateSpecificLotteryDrawCommand _updateSpecificLotteryDraw;
        private readonly ConcurrentBag<ILotteryDrawWithResults> _collectionLotteryDraws;

        public bool HasError { get; private set; }
        public string ErrorMessage { get; private set; }

        public Repository(Func<ConcurrentBag<ILotteryDrawWithResults>> factory, ICreateLotteryDrawCommand createLotteryDrawCommand, IUpdateSpecificLotteryDrawCommand updateSpecificLotteryDrawCommand)
        {
            _createLotteryDrawCommand = createLotteryDrawCommand;
            _updateSpecificLotteryDraw = updateSpecificLotteryDrawCommand;
            _collectionLotteryDraws = factory();
        }
        
        public void CreateLotteryDrawEntry(ILotteryDraw data)
        {
            _createLotteryDrawCommand.Execute(data);
            HasError = _createLotteryDrawCommand.HasError;
            ErrorMessage = HasError ? _createLotteryDrawCommand.ErrorMessage : null;
            if (HasError)
                return; 

            var value = _createLotteryDrawCommand.Value as ILotteryDrawWithResults;

            HasError = Get(value?.Name) != null;

            if (HasError)
            {
                ErrorMessage = $"Duplicate entry: {value?.Name}";
                return;
            }

            _collectionLotteryDraws.Add(value);
        }

        public ILotteryDrawWithResults Get(string name)
        {
            return _collectionLotteryDraws?.FirstOrDefault(x => x.Name == name);
        }

        public IEnumerable<ILotteryDrawWithResults> Get(DateTime date)
        {
            return _collectionLotteryDraws?.Where(x => x.DateOfDraw.Date == date);
        }

        public void Update(IWinningNumbers winningNumbers, string name)
        {
            var value = Get(name);
            HasError = value == null;
            if (HasError)
            {
                ErrorMessage = $"Unable to find entry: {name}";
                return;
            }

            _updateSpecificLotteryDraw.Execute(value, winningNumbers);
        }
    }
}
