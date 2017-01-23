using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.DataAccess.EFContext;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.DataAccess.Repositories.EntityRepositories
{
	public class DiscountRepository : IRepository<Discount>
	{
		private TourContext _context;

		public DiscountRepository(TourContext _context)
		{
			this._context = _context;
		}

		public IEnumerable<Discount> GetAll()
		{
			return _context.discounts;
		}

		public Discount Get(int id)
		{
			return _context.discounts.Find(id);
		}

		public IEnumerable<Discount> Find(Func<Discount, bool> predicate)
		{
			return _context.discounts.Where(predicate).ToList();
		}

		public void Create(Discount item)
		{
			_context.discounts.Add(item);
		}

		public void Update(Discount item)
		{
			_context.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			Discount item = _context.discounts.Find(id);
			if (item != null)
				_context.discounts.Remove(item);
		}
	}
}
