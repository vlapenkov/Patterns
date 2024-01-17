using ConfigureServices.Mediator;
using ConfigureServices.Models.OtherDto;
using ConfigureServices.ServicesAsHandler;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ConfigureServices.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        
        private readonly IEventProcessor<SecondMessage> _eventProcessor;

        public MessageController(IEventProcessor<SecondMessage> eventProcessor)
        {            
            _eventProcessor = eventProcessor;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           await _eventProcessor.Process(new SecondMessage { Id = 10, Name = "Test" });

            return Ok();
        }
    }
}
