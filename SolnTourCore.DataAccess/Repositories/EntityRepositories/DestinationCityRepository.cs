using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.DataAccess.EFContext;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.DataAccess.Repositories.EntityRepositories
{
	public class DestinationCityRepository : IRepository<DestinationCity>
	{
		private TourContext _context;

		public DestinationCityRepository(TourContext _context)
		{
			this._context = _context;
		}

		public IEnumerable<DestinationCity> GetAll()
		{
			return _context.destination_citys.Include(c => c.Country);
		}

		public DestinationCity Get(int id)
		{
			return _context.destination_citys.Find(id);
		}

		public IEnumerable<DestinationCity> Find(Func<DestinationCity, bool> predicate)
		{
			return _context.destination_citys.Where(predicate).ToList();
		}

		public void Create(DestinationCity item)
		{
			_context.destination_citys.Add(item);
		}

		public void Update(DestinationCity item)
		{
			_context.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			DestinationCity item = _context.destination_citys.Find(id);
			if (item != null)
				_context.destination_citys.Remove(item);
		}
	}
}
