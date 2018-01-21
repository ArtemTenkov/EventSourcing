using System;

namespace SharedKernel.Domain
{
    public abstract class Entity
    {
        public virtual Guid Id { get; protected set; }
    }
}
