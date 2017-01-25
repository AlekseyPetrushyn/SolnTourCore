using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SolnTourCore.Business.DTO;
using SolnTourCore.Business.Mapper;
using SolnTourCore.Business.Services.Implementations;
//using SolnTourCore.Business.Services.Interfaces;
using SolnTourCore.Business.Services.Interfaces.ServiceInterfaces;
//using SolnTourCore.Presentation.Models;
using SolnTourCore.DataAccess.Interfaces;
using SolnTourCore.DataAccess.EFContext;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Repositories.EntityRepositories;
using SolnTourCore.Presentation.Mapper;
using SolnTourCore.Presentation.ViewModels;

namespace SolnTourCore.Presentation
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
					.SetBasePath(env.ContentRootPath)
					.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
					.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
					.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();    //добавляем mvc как сервис для его использования

			//определим строку подключения к бд PostgreSQL из appsettings.json
			var connectionString = Configuration["DbContextSetting:ConnectionString"];
			//добавляем в сервис DbContent и подключаемся к postgresql
			services.AddDbContext<TourContext>(
				opts => opts.UseNpgsql(connectionString)
			);
				//add dependency injection from DataAccess layer
			services.AddScoped<IRepository<Country>, CountryRepository>();
			services.AddScoped<IRepository<Place>, PlaceRepository>();
			services.AddScoped<IRepository<Accomodation>, AccomodationRepository>();
			services.AddScoped<IRepository<HotelCategory>, HotelCategoryRepository>();
			services.AddScoped<IRepository<RoomType>, RoomTypeRepository>();
			services.AddScoped<IRepository<Food>, FoodRepository>();
			services.AddScoped<IRepository<Location>, LocationRepository>();
			services.AddScoped<IRepository<Recreation>, RecreationRepository>();
			services.AddScoped<IRepository<Hotel>, HotelRepository>();
			services.AddScoped<IRepository<Transport>, TransportRepository>();
			services.AddScoped<IRepository<DepartureCity>, DepartureCityRepository>();
			services.AddScoped<IRepository<DestinationCity>, DestinationCityRepository>();
			services.AddScoped<IRepository<Transfer>, TransferRepository>();
			services.AddScoped<IRepository<AdditionalService>, AdditionalServiceRepository>();
			services.AddScoped<IRepository<TourOperator>, TourOperatorRepository>();
			services.AddScoped<IRepository<Tour>, TourRepository>();
			services.AddScoped<IRepository<Discount>, DiscountRepository>();
			services.AddScoped<IRepository<Client>, ClientRepository>();
			services.AddScoped<IRepository<AccessLevel>, AccessLevelRepository>();
			services.AddScoped<IRepository<Employee>, EmployeeRepository>();
			services.AddScoped<IRepository<Order>, OrderRepository>();

				// add dependency injection from Business layer
			services.AddScoped<ICountryService, CountryService>();


		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseBrowserLink();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
									name: "default",
									template: "{controller=Home}/{action=Index}/{id?}");
			});
				//create map with AutoMapper from Business to Presintation layers
			AutoMapper.Mapper.Initialize(cfg =>
				{
					cfg.AddProfile<PresentationMapper>();

					cfg.AddProfile<BusinessMapper>();
				}
			);

		}
	}
}
