using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer_desktop.Models
{
    public partial class CurrentUser
    {
        public static User currentUser { get; set; } = null!;
    }
}
