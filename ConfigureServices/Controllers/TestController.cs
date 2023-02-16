using ConfigureServices.Models.Fields;
using ConfigureServices.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConfigureServices
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        IBaseTypeFactory _baseTypeFactory;



        public TestController(IBaseTypeFactory baseTypeFactory)
        {
            _baseTypeFactory = baseTypeFactory;
        }

        [HttpGet]
        public string Get(int i)
        {
            var result = _baseTypeFactory.Create(i);

            return result.ToString();
        }

        [HttpPost]
        public IActionResult Post([FromBody] IEnumerable<BaseField> model)
        {
            return Ok(model);
        }


    }
}
