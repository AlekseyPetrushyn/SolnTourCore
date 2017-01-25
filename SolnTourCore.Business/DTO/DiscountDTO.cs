using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.Business.DTO
{
	public class DiscountDTO
	{
		public int DiscountId { get; set; }
		public string DiscountName { get; set; }
		public double Percent { get; set; }
	}
}
