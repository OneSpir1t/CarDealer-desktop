using System;
using System.Collections.Generic;

namespace CarDealer_desktop.Models
{
    public partial class Manager
    {
        public Manager()
        {
            Callrequests = new HashSet<Callrequest>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? Patronymic { get; set; }
        public long Passport { get; set; }
        public string Phone { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Callrequest> Callrequests { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
