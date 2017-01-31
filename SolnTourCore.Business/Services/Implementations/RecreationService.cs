using System.Collections.Generic;
using System.Linq;
using SolnTourCore.Business.DTO;
using SolnTourCore.Business.Services.Interfaces.ServiceInterfaces;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.Business.Services.Implementations
{
    public class RecreationService : IRecreationService
    {
        private IRepository<Recreation> _recreationRepository;

        public RecreationService(IRepository<Recreation> recreationRepository)
        {
            _recreationRepository = recreationRepository;
        }

        public IEnumerable<RecreationDTO> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<Recreation>, List<RecreationDTO>>(_recreationRepository.GetAll());
        }

        public RecreationDTO Get(int id)
        {
            return AutoMapper.Mapper.Map<Recreation, RecreationDTO>(_recreationRepository.Get(id));
        }

        public void Create(RecreationDTO item)
        {
            _recreationRepository.Create(AutoMapper.Mapper.Map<Recreation>
                (new RecreationDTO
                {
                    RecreationId = _recreationRepository.GetAll().Count() + 1,
                    RecreationName = item.RecreationName,
                    Description = item.Description
                }));
        }

        public void Update(RecreationDTO item)
        {
            Recreation recreation = _recreationRepository.Get(item.RecreationId);
            recreation.RecreationName = item.RecreationName;
            recreation.Description = item.Description;
            _recreationRepository.Update(recreation);
        }

        public void Delete(int id)
        {
            _recreationRepository.Delete(id);
        }
    }
}
