using System;

namespace User.Infrastructure.Models
{
    public partial class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Guid PositionId { get; set; }
    }
}
