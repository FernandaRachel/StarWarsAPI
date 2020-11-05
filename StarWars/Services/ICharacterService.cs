using StarWars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Services
{
    public interface ICharacterService
    {
        Task<Character> GetCharacterAsync(string id);
        Task<IEnumerable<Character>> GetAllCharacterAsync();
    }
}
