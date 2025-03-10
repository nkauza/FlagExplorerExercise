using FlagExplorerAPI.Domain;

namespace FlagExplorerAPI.Services
{
    public interface ICountriesService
    {
        Task<List<Country>?> GetCountries();
        Task<Country?> GetCountryDetails(string countryName);
    }
}
