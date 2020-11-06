using StarWarsApi.Clients.Interfaces;
using StarWarsApi.Models;
using StarWarsApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsApi.Services
{
    public class StarshipService : IStarshipService
    {
        private IStarshipClient _starshipClient;
        public StarshipService(IStarshipClient starshipClient)
        {
            _starshipClient = starshipClient;
        }

        public async Task<Response<Starship>> GetAllStarshipAsync<Starship>()
        {
            return await _starshipClient.GetAllStarshipAsync<Starship>();
        }

        public async Task<Starship> GetStarshipByIdAsync(int id)
        {
            return await _starshipClient.GetStarshipByIdAsync(id);
        }

        public async Task<Response<Starship>> GetStarshipByNameAsync(string name)
        {
            return await _starshipClient.GetStarshipByNameAsync<Starship>(name);
        }
    }
}
