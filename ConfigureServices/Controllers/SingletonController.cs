using ConfigureServices.Models;
using ConfigureServices.OtherServices;
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
    public class SingletonController : ControllerBase
    {
        private readonly SingletonService2 _singletonService;

        public SingletonController(SingletonService2 singletonService)
        {
            _singletonService = singletonService;
        }

        [HttpGet]
        public IEnumerable<int> Get()
        {
            var data = _singletonService.Data;

            return data.Values.Select(p => p.Length);
            //return _factory(i);
        }
    }
}
