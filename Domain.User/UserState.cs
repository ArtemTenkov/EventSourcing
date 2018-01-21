using System.Collections.Generic;
using Domain.User.Events;
using SharedKernel;
using SharedKernel.Domain;
using SharedKernel.Enums;
using SharedKernel.ValueObjects;

namespace Domain.User
{
    public class UserState : StateBase
    {
        public Name UserName { get; private set; }
        public Name LastName { get; private set; }
        public PositionType Position { get; private set; }
        public UserState(IEnumerable<object> events = null) 
            : base(events) { }

        public override void Modify(object @event) => 
            RedirectToWhen.InvokeEventOptional(this, @event);        

        public void When(UserCreated @event)
        {
            UserName = new Name(@event.UserName);
            LastName = new Name(@event.LastName);
            Position = @event.Position;
        }
    }
}
