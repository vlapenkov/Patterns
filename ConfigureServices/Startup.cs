using ConfigureServices.Models;
using ConfigureServices.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigureServices
{
    //delegate x  = Func<int, BaseType>;
    public delegate BaseTypeService GetBaseType(int x);

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {



            services.AddControllers();
            services.AddHostedService<HostedService>();

            services.AddSingleton<SingletonService2>();


            // Пример реализации фабрики , где сервисы - НЕ IDisposable

            T GetInstance<T>() where T : new()
            {
                T instance = new T();
                return instance;
            }

            var dict2 = new Dictionary<int, BaseTypeService>
            {
                [1] = GetInstance<TypeAService>(),
                [2] = GetInstance<TypeBService>()
            };

            dict2[3] = GetInstance<TypeBService>();
            dict2[4] = GetInstance<TypeAService>();

            services.AddTransient<GetBaseType>(_ => (int parameter) =>
            {
                return dict2[parameter];
            });


            // Пример реализации фабрики , где сервисы   IDisposable

            services.AddFactory();

            // вместо закомментированной

            //services.AddTransient<TypeAService>();
            //services.AddTransient<TypeBService>();

            //services.AddTransient<Func<int, BaseTypeService>>(serviceProvider => (int parameter) =>
            //{
            //    ;
            //    var dict = new Dictionary<int, Func<BaseTypeService>>
            //    {
            //        [1] = () => serviceProvider.GetService<TypeAService>(),
            //        [2] = () => serviceProvider.GetService<TypeBService>()

            //    };

            //    return dict[parameter]();
            //});



            services.AddApiVersioning();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseRouting();


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                /* endpoints.MapGet("/", async context =>
                 {
                     await context.Response.WriteAsync("Hello World!");
                 }); */
            });

        }
    }
}
