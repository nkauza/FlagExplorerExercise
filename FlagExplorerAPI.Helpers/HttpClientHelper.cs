using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace FlagExplorerAPI.Helpers
{
    public class HttpClientHelper : IHttpClientHelper
    {
        private readonly HttpClient _httpClient;

        public HttpClientHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T?> GetAsync<T>(string baseUrl, string actionUrl)
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}{actionUrl}"))
            {
                using (var result = await _httpClient.SendAsync(requestMessage))
                {
                    if (result.IsSuccessStatusCode)
                    {
                        var jsonResponse = await result.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<T>(jsonResponse);
                    }
                }
            }

            return default(T);
        }
    }
}
