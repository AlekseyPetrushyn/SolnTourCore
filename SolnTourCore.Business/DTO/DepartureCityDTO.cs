using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.Business.DTO
{
	public class DepartureCityDTO
	{
		public int CityId { get; set; }
		public CountryDTO Country { get; set; }
		public int CountryId { get; set; }
		public string CityName { get; set; }
	}
}
