using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SolnTourCore.Business.DTO;
using SolnTourCore.Presentation.ViewModels;

namespace SolnTourCore.Presentation.Mapper
{
	public class PresentationMapper : Profile
	{
		[Obsolete]
		protected override void Configure()
		{
			CreateMap<CountryViewModel, CountryDTO>();
			CreateMap<CountryDTO, CountryViewModel>();

		    CreateMap<PlaceViewModel, PlaceDTO>();
		    CreateMap<PlaceDTO, PlaceViewModel>();

		    CreateMap<AccomodationViewModel, AccomodationDTO>();
		    CreateMap<AccomodationDTO, AccomodationViewModel>();

		    CreateMap<HotelCategoryViewModel, HotelCategoryDTO>();
		    CreateMap<HotelCategoryDTO, HotelCategoryViewModel>();

		    CreateMap<RoomTypeViewModel, RoomTypeDTO>();
		    CreateMap<RoomTypeDTO, RoomTypeViewModel>();

		    CreateMap<FoodViewModel, FoodDTO>();
		    CreateMap<FoodDTO, FoodViewModel>();

		    CreateMap<LocationViewModel, LocationDTO>();
		    CreateMap<LocationDTO, LocationViewModel>();

		    CreateMap<RecreationViewModel, RecreationDTO>();
		    CreateMap<RecreationDTO, RecreationViewModel>();

		    CreateMap<HotelViewModel, HotelDTO>();
		    CreateMap<HotelDTO, HotelViewModel>();

		    CreateMap<TransportViewModel, TransportDTO>();
		    CreateMap<TransportDTO, TransportViewModel>();

		    CreateMap<DepartureCityViewModel, DepartureCityDTO>();
		    CreateMap<DepartureCityDTO, DepartureCityViewModel>();

		    CreateMap<DestinationCityViewModel, DestinationCityDTO>();
		    CreateMap<DestinationCityDTO, DestinationCityViewModel>();

		    CreateMap<TransferViewModel, TransferDTO>();
		    CreateMap<TransferDTO, TransferViewModel>();
            
		}
	}
}
