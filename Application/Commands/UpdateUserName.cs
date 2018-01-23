using MediatR;
using SharedKernel.ValueObjects;
using System;

namespace Application.Commands
{
    public class UpdateUserName : IRequest<bool>
    {
        public Guid AggregateId { get; }
        public Name Name { get; }
        public UpdateUserName(Guid aggregateId, Name name)
        {
            AggregateId = aggregateId;
            Name = name;
        }
    }
}
