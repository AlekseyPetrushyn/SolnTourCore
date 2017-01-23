using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.DataAccess.EFContext;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.DataAccess.Repositories.EntityRepositories
{
	public class TourRepository : IRepository<Tour>
	{
		private TourContext _context;

		public TourRepository(TourContext _context)
		{
			this._context = _context;
		}

		public IEnumerable<Tour> GetAll()
		{
			return _context.tours.Include(t => t.TourOperator)
				.Include(t => t.Hotel);
		}

		public Tour Get(int id)
		{
			return _context.tours.Find(id);
		}

		public IEnumerable<Tour> Find(Func<Tour, bool> predicate)
		{
			return _context.tours.Where(predicate).ToList();
		}

		public void Create(Tour item)
		{
			_context.tours.Add(item);
		}

		public void Update(Tour item)
		{
			_context.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			Tour item = _context.tours.Find(id);
			if (item != null)
				_context.tours.Remove(item);
		}
	}
}
