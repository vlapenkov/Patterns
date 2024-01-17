using ConfigureServices.Models.OtherDto;
using ConfigureServices.OtherServices;
using System;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace ConfigureServices.ServicesAsHandler.Handlers
{
    public class FirstServiceHandler : IMessageHandler<FirstMessage>
    {
        private readonly SingletonService2 _singletonService;

        public FirstServiceHandler(SingletonService2 singletonService)
        {
            _singletonService = singletonService;
        }

        public Task Handle(FirstMessage message)
        {
            Console.WriteLine("Message handled" + message);
            return Task.CompletedTask;
        }
    }
}
