using System.Collections.Generic;
using System.Linq;
using SolnTourCore.Business.DTO;
using SolnTourCore.Business.Services.Interfaces.ServiceInterfaces;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.Business.Services.Implementations
{
    public class DestinationCityService : IDestinationCityService
    {
        private IRepository<DestinationCity> _destinationCityRepository;

        public DestinationCityService(IRepository<DestinationCity> _repository)
        {
            _destinationCityRepository = _repository;
        }

        public IEnumerable<DestinationCityDTO> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<DestinationCity>, List<DestinationCityDTO>>(_destinationCityRepository.GetAll());
        }

        public DestinationCityDTO Get(int id)
        {
            return AutoMapper.Mapper.Map<DestinationCity, DestinationCityDTO>(_destinationCityRepository.Get(id));
        }

        public void Create(DestinationCityDTO item)
        {
            _destinationCityRepository.Create(AutoMapper.Mapper.Map<DestinationCity>
                (new DestinationCityDTO
                {
                    CityId = _destinationCityRepository.GetAll().Count() + 1,
                    CityName = item.CityName,
                    CountryId = item.CountryId
                }));
        }

        public void Update(DestinationCityDTO item)
        {
            var city = _destinationCityRepository.Get(item.CityId);
            city.CityName = item.CityName;
            city.CountryId = item.CountryId;
            _destinationCityRepository.Update(city);
        }

        public void Delete(int id)
        {
            _destinationCityRepository.Delete(id);
        }
    }
}
