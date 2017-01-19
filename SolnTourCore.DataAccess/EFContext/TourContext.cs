using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.DataAccess.Entities;

namespace SolnTourCore.DataAccess.EFContext
{
	public class TourContext : DbContext
	{
		public TourContext(DbContextOptions<TourContext> options) : base(options)
		{
			
		}

		public DbSet<Country> countries { get; set; }
		public DbSet<Place> places { get; set; }
		public DbSet<Accomodation> accomodations { get; set; }
		public DbSet<HotelCategory> hotel_categorys { get; set; }
		public DbSet<RoomType> room_types { get; set; }
		public DbSet<Food> foods { get; set; }
		public DbSet<Location> locations { get; set; }
		public DbSet<Recreation> recreations { get; set; }
	}
}
