using FlagExplorerAPI.Helpers;
using FlagExplorerAPI.Repository;
using FlagExplorerAPI.Services;

namespace FlagExplorerAPI
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServicesExtensions(this IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddSingleton<IHttpClientHelper, HttpClientHelper>();
            services.AddSingleton<ICountriesRepository, CountriesRepository>();
            services.AddSingleton<ICountriesService, CountriesService>();

            return services;
        }
    }
}
