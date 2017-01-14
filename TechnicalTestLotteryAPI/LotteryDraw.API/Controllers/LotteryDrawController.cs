using System.Collections.Generic;
using System.Web.Http;
using LotteryDraw.Repository.Interfaces;

namespace LotteryDraw.API.Controllers
{
    public class LotteryDrawController : ApiController
    {
        private readonly IRepository _repository;
        public LotteryDrawController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/LotteryDraw
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LotteryDraw/5
        public Models.LotteryDraw Get(int id)
        {
            return null;
        }

        // POST: api/LotteryDraw
        public void Post([FromBody]Models.LotteryDraw value)
        {
            _repository.CreateLotteryDrawEntry(value);
        }

        // PUT: api/LotteryDraw/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LotteryDraw/5
        public void Delete(int id)
        {
        }
    }
}
