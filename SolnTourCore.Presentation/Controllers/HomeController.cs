﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
			return View(_context.places.ToList());
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
