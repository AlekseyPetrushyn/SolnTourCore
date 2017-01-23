using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.DataAccess.EFContext;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.DataAccess.Repositories.EntityRepositories
{
	public class FoodRepository : IRepository<Food>
	{
		private TourContext _context;

		public FoodRepository(TourContext _context)
		{
			this._context = _context;
		}

		public IEnumerable<Food> GetAll()
		{
			return _context.foods;
		}

		public Food Get(int id)
		{
			return _context.foods.Find(id);
		}

		public IEnumerable<Food> Find(Func<Food, bool> predicate)
		{
			return _context.foods.Where(predicate).ToList();
		}

		public void Create(Food item)
		{
			_context.foods.Add(item);
		}

		public void Update(Food item)
		{
			_context.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			Food item = _context.foods.Find(id);
			if (item != null)
				_context.foods.Remove(item);
		}
	}
}
