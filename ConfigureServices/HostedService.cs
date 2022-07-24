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

        public HostedService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {


            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    //   var service2 = scope.ServiceProvider.GetService<SingletonService2>();

                    var service2 = SingletonService.Instance;

                    var data = service2.Data;

                    //    Console.WriteLine(data[1]);

                    await Task.Delay(1000);

                }

            }
        }
    }
}