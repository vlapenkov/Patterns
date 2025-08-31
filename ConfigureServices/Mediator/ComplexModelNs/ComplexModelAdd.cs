using ConfigureServices.Models.ComplexModels;
using ConfigureServices.Models.OtherDto;
using System;
using System.Threading.Tasks;

namespace ConfigureServices.Mediator.ComplexModelNs
{
    public class ComplexModelAdd : IEventResolver<ComplexModel>
    {
        public Task Resolve(ComplexModel entity)
        {
            Console.WriteLine($"entity ${entity} resolved");

            return Task.CompletedTask;
        }
    }
}
