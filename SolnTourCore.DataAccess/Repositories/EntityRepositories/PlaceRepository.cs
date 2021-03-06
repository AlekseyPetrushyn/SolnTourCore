﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.DataAccess.EFContext;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.DataAccess.Repositories.EntityRepositories
{
	public class PlaceRepository : IRepository<Place>
	{
		private TourContext _context;
		public PlaceRepository(TourContext _context)
		{
			this._context = _context;
		}
				// т.к. есть внешний ключ, включаем с выражение ссылку на таблицу Country
		public IEnumerable<Place> GetAll()
		{
			return _context.places.Include(p => p.Country);
		}

		public Place Get(int id)
		{
			return _context.places.Find(id);
		}
		public IEnumerable<Place> Find(Func<Place, bool> predicate)
		{
			return _context.places.Include(p => p.Country).Where(predicate).ToList();
		}
		public void Create(Place item)
		{
			_context.places.Add(item);
		    _context.SaveChanges();
		}
		public void Update(Place item)
		{
			_context.Entry(item).State = EntityState.Modified;
		    _context.SaveChanges();
		}
		public void Delete(int id)
		{
			Place item = _context.places.Find(id);
			if (item != null)
				_context.places.Remove(item);
		    _context.SaveChanges();
		}
	}
}
