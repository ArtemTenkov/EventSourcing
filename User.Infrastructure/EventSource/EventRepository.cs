﻿using Domain.User;
using SharedKernel;
using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Infrastructure.Mapppers;
using User.Infrastructure.Models;

namespace User.Infrastructure.EventSource
{
    public class EventRepository : IEventRepository<UserRoot>
    {
        protected EventSourcingContext _dbContext;
        public IAggregateFactory<UserRoot> _aggregateFactory { get; }
        
        public EventRepository(IAggregateFactory<UserRoot> aggregateFactory,             
            EventSourcingContext dbContext)
        {
            _aggregateFactory = aggregateFactory;
            _dbContext = dbContext;           
        }
        public UserRoot GetById(Guid id)
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

        public IEnumerable<UserRoot> GetAggregates()
        {
            throw new NotImplementedException();
        }
    }
}
