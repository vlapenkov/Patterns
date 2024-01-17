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

        private readonly IMessageProcessor _processor;        

        public HostedService(IServiceScopeFactory serviceScopeFactory, IMessageProcessor processor) 
                                                                                                    
        {
            
            _processor = processor;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {


            while (!stoppingToken.IsCancellationRequested)
            {
               

               await _processor.Handle(new SecondMessage { Id = 3, Name = "Petya" });

               

                await _processor.Handle(new ThirdMessage {Id =1 });


                Console.WriteLine();

                await Task.Delay(1_000);

            }
        }
    }
}