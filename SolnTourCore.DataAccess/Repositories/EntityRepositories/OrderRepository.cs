using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.DataAccess.EFContext;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.DataAccess.Repositories.EntityRepositories
{
	public class OrderRepository : IRepository<Order>
	{
		private TourContext _context;

		public OrderRepository(TourContext _context)
		{
			this._context = _context;
		}

		public IEnumerable<Order> GetAll()
		{
			return _context.orders.Include(o => o.Employee)
				.Include(o => o.Client)
				.Include(o => o.Tour)
                .Include(o => o.Tour.Hotel)
                .Include(o => o.Tour.Hotel.Place)
                .Include(o => o.Tour.Hotel.Place.Country)
                .Include(o => o.Tour.Hotel.Accomodation)
                .Include(o => o.Tour.Hotel.Food)
                .Include(o => o.Tour.Hotel.HotelCategory)
                .Include(o => o.Tour.Hotel.Location)
                .Include(o => o.Tour.Hotel.Recreation)
                .Include(o => o.Tour.Hotel.RoomType)
                .Include(o => o.Tour.TourOperator)
                .Include(o => o.Tour.TourOperator.AdditionalService)
                .Include(o => o.Tour.TourOperator.Transfer)
                .Include(o => o.Tour.TourOperator.Transfer.DepartureCity)
                .Include(o => o.Tour.TourOperator.Transfer.DepartureCity.Country)
                .Include(o => o.Tour.TourOperator.Transfer.DestinationCity)
                .Include(o => o.Tour.TourOperator.Transfer.DestinationCity.Country)
                .Include(o => o.Tour.TourOperator.Transfer.Transport);
		}

		public Order Get(int id)
		{
			return _context.orders.Find(id);
		}

		public IEnumerable<Order> Find(Func<Order, bool> predicate)
		{
			return _context.orders.Where(predicate).ToList();
		}

		public void Create(Order item)
		{
			_context.orders.Add(item);
		}

		public void Update(Order item)
		{
			_context.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			Order item = _context.orders.Find(id);
			if (item != null)
				_context.orders.Remove(item);
		}
	}
}
