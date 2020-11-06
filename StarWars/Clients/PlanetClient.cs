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
    public class PlanetClient : IPlanetClient
    {
        private readonly ILogger<PlanetClient> _logger;
        public HttpClient _httpClient{ get; set; }

        public PlanetClient(HttpClient httpClient, IOptions<StarWarSettings> _starWarsSettings, ILogger<PlanetClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            httpClient.BaseAddress = new Uri(_starWarsSettings.Value.Url);
        }
       
        public async Task<Response<T>> GetAllPlanetsAsync<T>()
        {
            var url = $"planets/";

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

        public async Task<Planet> GetPlanetByIdAsync(int id)
        {
            var url = $"planets/{id}/";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<Planet>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }

        public async Task<Response<Planet>> GetPlanetByNameAsync<Planet>(string name)
        {
            var url = $"planets/?search={name}";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<Response<Planet>>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }
    }
}
