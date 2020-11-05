using StarWars.Clients.Interfaces;
using StarWars.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services
{
    public class CharacterService: ICharacterService
    {
        private ICharacterClient _characterClient;
        public CharacterService(ICharacterClient characterClient)
        {
            _characterClient = characterClient;
        }

        public async Task<IEnumerable<Character>> GetAllCharacterAsync()
        {
            return await _characterClient.GetAllCharacterAsync();
        }

        public async Task<Character> GetCharacterAsync(string id)
        {
            return await _characterClient.GetCharacterAsync(id);
        }
    }
}
