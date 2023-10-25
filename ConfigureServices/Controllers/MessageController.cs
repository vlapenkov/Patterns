using ConfigureServices.Models.OtherDto;
using ConfigureServices.ServicesAsHandler;
using Microsoft.AspNetCore.Mvc;

namespace ConfigureServices.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        MessageProcessor _processor;

        public MessageController(MessageProcessor processor)
        {
            _processor = processor;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _processor.Handle(new FirstMessage { Id = 10 });

            return Ok();
        }
    }
}
