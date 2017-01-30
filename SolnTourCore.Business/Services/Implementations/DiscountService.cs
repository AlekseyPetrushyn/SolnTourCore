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
    public class DiscountService : IDiscountService
    {
        private IRepository<Discount> _repository { get; set; }

        public DiscountService(IRepository<Discount> repository)
        {
            _repository = repository;
        }

        public IEnumerable<DiscountDTO> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<Discount>, List<DiscountDTO>>(_repository.GetAll());
        }

        public DiscountDTO Get(int id)
        {
            return AutoMapper.Mapper.Map<Discount, DiscountDTO>(_repository.Get(id));
        }

        public void Create(DiscountDTO item)
        {
            Discount discount = new Discount
            {
                DiscountId = _repository.GetAll().Count() + 1,
                DiscountName = item.DiscountName,
                Percent = item.Percent
            };
            _repository.Create(discount);
        }

        public void Update(DiscountDTO item)
        {
            var discount = _repository.Get(item.DiscountId);
            discount.DiscountName = item.DiscountName;
            discount.Percent = item.Percent;
            _repository.Update(discount);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
