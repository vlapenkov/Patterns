using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace ConfigureServices.ServicesAsHandler
{
    public class MessageProcessor : IMessageProcessor
    {
        private IServiceProvider _serviceProvider;

        public MessageProcessor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Handle<T>(T message) where T : class
        {

            var handler = _serviceProvider.GetService<IMessageHandler<T>>();

            if (handler == null) throw new Exception($"Не найдено обработчика для сообщения типа {typeof(T)}");

            await handler.Handle(message);
        }
    }



public interface IMessageProcessor
{
    public Task Handle<T>(T message) where T : class;

}
}
