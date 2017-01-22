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
	public class TransportRepository : IRepository<Transport>
	{
		private TourContext _context;

		public TransportRepository(TourContext _context)
		{
			this._context = _context;
		}

		public IEnumerable<Transport> GetAll()
		{
			return _context.transports;
		}

		public Transport Get(int id)
		{
			return _context.transports.Find(id);
		}

		public IEnumerable<Transport> Find(Func<Transport, bool> predicate)
		{
			return _context.transports.Where(predicate).ToList();
		}

		public void Create(Transport item)
		{
			_context.transports.Add(item);
		}

		public void Update(Transport item)
		{
			_context.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			Transport item = _context.transports.Find(id);
			if (item != null)
				_context.transports.Remove(item);
		}
	}
}
