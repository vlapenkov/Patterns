﻿using ConfigureServices.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace ConfigureServices.Services
{
    public static class ServiceCollectionExtensions
    {
        // Пример реализации фабрики , где сервисы IDisposable
        public static void AddFactory(this IServiceCollection services)
        {
            services.AddTransient<TypeAService>();
            services.AddTransient<TypeBService>();

            services.AddSingleton<Func<int, ITypeService>>(serviceProvider => (int parameter) =>
                {
                    ;
                    var dict = new Dictionary<int, Func<ITypeService>>
                    {
                        [1] = () => serviceProvider.GetService<TypeAService>(),
                        [2] = () => serviceProvider.GetService<TypeBService>()

                    };

                    return dict[parameter]();
                });

            services.AddSingleton<IBaseTypeFactory, BaseTypeFactory>();


        }

    }
}
