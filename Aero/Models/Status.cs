using System;
using System.Collections.Generic;

namespace Aero.Models
{
    public partial class Status
    {
        public Status()
        {
            Order = new HashSet<Order>();
        }

        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public byte[] Version { get; set; }
        public bool? Deleted { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
