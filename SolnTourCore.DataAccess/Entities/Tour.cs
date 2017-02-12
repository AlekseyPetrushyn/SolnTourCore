using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.DataAccess.Entities
{
	public class Tour
	{
		[Key, Column("tour_id")]
		public int TourId { get; set; }
		[ForeignKey("OperatorId")]
		public TourOperator TourOperator { get; set; }
		[Column("tour_operator_id")]
		public int OperatorId { get; set; }
		[ForeignKey("HotelId")]
		public Hotel Hotel { get; set; }
		[Column("hotel_id")]
		public int HotelId { get; set; }
		[Column("departure_date")]
		public DateTime DepartureDate { get; set; }
		[Column("destination_date")]
		public DateTime DestinationDate { get; set; }

		public IEnumerable<Order> Orders { get; set; }
	}
}