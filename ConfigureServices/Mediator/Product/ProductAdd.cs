using ConfigureServices.Models.ComplexModels;
using System;
using System.Threading.Tasks;
using ConfigureServices.Domain;

namespace ConfigureServices.Mediator
{
    public class ProductAdd : IEventResolver<Product>
    {
        public bool CanResolve(int state) => state == 4;


        public Task Resolve(Product entity)
        {

            Console.WriteLine($"entity with id ${entity.Id} ${entity} added");

            return Task.CompletedTask;
        }

        
    }
}
