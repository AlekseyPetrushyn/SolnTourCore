using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.DataAccess.EFContext;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.DataAccess.Repositories.EntityRepositories
{
	public class AccessLevelRepository : IRepository<AccessLevel>
	{
		private TourContext _context;

		public AccessLevelRepository(TourContext _context)
		{
			this._context = _context;
		}

		public IEnumerable<AccessLevel> GetAll()
		{
			return _context.access_levels;
		}

		public AccessLevel Get(int id)
		{
			return _context.access_levels.Find(id);
		}

		public IEnumerable<AccessLevel> Find(Func<AccessLevel, bool> predicate)
		{
			return _context.access_levels.Where(predicate).ToList();
		}

		public void Create(AccessLevel item)
		{
			_context.access_levels.Add(item);
		}

		public void Update(AccessLevel item)
		{
			_context.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			AccessLevel item = _context.access_levels.Find(id);
			if (item != null)
				_context.access_levels.Remove(item);
		}
	}
}
