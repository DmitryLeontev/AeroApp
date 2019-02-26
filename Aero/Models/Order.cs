using System;
using System.Collections.Generic;

namespace Aero.Models
{
    public partial class Order
    {
        public Order()
        {
            FlightsInOrder = new HashSet<FlightsInOrder>();
        }

        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public byte[] Version { get; set; }
        public bool? Deleted { get; set; }
        public string Status { get; set; }
        public string ClientId { get; set; }
        public double? Sum { get; set; }
        public double? Discount { get; set; }

        public virtual ICollection<FlightsInOrder> FlightsInOrder { get; set; }
        public virtual Clients Client { get; set; }
        public virtual Status StatusNavigation { get; set; }
    }
}
