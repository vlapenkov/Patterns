using ConfigureServices.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ConfigureServices
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        Func<int, ITypeService> _factory;
        GetBaseType _factory2;

        public ValuesController(Func<int, ITypeService> factory, GetBaseType factory2)
        {
            _factory = factory;
            _factory2 = factory2;
        }

        [HttpGet]
        public string Get(int i)
        {
            return _factory(i).ToString();
        }
    }
}
