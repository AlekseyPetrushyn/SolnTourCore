using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.DataAccess.EFContext;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.DataAccess.Repositories.EntityRepositories
{
	public class HotelCategoryRepository : IRepository<HotelCategory>
	{
		private TourContext _context;

		public HotelCategoryRepository(TourContext _context)
		{
			this._context = _context;
		}

		public IEnumerable<HotelCategory> GetAll()
		{
			return _context.hotel_categorys;
		}

		public HotelCategory Get(int id)
		{
			return _context.hotel_categorys.Find(id);
		}

		public IEnumerable<HotelCategory> Find(Func<HotelCategory, bool> predicate)
		{
			return _context.hotel_categorys.Where(predicate).ToList();
		}

		public void Create(HotelCategory item)
		{
			_context.hotel_categorys.Add(item);
		}

		public void Update(HotelCategory item)
		{
			_context.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			HotelCategory item = _context.hotel_categorys.Find(id);
			if (item != null)
				_context.hotel_categorys.Remove(item);
		}
	}
}
