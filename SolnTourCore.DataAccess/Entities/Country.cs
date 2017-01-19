using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SolnTourCore.DataAccess.Entities
{
	public class Country
	{
		[Key, Column("country_id")]
		public int CountryId { get; set; }
		[Column("country_name")]
		public string CountryName { get; set; }

		public IEnumerable<Place> Places { get; set; }	//referencies to Place
		public IEnumerable<DepartureCity> DepartureCities { get; set; } //referencies to DeparturCitys
		public IEnumerable<DestinationCity> DestinationCities { get; set; } //referencies to DestinationCitys

	}
}
