using ConfigureServices.Domain;
using ConfigureServices.Models.ComplexModels;
using System;
using System.Threading.Tasks;

namespace ConfigureServices.Mediator.ComplexModelNs
{
    public class ProductDelete : IEventResolver<Product>
    {
        public bool CanResolve(int state) => state == 2;


        public Task Resolve(Product entity)
        {


            Console.WriteLine($"entity ${entity} delete with id=${entity.Id}");



            return Task.CompletedTask;
        }
    }


}
