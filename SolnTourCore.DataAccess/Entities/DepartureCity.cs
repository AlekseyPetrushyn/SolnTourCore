using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.DataAccess.Entities
{
	public class DepartureCity
	{
		[Key, Column("city_id")]
		public int CityId { get; set; }
		[ForeignKey("CountryId")]
		public Country Country { get; set; }
		[Column("country_id")]
		public int CountryId { get; set; }
		[Column("city_name")]
		public string CityName { get; set; }

	}
}