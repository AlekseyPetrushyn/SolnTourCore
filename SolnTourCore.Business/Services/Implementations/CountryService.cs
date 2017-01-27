using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolnTourCore.Business.DTO;
using SolnTourCore.Business.Services.Interfaces.ServiceInterfaces;
using SolnTourCore.DataAccess.Entities;
using SolnTourCore.DataAccess.Interfaces;

namespace SolnTourCore.Business.Services.Implementations
{
	public class CountryService : ICountryService
	{
		private IRepository<Country> _countryRepository;

		public CountryService(IRepository<Country> countryRepository)
		{
			_countryRepository = countryRepository;
		}
		
		public IEnumerable<CountryDTO> GetAll()
		{
			return AutoMapper.Mapper.Map<IEnumerable<Country>, List<CountryDTO>>(_countryRepository.GetAll());
		}

		public CountryDTO Get(int id)
		{
			return AutoMapper.Mapper.Map<Country, CountryDTO>(_countryRepository.Get(id));
		}

		public void Create(CountryDTO item)
		{
			Country country = new Country
			{
				CountryId = _countryRepository.GetAll().Count() + 1,
				CountryName = item.CountryName
			};
			_countryRepository.Create(country);
		}

		public void Update(CountryDTO item)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			_countryRepository.Delete(id);
		}
	}
}
