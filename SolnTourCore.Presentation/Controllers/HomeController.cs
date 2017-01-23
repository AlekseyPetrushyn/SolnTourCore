using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.DataAccess.EFContext;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;


namespace SolnTourCore.Presentation.Controllers
{
	public class HomeController : Controller
	{
		private IRepository<Hotel> _hotelRepository;


		public HomeController(IRepository<Hotel> hotelRepository)
		{
			_hotelRepository = hotelRepository;
		}
		public IActionResult Index()
		{
			return View(_hotelRepository.GetAll());
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
