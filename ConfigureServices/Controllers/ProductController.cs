using ConfigureServices.Domain;
using ConfigureServices.Models.ComplexModelDto;
using ConfigureServices.Models.ComplexModels;
using ConfigureServices.Models.ProductDto;
using Medallion.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConfigureServices.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        AppDbContext _dbContext;
        


        public ProductController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody]  ProductDto model)
        {
            var product = new Product { Name = model.Name };
            _dbContext.Products.Add(product);
          await  _dbContext.SaveChangesAsync();
            return Ok(product.Id);
        }


        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] ProductDto model)
        {
            var found =_dbContext.Products.FirstOrDefault(x => x.Id == model.Id);

            found.Name = model.Name;
            
            await _dbContext.SaveChangesAsync();

            return Ok(model.Id);
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete(int id)
        {
            var found = _dbContext.Products.FirstOrDefault(x => x.Id == id);

            _dbContext.Remove(found);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

       
        
       
    }
}
