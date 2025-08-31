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

        public CancellationToken _ctx { get; set; }

        public HostedService(IServiceScopeFactory serviceScopeFactory, IMessageProcessor processor) 
                                                                                                    
        {
            
            _processor = processor;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Yield();

            CancellationTokenSource internalTokenSource = new CancellationTokenSource();

            internalTokenSource.CancelAfter(10_000);

            _ctx = internalTokenSource.Token;

            CancellationTokenSource linkedCts =
                 CancellationTokenSource.CreateLinkedTokenSource(stoppingToken, internalTokenSource.Token);
            await Process(linkedCts.Token);

            Console.WriteLine("App stopped");
        }

        private async Task Process(CancellationToken stoppingToken)
        {
            try
            {
              //  while (!stoppingToken.IsCancellationRequested)
                {


                    await _processor.Handle(new SecondMessage { Id = 3, Name = "Petya" });



                    await _processor.Handle(new ThirdMessage { Id = 1 });


                    Console.WriteLine();



                    await Task.Delay(100_000, stoppingToken);


                }
            }
            catch (OperationCanceledException ex)
            when (_ctx.IsCancellationRequested)
           // when (ex.CancellationToken == _ctx)
            {                
                Console.WriteLine("App cancelled after timeout");
            }
        }
    }
}