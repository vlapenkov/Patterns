using ConfigureServices.Models.OtherDto;
using ConfigureServices.OtherServices;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ConfigureServices.ServicesAsHandler.Handlers
{
    public class SecondServiceHandler : IMessageHandler<SecondMessage>
    {
        private readonly ILogger<SecondServiceHandler> _logger;

        public SecondServiceHandler(ILogger<SecondServiceHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(SecondMessage message)
        {
            _logger.LogInformation("{@message}", message);
            return Task.CompletedTask;
        }
    }
}
