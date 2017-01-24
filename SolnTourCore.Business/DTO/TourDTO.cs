using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.Business.DTO
{
	public class TourDTO
	{
		public int TourId { get; set; }
		public TourOperatorDTO TourOperator { get; set; }
		public int TourOperatorId { get; set; }
		public HotelDTO Hotel { get; set; }
		public int HotelId { get; set; }
		public DateTime DepartureDate { get; set; }
		public DateTime DestinationDate { get; set; }
	}
}
