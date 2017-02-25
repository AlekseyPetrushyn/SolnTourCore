using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
	    private ITourOperatorService _tourOperatorService;
	    private IOrderService _orderService;
	    private IHotelCategoryService _hotelCategoryService;
	    private ITourService _tourService;

		public HomeController(ICountryService countryService, IHotelService hotelService, IPlaceService placeService
            , ITourOperatorService tourOperatorService, IOrderService orderService, IHotelCategoryService hotelCategoryService
            , ITourService tourService)
		{
			_countryService = countryService;
		    _hotelService = hotelService;
		    _placeService = placeService;
            _tourOperatorService = tourOperatorService;
		    _orderService = orderService;
		    _hotelCategoryService = hotelCategoryService;
		    _tourService = tourService;

		}
		[HttpGet]
		public IActionResult Index()
		{

            IEnumerable<TourDTO> items = _tourService.GetAll();
            var tours = AutoMapper.Mapper.Map<IEnumerable<TourDTO>, List<TourViewModel>>(items);

            var maxPriceSpain = AutoMapper.Mapper.Map<TourDTO, TourViewModel>(_tourService.MaxPriceTour("Испания"));
		    var maxPriceItaly = AutoMapper.Mapper.Map<TourDTO, TourViewModel>(_tourService.MaxPriceTour("Италия"));
		    var maxPriceThailand = AutoMapper.Mapper.Map<TourDTO, TourViewModel>(_tourService.MaxPriceTour("Тайланд"));

            var minPriceTurkey = AutoMapper.Mapper.Map<TourDTO, TourViewModel>(_tourService.MinPriceTour("Турция"));
            var minPriceGreece = AutoMapper.Mapper.Map<TourDTO, TourViewModel>(_tourService.MinPriceTour("Греция"));
            var minPriceSpain = AutoMapper.Mapper.Map<TourDTO, TourViewModel>(_tourService.MinPriceTour("Испания"));
            var minPriceItaly = AutoMapper.Mapper.Map<TourDTO, TourViewModel>(_tourService.MinPriceTour("Италия"));
            var minPriceBali = AutoMapper.Mapper.Map<TourDTO, TourViewModel>(_tourService.MinPriceTour("Бали"));
            var minPriceEgypt = AutoMapper.Mapper.Map<TourDTO, TourViewModel>(_tourService.MinPriceTour("Египет"));

            ViewBag.MaxSpain = maxPriceSpain;
		    ViewBag.MaxItaly = maxPriceItaly;
		    ViewBag.MaxThailand = maxPriceThailand;

		    ViewBag.MaxSpainTotalPrice =_tourService.GetTotalPrice(maxPriceSpain.TourId);
            ViewBag.MaxItalyTotalPrice = _tourService.GetTotalPrice(maxPriceItaly.TourId);
            ViewBag.MaxThailandTotalPrice = _tourService.GetTotalPrice(maxPriceThailand.TourId);

            ViewBag.MinTurkey = minPriceTurkey;
            ViewBag.MinGreece = minPriceGreece;
            ViewBag.MinSpain = minPriceSpain;
            ViewBag.MinItaly = minPriceItaly;
            ViewBag.MinBali = minPriceBali;
            ViewBag.MinEgypt = minPriceEgypt;

		    ViewBag.MinTurkeyTotalPrice = _tourService.GetTotalPrice(minPriceTurkey.TourId);
            ViewBag.MinGreeceTotalPrice = _tourService.GetTotalPrice(minPriceGreece.TourId);
            ViewBag.MinSpainTotalPrice = _tourService.GetTotalPrice(minPriceSpain.TourId);
            ViewBag.MinItalyTotalPrice = _tourService.GetTotalPrice(minPriceItaly.TourId);
            ViewBag.MinBaliTotalPrice = _tourService.GetTotalPrice(minPriceBali.TourId);
            ViewBag.MinEgyptTotalPrice = _tourService.GetTotalPrice(minPriceEgypt.TourId);

            return View(tours);
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

        [HttpGet]
	    public IActionResult Search()
        {
            IEnumerable<HotelDTO> items = _hotelService.GetAll();
            var hotels = AutoMapper.Mapper.Map<IEnumerable<HotelDTO>, List<HotelViewModel>>(items);

            IEnumerable<CountryDTO> countryItems = _countryService.GetAll();
            var countries = AutoMapper.Mapper.Map<IEnumerable<CountryDTO>, List<CountryViewModel>>(countryItems);
            ViewBag.Countries = countries;

            IEnumerable<HotelCategoryDTO> hotelCategoryItems = _hotelCategoryService.GetAll();
            var hotelCategories = AutoMapper.Mapper.Map<IEnumerable<HotelCategoryDTO>, List<HotelCategoryViewModel>>(hotelCategoryItems);
            ViewBag.HotelCategories = hotelCategories;

            return View(hotels);
	    }

        [HttpPost]
	    public IActionResult FindTour(string countryName, string hotelCategoryName)
        {
            IEnumerable<TourDTO> items = _tourService.FindTours(countryName, hotelCategoryName);
            var tours = AutoMapper.Mapper.Map<IEnumerable<TourDTO>, List<TourViewModel>>(items);




            ViewBag.CountryName = countryName;
            ViewBag.HotelCategoryName = hotelCategoryName;
	        return View(tours);
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
