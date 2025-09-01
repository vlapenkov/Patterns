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

        public async Task Process(TEntity entity, int state)
        {
            foreach (var resolver in _resolvers)
            {
                if (resolver.CanResolve(state))
                {
                    await resolver.Resolve(entity);
                }

            }
        }
    }

    public interface IEventProcessor<TEntity> where TEntity : class
    {
        public Task Process(TEntity entry, int state);
    }

    public interface IEventResolver<TEntity> where TEntity : class
    {


        public bool CanResolve(int state);
        public Task Resolve(TEntity entry);
    }
}
