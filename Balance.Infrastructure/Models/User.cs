using System;
using System.Collections.Generic;

namespace Balance.Infrastructure.Models
{
    public partial class User
    {
        public User()
        {
            Transaction = new HashSet<Transaction>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Guid? PositionId { get; set; }

        public ICollection<Transaction> Transaction { get; set; }
    }
}
