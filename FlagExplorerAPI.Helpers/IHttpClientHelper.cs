namespace FlagExplorerAPI.Helpers
{
    public interface IHttpClientHelper
    {
        Task<T?> GetAsync<T>(string baseUrl, string actionUrl);
    }
}
