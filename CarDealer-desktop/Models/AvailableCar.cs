using System;
using System.Collections.Generic;

namespace CarDealer_desktop.Models
{
    public partial class AvailableCar
    {
        public AvailableCar()
        {
            Callrequests = new HashSet<Callrequest>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public string Vin { get; set; } = null!;
        public string MileAge { get; set; } = null!;
        public int? Owners { get; set; }
        public int CanOrder { get; set; }

        public virtual Equipment Equipment { get; set; } = null!;
        public virtual ICollection<Callrequest> Callrequests { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
