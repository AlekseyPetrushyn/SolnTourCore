using System;
using System.Collections;
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
	    private IHotelService _hotelService;
	    private IPlaceService _placeService;

		public HomeController(IRepository<Hotel> hotelRepository, ICountryService countryService, IHotelService hotelService
            , IPlaceService placeService)
		{
			_countryService = countryService;
		    _hotelService = hotelService;
		    _placeService = placeService;

		}
		//[HttpGet]
		public IActionResult Index()
		{
            // добавим вывод ввсего что есть в Местах для теста

		    IEnumerable<PlaceDTO> items = _placeService.GetAll();
		    var placies = AutoMapper.Mapper.Map<IEnumerable<PlaceDTO>, List<PlaceViewModel>>(items);


			//IEnumerable<HotelDTO> items = _hotelService.GetAll();
			//var hotels = AutoMapper.Mapper.Map<IEnumerable<HotelDTO>, List<HotelViewModel>>(items);
		 //   var maxPriceSpain = AutoMapper.Mapper.Map<HotelDTO, HotelViewModel>(_hotelService.MaxPriceHotel("Испания"));
		 //   ViewBag.MaxSpain = maxPriceSpain;
			return View(placies/*hotels*/);
		}

		[HttpPost]
		public ActionResult Delete(int countryId)
		{
			_countryService.Delete(countryId);
			return RedirectToAction(nameof(HomeController.Index));
		}

	    [HttpPost]
	    public ActionResult Update(int countryIdLast, string countryNewName)
	    {
	        CountryViewModel cnt = new CountryViewModel
	        {
	            CountryId = countryIdLast,
	            CountryName = countryNewName
	        };
            var ctt = AutoMapper.Mapper.Map<CountryViewModel, CountryDTO>(cnt);
	        _countryService.Update(ctt);

            return RedirectToAction(nameof(HomeController.Index));
	    }

	    [HttpPost]
	    public ActionResult Create(string countryName)
	    {
	        CountryViewModel cnt = new CountryViewModel
	        {
                CountryId = 1,
                CountryName = countryName
	        };
	        var ctt = AutoMapper.Mapper.Map<CountryViewModel, CountryDTO>(cnt);
            _countryService.Create(ctt);
	        return RedirectToAction(nameof(HomeController.Index));
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
