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
	public class TransferRepository : IRepository<Transfer>
	{
		private TourContext _context;

		public TransferRepository(TourContext _context)
		{
			this._context = _context;
		}

		public IEnumerable<Transfer> GetAll()
		{
			return _context.transfers.Include(t => t.Transport)
				.Include(t => t.DepartureCity)
				.Include(t => t.DestinationCity);
		}

		public Transfer Get(int id)
		{
			return _context.transfers.Find(id);
		}

		public IEnumerable<Transfer> Find(Func<Transfer, bool> predicate)
		{
			return _context.transfers.Where(predicate).ToList();
		}

		public void Create(Transfer item)
		{
			_context.transfers.Add(item);
		}

		public void Update(Transfer item)
		{
			_context.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			Transfer item = _context.transfers.Find(id);
			if (item != null)
				_context.transfers.Remove(item);
		}
	}
}
