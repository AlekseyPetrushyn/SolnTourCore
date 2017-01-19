using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.DataAccess.Entities
{
	public class AdditionalService
	{
		[Key, Column("service_id")]
		public int ServiceId { get; set; }
		[Column("service_name")]
		public int ServiceName { get; set; }
		[Column("description")]
		public string Description { get; set; }
		[Column("price")]
		public decimal Price { get; set; }

		public IEnumerable<TourOperator> TourOperators { get; set; }
	}
}