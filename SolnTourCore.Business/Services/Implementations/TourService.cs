using System.Collections.Generic;
using System.Linq;
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
            tour.TourOperatorId = item.TourOperatorId;
            tour.HotelId = item.HotelId;
            tour.DepartureDate = item.DepartureDate;
            tour.DestinationDate = item.DestinationDate;
            _repository.Update(tour);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
