using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StarWarsApi.Clients.Interfaces;
using StarWarsApi.Controllers;
using StarWarsApi.Models;
using StarWarsApi.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsApi.Clients
{
    public class FilmClient : IFilmClient
    {
        private readonly ILogger<FilmClient> _logger;
        public HttpClient _httpClient{ get; set; }

        public FilmClient(HttpClient httpClient, IOptions<StarWarSettings> _starWarsSettings, ILogger<FilmClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            httpClient.BaseAddress = new Uri(_starWarsSettings.Value.Url);
        }
       
        public async Task<Response<T>> GetAllFilmAsync<T>()
        {
            var url = $"films/";

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

        public async Task<Film> GetFilmByIdAsync(int id)
        {
            var url = $"films/{id}/";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<Film>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }

        public async Task<Response<Film>> GetFilmByNameAsync<Film>(string name)
        {
            var url = $"films/?search={name}";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<Response<Film>>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }
    }
}
