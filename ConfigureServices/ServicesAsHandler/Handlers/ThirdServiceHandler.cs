using ConfigureServices.Models.OtherDto;
using ConfigureServices.OtherServices;
using System;
using System.Threading.Tasks;

namespace ConfigureServices.ServicesAsHandler.Handlers
{
    public class ThirdServiceHandler : IMessageHandler<ThirdMessage>
    {
        private readonly SingletonService2 _singletonService;

        public ThirdServiceHandler(SingletonService2 singletonService)
        {
            _singletonService = singletonService;
        }

        public Task Handle(ThirdMessage message)
        {
            Console.WriteLine(message);
            return Task.CompletedTask;
        }
    }
}
