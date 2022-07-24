using ConfigureServices.Models;
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
    public class ValuesController : ControllerBase
    {
        Func<int, BaseTypeService> _factory;
        GetBaseType _factory2;

        public ValuesController(Func<int, BaseTypeService> factory, GetBaseType factory2)
        {
            _factory = factory;
            _factory2 = factory2;
        }

        [HttpGet]
        public BaseTypeService Get(int i)
        {
            return _factory(i);
        }
    }
}
