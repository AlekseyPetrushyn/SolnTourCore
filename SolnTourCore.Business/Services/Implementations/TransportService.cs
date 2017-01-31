using System.Collections.Generic;
using System.Linq;
using SolnTourCore.Business.DTO;
using SolnTourCore.Business.Services.Interfaces.ServiceInterfaces;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.Business.Services.Implementations
{
    public class TransportService : ITransportService
    {
        private IRepository<Transport> _transportRepository;

        public TransportService(IRepository<Transport> transportRepository)
        {
            _transportRepository = transportRepository;
        }

        public IEnumerable<TransportDTO> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<Transport>, List<TransportDTO>>(_transportRepository.GetAll());
        }

        public TransportDTO Get(int id)
        {
            return AutoMapper.Mapper.Map<Transport, TransportDTO>(_transportRepository.Get(id));
        }

        public void Create(TransportDTO item)
        {
            _transportRepository.Create(AutoMapper.Mapper.Map<Transport>
                (new TransportDTO
                {
                    TransportId = _transportRepository.GetAll().Count() + 1,
                    TransportName = item.TransportName
                }));
        }

        public void Update(TransportDTO item)
        {
            Transport transport = _transportRepository.Get(item.TransportId);
            transport.TransportName = item.TransportName;
            _transportRepository.Update(transport);
        }

        public void Delete(int id)
        {
            _transportRepository.Delete(id);
        }
    }
}
