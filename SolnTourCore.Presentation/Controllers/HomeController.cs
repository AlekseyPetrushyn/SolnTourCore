using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolnTourCore.Presentation.Models;

namespace SolnTourCore.Presentation.Controllers
{
	public class HomeController : Controller
	{
		private readonly CountryContext _context;

		public HomeController(CountryContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var hh = _context.hotels.Include(p => p.Place.Country).Include(p => p.Accomodation);
			return View(hh.ToList());
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
