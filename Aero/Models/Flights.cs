using System;
using System.Collections.Generic;

namespace Aero.Models
{
    public partial class Flights
    {
        public Flights()
        {
            FlightsInOrder = new HashSet<FlightsInOrder>();
        }

        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public byte[] Version { get; set; }
        public bool? Deleted { get; set; }
        public string Port1 { get; set; }
        public DateTimeOffset? Time1 { get; set; }
        public string Port2 { get; set; }
        public DateTimeOffset? Time2 { get; set; }
        public string PlaneId { get; set; }
        public double? Price { get; set; }
        public string StatusId { get; set; }
        public string BonusId { get; set; }

        public virtual ICollection<FlightsInOrder> FlightsInOrder { get; set; }
        public virtual Bonus Bonus { get; set; }
        public virtual Planes Plane { get; set; }
        public virtual Airports Port1Navigation { get; set; }
        public virtual Airports Port2Navigation { get; set; }
    }
}
