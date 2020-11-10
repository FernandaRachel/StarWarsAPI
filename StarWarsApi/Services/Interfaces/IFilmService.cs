using StarWarsApi.Models;
using StarWarsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApi.Services
{
    public interface IFilmService
    {
        Task<Response<T>> GetAllFilmAsync<T>();
        Task<Film> GetFilmByIdAsync(int id);
        Task<Response<Film>> GetFilmByNameAsync(string name);
    }
}
