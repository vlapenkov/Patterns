using ConfigureServices.Models.OtherDto;
using ConfigureServices.ServicesAsHandler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConfigureServices
{
    internal class HostedService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        private readonly IMessageProcessor _processor;        

        public HostedService(IServiceScopeFactory serviceScopeFactory, IMessageProcessor processor) //, IServiceCollection services
                                                                                                    //)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _processor = processor;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {


            while (!stoppingToken.IsCancellationRequested)
            {
                //using IServiceScope scope = _serviceScopeFactory.CreateScope();
                // MessageProcessor processor = scope.ServiceProvider.GetService<MessageProcessor>();

               await _processor.Handle(new SecondMessage { Id = 3, Name = "Petya" });

                //await _processor.Handle(new FirstMessage { Id = 1});

                await _processor.Handle(new ThirdMessage { });


                Console.WriteLine();

                await Task.Delay(1_000);

            }
        }
    }
}