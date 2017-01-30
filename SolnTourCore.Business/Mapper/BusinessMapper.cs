using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SolnTourCore.Business.DTO;
using SolnTourCore.DataAccess.Entities;

namespace SolnTourCore.Business.Mapper
{
	public class BusinessMapper : Profile
	{
		[Obsolete]
		protected override void Configure()
		{
				//сопоставляем соответствующие сущности из DataAccess layer с соответсвующими DTO сущностями из Business layer
			CreateMap<CountryDTO, Country>();
			CreateMap<Country, CountryDTO>();

			CreateMap<PlaceDTO, Place>();
			CreateMap<Place, PlaceDTO>();

			CreateMap<AccomodationDTO, Accomodation>();
			CreateMap<Accomodation, AccomodationDTO>();

			CreateMap<HotelCategoryDTO, HotelCategory>();
			CreateMap<HotelCategory, HotelCategoryDTO>();

			CreateMap<RoomTypeDTO, RoomType>();
			CreateMap<RoomType, RoomTypeDTO>();

			CreateMap<FoodDTO, Food>();
			CreateMap<Food, FoodDTO>();

			CreateMap<LocationDTO, Location>();
			CreateMap<Location, LocationDTO>();

			CreateMap<RecreationDTO, Recreation>();
			CreateMap<Recreation, RecreationDTO>();

			CreateMap<HotelDTO, Hotel>();
			CreateMap<Hotel, HotelDTO>();

			CreateMap<TransportDTO, Transport>();
			CreateMap<Transport, TransportDTO>();

			CreateMap<DepartureCityDTO, DepartureCity>();
			CreateMap<DepartureCity, DepartureCityDTO>();

			CreateMap<DestinationCityDTO, DestinationCity>();
			CreateMap<DestinationCity, DestinationCityDTO>();

			CreateMap<TransferDTO, Transfer>();
			CreateMap<Transfer, TransferDTO>();

			CreateMap<AdditionalServiceDTO, AdditionalService>();
			CreateMap<AdditionalService, AdditionalServiceDTO>();

			CreateMap<TourOperatorDTO, TourOperator>();
			CreateMap<TourOperator, TourOperatorDTO>();

			CreateMap<TourDTO, Tour>();
			CreateMap<Tour, TourDTO>();

			CreateMap<DiscountDTO, Discount>();
			CreateMap<Discount, DiscountDTO>();

			CreateMap<ClientDTO, Client>();
			CreateMap<Client, ClientDTO>();

			CreateMap<AccessLevelDTO, AccessLevel>();
			CreateMap<AccessLevel, AccessLevelDTO>();

			CreateMap<EmployeeDTO, Employee>();
			CreateMap<Employee, EmployeeDTO>();

			CreateMap<OrderDTO, Order>();
			CreateMap<Order, OrderDTO>();
		}
	}
}
