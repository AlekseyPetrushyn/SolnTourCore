using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.Presentation.ViewModels
{
    public class AdditionalServiceViewModel
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
