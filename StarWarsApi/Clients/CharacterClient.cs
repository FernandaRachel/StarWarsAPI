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
    public class CharacterClient : ICharacterClient
    {
        private readonly ILogger<CharacterClient> _logger;
        public HttpClient _httpClient{ get; set; }

        public CharacterClient(HttpClient httpClient, IOptions<StarWarSettings> _starWarsSettings, ILogger<CharacterClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            httpClient.BaseAddress = new Uri(_starWarsSettings.Value.Url);
        }
       
        public async Task<Response<T>> GetAllCharacterAsync<T>()
        {
            var url = $"people/";

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

        public async Task<Character> GetCharacterByIdAsync(int id)
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

        public async Task<Response<Character>> GetCharacterByNameAsync<Character>(string name)
        {
            var url = $"people/?search={name}";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<Response<Character>>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }
    }
}
