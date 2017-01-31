using System.Collections.Generic;
using System.Linq;
using SolnTourCore.Business.DTO;
using SolnTourCore.Business.Services.Interfaces.ServiceInterfaces;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.Business.Services.Implementations
{
    public class RoomTypeService : IRoomTypeService
    {
        private IRepository<RoomType> _roomTypeRepository;

        public RoomTypeService(IRepository<RoomType> roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }
        public IEnumerable<RoomTypeDTO> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<RoomType>, List<RoomTypeDTO>>(_roomTypeRepository.GetAll());
        }

        public RoomTypeDTO Get(int id)
        {
            return AutoMapper.Mapper.Map<RoomType, RoomTypeDTO>(_roomTypeRepository.Get(id));
        }

        public void Create(RoomTypeDTO item)
        {
            _roomTypeRepository.Create(AutoMapper.Mapper.Map<RoomType>
                (new RoomTypeDTO
                {
                    RoomTypeId = _roomTypeRepository.GetAll().Count() + 1,
                    RoomTypeName = item.RoomTypeName,
                    Description = item.Description
                }));
        }

        public void Update(RoomTypeDTO item)
        {
            RoomType roomType = _roomTypeRepository.Get(item.RoomTypeId);
            roomType.RoomTypeName = item.RoomTypeName;
            roomType.Description = item.Description;
            _roomTypeRepository.Update(roomType);
        }

        public void Delete(int id)
        {
            _roomTypeRepository.Delete(id);
        }
    }
}
