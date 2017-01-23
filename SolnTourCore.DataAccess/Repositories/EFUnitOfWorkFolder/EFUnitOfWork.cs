using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.DataAccess.EFContext;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;
using SolnTourCore.DataAccess.Repositories.EntityRepositories;

namespace SolnTourCore.DataAccess.Repositories.EFUnitOfWorkFolder
{
	public class EFUnitOfWork : IUnitOfWork
	{
		private TourContext _context;
			//определяем приватные поля для репозиториев сущностей
		private CountryRepository countryRepository;
		private PlaceRepository placeRepository;
		private AccomodationRepository accomodationRepository;
		private HotelCategoryRepository hotelCategoryRepository;
		private RoomTypeRepository roomTypeRepository;
		private FoodRepository foodRepository;
		private LocationRepository locationRepository;
		private RecreationRepository recreationRepository;
		private HotelRepository hotelRepository;
		private TransportRepository transportRepository;
		private DepartureCityRepository departureCityRepository;
		private DestinationCityRepository destinationCityRepository;
		private TransferRepository transferRepository;
		private AdditionalServiceRepository additionalServiceRepository;
		private TourOperatorRepository tourOperatorRepository;
		private TourRepository tourRepository;
		private DiscountRepository discountRepository;
		private ClientRepository clientRepository;
		private AccessLevelRepository accessLevelRepository;
		private EmployeeRepository employeeRepository;
		private OrderRepository orderRepository;

			//конструктор со строкой подключения
		public EFUnitOfWork(DbContextOptions<TourContext> connectionString)
		{
			_context = new TourContext(connectionString);
		}
		
			//определяем свойства по интерфейсу
		public IRepository<Country> Countries 
			=> countryRepository ?? (countryRepository = new CountryRepository(_context));
		public IRepository<Place> Placies 
			=> placeRepository ?? (placeRepository = new PlaceRepository(_context));
		public IRepository<Accomodation> Accomodations
			=> accomodationRepository ?? (accomodationRepository = new AccomodationRepository(_context));

		public IRepository<HotelCategory> HotelCategorys
			=> hotelCategoryRepository ?? (hotelCategoryRepository = new HotelCategoryRepository(_context));

		public IRepository<RoomType> RoomTypes
			=> roomTypeRepository ?? (roomTypeRepository = new RoomTypeRepository(_context));

		public IRepository<Food> Foods => foodRepository ?? (foodRepository = new FoodRepository(_context));

		public IRepository<Location> Locations
			=> locationRepository ?? (locationRepository = new LocationRepository(_context));

		public IRepository<Recreation> Recreations
			=> recreationRepository ?? (recreationRepository = new RecreationRepository(_context));

		public IRepository<Hotel> Hotels => hotelRepository ?? (hotelRepository = new HotelRepository(_context));

		public IRepository<Transport> Transports
			=> transportRepository ?? (transportRepository = new TransportRepository(_context));

		public IRepository<DepartureCity> DepartureCitys
			=> departureCityRepository ?? (departureCityRepository = new DepartureCityRepository(_context));

		public IRepository<DestinationCity> DestinationCitys
			=> destinationCityRepository ?? (destinationCityRepository = new DestinationCityRepository(_context));

		public IRepository<Transfer> Transfers
			=> transferRepository ?? (transferRepository = new TransferRepository(_context));

		public IRepository<AdditionalService> AdditionalServices
			=> additionalServiceRepository ?? (additionalServiceRepository = new AdditionalServiceRepository(_context));

		public IRepository<TourOperator> TourOperators
			=> tourOperatorRepository ?? (tourOperatorRepository = new TourOperatorRepository(_context));

		public IRepository<Tour> Tours => tourRepository ?? (tourRepository = new TourRepository(_context));

		public IRepository<Discount> Discounts
			=> discountRepository ?? (discountRepository = new DiscountRepository(_context));

		public IRepository<Client> Clients => clientRepository ?? (clientRepository = new ClientRepository(_context));

		public IRepository<AccessLevel> AccessLevels
			=> accessLevelRepository ?? (accessLevelRepository = new AccessLevelRepository(_context));

		public IRepository<Employee> Employees
			=> employeeRepository ?? (employeeRepository = new EmployeeRepository(_context));

		public IRepository<Order> Orders => orderRepository ?? (orderRepository = new OrderRepository(_context));

		public void Save()
		{
			_context.SaveChanges();
		}

		private bool disposed = false;

		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
				this.disposed = true;
			}
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
