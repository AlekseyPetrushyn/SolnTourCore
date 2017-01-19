using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.DataAccess.Entities
{
	public class Accomodation
	{
		[Key, Column("accomodation_id")]
		public int AccomodationId { get; set; }
		[Column("accomodation_name")]
		public string AccomodationName { get; set; }
		[Column("description")]
		public string Description { get; set; }
		public IEnumerable<Hotel> Hotels { get; set; } //referencies to Hotel
	}
}