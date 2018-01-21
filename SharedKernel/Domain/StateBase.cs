using System.Collections.Generic;

namespace SharedKernel.Domain
{
    public abstract class StateBase
    {
        public int Version { get; set; }
        public StateBase(IEnumerable<object> events = null)
        {
            if (events == null) return;
            foreach (var @event in events)
            {
                Version++;
                Modify(@event);
            }
                
        }

        public abstract void Modify(object @event);
    }
}
