using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StarWars.Clients.Interfaces;
using StarWars.Controllers;
using StarWars.Models;
using StarWars.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWars.Clients
{
    public class StarshipClient : ICharacterClient
    {
        private readonly ILogger<StarshipClient> _logger;
        public HttpClient _httpClient{ get; set; }

        public StarshipClient(HttpClient httpClient, IOptions<StarWarSettings> _starWarsSettings, ILogger<StarshipClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            httpClient.BaseAddress = new Uri(_starWarsSettings.Value.Url);
        }
       
        public async Task<IEnumerable<Character>> GetAllCharacterAsync()
        {
            var url = $"people/";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<IEnumerable<Character>>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }

        public async Task<Character> GetCharacterAsync(string id)
        {
            var url = $"people/{id}/";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<Character>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }

    }
}
