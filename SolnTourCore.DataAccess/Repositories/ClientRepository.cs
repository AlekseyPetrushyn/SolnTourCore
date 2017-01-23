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
	public class ClientRepository : IRepository<Client>
	{
		private TourContext _context;

		public ClientRepository(TourContext _context)
		{
			this._context = _context;
		}

		public IEnumerable<Client> GetAll()
		{
			return _context.clients.Include(c => c.Discount);
		}

		public Client Get(int id)
		{
			return _context.clients.Find(id);
		}

		public IEnumerable<Client> Find(Func<Client, bool> predicate)
		{
			return _context.clients.Where(predicate).ToList();
		}

		public void Create(Client item)
		{
			_context.clients.Add(item);
		}

		public void Update(Client item)
		{
			_context.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			Client item = _context.clients.Find(id);
			if (item != null)
				_context.clients.Remove(item);
		}
	}
}
