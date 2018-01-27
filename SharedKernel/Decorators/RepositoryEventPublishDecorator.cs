using System;
using System.Threading.Tasks;
using MediatR;
using SharedKernel.Domain;

namespace SharedKernel.Decorators
{
    public class RepositoryEventPublishDecorator<T> : IEventRepository<T>
    {
        private IEventRepository<T> _eventRepository;
        private IMediator _mediator;
        public RepositoryEventPublishDecorator(IMediator mediator, 
            IEventRepository<T> eventRepository)
        {
            _mediator = mediator;
            _eventRepository = eventRepository;
        }

        public T GetById(Guid id)
        {
            return _eventRepository.GetById(id);
        }

        public async Task Save(AggregateRoot aggregate)
        {
            var result = _eventRepository.Save(aggregate);

            foreach (var @event in aggregate.DomainEvents)
                await _mediator.Publish(@event);

            aggregate.ClearEvents();
        }
    }
}
