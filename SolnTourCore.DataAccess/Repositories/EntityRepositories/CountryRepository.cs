using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.DataAccess.EFContext;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.DataAccess.Repositories.EntityRepositories
{
	public class CountryRepository : IRepository<Country>
	{
		private TourContext _context;

		public CountryRepository(TourContext _context)
		{
			this._context = _context;
		}
		public IEnumerable<Country> GetAll()
		{
			return _context.countries;
		}
		public Country Get(int id)
		{
			return _context.countries.Find(id);
		}
		public void Create(Country item)
		{
			_context.countries.Add(item);
			_context.SaveChanges();
		}
		public void Update(Country item)
		{
			_context.Entry(item).State = EntityState.Modified;
			_context.SaveChanges();
		}
		public IEnumerable<Country> Find(Func<Country, bool> predicate)
		{
			return _context.countries.Where(predicate).ToList();
		}
		public void Delete(int id)
		{
			Country item = _context.countries.Find(id);
			if (item != null)
				_context.countries.Remove(item);
			_context.SaveChanges();
		}
	}
}
