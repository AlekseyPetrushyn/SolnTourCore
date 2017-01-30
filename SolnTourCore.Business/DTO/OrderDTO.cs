using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.Business.DTO
{
	public class OrderDTO
	{
		public int OrderId { get; set; }
		public int TourId { get; set; }
		public int ClientId { get; set; }
		public int EmployeeId { get; set; }
		public decimal OrderPrice { get; set; }
	}
}
