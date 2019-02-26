using System;
using System.Collections.Generic;

namespace Aero.Models
{
    public partial class Users
    {
        public Users()
        {
            Clients = new HashSet<Clients>();
        }

        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public byte[] Version { get; set; }
        public bool? Deleted { get; set; }
        public string FName { get; set; }
        public string SName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double? PhoneNumber { get; set; }

        public virtual ICollection<Clients> Clients { get; set; }
    }
}
