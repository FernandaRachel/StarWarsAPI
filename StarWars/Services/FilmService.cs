using StarWarsApi.Clients;
using StarWarsApi.Clients.Interfaces;
using StarWarsApi.Models;
using StarWarsApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsApi.Services
{
    public class FilmService : IFilmService
    {
        private IFilmClient _filmClient;
        public FilmService(IFilmClient filmClient)
        {
            _filmClient = filmClient;
        }

        public async Task<Response<T>> GetAllFilmAsync<T>()
        {
            return await _filmClient.GetAllFilmAsync<T>();
        }

        public async Task<Film> GetFilmByIdAsync(int id)
        {
            return await _filmClient.GetFilmByIdAsync(id);
        }

        public async Task<Response<Film>> GetFilmByNameAsync(string name)
        {
            return await _filmClient.GetFilmByNameAsync<Film>(name);
        }
    }
}
