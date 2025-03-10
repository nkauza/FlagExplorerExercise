using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FlagExplorerAPI.TestProject
{
    public class CountriesServiceIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public CountriesServiceIntegrationTest(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

       
        [Fact]
        public async Task GetCountries_ReturnsOkResponse_WithCountriesList()
        {
            var response = await _client.GetAsync("/countries");

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var countries = JsonConvert.DeserializeObject<dynamic>(content);
            Assert.NotNull(countries);
            Assert.True(countries.Count > 0);
        }

        [Fact]
        public async Task GetCountryDetails_ValidName_ReturnsOkResponse_WithCountryDetails()
        {
            string countryName = "Canada";

            
            var response = await _client.GetAsync($"/countries/{countryName}");

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains(countryName, content);
        }

        [Fact]
        public async Task GetCountryDetails_InvalidName_ReturnsNotFound()
        {
            string invalidCountryName = "NonExistentCountry";

            var response = await _client.GetAsync($"/countries/{invalidCountryName}");

            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal(404, (int)response.StatusCode);
        }

       
        [Fact]
        public async Task GetCountryDetails_MalformedName_ReturnsBadRequest()
        {
            string malformedName = ""; 

            var response = await _client.GetAsync($"/countries/{malformedName}");

            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal(400, (int)response.StatusCode);
        }
    }
}