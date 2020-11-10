using StarWarsApi.Models;
using StarWarsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsApi.Clients.Interfaces
{
    public interface IPlanetClient
    {
        Task<Response<T>> GetAllPlanetsAsync<T>();
        Task<Planet> GetPlanetByIdAsync(int id);
        Task<Response<Planet>> GetPlanetByNameAsync<Planet>(string name);
    }
}