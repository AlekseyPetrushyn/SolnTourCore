using System.Collections.Generic;
using System.Linq;
using SolnTourCore.Business.DTO;
using SolnTourCore.Business.Services.Interfaces.ServiceInterfaces;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.Business.Services.Implementations
{
    public class PlaceService : IPlaceService
    {
        private IRepository<Place> _placeRepository;

        public PlaceService(IRepository<Place> placeRepository)
        {
            _placeRepository = placeRepository;
        }
        public IEnumerable<PlaceDTO> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<Place>, List<PlaceDTO>>(_placeRepository.GetAll());
        }

        public PlaceDTO Get(int id)
        {
            return AutoMapper.Mapper.Map<Place, PlaceDTO>(_placeRepository.Get(id));
        }

        public void Create(PlaceDTO item)
        {
            _placeRepository.Create(AutoMapper.Mapper.Map<Place>
                (new PlaceDTO
                {
                    PlaceId = _placeRepository.GetAll().Count() + 1,
                    PlaceName = item.PlaceName,
                    CountryId = item.CountryId
                }
                ));
        }

        public void Update(PlaceDTO item)
        {
            Place place = _placeRepository.Get(item.PlaceId);
            place.PlaceName = item.PlaceName;
            place.CountryId = item.CountryId;
            _placeRepository.Update(place);
        }

        public void Delete(int id)
        {
            _placeRepository.Delete(id);
        }
    }
}
