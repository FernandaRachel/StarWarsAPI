using StarWars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Clients.Interfaces
{
    public interface ICharacterClient
    {
        Task<Character> GetCharacterAsync(string id);
        Task<IEnumerable<Character>> GetAllCharacterAsync();
    }
}
