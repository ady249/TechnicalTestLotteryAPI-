using System.Collections.Generic;
using LotteryDraw.Models.Interfaces.Models;
using LotteryDraw.Models.Interfaces.Storage;
using LotteryDraw.Repository.Memory.Interfaces;

namespace LotteryDraw.Repository.Memory.Storage
{
    public class PersistantStorage : IPersistantStorage
    {
        private readonly ILotteryDrawWithResultsListFactory _factory;
        private IList<ILotteryDrawWithResults> _internalStorage;

        public IList<ILotteryDrawWithResults> Storage => _internalStorage ?? (_internalStorage = _factory.Create());

        public PersistantStorage(ILotteryDrawWithResultsListFactory factory)
        {
            _factory = factory;
        }
    }
}
