using System.Collections.Generic;
using System.Linq;
using SolnTourCore.Business.DTO;
using SolnTourCore.Business.Services.Interfaces.ServiceInterfaces;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.Business.Services.Implementations
{
    public class ClientService : IClientService
    {
        private IRepository<Client> _repository { get; set; }

        public ClientService(IRepository<Client> repository)
        {
            _repository = repository;
        }

        public IEnumerable<ClientDTO> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<Client>, List<ClientDTO>>(_repository.GetAll());
        }

        public ClientDTO Get(int id)
        {
            return AutoMapper.Mapper.Map<Client, ClientDTO>(_repository.Get(id));
        }

        public void Create(ClientDTO item)
        {
            _repository.Create(AutoMapper.Mapper.Map<Client>
                (new ClientDTO
                {
                    ClientId = _repository.GetAll().Count() + 1,
                    SecondName = item.SecondName,
                    FirstName = item.FirstName,
                    Patronymic = item.Patronymic,
                    BirthDay = item.BirthDay,
                    Address = item.Address,
                    MobilNumber = item.MobilNumber,
                    Email = item.Email,
                    DiscountId = item.DiscountId,
                    Login = item.Login,
                    Password = item.Password
                }));
        }

        public void Update(ClientDTO item)
        {
            var client = _repository.Get(item.ClientId);
            client.SecondName = item.SecondName;
            client.FirstName = item.FirstName;
            client.Patronymic = item.Patronymic;
            client.BirthDay = item.BirthDay;
            client.MobilNumber = item.MobilNumber;
            client.Email = item.Email;
            client.DiscountId = item.DiscountId;
            client.Login = item.Login;
            client.Password = item.Password;
            _repository.Update(client);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
