using StarWarsApi.Clients.Interfaces;
using StarWarsApi.Models;
using StarWarsApi.Models;
using StarWarsApi.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsApi.Services
{
    public class CharacterService : ICharacterService
    {
        private ICharacterClient _characterClient;
        private IPlanetClient _planetClient;
        private IFilmClient _filmClient;
        public CharacterService(ICharacterClient characterClient, IPlanetClient planetClient, IFilmClient filmClient)
        {
            _characterClient = characterClient;
            _planetClient = planetClient;
            _filmClient = filmClient;
        }

        public async Task<Response<Character>> GetAllCharacterAsync<Character>()
        {
            return await _characterClient.GetAllCharacterAsync<Character>();
        }

        public async Task<Character> GetCharacterByIdAsync(int id)
        {
            return await _characterClient.GetCharacterByIdAsync(id);
        }

        public async Task<List<CharacterResult>> GetCharacterByNameAsync(string name)
        {
            var response = new List<CharacterResult>();

            var characters = await _characterClient.GetCharacterByNameAsync<Character>(name);
            if (characters is null)
                return response;

            foreach (var c in characters.results)
            {
                var obj = await GetSimilarCharacters(c);
                if (obj != null)
                {
                    response.Add(obj);
                }
            }

            return response;
        }

        public async Task<CharacterResult> GetSimilarCharacters(Character character)
        {
            var obj = new CharacterResult();
            // Select ID of Planet and Film form chracter resposne
            var planetId = Convert.ToInt32(character.homeworld.Substring((character.homeworld.Length - 2), 1));
            var filmId = Convert.ToInt32(character.films[0].Substring((character.films[0].Length - 2), 1));
            // GET Planet based on ID
            var planet = await _planetClient.GetPlanetByIdAsync(planetId);

            if (planet != null)
            {
                // Get residents of the planet - limiting to 3 residents
                var tasks = planet.residents.Take(3).Select(r => _characterClient.GetCharacterByIdAsync(Convert.ToInt32(r.Substring((r.Length - 2), 1))));
                var characterList = (await Task.WhenAll(tasks)).Where(c => c != null);
                obj.MainCharacter = character;
                obj.SuggestedCharacter = characterList.Where(cl => cl.name != character.name).Take(3).ToList();
            }
            else
            {
                // Get characters film  - limiting to 3 characters
                var film = await _filmClient.GetFilmByIdAsync(filmId);
                var tasks = film.characters.Take(3).Select(c => _characterClient.GetCharacterByIdAsync(Convert.ToInt32(c.Substring((c.Length - 2), 1))));
                var characterList = (await Task.WhenAll(tasks)).Where(c => c != null);
                obj.MainCharacter = character;
                obj.SuggestedCharacter = characterList.Where(cl => cl.name != character.name).Take(3).ToList();
            }
            return obj;
        }

    }
}
