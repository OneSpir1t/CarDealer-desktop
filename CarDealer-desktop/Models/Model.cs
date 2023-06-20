using System;
using System.Collections.Generic;

namespace CarDealer_desktop.Models
{
    public partial class Model
    {
        public Model()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Video { get; set; }

        public virtual Brand Brand { get; set; } = null!;
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
