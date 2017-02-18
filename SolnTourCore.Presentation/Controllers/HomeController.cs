﻿using System;
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
	    private ITourOperatorService _tourOperatorService;
	    private IOrderService _orderService;

		public HomeController(ICountryService countryService, IHotelService hotelService, IPlaceService placeService
            , ITourOperatorService tourOperatorService, IOrderService orderService)
		{
			_countryService = countryService;
		    _hotelService = hotelService;
		    _placeService = placeService;
            _tourOperatorService = tourOperatorService;
		    _orderService = orderService;

		}
		//[HttpGet]
		public IActionResult Index()
		{

            IEnumerable<HotelDTO> items = _hotelService.GetAll();
            var hotels = AutoMapper.Mapper.Map<IEnumerable<HotelDTO>, List<HotelViewModel>>(items);
            var maxPriceSpain = AutoMapper.Mapper.Map<HotelDTO, HotelViewModel>(_hotelService.MaxPriceHotel("Испания"));
		    var maxPriceItaly = AutoMapper.Mapper.Map<HotelDTO, HotelViewModel>(_hotelService.MaxPriceHotel("Италия"));
		    var maxPriceThailand = AutoMapper.Mapper.Map<HotelDTO, HotelViewModel>(_hotelService.MaxPriceHotel("Тайланд"));

            var minPriceTurkey = AutoMapper.Mapper.Map<HotelDTO, HotelViewModel>(_hotelService.MaxPriceHotel("Турция"));
            var minPriceGreece = AutoMapper.Mapper.Map<HotelDTO, HotelViewModel>(_hotelService.MaxPriceHotel("Греция"));
            var minPriceSpain = AutoMapper.Mapper.Map<HotelDTO, HotelViewModel>(_hotelService.MaxPriceHotel("Испания"));
            var minPriceItaly = AutoMapper.Mapper.Map<HotelDTO, HotelViewModel>(_hotelService.MaxPriceHotel("Италия"));
            var minPriceBali = AutoMapper.Mapper.Map<HotelDTO, HotelViewModel>(_hotelService.MaxPriceHotel("Бали"));
            var minPriceEgypt = AutoMapper.Mapper.Map<HotelDTO, HotelViewModel>(_hotelService.MaxPriceHotel("Египет"));

            ViewBag.MaxSpain = maxPriceSpain;
		    ViewBag.MaxItaly = maxPriceItaly;
		    ViewBag.MaxThailand = maxPriceThailand;

		    ViewBag.MinTurkey = minPriceTurkey;
            ViewBag.MinGreece = minPriceGreece;
            ViewBag.MinSpain = minPriceSpain;
            ViewBag.MinItaly = minPriceItaly;
            ViewBag.MinBali = minPriceBali;
            ViewBag.MinEgypt = minPriceEgypt;
            return View(hotels);
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
