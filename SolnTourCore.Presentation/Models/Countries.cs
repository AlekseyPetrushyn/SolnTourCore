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
		public IEnumerable<Place> Places { get; set; }  //referencies to Place
		public IEnumerable<DepartureCity> DepartureCities { get; set; } //referencies to DeparturCitys
		public IEnumerable<DestinationCity> DestinationCities { get; set; } //referencies to DestinationCitys
	}
	public class Place
	{
		[Key, Column("place_id")]
		public int PlaceId { get; set; }
		[Column("place_name")]
		public string PlaceName { get; set; }
		[ForeignKey("CountryId")]
		public Country Country { get; set; }
		[Column("country_id")]
		public int CountryId { get; set; }
		public IEnumerable<Hotel> Hotels { get; set; }  //referencies to Hotel
	}
	public class Accomodation
	{
		[Key, Column("accomodation_id")]
		public int AccomodationId { get; set; }
		[Column("accomodation_name")]
		public string AccomodationName { get; set; }
		[Column("description")]
		public string Description { get; set; }
		public IEnumerable<Hotel> Hotels { get; set; } //referencies to Hotel
	}
	public class HotelCategory
	{
		[Key, Column("hotel_category_id")]
		public int HotelCategoryId { get; set; }
		[Column("hotel_category_name")]
		public string HotelCategoryName { get; set; }
		[Column("description")]
		public string Description { get; set; }
		public IEnumerable<Hotel> Hotels { get; set; } //referencies to Hotel
	}
	public class RoomType
	{
		[Key, Column("room_type_id")]
		public int RoomTypeId { get; set; }
		[Column("room_type_name")]
		public string RoomTypeName { get; set; }
		[Column("description")]
		public string Description { get; set; }
		public IEnumerable<Hotel> Hotels { get; set; } //referencies to Hotel
	}
	public class Food
	{
		[Key, Column("food_id")]
		public int FoodId { get; set; }
		[Column("food_name")]
		public string FoodName { get; set; }
		[Column("description")]
		public string Description { get; set; }
		public IEnumerable<Hotel> Hotels { get; set; } //referencies to Hotel
	}
	public class Location
	{
		[Key, Column("location_id")]
		public int LocationId { get; set; }
		[Column("location_name")]
		public string LocationName { get; set; }
		[Column("description")]
		public string Description { get; set; }
		public IEnumerable<Hotel> Hotels { get; set; } //referencies to Hotel
	}
	public class Recreation
	{
		[Key, Column("recreation_id")]
		public int RecreationId { get; set; }
		[Column("recreation_name")]
		public string RecreationName { get; set; }
		[Column("description")]
		public string Description { get; set; }
		public IEnumerable<Hotel> Hotels { get; set; } //referencies to Hotel
	}
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
		public IEnumerable<Tour> Tours { get; set; }
	}


	public class Transport
	{
		[Key, Column("transport_id")]
		public int TransportId { get; set; }
		[Column("transport_name")]
		public string TransportName { get; set; }
		public IEnumerable<Transfer> Transfers { get; set; }
	}
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
		public IEnumerable<Transfer> Transfers { get; set; }
	}
	public class DestinationCity
	{
		[Key, Column("city_id")]
		public int CityId { get; set; }
		[ForeignKey("CountryId")]
		public Country Country { get; set; }
		[Column("country_id")]
		public int CountryId { get; set; }
		[Column("city_name")]
		public string CityName { get; set; }
		public IEnumerable<Transfer> Transfers { get; set; }
	}
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


	public class AdditionalService
	{
		[Key, Column("service_id")]
		public int ServiceId { get; set; }
		[Column("service_name")]
		public int ServiceName { get; set; }
		[Column("description")]
		public string Description { get; set; }
		[Column("price")]
		public decimal Price { get; set; }
		public IEnumerable<TourOperator> TourOperators { get; set; }
	}
	public class TourOperator
	{
		[Key, Column("operator_id")]
		public int OperatorId { get; set; }
		[Column("operator_name")]
		public string OperatorName { get; set; }
		[ForeignKey("ServiceId")]
		public AdditionalService AdditionalService { get; set; }
		[Column("additional_service_id")]
		public int AdditionalServiceId { get; set; }
		[ForeignKey("TransferId")]
		public Transfer Transfer { get; set; }
		[Column("transfer_id")]
		public int TransferId { get; set; }
		public IEnumerable<Tour> Tours { get; set; }
	}
	public class Tour
	{
		[Key, Column("tour_id")]
		public int TourId { get; set; }
		[ForeignKey("OperatorId")]
		public TourOperator TourOperator { get; set; }
		[Column("tour_operator_id")]
		public int TourOperatorId { get; set; }
		[ForeignKey("HotelId")]
		public Hotel Hotel { get; set; }
		[Column("hotel_id")]
		public int HotelId { get; set; }
		[Column("departure_date")]
		public DateTime DapartureDate { get; set; }
		[Column("destination_date")]
		public DateTime DestinationDate { get; set; }
	}
	public class Discount
	{
		[Key, Column("discount_id")]
		public int DiscountId { get; set; }
		[Column("discount_name")]
		public string DiscountName { get; set; }
		[Column("percent")]
		public double Percent { get; set; }
		public IEnumerable<Client> Clients { get; set; }
	}
	public class Client
	{
		[Key, Column("client_id")]
		public int ClientId { get; set; }
		[Column("second_name")]
		public string SecondName { get; set; }
		[Column("first_name")]
		public string FirstName { get; set; }
		[Column("patronymic")]
		public string Patronymic { get; set; }
		[Column("birth_day")]
		public DateTime BirthDay { get; set; }
		[Column("adress")]
		public string Address { get; set; }
		[Column("mobil_number")]
		public string MobilNumber { get; set; }
		[Column("email")]
		public string Email { get; set; }
		[ForeignKey("DiscountId")]
		public Discount Discount { get; set; }
		[Column("discount_id")]
		public int DiscountId { get; set; }
		[Column("login")]
		public string Login { get; set; }
		[Column("password")]
		public string Password { get; set; }
	}
	public class AccessLevel
	{
		[Key, Column("access_id")]
		public int AccessId { get; set; }
		[Column("access_name")]
		public string AccessName { get; set; }
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
		public DbSet<Hotel> hotels { get; set; }

		public DbSet<Transport> transports { get; set; }
		public DbSet<DepartureCity> departure_citys { get; set; }
		public DbSet<DestinationCity> destination_citys { get; set; }
		public DbSet<Transfer> transfers { get; set; }

		public DbSet<AdditionalService> additional_services { get; set; }
		public DbSet<TourOperator> tour_operators { get; set; }
		public DbSet<Tour> tours { get; set; }
		public DbSet<Discount> discounts { get; set; }
		public DbSet<Client> clients { get; set; }
		public DbSet<AccessLevel> access_levels { get; set; }
	}
}
