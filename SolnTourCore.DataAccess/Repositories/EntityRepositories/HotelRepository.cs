using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.DataAccess.EFContext;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.DataAccess.Repositories.EntityRepositories
{
	public class HotelRepository : IRepository<Hotel>
	{
		private TourContext _context;

		public HotelRepository(TourContext _context)
		{
			this._context = _context;
		}

		public IEnumerable<Hotel> GetAll()
		{
			return
				_context.hotels.Include(h => h.Place)
					.Include(h => h.HotelCategory)
					.Include(h => h.Food)
					.Include(h => h.RoomType)
					.Include(h => h.Accomodation)
					.Include(h => h.Location)
					.Include(h => h.Recreation);
		}

		public Hotel Get(int id)
		{
			return _context.hotels.Find(id);
		}

		public IEnumerable<Hotel> Find(Func<Hotel, bool> predicate)
		{
			return _context.hotels.Where(predicate).ToList();
		}

		public void Create(Hotel item)
		{
			_context.hotels.Add(item);
		}

		public void Update(Hotel item)
		{
			_context.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			Hotel item = _context.hotels.Find(id);
			if (item != null)
				_context.hotels.Remove(item);
		}
	}
}
