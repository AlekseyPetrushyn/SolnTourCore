using System.Collections.Generic;
using System.Linq;
using SolnTourCore.Business.DTO;
using SolnTourCore.Business.Services.Interfaces.ServiceInterfaces;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.Business.Services.Implementations
{
    public class LocationService : ILocationService
    {
        private IRepository<Location> _locationRepository;

        public LocationService(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public IEnumerable<LocationDTO> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<Location>, List<LocationDTO>>(_locationRepository.GetAll());
        }

        public LocationDTO Get(int id)
        {
            return AutoMapper.Mapper.Map<Location, LocationDTO>(_locationRepository.Get(id));
        }

        public void Create(LocationDTO item)
        {
            _locationRepository.Create(AutoMapper.Mapper.Map<Location>
                (new LocationDTO
                {
                    LocationId = _locationRepository.GetAll().Count() + 1,
                    LocationName = item.LocationName,
                    Description = item.Description
                }));
        }

        public void Update(LocationDTO item)
        {
            Location location = _locationRepository.Get(item.LocationId);
            location.LocationName = item.LocationName;
            location.Description = item.Description;
            _locationRepository.Update(location);

        }

        public void Delete(int id)
        {
            _locationRepository.Delete(id);
        }
    }
}
