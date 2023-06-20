using System;
using System.Collections.Generic;

namespace CarDealer_desktop.Models
{
    public partial class Technicalinformation
    {
        public Technicalinformation()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int Id { get; set; }
        public int EngineTypeId { get; set; }
        public int ColorId { get; set; }
        public int BodyTypeId { get; set; }
        public int CountSeats { get; set; }
        public int Horsepower { get; set; }
        public string Yearofmanufacture { get; set; } = null!;
        public int TransmissionId { get; set; }
        public string Enginedisplacement { get; set; } = null!;
        public int DriveTypeId { get; set; }

        public virtual Bodytype BodyType { get; set; } = null!;
        public virtual Color Color { get; set; } = null!;
        public virtual Drivetype DriveType { get; set; } = null!;
        public virtual Enginetype EngineType { get; set; } = null!;
        public virtual Transmission Transmission { get; set; } = null!;
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
