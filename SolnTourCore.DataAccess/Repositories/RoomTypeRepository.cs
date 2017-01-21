using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.DataAccess.EFContext;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.DataAccess.Repositories
{
	public class RoomTypeRepository : IRepository<RoomType>
	{
		private TourContext _context;

		public RoomTypeRepository(TourContext _context)
		{
			this._context = _context;
		}

		public IEnumerable<RoomType> GetAll()
		{
			return _context.room_types;
		}

		public RoomType Get(int id)
		{
			return _context.room_types.Find(id);
		}

		public IEnumerable<RoomType> Find(Func<RoomType, bool> predicate)
		{
			return _context.room_types.Where(predicate).ToList();
		}

		public void Create(RoomType item)
		{
			_context.room_types.Add(item);
		}

		public void Update(RoomType item)
		{
			_context.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			RoomType item = _context.room_types.Find(id);
			if (item != null)
				_context.room_types.Remove(item);
		}
	}
}
