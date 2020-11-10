using StarWarsApi.Clients;
using StarWarsApi.Clients.Interfaces;
using StarWarsApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsApi.Services
{
    public class PlanetService: IPlanetService
    {
        private IPlanetClient _planetClient;
        public PlanetService(IPlanetClient planetClient)
        {
            _planetClient = planetClient;
        }

        public async Task<Response<Planet>> GetAllPlanetAsync<Planet>()
        {
            return await _planetClient.GetAllPlanetsAsync<Planet>();
        }

        public async Task<Planet> GetPlanetByIdAsync(int id)
        {
            return await _planetClient.GetPlanetByIdAsync(id);
        }

        public async Task<Response<Planet>> GetPlanetByNameAsync(string name)
        {
            return await _planetClient.GetPlanetByNameAsync<Planet>(name);
        }
    }
}
