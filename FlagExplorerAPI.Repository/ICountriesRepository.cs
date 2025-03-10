using FlagExplorerAPI.Domain;

namespace FlagExplorerAPI.Repository
{
    public interface ICountriesRepository
    {
        Task<List<Country>?> GetCountries();
        Task<Country?> GetCountryDetails(string countryName);
    }
}
