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
    public class AccomodationService : IAccomodationService
    {
        private IRepository<Accomodation> _accomodationRepository;

        public AccomodationService(IRepository<Accomodation> accomodationRepository)
        {
            _accomodationRepository = accomodationRepository;
        }
        public IEnumerable<AccomodationDTO> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<Accomodation>, List<AccomodationDTO>>(_accomodationRepository.GetAll());
        }

        public AccomodationDTO Get(int id)
        {
            return AutoMapper.Mapper.Map<Accomodation, AccomodationDTO>(_accomodationRepository.Get(id));
        }

        public void Create(AccomodationDTO item)
        {
            Accomodation accomodation = new Accomodation
            {
                AccomodationId = _accomodationRepository.GetAll().Count() + 1,
                AccomodationName = item.AccomodationName,
                Description = item.Description
            };
            _accomodationRepository.Create(accomodation);
        }

        public void Update(AccomodationDTO item)
        {
            Accomodation accomodation = _accomodationRepository.Get(item.AccomodationId);
            accomodation.AccomodationName = item.AccomodationName;
            accomodation.Description = item.Description;
            _accomodationRepository.Update(accomodation);
        }

        public void Delete(int id)
        {
            _accomodationRepository.Delete(id);
        }
    }
}
