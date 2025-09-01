using ConfigureServices.Models.OtherDto;
using System;
using System.Threading.Tasks;

namespace ConfigureServices.Mediator.Resolvers
{
    public class Resolver1 : IEventResolver<SecondMessage>
    {


        public bool CanResolve(int state)
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
