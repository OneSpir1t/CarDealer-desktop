using System;
using System.Collections.Generic;

namespace CarDealer_desktop.Models
{
    public partial class User
    {
        public User()
        {
            CallrequestBuyers = new HashSet<Callrequest>();
            CallrequestManagers = new HashSet<Callrequest>();
            OrderBuyers = new HashSet<Order>();
            OrderManagers = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? LastName { get; set; }
        public string FirstName { get; set; } = null!;
        public string? Patronymic { get; set; }
        public DateOnly? Birthday { get; set; }
        public long? Passport { get; set; }
        public string? Address { get; set; }
        public string Phone { get; set; } = null!;
        public string? Login { get; set; }
        public string? Password { get; set; }
        public int UserRoleId { get; set; }

        public virtual UserRole UserRole { get; set; } = null!;
        public virtual ICollection<Callrequest> CallrequestBuyers { get; set; }
        public virtual ICollection<Callrequest> CallrequestManagers { get; set; }
        public virtual ICollection<Order> OrderBuyers { get; set; }
        public virtual ICollection<Order> OrderManagers { get; set; }
    }
}
