using ConfigureServices.Models.ComplexModelDto;
using ConfigureServices.Models.ComplexModels;
using Medallion.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
        public async Task<IActionResult> Post([FromBody] /* IEnumerable<SimpleModel> */ ComplexModelDto model)
        {
            _dbContext.ComplexModels.Add(new ComplexModel {Name = model.Name });
          await  _dbContext.SaveChangesAsync();
            return Ok(model.Id);
        }


        [HttpPut("complexmodel")]
        public async Task<IActionResult> Put([FromBody]  ComplexModelDto model)
        {
            var found =_dbContext.ComplexModels.FirstOrDefault(x => x.Id == model.Id);

            found.Name = model.Name;
            
            await _dbContext.SaveChangesAsync();
            return Ok(model.Id);
        }

        [HttpDelete("complexmodel")]
        public async Task<IActionResult> Delete(int id)
        {
            var found = _dbContext.ComplexModels.FirstOrDefault(x => x.Id == id);

            _dbContext.Remove(found);

            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("complexmodel")]
        public IActionResult Get1()
        {
            var exists =_dbContext.ComplexModels.Any();

            var  result = _dbContext.ComplexModels.Select(p=> new ComplexModelDto {Id =p.Id, Name= p.Name }).ToArray();
            
            return Ok(result);
        }

        [HttpGet("getlock")]

        public async Task<IActionResult> Get()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;

            using (this._synchronizationProvider.AcquireLock($"UserAccount"))
            {
                Console.WriteLine($"before lock {threadId} {DateTime.Now}");

                await Task.Delay(10_000);

                Console.WriteLine($"after lock {threadId} {DateTime.Now}");
            }
            return Ok();
        }
        
       
    }
}
