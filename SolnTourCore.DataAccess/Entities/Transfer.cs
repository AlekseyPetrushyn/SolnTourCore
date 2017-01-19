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
	}
}
transfer_id SERIAL UNIQUE NOT NULL PRIMARY KEY,
transport_id INTEGER REFERENCES transports(transport_id),
departure_city_id INTEGER REFERENCES departure_citys(city_id),
destination_city_id INTEGER REFERENCES destination_citys(city_id),
transfer_price NUMERIC(6,2) NOT NULL