using System;
using System.Collections.Generic;

namespace CarDealer_desktop.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int ManagerId { get; set; }
        public int? AvailableCarId { get; set; }
        public DateOnly? Date { get; set; }
        public int? EquipmentId { get; set; }

        public virtual AvailableCar? AvailableCar { get; set; }
        public virtual User Buyer { get; set; } = null!;
        public virtual Equipment? Equipment { get; set; }
        public virtual User Manager { get; set; } = null!;
    }
}
