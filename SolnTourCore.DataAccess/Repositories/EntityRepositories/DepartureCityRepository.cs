using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.DataAccess.EFContext;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.DataAccess.Repositories.EntityRepositories
{
	public class DepartureCityRepository : IRepository<DepartureCity>
	{
		private TourContext _context;

		public DepartureCityRepository(TourContext _context)
		{
			this._context = _context;
		}

		public IEnumerable<DepartureCity> GetAll()
		{
			return _context.departure_citys.Include(c => c.Country);
		}

		public DepartureCity Get(int id)
		{
			return _context.departure_citys.Find(id);
		}

		public IEnumerable<DepartureCity> Find(Func<DepartureCity, bool> predicate)
		{
			return _context.departure_citys.Where(predicate).ToList();
		}

		public void Create(DepartureCity item)
		{
			_context.departure_citys.Add(item);
		}

		public void Update(DepartureCity item)
		{
			_context.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			DepartureCity item = _context.departure_citys.Find(id);
			if (item != null)
				_context.departure_citys.Remove(item);
		}
	}
}
