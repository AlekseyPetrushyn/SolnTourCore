using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.DataAccess.EFContext;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.DataAccess.Repositories.EntityRepositories
{
	public class EmployeeRepository : IRepository<Employee>
	{
		private TourContext _context;

		public EmployeeRepository(TourContext _context)
		{
			this._context = _context;
		}

		public IEnumerable<Employee> GetAll()
		{
			return _context.employees.Include(e => e.AccessLevel);
		}

		public Employee Get(int id)
		{
			return _context.employees.Find(id);
		}

		public IEnumerable<Employee> Find(Func<Employee, bool> predicate)
		{
			return _context.employees.Where(predicate).ToList();
		}

		public void Create(Employee item)
		{
			_context.employees.Add(item);
		}

		public void Update(Employee item)
		{
			_context.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			Employee item = _context.employees.Find(id);
			if (item != null)
				_context.employees.Remove(item);
		}
	}
}
