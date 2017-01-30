using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolnTourCore.Business.DTO;
using SolnTourCore.Business.Services.Interfaces.ServiceInterfaces;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;
using SolnTourCore.DataAccess.Repositories.EntityRepositories;

namespace SolnTourCore.Business.Services.Implementations
{
    public class TourOperatorService : ITourOperatorService
    {
        private IRepository<TourOperator> _repository { get; set; }

        public TourOperatorService(IRepository<TourOperator> repository)
        {
            _repository = repository;
        }

        public IEnumerable<TourOperatorDTO> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<TourOperator>, List<TourOperatorDTO>>(_repository.GetAll());
        }

        public TourOperatorDTO Get(int id)
        {
            return AutoMapper.Mapper.Map<TourOperator, TourOperatorDTO>(_repository.Get(id));
        }

        public void Create(TourOperatorDTO item)
        {
            TourOperator tourOperator = new TourOperator
            {
                OperatorId = _repository.GetAll().Count() + 1,
                OperatorName = item.OperatorName,
                AdditionalServiceId = item.AdditionalServiceId,
                TransferId = item.TransferId
            };
            _repository.Create(tourOperator);
        }

        public void Update(TourOperatorDTO item)
        {
            var tourOperator = _repository.Get(item.OperatorId);
            tourOperator.OperatorName = item.OperatorName;
            tourOperator.AdditionalServiceId = item.AdditionalServiceId;
            tourOperator.TransferId = item.TransferId;
            _repository.Update(tourOperator);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
