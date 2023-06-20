using System;
using System.Collections.Generic;

namespace CarDealer_desktop.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Models = new HashSet<Model>();
        }

        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Title { get; set; } = null!;

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Model> Models { get; set; }
    }
}
