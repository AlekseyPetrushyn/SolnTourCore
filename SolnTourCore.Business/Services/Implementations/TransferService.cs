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
    public class TransferService : ITransferService
    {
        public IRepository<Transfer> _transferRepository { get; set; }

        public TransferService(IRepository<Transfer> transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public IEnumerable<TransferDTO> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<Transfer>, List<TransferDTO>>(_transferRepository.GetAll());
        }

        public TransferDTO Get(int id)
        {
            return AutoMapper.Mapper.Map<Transfer, TransferDTO>(_transferRepository.Get(id));
        }

        public void Create(TransferDTO item)
        {
            Transfer transfer = new Transfer
            {
                TransferId = _transferRepository.GetAll().Count() + 1,
                DepartureCityId = item.DepartureCityId,
                DestinationCityId = item.DestinationCityId,
                TransportId = item.TransportId,
                Price = item.Price
            };
            _transferRepository.Create(transfer);
        }

        public void Update(TransferDTO item)
        {
            var transfer = _transferRepository.Get(item.TransferId);
            transfer.DepartureCityId = item.DepartureCityId;
            transfer.DestinationCityId = item.DestinationCityId;
            transfer.TransportId = item.TransportId;
            transfer.Price = item.Price;
            _transferRepository.Update(transfer);
        }

        public void Delete(int id)
        {
            _transferRepository.Delete(id);
        }
    }
}
