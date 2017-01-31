using System.Collections.Generic;
using System.Linq;
using SolnTourCore.Business.DTO;
using SolnTourCore.Business.Services.Interfaces.ServiceInterfaces;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.Business.Services.Implementations
{
    public class FoodService : IFoodService
    {
        private IRepository<Food> _foodRepository;

        public FoodService(IRepository<Food> foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public IEnumerable<FoodDTO> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<Food>, List<FoodDTO>>(_foodRepository.GetAll());
        }

        public FoodDTO Get(int id)
        {
            return AutoMapper.Mapper.Map<Food, FoodDTO>(_foodRepository.Get(id));
        }

        public void Create(FoodDTO item)
        {
            _foodRepository.Create(AutoMapper.Mapper.Map<Food>
                (new FoodDTO
                {
                    FoodId = _foodRepository.GetAll().Count() + 1,
                    FoodName = item.FoodName,
                    Description = item.Description
                }));
        }

        public void Update(FoodDTO item)
        {
            Food food = _foodRepository.Get(item.FoodId);
            food.FoodName = item.FoodName;
            food.Description = item.Description;
            _foodRepository.Update(food);
        }

        public void Delete(int id)
        {
            _foodRepository.Delete(id);
        }
    }
}
