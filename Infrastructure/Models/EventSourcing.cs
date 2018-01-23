using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class EventSourcing
    {
        public Guid Id { get; set; }
        public string AggregateType { get; set; }
        public Guid AggregateId { get; set; }
        public int Version { get; set; }
        public string Event { get; set; }
        public string Metadata { get; set; }
        public bool Dispatched { get; set; }
    }
}
