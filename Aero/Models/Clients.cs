using System;
using System.Collections.Generic;

namespace Aero.Models
{
    public partial class Clients
    {
        public Clients()
        {
            Order = new HashSet<Order>();
        }

        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public byte[] Version { get; set; }
        public bool? Deleted { get; set; }
        public string IdUser { get; set; }
        public double? NumbPassport { get; set; }
        public DateTimeOffset? BirthDate { get; set; }

        public virtual ICollection<Order> Order { get; set; }
        public virtual Users IdUserNavigation { get; set; }
    }
}
