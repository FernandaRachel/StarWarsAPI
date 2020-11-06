using StarWarsApi.Models;
using StarWarsApi.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApi.Services
{
    public interface ICharacterService
    {
        Task<Response<Character>> GetAllCharacterAsync<Character>();
        Task<Character> GetCharacterByIdAsync(int id);
        Task<List<CharacterResult>> GetCharacterByNameAsync(string name);
        Task<CharacterResult> GetSimilarCharacters(Character character);
    }
}
