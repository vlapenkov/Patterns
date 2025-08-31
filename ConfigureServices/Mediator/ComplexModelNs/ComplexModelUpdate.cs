using ConfigureServices.Models.ComplexModels;
using System;
using System.Threading.Tasks;

namespace ConfigureServices.Mediator.ComplexModelNs
{
    public class ComplexModelUpdate : IEventResolver<ComplexModel>
    {
        public Task Resolve(ComplexModel entity)
        {
            if (entity.State == 3)
            {

                Console.WriteLine($"entity with id ${entity.Id} ${entity} updated");

            }

            return Task.CompletedTask;
        }
    }

    
}
