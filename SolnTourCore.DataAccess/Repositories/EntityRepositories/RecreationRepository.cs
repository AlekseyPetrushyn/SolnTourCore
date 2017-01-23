using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.DataAccess.EFContext;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.DataAccess.Repositories.EntityRepositories
{
	public class RecreationRepository : IRepository<Recreation>
	{
		private TourContext _context;

		public RecreationRepository(TourContext _context)
		{
			this._context = _context;
		}

		public IEnumerable<Recreation> GetAll()
		{
			return _context.recreations;
		}

		public Recreation Get(int id)
		{
			return _context.recreations.Find(id);
		}

		public IEnumerable<Recreation> Find(Func<Recreation, bool> predicate)
		{
			return _context.recreations.Where(predicate).ToList();
		}

		public void Create(Recreation item)
		{
			_context.recreations.Add(item);
		}

		public void Update(Recreation item)
		{
			_context.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			Recreation item = _context.recreations.Find(id);
			if (item != null)
				_context.recreations.Remove(item);
		}
	}
}
