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
	public class AccomodationRepository : IRepository<Accomodation>
	{
		private TourContext _context;

		public AccomodationRepository(TourContext _context)
		{
			this._context = _context;
		}
		public IEnumerable<Accomodation> GetAll()
		{
			return _context.accomodations;
		}
		public Accomodation Get(int id)
		{
			return _context.accomodations.Find(id);
		}

		public IEnumerable<Accomodation> Find(Func<Accomodation, bool> predicate)
		{
			return  _context.accomodations.Where(predicate).ToList();
		}

		public void Create(Accomodation item)
		{
			_context.accomodations.Add(item);
		}

		public void Update(Accomodation item)
		{
			_context.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			Accomodation item = _context.accomodations.Find(id);
			if (item != null)
				_context.accomodations.Remove(item);
		}
	}
}
