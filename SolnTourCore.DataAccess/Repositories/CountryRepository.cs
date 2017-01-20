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
	public class CountryRepository : IRepository<Country>
	{
		private TourContext db;

		public CountryRepository(TourContext _context)
		{
			db = _context;
		}
		public IEnumerable<Country> GetAll()
		{
			return db.countries;
		}
		public Country Get(int id)
		{
			return db.countries.Find(id);
		}
		public void Create(Country item)
		{
			db.countries.Add(item);
		}
		public void Update(Country item)
		{
			db.Entry(item).State = EntityState.Modified;
		}
		public IEnumerable<Country> Find(Func<Country, bool> predicate)
		{
			return db.countries.Where(predicate).ToList();
		}
		public void Delete(int id)
		{
			Country item = db.countries.Find(id);
			if (item != null)
				db.countries.Remove(item);
		}
	}
}
