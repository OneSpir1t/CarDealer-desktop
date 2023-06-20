using System;
using System.Collections.Generic;

namespace CarDealer_desktop.Models
{
    public partial class Status
    {
        public Status()
        {
            Callrequests = new HashSet<Callrequest>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<Callrequest> Callrequests { get; set; }
    }
}
