using ConfigureServices.Models.EmployeeDto;
using ConfigureServices.Models.OtherDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ConfigureServices.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            var result = new[] { new EmployeeDto { Id = 1, Name = "Петров" }, new EmployeeDto { Id = 2, Name = "Иванов" } };

            return Ok(result);
        }
    }
}
