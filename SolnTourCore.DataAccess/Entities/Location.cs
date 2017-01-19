using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.DataAccess.Entities
{
	public class Location
	{
		[Key, Column("location_id")]
		public int LocationId { get; set; }
		[Column("location_name")]
		public string LocationName { get; set; }
		[Column("description")]
		public string Description { get; set; }
		public IEnumerable<Hotel> Hotels { get; set; } //referencies to Hotel
	}
}
