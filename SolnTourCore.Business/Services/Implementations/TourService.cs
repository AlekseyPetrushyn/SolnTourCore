using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using SolnTourCore.Business.DTO;
using SolnTourCore.Business.Services.Interfaces.ServiceInterfaces;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.Business.Services.Implementations
{
    public class TourService : ITourService
    {
        private IRepository<Tour> _repository { get; set; }

        public TourService(IRepository<Tour> repository)
        {
            _repository = repository;
        }

        public IEnumerable<TourDTO> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<Tour>, List<TourDTO>>(_repository.GetAll());
        }

        public TourDTO Get(int id)
        {
            return AutoMapper.Mapper.Map<Tour, TourDTO>(_repository.Get(id));
        }

        public void Create(TourDTO item)
        {
            _repository.Create(AutoMapper.Mapper.Map<Tour>
                (new TourDTO
                {
                    TourId = _repository.GetAll().Count() + 1,
                    TourOperatorId = item.TourOperatorId,
                    HotelId = item.HotelId,
                    DestinationDate = item.DestinationDate,
                    DepartureDate = item.DepartureDate
                }));
        }

        public void Update(TourDTO item)
        {
            var tour = _repository.Get(item.TourId);
            tour.OperatorId = item.TourOperatorId;
            tour.HotelId = item.HotelId;
            tour.DepartureDate = item.DepartureDate;
            tour.DestinationDate = item.DestinationDate;
            _repository.Update(tour);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<TourDTO> FindTours(string countryName, string hotelCategoryName)
        {
            IEnumerable<TourDTO> tours =
                AutoMapper.Mapper.Map<IEnumerable<Tour>, List<TourDTO>>(_repository.GetAll().Where(t => t.Hotel.Place.Country.CountryName == countryName)
                .Where(t => t.Hotel.HotelCategory.HotelCategoryName == hotelCategoryName));
            return tours;
        }

        //рассчитаем общую стоимость тура
        public decimal GetTotalPrice(int id)
        {
            TourDTO tour = AutoMapper.Mapper.Map<Tour, TourDTO>(_repository.Get(id));
            return (tour.Hotel.Price + tour.TourOperator.AdditionalService.Price + tour.TourOperator.Transfer.Price);
        }

        public TourDTO MaxPriceTour(string countryName)
        {
            IEnumerable<TourDTO> tours =
                AutoMapper.Mapper.Map<IEnumerable<Tour>, List<TourDTO>>(
                    _repository.Find(t => t.Hotel.Place.Country.CountryName == countryName));
            List<Tuple<TourDTO, decimal>> Tours = new List<Tuple<TourDTO, decimal>>();

            foreach (var item in tours)
            {
                Tours.Add(new Tuple<TourDTO, decimal>(item, GetTotalPrice(item.TourId)));
            }
            
            return Tours.Find(t => t.Item2 == Tours.Max(m => m.Item2)).Item1; //находим макс стоимость и по ней находим соответсвующий DTO
        }

        public TourDTO MinPriceTour(string countryName)
        {

            IEnumerable<TourDTO> tours =
                AutoMapper.Mapper.Map<IEnumerable<Tour>, List<TourDTO>>(
                    _repository.Find(t => t.Hotel.Place.Country.CountryName == countryName));
            List<Tuple< TourDTO, decimal>> Tours = new List<Tuple<TourDTO, decimal>>();

            foreach (var item in tours)
            {
                Tours.Add(new Tuple<TourDTO, decimal>(item, GetTotalPrice(item.TourId)));
            }
            return Tours.Find(t => t.Item2 == Tours.Min(m => m.Item2)).Item1;
        }
    }
}
