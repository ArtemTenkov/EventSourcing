using JustSaying;
using JustSaying.Messaging.MessageHandling;
using StructureMap;

namespace Domain.Balance
{
    public class StructureMapHandlerResolver : IHandlerResolver
    {
        private readonly IContainer _container;

        public StructureMapHandlerResolver(IContainer container)
        {
            _container = container;
        }

        public IHandlerAsync<T> ResolveHandler<T>(HandlerResolutionContext context)
        {
            var namedHandler = _container.TryGetInstance<IHandlerAsync<T>>(context.QueueName);
            if (namedHandler != null)
            {
                return namedHandler;
            }

            return _container.GetInstance<IHandlerAsync<T>>();
        }
    }
}
