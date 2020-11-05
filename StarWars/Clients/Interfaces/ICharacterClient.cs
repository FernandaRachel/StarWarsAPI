using StarWars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Clients.Interfaces
{
    public interface IStarshipClient
    {
        Task<IEnumerable<Startship>> GetAllStarshipAsync();
        Task<Startship> GetStarshipAsync(string id);
    }
}
