using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.Presentation.ViewModels
{
    public class OrderViewModel
    {
		public int OrderId { get; set; }
		public int TourId { get; set; }
		public int ClientId { get; set; }
		public int EmployeeId { get; set; }
		public decimal OrderPrice { get; set; }

        public TourViewModel Tour { get; set; }
        public ClientViewModel Client { get; set; }
        public EmployeeViewModel Employee { get; set; }
    }
}
