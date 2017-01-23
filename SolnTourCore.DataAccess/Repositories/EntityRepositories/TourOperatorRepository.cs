using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.DataAccess.EFContext;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.DataAccess.Repositories.EntityRepositories
{
	public class TourOperatorRepository : IRepository<TourOperator>
	{
		private TourContext _context;

		public TourOperatorRepository(TourContext _context)
		{
			this._context = _context;
		}

		public IEnumerable<TourOperator> GetAll()
		{
			return _context.tour_operators.Include(o => o.Transfer)
				.Include(o => o.AdditionalService);
		}

		public TourOperator Get(int id)
		{
			return _context.tour_operators.Find(id);
		}

		public IEnumerable<TourOperator> Find(Func<TourOperator, bool> predicate)
		{
			return _context.tour_operators.Where(predicate).ToList();
		}

		public void Create(TourOperator item)
		{
			_context.tour_operators.Add(item);
		}

		public void Update(TourOperator item)
		{
			_context.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			TourOperator item = _context.tour_operators.Find(id);
			if (item != null)
				_context.tour_operators.Remove(item);
		}
	}
}
