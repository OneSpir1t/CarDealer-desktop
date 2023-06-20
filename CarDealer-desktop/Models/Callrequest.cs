using System;
using System.Collections.Generic;

namespace CarDealer_desktop.Models
{
    public partial class Callrequest
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int EquipmentId { get; set; }
        public int StatusId { get; set; }
        public int? ManagerId { get; set; }
        public DateOnly? DateRequest { get; set; }
        public DateOnly? DateStart { get; set; }
        public DateOnly? DateEnd { get; set; }
        public int? AvailableCarId { get; set; }

        public virtual AvailableCar? AvailableCar { get; set; }
        public virtual User Buyer { get; set; } = null!;
        public virtual Equipment Equipment { get; set; } = null!;
        public virtual User? Manager { get; set; }
        public virtual Status Status { get; set; } = null!;
    }
}
