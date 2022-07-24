using ConfigureServices.Models;
using ConfigureServices.Models.Fields;
using ConfigureServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigureServices
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        IBaseTypeFactory _baseTypeFactory;
        //  Func<int, BaseTypeService> _func;
        //public TestController(Func<int, BaseTypeService> func)
        //{
        //    _func = func;
        //}

        //[HttpGet]
        //public BaseTypeService Get(int i)
        //{
        //    return _func(i);
        //}

        public TestController(IBaseTypeFactory baseTypeFactory)
        {
            _baseTypeFactory = baseTypeFactory;
        }

        [HttpGet]
        public BaseTypeService Get(int i)
        {
            var result = _baseTypeFactory.Create(i);

            return result;
        }

        [HttpPost]
        public IActionResult Post([FromBody] IEnumerable<BaseField> model)
        {
            return Ok(model);
        }
    }
}
