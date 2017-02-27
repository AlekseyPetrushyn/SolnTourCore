using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.DataAccess.EFContext;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.DataAccess.Repositories.EntityRepositories
{
	public class TourRepository : IRepository<Tour>
	{
		private TourContext _context;

		public TourRepository(TourContext _context)
		{
			this._context = _context;
		}

		public IEnumerable<Tour> GetAll()
		{
			return _context.tours.Include(t => t.TourOperator)
                .Include(t => t.TourOperator.AdditionalService)
                .Include(t => t.TourOperator.Transfer)
                .Include(t => t.TourOperator.Transfer.DepartureCity)
                .Include(t => t.TourOperator.Transfer.DepartureCity.Country)
                .Include(t => t.TourOperator.Transfer.DestinationCity)
                .Include(t => t.TourOperator.Transfer.DestinationCity.Country)
                .Include(t => t.TourOperator.Transfer.Transport)
                .Include(t => t.Hotel)
                .Include(t => t.Hotel.Accomodation)
                .Include(t => t.Hotel.HotelCategory)
                .Include(t => t.Hotel.Location)
                .Include(t => t.Hotel.Recreation)
                .Include(t => t.Hotel.RoomType)
                .Include(t => t.Hotel.Place.Country)
                .Include(t => t.Hotel.Place)
                .Include(t => t.Hotel.Food);
		}

		public Tour Get(int id)
		{
			return GetAll().FirstOrDefault(t => t.TourId == id);
		}

		public IEnumerable<Tour> Find(Func<Tour, bool> predicate)
		{
			return _context.tours.Where(predicate).ToList();
		}

		public void Create(Tour item)
		{
			_context.tours.Add(item);
		}

		public void Update(Tour item)
		{
			_context.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			Tour item = _context.tours.Find(id);
			if (item != null)
				_context.tours.Remove(item);
		}
	}
}
