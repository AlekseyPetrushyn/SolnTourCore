﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SolnTourCore.Business.DTO;
using SolnTourCore.Presentation.ViewModels;

namespace SolnTourCore.Presentation.Mapper
{
	public class PresentationMapper : Profile
	{
		[Obsolete]
		protected override void Configure()
		{
			CreateMap<CountryViewModel, CountryDTO>();
			CreateMap<CountryDTO, CountryViewModel>();
		}
	}
}