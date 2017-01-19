using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.DataAccess.Entities
{
	public class Hotel
	{
		[Key, Column("hotel_id")]
		public int HotelId { get; set; }
		[ForeignKey("PlaceId")]
		public Place Place { get; set; }
		[Column("place_id")]
		public int PlaceId { get; set; }
		[Column("hotel_name")]
		public string HotelName { get; set; }
		[ForeignKey("HotelCategoryId")]
		public HotelCategory HotelCategory { get; set; }
		[Column("hotel_category_id")]
		public int HotelCategoryId { get; set; }
		[ForeignKey("FoodId")]
		public Food Food { get; set; }
		[Column("food_id")]
		public int FoodId { get; set; }
		[ForeignKey("RoomTypeId")]
		public RoomType RoomType { get; set; }
		[Column("room_type_id")]
		public int RoomTypeId { get; set; }
		[ForeignKey("AccomodationId")]
		public Accomodation Accomodation { get; set; }
		[Column("accomodation_id")]
		public int AccomodationId { get; set; }
		[ForeignKey("LocationId")]
		public Location Location { get; set; }
		[Column("location_id")]
		public int LocationId { get; set; }
		[ForeignKey("RecreationId")]
		public Recreation Recreation { get; set; }
		[Column("recreation_id")]
		public int RecreationId { get; set; }
		[Column("price")]
		public decimal Price { get; set; }
	}
}
