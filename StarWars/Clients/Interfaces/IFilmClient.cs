using StarWarsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsApi.Clients.Interfaces
{
    public interface IFilmClient
    {
        Task<Response<T>> GetAllFilmAsync<T>();
        Task<Film> GetFilmByIdAsync(int id);
        Task<Response<Film>> GetFilmByNameAsync<Film>(string name);
    }
}