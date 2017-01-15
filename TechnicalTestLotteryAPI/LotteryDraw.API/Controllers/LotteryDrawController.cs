using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using LotteryDraw.ErrorHandler.Interfaces.Attributes;
using LotteryDraw.Models.Interfaces.Models;
using LotteryDraw.Models.Interfaces.Response;
using LotteryDraw.Repository.Interfaces;
using LotteryDraw.Tracer.Interfaces;

namespace LotteryDraw.API.Controllers
{
    public class LotteryDrawController : ApiController
    {
        private readonly ITracer _tracer;
        private readonly IRepository _repository;
        private readonly Func<IHasError, IErrorMessage, ISimpleResponse> _simpleResponseFactory;
        private readonly Func<IHasError, IErrorMessage, IEnumerable<ILotteryDrawWithResults>, ISimpleResponseWithData> _simpleResponseWithDataFactory;

        public LotteryDrawController(ITracer tracer, IRepository repository, Func<IHasError, IErrorMessage, ISimpleResponse> simpleResponseFactory, Func<IHasError, IErrorMessage, IEnumerable<ILotteryDrawWithResults>, ISimpleResponseWithData> simpleResponseWithDataFactory )
        {
            _tracer = tracer;
            _repository = repository;
            _simpleResponseFactory = simpleResponseFactory;
            _simpleResponseWithDataFactory = simpleResponseWithDataFactory;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(DateTime dateTime)
        {
            IEnumerable<ILotteryDrawWithResults> data = null;

            await Task.Factory.StartNew(() =>
            {
                data = _repository.Get(dateTime);
            });

            return Ok(_simpleResponseWithDataFactory(_repository, _repository, data));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]Models.Models.LotteryDraw value)
        {
            await Task.Factory.StartNew(() =>
            {
                _repository.CreateLotteryDrawEntry(value);
            });

            return Ok(CreateSimpleResponse());
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(string name, [FromBody]Models.Models.WinningNumbers value)
        {
            await Task.Factory.StartNew(() =>
            {
                _repository.Update(name, value);
            });

            return Ok(CreateSimpleResponse());
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(string name)
        {
            await Task.Factory.StartNew(() =>
            {
                _repository.Delete(name);
            });

            return Ok(CreateSimpleResponse());
        }

        private ISimpleResponse CreateSimpleResponse()
        {
            if (_repository.HasError)
                _tracer.WriteLine(_repository.ErrorMessage);

            return _simpleResponseFactory(_repository, _repository);
        }
    }
}
