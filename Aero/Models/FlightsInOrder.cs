using System;
using System.Collections.Generic;

namespace Aero.Models
{
    public partial class FlightsInOrder
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public byte[] Version { get; set; }
        public bool? Deleted { get; set; }
        public string OrderId { get; set; }
        public string FlightId { get; set; }

        public virtual Flights Flight { get; set; }
        public virtual Order Order { get; set; }
    }
}
