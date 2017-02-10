using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SolnTourCore.Business.DTO;
using SolnTourCore.Business.Services.Interfaces.ServiceInterfaces;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.Business.Services.Implementations
{
    public class HotelService : IHotelService
    {
        private IRepository<Hotel> _hotelRepository;

        public HotelService(IRepository<Hotel> hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public IEnumerable<HotelDTO> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<Hotel>, List<HotelDTO>>(_hotelRepository.GetAll());
        }

        public HotelDTO Get(int id)
        {
            return AutoMapper.Mapper.Map<Hotel, HotelDTO>(_hotelRepository.Get(id));
        }

        public void Create(HotelDTO item)
        {
            _hotelRepository.Create(AutoMapper.Mapper.Map<Hotel>
                (new HotelDTO
                {
                    HotelId = _hotelRepository.GetAll().Count() + 1,
                    PlaceId = item.PlaceId,
                    HotelName = item.HotelName,
                    HotelCategoryId = item.HotelCategoryId,
                    FoodId = item.FoodId,
                    RoomTypeId = item.RoomTypeId,
                    AccomodationId = item.AccomodationId,
                    LocationId = item.LocationId,
                    RecreationId = item.RecreationId,
                    Price = item.Price
                }));
        }

        public void Update(HotelDTO item)
        {
            Hotel hotel = _hotelRepository.Get(item.HotelId);
            hotel.PlaceId = item.PlaceId;
            hotel.HotelName = item.HotelName;
            hotel.HotelCategoryId = item.HotelCategoryId;
            hotel.FoodId = item.FoodId;
            hotel.RoomTypeId = item.RoomTypeId;
            hotel.AccomodationId = item.AccomodationId;
            hotel.LocationId = item.LocationId;
            hotel.RecreationId = item.RecreationId;
            hotel.Price = item.Price;
            _hotelRepository.Update(hotel);
        }

        public void Delete(int id)
        {
            _hotelRepository.Delete(id);
        }

            //найдём самый догорой отель
        public HotelDTO MaxPriceHotel(string countryName)
        {

            IEnumerable<HotelDTO> hotels =
                AutoMapper.Mapper.Map<IEnumerable<Hotel>, List<HotelDTO>>(_hotelRepository.Find(h => h.Place.Country.CountryName == countryName));  //все отели в заданной стране
            hotels.OrderBy(h => h.Price);       //сортируем по возрастанию цены

            return hotels.Last();
        }

        //найдём самый дешёвый отель
        public HotelDTO MinPriceHotel(string country)
        {


            return null;
        }
    }
}
