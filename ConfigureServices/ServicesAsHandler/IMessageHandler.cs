using System.Threading.Tasks;

namespace ConfigureServices.ServicesAsHandler
{
    public interface IMessageHandler
    {
    }

    public interface IMessageHandler<in T> : IMessageHandler where T : class
    {
        Task Handle(T message);
    }
   
}
