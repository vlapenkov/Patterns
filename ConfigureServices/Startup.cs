using ConfigureServices.Models;
using ConfigureServices.Models.OtherDto;
using ConfigureServices.OtherServices;
using ConfigureServices.Services;
using ConfigureServices.ServicesAsHandler;
using ConfigureServices.ServicesAsHandler.Handlers;
using HealthChecks.UI.Client;
using Medallion.Threading;
using Medallion.Threading.Postgres;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace ConfigureServices
{

    public delegate ITypeService GetBaseType(int x);


    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {


             services.AddDbContext<AppDbContext>(
            //options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"))
            options => options.UseNpgsql(Configuration.GetConnectionString("SqlConnection"))
           );

            services.AddControllers();
            services.AddHostedService<HostedService>();

            services.AddSingleton<SingletonService2>();


            // Пример реализации фабрики , где сервисы - НЕ IDisposable

            static T GetInstance<T>() where T : new()
            {
                T instance = new();
                return instance;
            }

            Dictionary<int, ITypeService> dict2 = new()
            {
                [1] = GetInstance<TypeAService>(),
                [2] = GetInstance<TypeBService>()
            };

            dict2[3] = GetInstance<TypeBService>();
            dict2[4] = GetInstance<TypeAService>();

            services.AddTransient<GetBaseType>(_ => (int parameter) => { return dict2[parameter]; });


            // Пример реализации фабрики , где сервисы   IDisposable

            services.AddFactory();

            services.AddSingleton<IDistributedLockProvider>(_ => new PostgresDistributedSynchronizationProvider(Configuration.GetConnectionString("SqlConnection")));

            // вместо закомментированной

            services.AddTransient<TypeAService>();
            services.AddTransient<TypeBService>();


            services.AddHealthChecks();
            //services.AddHealthChecksUI()
            //     .AddInMemoryStorage();

            services.AddApiVersioning();
            services.AddSwaggerGen();            
         

            services.AddEventServiceDescriptor(
                opt => {
                    opt.AddEventHandler<SecondMessage, SecondServiceHandler>();
                    opt.AddEventHandler<FirstMessage, FirstServiceHandler>();
                    opt.AddEventHandler<ThirdMessage, ThirdServiceHandler>();
                });

         

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
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1"); });

            app.UseEndpoints(endpoints => { _ = endpoints.MapControllers(); _ = endpoints.MapHealthChecks("/hc", new HealthCheckOptions { Predicate = _ => true, ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse }); });

            //  app.UseHealthChecksUI(config => config.UIPath = "/hc-ui");

            //try
            //{
            //    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            //    {
            //        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
            //        context.Database.Migrate();
            //    }

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine($"MyWebApi migration not working");
            //    Console.Write(e.Message);
            //    Console.Write(e.InnerException);
            //    Console.Write(e.StackTrace);
            //}

        }
    }
}
