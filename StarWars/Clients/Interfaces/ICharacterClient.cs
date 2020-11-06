using StarWarsApi.Models;
using StarWarsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApi.Clients.Interfaces
{
    public interface ICharacterClient
    {
        Task<Response<T>> GetAllCharacterAsync<T>();
        Task<Character> GetCharacterByIdAsync(int id);
        Task<Response<Character>> GetCharacterByNameAsync<Character>(string name);
    }
}
