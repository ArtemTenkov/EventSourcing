using System;

namespace SharedKernel.DataObjects
{
    public class EventDataDto
    {
        public Guid Id { get; }
        public DateTime Created { get; }
        public string AggregateType { get; }
        public Guid AggregateId { get; }
        public int Version { get; }
        public string Event { get; }
        public string Metadata { get; }
        public EventDataDto(Guid id, DateTime created, string aggregateType,
             Guid aggregateId, int version, string @event, string metadata)
        {
            Id = id;
            Created = created;
            AggregateType = aggregateType;
            AggregateId = aggregateId;
            Version = version;
            Event = @event;
            Metadata = metadata;
        }
    }
}
