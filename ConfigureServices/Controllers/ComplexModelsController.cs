using ConfigureServices.Models.ComplexModels;
using Medallion.Threading;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConfigureServices.Controllers
{
    public class ComplexModelsController : ControllerBase
    {
        AppDbContext _dbContext;
        private readonly IDistributedLockProvider _synchronizationProvider;

        public ComplexModelsController(AppDbContext dbContext, IDistributedLockProvider synchronizationProvider)
        {
            _dbContext = dbContext;
            _synchronizationProvider = synchronizationProvider;
        }

        [HttpPost("complexmodel")]
        public IActionResult Post([FromBody] /* IEnumerable<SimpleModel> */ ComplexModel model)
        {
            _dbContext.ComplexModels.Add(model);
            _dbContext.SaveChanges();
            return Ok(model.Id);
        }

        [HttpGet("getlock")]

        public async Task<IActionResult> Get()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;

            using (this._synchronizationProvider.AcquireLock($"UserAccount"))
            {
                Console.WriteLine($"before lock {threadId}");

                await Task.Delay(1_000);

                Console.WriteLine($"after lock {threadId}");
            }
            return Ok();
        }
        //[HttpGet("{id}")]
        //public IActionResult Get(long id)
        //{
        //    var complexModelFound = _dbContext.ComplexModels
        //        .Include(cm => cm.AttributeValues)
        //        .First(x => x.Id == id);

        //    return Ok(complexModelFound);
        //}
    }
}
