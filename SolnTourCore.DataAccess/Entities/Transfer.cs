using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.DataAccess.Entities
{
	public class Transfer
	{
		[Key, Column("transfer_id")]
		public int TransferId { get; set; }
		[ForeignKey("TransportId")]
		public Transport Transport { get; set; }
		[Column("transport_id")]
		public int TransportId { get; set; }
		[ForeignKey("CityId")]
		public DepartureCity DepartureCity { get; set; }
		[Column("departure_city_id")]
		public int DepartureCityId { get; set; }
		[ForeignKey("CityId")]
		public DestinationCity DestinationCity { get; set; }
		[Column("destination_city_id")]
		public int DestinationCityId { get; set; }
		[Column("price")]
		public decimal Price { get; set; }

		public IEnumerable<TourOperator> TourOperators { get; set; }
	}
}
