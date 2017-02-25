﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolnTourCore.Business.DTO;

namespace SolnTourCore.Business.Services.Interfaces.ServiceInterfaces
{
    public interface ITourService : IService<TourDTO>
    {
        IEnumerable<TourDTO> FindTours(string countryName, string hotelCategoryName, string recreationTypeName, string departureCityName, int sortBy);
        decimal GetTotalPrice(int id);
        TourDTO MaxPriceTour(string countryName);
        TourDTO MinPriceTour(string countryName);
    }
}
