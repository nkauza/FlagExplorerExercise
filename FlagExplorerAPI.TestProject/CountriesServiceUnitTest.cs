using FlagExplorerAPI.Domain;
using FlagExplorerAPI.Repository;
using FlagExplorerAPI.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FlagExplorerAPI.TestProject
{
    public class CountriesServiceUnitTest
    {
        [Fact]
        public async Task GetCountries_ShouldReturnCountries_WhenRepositoryReturnsCountries()
        {
            var mockCountriesRepository = new Mock<ICountriesRepository>();
            var mockLogger = new Mock<ILogger<CountriesService>>();

            var countries = new List<Country>
            {
                new Country { Name = new CountryName{ Common= "USA", Official = "USA"} },
                new Country { Name = new CountryName { Common = "Canada", Official = "Canada" } }
            };

            mockCountriesRepository.Setup(repo => repo.GetCountries()).ReturnsAsync(countries);

            var countriesService = new CountriesService(mockCountriesRepository.Object, mockLogger.Object);
            var result = await countriesService.GetCountries();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("USA", result[0].Name.Common);
            Assert.Equal("Canada", result[1].Name.Common);
        }

        [Fact]
        public async Task GetCountries_ShouldReturnNull_WhenRepositoryThrowsException()
        {
            var mockCountriesRepository = new Mock<ICountriesRepository>();
            var mockLogger = new Mock<ILogger<CountriesService>>();

            mockCountriesRepository.Setup(repo => repo.GetCountries()).ThrowsAsync(new Exception("Repository error"));

            var countriesService = new CountriesService(mockCountriesRepository.Object, mockLogger.Object);

            var result = await countriesService.GetCountries();

            Assert.Null(result);
        }

        [Fact]
        public async Task GetCountryDetails_ShouldReturnCountry_WhenRepositoryReturnsCountry()
        {
            var mockCountriesRepository = new Mock<ICountriesRepository>();
            var mockLogger = new Mock<ILogger<CountriesService>>();

            var country = new Country { Name = new CountryName { Common = "USA", Official = "USA" } };

            mockCountriesRepository.Setup(repo => repo.GetCountryDetails("USA")).ReturnsAsync(country);

            var countriesService = new CountriesService(mockCountriesRepository.Object, mockLogger.Object);

            var result = await countriesService.GetCountryDetails("USA");

            Assert.NotNull(result);
            Assert.Equal("USA", result.Name.Common);
        }

        [Fact]
        public async Task GetCountryDetails_ShouldReturnNull_WhenRepositoryThrowsException()
        {
            var mockCountriesRepository = new Mock<ICountriesRepository>();
            var mockLogger = new Mock<ILogger<CountriesService>>();

            mockCountriesRepository.Setup(repo => repo.GetCountryDetails(It.IsAny<string>())).ThrowsAsync(new Exception("Repository error"));

            var countriesService = new CountriesService(mockCountriesRepository.Object, mockLogger.Object);

            var result = await countriesService.GetCountryDetails("USA");

            Assert.Null(result);
        }
    }
}