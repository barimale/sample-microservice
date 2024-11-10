using System.Net.Http;
using System.Net.Http.Json;

namespace Ordering.Application.Integration
{
    public class StarWarsHttpClient : IStarWarsService
    {
        private readonly HttpClient _httpClient;

        public StarWarsHttpClient(string api, HttpClient httpClientFactory)
        {
            _httpClient = httpClientFactory;
            _httpClient.BaseAddress = new Uri(api);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
        }

        public async ValueTask<dynamic> GetPeople(string peopleId)
        {
            return await _httpClient.GetFromJsonAsync<dynamic>($"people/{peopleId}");
        }

        public async ValueTask<dynamic> GetPlanet(string planetId)
        {
            return await _httpClient.GetFromJsonAsync<dynamic>($"planets/{planetId}");
        }

        public async ValueTask<dynamic> GetSpecies(string speciesId)
        {
            return await _httpClient.GetFromJsonAsync<dynamic>($"species/{speciesId}");

        }
    }
}
