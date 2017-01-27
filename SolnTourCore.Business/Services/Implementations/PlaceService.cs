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
            throw new NotImplementedException();
        }

        public void Create(PlaceDTO item)
        {
            throw new NotImplementedException();
        }

        public void Update(PlaceDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
