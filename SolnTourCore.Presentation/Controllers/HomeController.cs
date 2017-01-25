using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.Business.DTO;
using SolnTourCore.Business.Services.Interfaces.ServiceInterfaces;
using SolnTourCore.DataAccess.EFContext;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;
using SolnTourCore.Presentation.ViewModels;


namespace SolnTourCore.Presentation.Controllers
{
	public class HomeController : Controller
	{
		private ICountryService _countryService;

		private IRepository<Hotel> _hotelRepository;


		public HomeController(IRepository<Hotel> hotelRepository, ICountryService countryService)
		{
			_countryService = countryService;
			_hotelRepository = hotelRepository;
		}
		public IActionResult Index()
		{
			IEnumerable<CountryDTO> item = _countryService.GetAll();
			AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<CountryDTO, CountryViewModel>());
			var country = AutoMapper.Mapper.Map<IEnumerable<CountryDTO>, List<CountryViewModel>>(item);
			return View(country);
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Error()
		{
			return View();
		}
	}
}
