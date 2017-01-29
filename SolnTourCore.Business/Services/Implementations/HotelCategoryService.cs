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
    public class HotelCategoryService : IHotelCategoryService
    {
        private IRepository<HotelCategory> _hotelCategoryRepository;

        public HotelCategoryService(IRepository<HotelCategory> hotelCategoryRepository)
        {
            _hotelCategoryRepository = hotelCategoryRepository;
        }

        public IEnumerable<HotelCategoryDTO> GetAll()
        {
            return
                AutoMapper.Mapper.Map<IEnumerable<HotelCategory>, List<HotelCategoryDTO>>(
                    _hotelCategoryRepository.GetAll());
        }

        public HotelCategoryDTO Get(int id)
        {
            return AutoMapper.Mapper.Map<HotelCategory, HotelCategoryDTO>(_hotelCategoryRepository.Get(id));
        }

        public void Create(HotelCategoryDTO item)
        {
            HotelCategory hotelCategory = new HotelCategory
            {
                HotelCategoryId = _hotelCategoryRepository.GetAll().Count() + 1,
                HotelCategoryName = item.HotelCategoryName,
                Description = item.Description
            };
        }

        public void Update(HotelCategoryDTO item)
        {
            HotelCategory hotelCategory = _hotelCategoryRepository.Get(item.HotelCategoryId);
            hotelCategory.HotelCategoryName = item.HotelCategoryName;
            hotelCategory.Description = item.Description;
            _hotelCategoryRepository.Update(hotelCategory);
        }

        public void Delete(int id)
        {
            _hotelCategoryRepository.Delete(id);
        }
    }
}
