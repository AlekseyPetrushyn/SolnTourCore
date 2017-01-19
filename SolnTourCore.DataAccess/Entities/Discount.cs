using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.DataAccess.Entities
{
	public class Discount
	{
		[Key, Column("discount_id")]
		public int DiscountId { get; set; }
		[Column("discount_name")]
		public string DiscountName { get; set; }
		[Column("percent")]
		public double Percent { get; set; }
	}
}
