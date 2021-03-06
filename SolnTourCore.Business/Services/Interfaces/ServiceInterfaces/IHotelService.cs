﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolnTourCore.Business.DTO;

namespace SolnTourCore.Business.Services.Interfaces.ServiceInterfaces
{
    public interface IHotelService : IService<HotelDTO>
    {
        HotelDTO MaxPriceHotel(string countryName);
        HotelDTO MinPriceHotel(string countryName);
    }
}
