using ConfigureServices.Models.ComplexModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigureServices.Controllers
{
    public class ComplexModelsController : ControllerBase
    {
        AppDbContext _dbContext;

        public ComplexModelsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("complexmodel")]
        public IActionResult Post([FromBody] /* IEnumerable<SimpleModel> */ ComplexModel model)
        {
            _dbContext.ComplexModels.Add(model);
            _dbContext.SaveChanges();
            return Ok(model.Id);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var complexModelFound = _dbContext.ComplexModels
                .Include(cm => cm.AttributeValues)
                .First(x => x.Id == id);

            return Ok(complexModelFound);
        }
    }
}
