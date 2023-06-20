using System;
using System.Collections.Generic;

namespace CarDealer_desktop.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            AvailableCars = new HashSet<AvailableCar>();
            Callrequests = new HashSet<Callrequest>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int ModelId { get; set; }
        public int TechnicalInformationId { get; set; }
        public string Title { get; set; } = null!;
        public double Cost { get; set; }
        public string? Image { get; set; }
        public int CanOrder { get; set; }

        public virtual Model Model { get; set; } = null!;
        public virtual Technicalinformation TechnicalInformation { get; set; } = null!;
        public virtual ICollection<AvailableCar> AvailableCars { get; set; }
        public virtual ICollection<Callrequest> Callrequests { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
