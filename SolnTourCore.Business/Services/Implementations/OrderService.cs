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
    public class OrderService : IOrderService
    {
        private IRepository<Order> _repository { get; set; }

        public OrderService(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<Order>, List<OrderDTO>>(_repository.GetAll());
        }

        public OrderDTO Get(int id)
        {
            return AutoMapper.Mapper.Map<Order, OrderDTO>(_repository.Get(id));
        }

        public void Create(OrderDTO item)
        {
            Order order = new Order
            {
                OrderId = _repository.GetAll().Count() + 1,
                TourId = item.TourId,
                ClientId = item.ClientId,
                EmployeeId = item.EmployeeId,
                OrderPrice = item.OrderPrice
            };
            _repository.Create(order);
        }

        public void Update(OrderDTO item)
        {
            var order = _repository.Get(item.ClientId);
            order.TourId = item.TourId;
            order.ClientId = item.ClientId;
            order.EmployeeId = item.EmployeeId;
            order.OrderPrice = item.OrderPrice;
            _repository.Update(order);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
