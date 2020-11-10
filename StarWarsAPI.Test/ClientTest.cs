using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Moq;
using StarWarsApi.Clients;
using StarWarsApi.Clients.Interfaces;
using StarWarsApi.Models;
using StarWarsApi.Services;
using StarWarsApi.Settings;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsAPI.Test
{
    [TestClass]
    public class ClientTest: BaseTest
    {
        private ICharacterClient _characterClient;
        private IStarshipClient _starshiptClient;

        [TestMethod]
        public async Task GetAllCharacters()
        {
            //or use this short equivalent 
            var logger = Mock.Of<ILogger<CharacterClient>>();
            var starWarsSettings = Options.Create(new StarWarSettings() { Url = configuration["StarWarSettings:Url"] });
            var httpClient = new HttpClient();

            _characterClient = new CharacterClient(httpClient, starWarsSettings, logger);

            var response = await _characterClient.GetAllCharacterAsync<Character>();

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task GetlAllStarships()
        {
            //or use this short equivalent 
            var logger = Mock.Of<ILogger<StarshipClient>>();
            var starWarsSettings = Options.Create(new StarWarSettings() { Url = configuration["StarWarSettings:Url"] });
            var httpClient = new HttpClient();

            _starshiptClient = new StarshipClient(httpClient, starWarsSettings, logger);

            var response = await _starshiptClient.GetAllStarshipAsync<Starship>();

            Assert.IsNotNull(response);
        }
    }
}
