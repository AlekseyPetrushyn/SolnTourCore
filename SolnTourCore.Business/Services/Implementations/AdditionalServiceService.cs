using System.Collections.Generic;
using System.Linq;
using SolnTourCore.Business.DTO;
using SolnTourCore.Business.Services.Interfaces.ServiceInterfaces;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.Business.Services.Implementations
{
    public class AdditionalServiceService : IAdditionalServiceService
    {
        private IRepository<AdditionalService> _repository { get; set; }

        public AdditionalServiceService(IRepository<AdditionalService> repository)
        {
            _repository = repository;
        }

        public IEnumerable<AdditionalServiceDTO> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<AdditionalService>, List<AdditionalServiceDTO>>(_repository.GetAll());
        }

        public AdditionalServiceDTO Get(int id)
        {
            return AutoMapper.Mapper.Map<AdditionalService, AdditionalServiceDTO>(_repository.Get(id));
        }

        public void Create(AdditionalServiceDTO item)
        {
            _repository.Create(AutoMapper.Mapper.Map<AdditionalService>
                (new AdditionalServiceDTO
                {
                    ServiceId = _repository.GetAll().Count() + 1,
                    ServiceName = item.ServiceName,
                    Description = item.Description,
                    Price = item.Price
                }
                ));
        }

        public void Update(AdditionalServiceDTO item)
        {
            var additionalService = _repository.Get(item.ServiceId);
            additionalService.ServiceName = item.ServiceName;
            additionalService.Price = item.Price;
            additionalService.Description = item.Description;
            _repository.Update(additionalService);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
