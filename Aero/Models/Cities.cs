using System;
using System.Collections.Generic;

namespace Aero.Models
{
    public partial class Cities
    {
        public Cities()
        {
            Airports = new HashSet<Airports>();
        }

        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public byte[] Version { get; set; }
        public bool? Deleted { get; set; }
        public string Name { get; set; }
        public string IdCountry { get; set; }

        public virtual ICollection<Airports> Airports { get; set; }
        public virtual Countries IdCountryNavigation { get; set; }
    }
}
