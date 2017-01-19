using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolnTourCore.Presentation.Models
{
	public class Country
	{
		[Key, Column("country_id")]
		public int CountryId { get; set; }
		[Column("country_name")]
		public string CountryName { get; set; }
		
	}
	public class Place
	{
		[Key, Column("place_id")]
		public int PlaceId { get; set; }
		[Column("place_name")]
		public string PlaceName { get; set; }
		[ForeignKey("CountryId"), Column("country_id")]
		public int CountryId { get; set; }
	}
	public class Accomodation
	{
		[Key, Column("accomodation_id")]
		public int AccomodationId { get; set; }
		[Column("accomodation_name")]
		public string AccomodationName { get; set; }
		[Column("description")]
		public string Description { get; set; }
	}
	public class HotelCategory
	{
		[Key, Column("hotel_category_id")]
		public int HotelCategoryId { get; set; }
		[Column("hotel_category_name")]
		public string HotelCategoryName { get; set; }
		[Column("description")]
		public string Description { get; set; }
	}
	public class RoomType
	{
		[Key, Column("room_type_id")]
		public int RoomTypeId { get; set; }
		[Column("room_type_name")]
		public string RoomTypeName { get; set; }
		[Column("description")]
		public string Description { get; set; }
	}
	public class Food
	{
		[Key, Column("food_id")]
		public int FoodId { get; set; }
		[Column("food_name")]
		public string FoodName { get; set; }
		[Column("description")]
		public string Description { get; set; }
	}
	public class Location
	{
		[Key, Column("location_id")]
		public int LocationId { get; set; }
		[Column("location_name")]
		public string LocationName { get; set; }
		[Column("description")]
		public string Description { get; set; }
	}
	public class Recreation
	{
		[Key, Column("recreation_id")]
		public int RecreationId { get; set; }
		[Column("recreation_name")]
		public string RecreationName { get; set; }
		[Column("description")]
		public string Description { get; set; }
	}
	public class CountryContext : DbContext
	{
		public CountryContext(DbContextOptions<CountryContext> options) : base(options)
		{
			
		}
		public DbSet<Country> countries { get; set; }
		public DbSet<Place> places { get; set; }
		public DbSet<Accomodation> accomodations { get; set; }
		public DbSet<HotelCategory> hotel_categorys { get; set; }
		public DbSet<RoomType> room_types { get; set; }
		public DbSet<Food> foods { get; set; }
		public DbSet<Location> locations { get; set; }
		public DbSet<Recreation> recreations { get; set; }
	}
}
