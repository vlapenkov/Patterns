using ConfigureServices.Models.ComplexModels;
using System;
using System.Threading.Tasks;

namespace ConfigureServices.Mediator.ComplexModelNs
{
    public class ComplexModelDelete : IEventResolver<ComplexModel>
    {
        public bool CanResolve(int state)
        {
            return state == 2;
        }

        public Task Resolve(ComplexModel entity)
        {
            

                Console.WriteLine($"entity ${entity} delete");

            

            return Task.CompletedTask;
        }
    }

    
}
