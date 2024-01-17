using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConfigureServices.Mediator
{
    public class EventProcessor<TEntity> : IEventProcessor<TEntity> where TEntity : class
    {
        private readonly IEnumerable<IEventResolver<TEntity>> _resolvers;

        public EventProcessor(IEnumerable<IEventResolver<TEntity>> resolvers)
        {
            _resolvers = resolvers;
        }

        public async Task Process(TEntity entry)
        {
            foreach (var resolver in _resolvers)
            {

                await resolver.Resolve(entry);

            }
        }
    }

    public interface IEventProcessor<TEntity> where TEntity : class
    {
        public Task Process(TEntity entry);
    }

    public interface IEventResolver<TEntity> where TEntity : class
    {

        public Task Resolve(TEntity entry);
    }
}
