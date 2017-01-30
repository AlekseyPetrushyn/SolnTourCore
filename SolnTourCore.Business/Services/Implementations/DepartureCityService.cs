using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolnTourCore.Business.DTO;
using SolnTourCore.Business.Services.Interfaces.ServiceInterfaces;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.Business.Services.Implementations
{
    public class DepartureCityService : IDepartureCityService
    {
        private IRepository<DepartureCity> _departureCityRepository;

        public DepartureCityService(IRepository<DepartureCity> departureCityRepository)
        {
            _departureCityRepository = departureCityRepository;
        }

        public IEnumerable<DepartureCityDTO> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<DepartureCity>, List<DepartureCityDTO>>(_departureCityRepository.GetAll());
        }

        public DepartureCityDTO Get(int id)
        {
            return AutoMapper.Mapper.Map<DepartureCity, DepartureCityDTO>(_departureCityRepository.Get(id));
        }

        public void Create(DepartureCityDTO item)
        {
            DepartureCity city = new DepartureCity
            {
                CityId = _departureCityRepository.GetAll().Count() + 1,
                CityName = item.CityName,
                CountryId = item.CountryId
            };
            _departureCityRepository.Create(city);
        }

        public void Update(DepartureCityDTO item)
        {
            DepartureCity city = _departureCityRepository.Get(item.CityId);
            city.CityName = item.CityName;
            city.CountryId = item.CountryId;
            _departureCityRepository.Update(city);
        }

        public void Delete(int id)
        {
            _departureCityRepository.Delete(id);
        }
    }
}
