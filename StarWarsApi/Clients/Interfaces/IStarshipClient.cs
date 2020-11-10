using StarWarsApi.Models;
using StarWarsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApi.Clients.Interfaces
{
    public interface IStarshipClient
    {
        Task<Response<Starship>> GetAllStarshipAsync<Starship>();
        Task<Starship> GetStarshipByIdAsync(int id);
        Task<Response<Starship>> GetStarshipByNameAsync<Starship>(string name);
    }
}
