using System;
using System.Collections.Generic;

namespace CarDealer_desktop.Models
{
    public partial class Country
    {
        public Country()
        {
            Brands = new HashSet<Brand>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<Brand> Brands { get; set; }
    }
}
