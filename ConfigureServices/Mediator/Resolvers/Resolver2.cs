using ConfigureServices.Models.OtherDto;
using System;
using System.Threading.Tasks;

namespace ConfigureServices.Mediator.Resolvers
{
    public class Resolver2 : IEventResolver<SecondMessage>
    {


        public Resolver2()
        {

        }

        public bool CanResolve(SecondMessage entry)
        {
            return true;
            // throw new NotImplementedException();
        }

        public Task Resolve(SecondMessage entry)
        {

            Console.WriteLine($"Message resolved {entry}");
            return Task.CompletedTask;
            // throw new NotImplementedException();
        }
    }
}
