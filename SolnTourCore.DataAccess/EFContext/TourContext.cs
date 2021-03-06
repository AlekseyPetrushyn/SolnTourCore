﻿using System;
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
		public DbSet<Hotel> hotels { get; set; }

		public DbSet<Transport> transports { get; set; }
		public DbSet<DepartureCity> departure_citys { get; set; }
		public DbSet<DestinationCity> destination_citys { get; set; }
		public DbSet<Transfer> transfers { get; set; }

		public DbSet<AdditionalService> additional_services { get; set; }
		public DbSet<TourOperator> tour_operators { get; set; }
		public DbSet<Tour> tours { get; set; }
		public DbSet<Discount> discounts { get; set; }
		public DbSet<Client> clients { get; set; }
		public DbSet<AccessLevel> access_levels { get; set; }
		public DbSet<Employee> employees { get; set; }
		public DbSet<Order> orders { get; set; }
	}
}
