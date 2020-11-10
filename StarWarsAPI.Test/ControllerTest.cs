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
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsAPI.Test
{
    [TestClass]
    public class ControllerTest : BaseTest
    {

        [TestMethod]
        public async Task TestMethod1()
        {
            var response = await GetAsync<Character>($"api/character");

            Assert.IsNotNull(response);
        }
    }
}
