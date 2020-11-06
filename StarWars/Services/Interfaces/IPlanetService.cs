using StarWarsApi.Models;
using StarWarsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApi.Services
{
    public interface IPlanetService
    {
        Task<Response<Planet>> GetAllPlanetAsync<Planet>();
        Task<Planet> GetPlanetByIdAsync(int id);
        Task<Response<Planet>> GetPlanetByNameAsync(string name);
    }
}
