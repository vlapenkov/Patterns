using ConfigureServices.Models.ComplexModels;
using System;
using System.Threading.Tasks;

namespace ConfigureServices.Mediator.ComplexModelNs
{
    public class ComplexModelDelete : IEventResolver<ComplexModel>
    {
        public Task Resolve(ComplexModel entity)
        {
            if (entity.State == 2)
            {

                Console.WriteLine($"entity ${entity} delete");

            }

            return Task.CompletedTask;
        }
    }

    
}
