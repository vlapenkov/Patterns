﻿using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConfigureServices.Mediator
{
    public static class EventProcessorExtensions
    {
        public static void AddEventProcessor<TEntity>(this IServiceCollection services,
            Action<EventResolverConfigurator<TEntity>> configure = null) where TEntity : class
        {
            var configurator = new EventResolverConfigurator<TEntity>(services);
            configure(configurator);
            //configure?.Invoke(configurator);
            services.AddScoped<IEventProcessor<TEntity>, EventProcessor<TEntity>>();
        }
    }

    public class EventResolverConfigurator<TEntity> where TEntity : class
    {
        private readonly IServiceCollection _services;
        public EventResolverConfigurator(IServiceCollection services)
        {
            _services = services;
        }

        public void AddResolver<TResolver>() where TResolver : class, IEventResolver<TEntity>
        {
            _services.AddScoped<IEventResolver<TEntity>, TResolver>();
        }
    }
}
