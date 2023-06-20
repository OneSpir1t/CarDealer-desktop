using System;
using System.Collections.Generic;

namespace CarDealer_desktop.Models
{
    public partial class Buyer
    {
        public Buyer()
        {
            Callrequests = new HashSet<Callrequest>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? LastName { get; set; }
        public string FirstName { get; set; } = null!;
        public string? Patronymic { get; set; }
        public DateOnly? Birthday { get; set; }
        public long? Passport { get; set; }
        public string? Address { get; set; }
        public string Phone { get; set; } = null!;

        public virtual ICollection<Callrequest> Callrequests { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
