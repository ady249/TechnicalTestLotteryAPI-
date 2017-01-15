using System;
using System.Collections.Generic;
using System.Linq;
using LotteryDraw.Models.Interfaces.Models;
using LotteryDraw.Models.Interfaces.Storage;
using LotteryDraw.Repository.Interfaces;
using LotteryDraw.Repository.Memory.Interfaces.Commands;

namespace LotteryDraw.Repository.Memory
{
    public class Repository : IRepository
    {
        private readonly IPersistantStorage _persistantStorage;
        private readonly ICreateLotteryDrawCommand _createLotteryDrawCommand;
        private readonly IUpdateSpecificLotteryDrawCommand _updateSpecificLotteryDraw;

        public bool HasError { get; private set; }
        public string ErrorMessage { get; private set; }

        public Repository(IPersistantStorage persistantStorage, ICreateLotteryDrawCommand createLotteryDrawCommand, IUpdateSpecificLotteryDrawCommand updateSpecificLotteryDrawCommand)
        {
            _persistantStorage = persistantStorage;
            _createLotteryDrawCommand = createLotteryDrawCommand;
            _updateSpecificLotteryDraw = updateSpecificLotteryDrawCommand;
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

            _persistantStorage.Storage.Add(value);
        }

        public ILotteryDrawWithResults Get(string name)
        {
            return _persistantStorage.Storage?.FirstOrDefault(x => x.Name == name);
        }

        public IEnumerable<ILotteryDrawWithResults> Get(DateTime date)
        {
            var data = _persistantStorage.Storage?.Where(x => x.DateOfDraw.Date == date).ToList();
            HasError = !data?.Any() ?? false;
            if (HasError)
                ErrorMessage = $"Using {date} yielded no data";

            return data;
        }

        public void Update(string name, IWinningNumbers winningNumbers)
        {
            var value = Get(name);
            HasError = value == null;
            if (HasError)
            {
                ErrorMessage = $"Unable to find entry: {name}";
                return;
            }

            _updateSpecificLotteryDraw.Execute(value, winningNumbers);
            HasError = _updateSpecificLotteryDraw.HasError;
            ErrorMessage = _updateSpecificLotteryDraw.ErrorMessage;
        }

        public void Delete(string name)
        {
            HasError = !_persistantStorage?.Storage?.Remove(Get(name)) ?? false;
            ErrorMessage = $"Unable to remove entry: {name} because it does not exist";
        }
    }
}
