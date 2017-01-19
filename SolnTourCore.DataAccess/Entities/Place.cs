using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolnTourCore.DataAccess.Entities
{
	public class Place
	{
		[Key, Column("place_id")]
		public int PlaceId { get; set; }
		[Column("place_name")]
		public string PlaceName { get; set; }
		[ForeignKey("CountryId"), Column("country_id")]
		public int CountryId { get; set; }
		public IEnumerable<Hotel> Hotels { get; set; } //referencies to Hotel
	}
}
