using System;
using System.Collections.Generic;

namespace CarDealer_desktop.Models
{
    public partial class Bodytype
    {
        public Bodytype()
        {
            Technicalinformations = new HashSet<Technicalinformation>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<Technicalinformation> Technicalinformations { get; set; }
    }
}
