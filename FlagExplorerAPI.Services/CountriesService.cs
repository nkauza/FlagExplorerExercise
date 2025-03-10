using FlagExplorerAPI.Domain;
using FlagExplorerAPI.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagExplorerAPI.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly ICountriesRepository _countriesRepository;
        private readonly ILogger<CountriesService> _logger;
        public CountriesService(ICountriesRepository countriesRepository,ILogger<CountriesService> logger)
        {
            _countriesRepository = countriesRepository;
            _logger = logger;
        }

        public async Task<List<Country>?> GetCountries()
        {
            try
            {
                return await _countriesRepository.GetCountries();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<Country?> GetCountryDetails(string countryName)
        {
            try
            {
                return await _countriesRepository.GetCountryDetails(countryName);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }
    }
}
