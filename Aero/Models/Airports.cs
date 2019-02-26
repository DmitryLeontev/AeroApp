using System;
using System.Collections.Generic;

namespace Aero.Models
{
    public partial class Airports
    {
        public Airports()
        {
            FlightsPort1Navigation = new HashSet<Flights>();
            FlightsPort2Navigation = new HashSet<Flights>();
        }

        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public byte[] Version { get; set; }
        public bool? Deleted { get; set; }
        public string Iatacode { get; set; }
        public string Name { get; set; }
        public string CityId { get; set; }

        public virtual ICollection<Flights> FlightsPort1Navigation { get; set; }
        public virtual ICollection<Flights> FlightsPort2Navigation { get; set; }
        public virtual Cities City { get; set; }
    }
}
