using ConfigureServices.Models.OtherDto;
using ConfigureServices.OtherServices;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ConfigureServices.ServicesAsHandler.Handlers
{
    public class ThirdServiceHandler : IMessageHandler<ThirdMessage>
    {
        private readonly ILogger<ThirdServiceHandler> _logger;

        public ThirdServiceHandler(ILogger<ThirdServiceHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ThirdMessage message)
        {
            _logger.LogInformation("Message handled {@message}", message);
            return Task.CompletedTask;
        }
    }
}
