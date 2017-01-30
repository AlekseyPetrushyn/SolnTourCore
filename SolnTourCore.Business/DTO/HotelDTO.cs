using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.Business.DTO
{
	public class HotelDTO
	{
		public int HotelId { get; set; }
		public int PlaceId { get; set; }
		public string HotelName { get; set; }
		public int HotelCategoryId { get; set; }
		public int FoodId { get; set; }
		public int RoomTypeId { get; set; }
		public int AccomodationId { get; set; }
		public int LocationId { get; set; }
		public int RecreationId { get; set; }
		public decimal Price { get; set; }
	}
}
