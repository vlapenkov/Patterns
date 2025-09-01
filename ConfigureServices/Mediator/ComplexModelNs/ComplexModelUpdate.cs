using ConfigureServices.Models.ComplexModels;
using System;
using System.Threading.Tasks;

namespace ConfigureServices.Mediator.ComplexModelNs
{
    public class ComplexModelUpdate : IEventResolver<ComplexModel>
    {
        public bool CanResolve(int state)
        {
            return state == 3;
        }

        public Task Resolve(ComplexModel entity)
        {

            Console.WriteLine($"entity with id ${entity.Id} ${entity} updated");



            return Task.CompletedTask;
        }
    }


}
