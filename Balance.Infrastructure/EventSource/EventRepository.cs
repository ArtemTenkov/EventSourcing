using Balance.Infrastructure.Mapppers;
using Balance.Infrastructure.Models;
using Domain.Balance;
using SharedKernel;
using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Balance.Infrastructure.EventSource
{
    public class EventRepository : IEventRepository<AccountRoot>
    {
        protected EventSourcingContext _dbContext;
        public IAggregateFactory<AccountRoot> _aggregateFactory { get; }
        
        public EventRepository(IAggregateFactory<AccountRoot> aggregateFactory,             
            EventSourcingContext dbContext)
        {
            _aggregateFactory = aggregateFactory;
            _dbContext = dbContext;           
        }
        public AccountRoot GetById(Guid id)
        {
            var dbEvents = _dbContext.EventSourcing.Where(evnt => evnt.AggregateId == id);

            var deserializedEvents = 
                dbEvents.Select(e => new MapperGeneric().Map(e));

            var aggregate = _aggregateFactory.Restore(id, deserializedEvents);
            return aggregate;
        }

        public async Task Save(AggregateRoot aggregate)
        {
            var events = aggregate.DomainEvents;
            if (!events.Any()) return;

            var aggregateType = aggregate.GetType().Name;
            var originalVersion = aggregate.Version - events.Count() + 1;
            var eventsToSave = events
                .Select(@event => new MapperGeneric()
                    .Map(@event, aggregateType,
                aggregate.Id, originalVersion++)).ToList();

            await _dbContext.EventSourcing.AddRangeAsync(eventsToSave);
            _dbContext.SaveChanges();           
        }

        public IEnumerable<AccountRoot> GetAggregates()
        {
            var aggregates = new List<AccountRoot>();

            _dbContext.EventSourcing
                .Select(@event => @event.AggregateId)
                .Distinct()
                .ToList()
                .ForEach(id => 
                {
                    var aggregate = GetById(id);
                    if (aggregate == null) return;

                    aggregates.Add(aggregate);
                });

            return aggregates;
        }
    }
}
