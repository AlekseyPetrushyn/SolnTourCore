using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolnTourCore.DataAccess.Entities;

namespace SolnTourCore.DataAccess.Interfaces
{
	public interface IUnitOfWork :IDisposable
	{
		IRepository<Country> Countries { get; }
		IRepository<Place> Placies { get; }
		IRepository<Accomodation> Accomodations { get; }
		IRepository<HotelCategory> HotelCategorys { get; }
		IRepository<RoomType> RoomTypes { get; }
		IRepository<Food> Foods { get; }
		IRepository<Location> Locations { get; }
		IRepository<Recreation> Recreations { get; }
		IRepository<Hotel> Hotels { get; }

		IRepository<Transport> Transports { get; }
		IRepository<DepartureCity> DepartureCitys { get; }
		IRepository<DestinationCity> DestinationCitys { get; }
		IRepository<Transfer> Transfers { get; }

		IRepository<AdditionalService> AdditionalServices { get; }
		IRepository<TourOperator> TourOperators { get; }
		IRepository<Tour> Tours { get; }
		IRepository<Discount> Discounts { get; }
		IRepository<Client> Clients { get; }
		IRepository<AccessLevel> AccessLevels { get; }
		IRepository<Employee> Employees { get; }
		IRepository<Order> Orders { get; }

		void Save();
	}
}
