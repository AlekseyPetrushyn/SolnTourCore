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
	public class AdditionalServiceRepository : IRepository<AdditionalService>
	{
		private TourContext _context;

		public AdditionalServiceRepository(TourContext _context)
		{
			this._context = _context;
		}

		public IEnumerable<AdditionalService> GetAll()
		{
			return _context.additional_services;
		}

		public AdditionalService Get(int id)
		{
			return _context.additional_services.Find(id);
		}

		public IEnumerable<AdditionalService> Find(Func<AdditionalService, bool> predicate)
		{
			return _context.additional_services.Where(predicate).ToList();
		}

		public void Create(AdditionalService item)
		{
			_context.additional_services.Add(item);
		}

		public void Update(AdditionalService item)
		{
			_context.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			AdditionalService item = _context.additional_services.Find(id);
			if (item != null)
				_context.additional_services.Remove(item);
		}
	}
}
