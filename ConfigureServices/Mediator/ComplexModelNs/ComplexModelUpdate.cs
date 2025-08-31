using ConfigureServices.Models.ComplexModels;
using System;
using System.Threading.Tasks;

namespace ConfigureServices.Mediator.ComplexModelNs
{
    public class ComplexModelUpdate : IEventResolver<ComplexModel>
    {
        public Task Resolve(ComplexModel entry)
        {
            Console.WriteLine($"entity ${entry} resolved");

            return Task.CompletedTask;
        }
    }

    
}
