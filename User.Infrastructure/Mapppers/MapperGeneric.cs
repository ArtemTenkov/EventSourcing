using User.Infrastructure.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharedKernel.DataObjects;
using SharedKernel.Domain;
using System;
using System.Collections.Generic;

namespace User.Infrastructure.Mapppers
{
    public class MapperGeneric
    {
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.None };
        public object Map(EventSourcing @event)
        {
            var eventData = new EventDataDto(@event.Id, DateTime.Now, @event.AggregateType,
                @event.AggregateId, @event.Version, @event.Event, @event.Metadata);

            var eventClrTypeName = JObject.Parse(eventData.Metadata).Property("EventClrType").Value;
            return JsonConvert.DeserializeObject(eventData.Event,
               Type.GetType((string)eventClrTypeName));
        }

        public EventSourcing Map(IDomainEvent @event, string aggregateType, Guid aggregateId, int version)
        {
            var data = JsonConvert.SerializeObject(@event, SerializerSettings);
            var eventHeaders = new Dictionary<string, object>
            {
                {
                    "EventClrType", @event.GetType().AssemblyQualifiedName
                }
            };
            var metadata = JsonConvert.SerializeObject(eventHeaders, SerializerSettings);
            var eventId = Guid.NewGuid();

            return new EventSourcing
            {
                Id = eventId,
                AggregateId = aggregateId,
                AggregateType = aggregateType,
                Version = version,
                Event = data,
                Metadata = metadata
            };
        }
    }
}
