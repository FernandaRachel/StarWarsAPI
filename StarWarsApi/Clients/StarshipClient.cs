using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StarWarsApi.Clients.Interfaces;
using StarWarsApi.Controllers;
using StarWarsApi.Models;
using StarWarsApi.Settings;
using StarWarsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsApi.Clients
{
    public class StarshipClient : IStarshipClient
    {
        private readonly ILogger<StarshipClient> _logger;
        public HttpClient _httpClient{ get; set; }

        public StarshipClient(HttpClient httpClient, IOptions<StarWarSettings> _starWarsSettings, ILogger<StarshipClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            httpClient.BaseAddress = new Uri(_starWarsSettings.Value.Url);
        }
       
        public async Task<Response<T>> GetAllStarshipAsync<T>()
        {
            var url = $"starships/";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<Response<T>>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }

        public async Task<Response<Starship>> GetStarshipByNameAsync<Starship>(string name)
        {
            var url = $"starships/?search={name}";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<Response<Starship>>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }

        public async Task<Starship> GetStarshipByIdAsync(int id)
        {
            var url = $"starships/{id}/";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<Starship>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }

    }
}
