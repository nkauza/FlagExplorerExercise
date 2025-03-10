using FlagExplorerAPI.Domain;
using FlagExplorerAPI.Helpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagExplorerAPI.Repository
{
    public class CountriesRepository : ICountriesRepository
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly IConfiguration _configuration;
        private readonly string baseUrl;

        public CountriesRepository(IHttpClientHelper httpClientHelper, IConfiguration configuration)
        {
            _httpClientHelper = httpClientHelper;
            _configuration = configuration;
            baseUrl = _configuration["FlagExplorerApiBaseUrl"]!;
        }

        public async Task<List<Country>?> GetCountries()
        {
            return await _httpClientHelper.GetAsync<List<Country>>(baseUrl, "v3.1/all");
        }

        public async Task<Country?> GetCountryDetails(string countryName)
        {
            var countries = await GetCountries();

            if (countries != null && countries.Any())
            {
                return countries.FirstOrDefault(s =>  string.Equals(s.Name?.Official,countryName, StringComparison.OrdinalIgnoreCase));
            }

            return null;
        }
    }
}
