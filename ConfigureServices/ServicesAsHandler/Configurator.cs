using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ConfigureServices.ServicesAsHandler.EventProcessorExtensions;

namespace ConfigureServices.ServicesAsHandler
{
    public static class EventProcessorExtensions
    {

        public static void AddEventServiceDescriptor(this IServiceCollection services,
           Action<ProcessorConfigurator> configure = null)
        {
            var configurator = new ProcessorConfigurator(services);
            configure?.Invoke(configurator);
            services.AddMessageProcessor();
        }

        public static void AddMessageProcessor(this IServiceCollection services)
        {
            services.AddTransient<IMessageProcessor, MessageProcessor>();
        }

    }
        

    /// <summary>
    /// Нужен только для DI <сообщение, хэндлер>
    /// </summary>
    public class ProcessorConfigurator
    {
        private readonly IServiceCollection _services;

        public ProcessorConfigurator(IServiceCollection serviceDescriptors)
        {
            _services = serviceDescriptors;
        }       

        public void AddEventHandler<TEntity, ServiceHandler>() where ServiceHandler : class, IMessageHandler<TEntity> where TEntity : class
        {
            _services.AddTransient<IMessageHandler<TEntity>, ServiceHandler>();         
        }
    }  

    
}
