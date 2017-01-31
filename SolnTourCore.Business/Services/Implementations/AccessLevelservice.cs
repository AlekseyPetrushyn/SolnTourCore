using System.Collections.Generic;
using System.Linq;
using SolnTourCore.Business.DTO;
using SolnTourCore.Business.Services.Interfaces.ServiceInterfaces;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.Business.Services.Implementations
{
    public class AccessLevelService : IAccessLevelService
    {
        private IRepository<AccessLevel> _repository { get; set; }

        public AccessLevelService(IRepository<AccessLevel> repository)
        {
            _repository = repository;
        }

        public IEnumerable<AccessLevelDTO> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<AccessLevel>, List<AccessLevelDTO>>(_repository.GetAll());
        }

        public AccessLevelDTO Get(int id)
        {
            return AutoMapper.Mapper.Map<AccessLevel, AccessLevelDTO>(_repository.Get(id));
        }

        public void Create(AccessLevelDTO item)
        {
            _repository.Create(AutoMapper.Mapper.Map<AccessLevel>
                (new AccessLevelDTO
                {
                    AccessId = _repository.GetAll().Count() + 1,
                    AccessName = item.AccessName,
                    Description = item.Description
                }
                ));
        }

        public void Update(AccessLevelDTO item)
        {
            var level = _repository.Get(item.AccessId);
            level.AccessName = item.AccessName;
            level.Description = item.Description;
            _repository.Update(level);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
