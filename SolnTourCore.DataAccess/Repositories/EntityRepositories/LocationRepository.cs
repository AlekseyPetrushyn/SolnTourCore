using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.DataAccess.EFContext;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.DataAccess.Repositories.EntityRepositories
{
	public class LocationRepository : IRepository<Location>
	{
		private TourContext _context;

		public LocationRepository(TourContext _context)
		{
			this._context = _context;
		}

		public IEnumerable<Location> GetAll()
		{
			return _context.locations;
		}

		public Location Get(int id)
		{
			return _context.locations.Find(id);
		}

		public IEnumerable<Location> Find(Func<Location, bool> predicate)
		{
			return _context.locations.Where(predicate).ToList();
		}

		public void Create(Location item)
		{
			_context.locations.Add(item);
		}

		public void Update(Location item)
		{
			_context.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			Location item = _context.locations.Find(id);
			if (item != null)
				_context.locations.Remove(item);
		}
	}
}
