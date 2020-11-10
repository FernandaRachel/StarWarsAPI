using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Moq;
using StarWarsApi;
using StarWarsApi.Clients;
using StarWarsApi.Clients.Interfaces;
using StarWarsApi.Models;
using StarWarsApi.Services;
using StarWarsApi.Settings;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsAPI.Test
{
    [TestClass]
    public class ServiceTest : BaseTest
    {
        private ICharacterService _characterService;
        private IStarshipService _starshipService;

        [TestInitialize]
        public void TestInitialize()
        {
            // Loggers
            var loggerStarship = Mock.Of<ILogger<StarshipClient>>();
            var loggerCharacter = Mock.Of<ILogger<CharacterClient>>();
            var loggerFilm = Mock.Of<ILogger<FilmClient>>();
            var loggerPlanet = Mock.Of<ILogger<PlanetClient>>();
            
            // Settings
            var starWarsSettings = Options.Create(new StarWarSettings() { Url = configuration["StarWarSettings:Url"] });
            
            // Clients
            var httpClient = new HttpClient(); 
            var characterClient = new CharacterClient(httpClient, starWarsSettings, loggerCharacter);
            var filmClient = new FilmClient(httpClient, starWarsSettings, loggerFilm);
            var planetClient = new PlanetClient(httpClient, starWarsSettings, loggerPlanet);
            var starshipClient = new StarshipClient(httpClient, starWarsSettings, loggerStarship);

            _characterService = new CharacterService(characterClient, planetClient, filmClient);
            _starshipService = new StarshipService(starshipClient);
        }

        [TestMethod]
        public async Task GetAllCharacters()
        {
            var response = await _characterService.GetAllCharacterAsync<Character>();

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task GetCharacterByName()
        {
            var response = await _characterService.GetCharacterByNameAsync("Sky");

            Assert.IsTrue(response.Count > 1);
        }
        public async Task GetSimilarCharacters()
        {
            var character = await _characterService.GetCharacterByIdAsync(1);
            var response = await _characterService.GetSimilarCharacters(character);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.MainCharacter);
            Assert.IsNotNull(response.SuggestedCharacter);
        }

        [TestMethod]
        public async Task GetlAllStarships()
        {
            var response = await _starshipService.GetAllStarshipAsync<Character>();

            Assert.IsNotNull(response);
        }
    }
}
