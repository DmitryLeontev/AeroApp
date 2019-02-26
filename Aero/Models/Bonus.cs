using System;
using System.Collections.Generic;

namespace Aero.Models
{
    public partial class Bonus
    {
        public Bonus()
        {
            Flights = new HashSet<Flights>();
        }

        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public byte[] Version { get; set; }
        public bool? Deleted { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public string Descript { get; set; }
        public string PathImage { get; set; }

        public virtual ICollection<Flights> Flights { get; set; }
    }
}
